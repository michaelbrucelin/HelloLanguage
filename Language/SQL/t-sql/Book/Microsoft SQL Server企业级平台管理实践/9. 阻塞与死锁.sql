9.4.1 检查一个连接当前所持有的锁
select request_session_id,resource_type, resource_associated_entity_id,
request_status, request_mode,
resource_description 
FROM sys.dm_tran_locks


--当然我们也可以结合其他的动态管理视图，直接查出某个数据库上面的锁是在哪些表格，以及在哪些索引上面。例如（图9-3）：
use AdventureWorks
go
SELECT request_session_id,resource_type, resource_associated_entity_id,
request_status, request_mode,
resource_description, p.object_id,object_name(p.object_id) as object_name, p.*
FROM sys.dm_tran_locks left join sys.partitions p
on sys.dm_tran_locks.resource_associated_entity_id = p.hobt_id
WHERE resource_database_id = db_id('AdventureWorks')
order by request_session_id, resource_type, resource_associated_entity_id


9.5 锁和语句调优的关系
首先，请读者先用下面的语句建立两张表，[Employee_Demo_BTree]和[Employee_Demo_Heap]。它们的字段定义一样，在[EmployeeID]、[ManagerID]和[ModifiedDate]上都各有一个索引。唯一不同的是，[Employee_Demo_BTree]在[EmployeeID]上的是一个clustered index。[Employee_Demo_Heap]是一个nonclustered index。两张表的数据记录都是从HumanResources.Employee中导入，一模一样。但是正是在[EmployeeID]这个列上的索引不同，导致了它们的执行计划有所不同。
USE [AdventureWorks]
GO
drop table Employee_Demo_BTree
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Employee_Demo_BTree](
	[EmployeeID] [int] NOT NULL,
	[NationalIDNumber] [nvarchar](15) NOT NULL,
	[ContactID] [int] NOT NULL,
	[LoginID] [nvarchar](256) NOT NULL,
	[ManagerID] [int] NULL,
	[Title] [nvarchar](50) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[MaritalStatus] [nchar](1) NOT NULL,
	[Gender] [nchar](1) NOT NULL,
	[HireDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL   DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_EmployeeID_Demo_BTree] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Employee_ManagerID_Demo_BTree] ON [Employee_Demo_BTree] 
(
	[ManagerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Employee_ModifiedDate_Demo_BTree] ON [Employee_Demo_BTree] 
(
	[ModifiedDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
insert into Employee_Demo_BTree
select [EmployeeID] ,
	[NationalIDNumber] ,
	[ContactID] ,
	[LoginID] ,
	[ManagerID],
	[Title] ,
	[BirthDate] ,
	[MaritalStatus] ,
	[Gender] ,
	[HireDate] ,
	[ModifiedDate] from HumanResources.Employee
go
USE [AdventureWorks]
GO
drop table Employee_Demo_Heap
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Employee_Demo_Heap](
	[EmployeeID] [int] NOT NULL,
	[NationalIDNumber] [nvarchar](15) NOT NULL,
	[ContactID] [int] NOT NULL,
	[LoginID] [nvarchar](256) NOT NULL,
	[ManagerID] [int] NULL,
	[Title] [nvarchar](50) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[MaritalStatus] [nchar](1) NOT NULL,
	[Gender] [nchar](1) NOT NULL,
	[HireDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL   DEFAULT (getdate()),
 CONSTRAINT [PK_Employee_EmployeeID_Demo_Heap] PRIMARY KEY nonCLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, 
IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Employee_ManagerID_Demo_Heap] ON [Employee_Demo_Heap] 
(
	[ManagerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Employee_ModifiedDate_Demo_Heap] ON [Employee_Demo_Heap] 
(
	[ModifiedDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
insert into Employee_Demo_Heap
select [EmployeeID] ,
	[NationalIDNumber] ,
	[ContactID] ,
	[LoginID] ,
	[ManagerID],
	[Title] ,
	[BirthDate] ,
	[MaritalStatus] ,
	[Gender] ,
	[HireDate] ,
	[ModifiedDate] from HumanResources.Employee
go


9.5.1 一个常见的Select动作要申请的锁
1. 让我们先在有clustered index的那张表上运行一句最简单的查询。（查询1）
set transaction isolation level REPEATABLE READ
go
set statistics profile on
go
--查询 1
begin tran
select EmployeeId, LoginID, Title 
from Employee_Demo_BTree
where EmployeeId in (3, 30, 200)

2. 我们再运行一下DMV查询，看看现在有哪些锁被这个连接持有。（图9-6）
use AdventureWorks
go
SELECT request_session_id, resource_type, 
    request_status, request_mode,
    resource_description, object_name(p.object_id) as object_name,p.index_id
    FROM sys.dm_tran_locks left join sys.partitions p
on sys.dm_tran_locks.resource_associated_entity_id = p.hobt_id
order by request_session_id, resource_type

3. 我们再来看看下面查询2。在运行它之前，请记得将前面的那个事务提交或回滚。
--查询 2
begin tran
select EmployeeId, LoginID, Title 
from Employee_Demo_Heap
where EmployeeId =3


4. 那么是不是所有的查询都只在返回的记录上加锁呢？我们再来做下面这个试验。在运行它之前，请记得将前面的那个事务提交或回滚。
--我们先开启一个事务，修改一条查询不会返回的记录（修改1）。
begin tran
--修改1
update Employee_Demo_Heap
set Title = 'aaa'
where employeeId = 70

--再在另外一个连接里运行查询3。
begin tran
--查询 3
select EmployeeId, LoginID, Title 
from Employee_Demo_Heap
where EmployeeId in (3, 30, 200)


--但是如果运行同样的修改在Employee_Demo_BTree上（修改2），再运行查询1，就不会有问题。
begin tran
--修改2
update Employee_Demo_BTree
set Title = 'aaa'
where employeeId = 70


9.5.2 一个常见的Update动作要申请的锁
1. 我们还是用上面这两张表作例子，看看SQL Server在做Update的时候是怎么申请锁的。我们还是选用REPEATABLE READ的隔离级别，运行一个Update语句。
set transaction isolation level REPEATABLE READ
go
begin tran
update Employee_Demo_Heap
set Title = 'ChangedHeap'
where EmployeeId in (3, 30, 200)

SELECT request_session_id, resource_type, 
    request_status, request_mode,
    resource_description, object_name(p.object_id) as object_name,p.index_id
    FROM sys.dm_tran_locks left join sys.partitions p
on sys.dm_tran_locks.resource_associated_entity_id = p.hobt_id

2. 如果修改的列被一个索引使用到了，会是什么情况呢？为了完成这个测试，先在Employee_Demo_BTree上建一个会被修改到的索引。
CREATE NONCLUSTERED INDEX [Employee_Demo_BTree_Title] ON [dbo].[Employee_Demo_BTree] 
(
	[Title] ASC
) ON [PRIMARY]
然后运行下面这个Update语句。
begin tran
update Employee_Demo_BTree
set Title = 'Changed'
where EmployeeId in (3, 30, 200)

9.5.3 一个常见的Delete动作要申请的锁
1. 我们再来看看一个Delete语句会申请哪些锁。这次我们用READ COMMITTED这个缺省的隔离级别。
begin tran
Delete Employee_Demo_BTree
where loginid ='adventure-works\kim1'


2. 如果我们用REPEATABLE READ这个级别，我们就能看出象做SELECE的时候一样，做DELETE的时候SQL也需要先找到要删除的记录。在找的过程中也会加锁。
set transaction isolation level REPEATABLE READ
go
begin tran
Delete Employee_Demo_Heap
where loginid ='adventure-works\tete0'


9.5.4 一个常见的Insert动作要申请的锁
1. 首先要插入的是heap结构的表。
set transaction isolation level REPEATABLE READ
go
begin tran
insert into Employee_Demo_Heap values(
501,480168528,1009, 'adventure-works\thierry0',
263,'Tool Designer','1949-08-29 00:00:00.000','M','M','1998-01-11 00:00:00.000','2004-07-31 00:00:00.000')


2. 如果我们插入的是有B-Tree结构的表格，结果是：
set transaction isolation level REPEATABLE READ
go
begin tran
insert into Employee_Demo_BTree values(
501,480168528,1009, 'adventure-works\thierry0',
263,'Tool Designer','1949-08-29 00:00:00.000','M','M','1998-01-11 00:00:00.000','2004-07-31 00:00:00.000')




9.7 数据库引擎中基于行版本控制的隔离级别
A．普通已提交事务
--在此示例中，一个普通Read Committed事务将读取数据，然后由另一事务修改此数据。执行完的读操作不阻塞由其他事务执行的更新操作。但是，当其他事务已经做了更新操作后，读操作会被阻塞住，直到更新操作事务提交为止。
--在会话 1 上：
USE AdventureWorks;
GO

BEGIN TRANSACTION;
    -- 查询1
-- 这个查询将返回员工有48小时休假时间.
    SELECT EmployeeID, VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;
--在会话 2 上：
USE AdventureWorks;
GO

BEGIN TRANSACTION;
    -- 修改1
    -- 休假时间减4
    -- 修改不会被阻塞，因为会话1不会持有S锁不放
    UPDATE HumanResources.Employee
        SET VacationHours = VacationHours - 8
        WHERE EmployeeID = 4;

    -- 查询1
-- 现在休假时间只有40小时
    SELECT VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;
--在会话 1 上：
    -- 重新运行查询语句，会被会话2阻塞
    -- 查询2
SELECT EmployeeID, VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;
--在会话 2 上：
-- 提交事务
COMMIT TRANSACTION;
GO
--在会话 1 上：
-- 此时先前被阻塞的查询结束，返回会话2修改好的新数据：40。
-- 查询3
-- 这里返回40，因为会话2已经提交了事务
    SELECT EmployeeID, VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;

    -- 修改2
-- 这里会成功.
    UPDATE HumanResources.Employee
        SET SickLeaveHours = SickLeaveHours - 8
        WHERE EmployeeID = 4;

-- 可以回滚会话1的修改
-- 会话2的修改不会受影响
ROLLBACK TRANSACTION;
GO


B. 使用快照隔离
--在此示例中，在快照隔离下运行的事务将读取数据，然后由另一事务修改此数据。快照事务不阻塞由其他事务执行的更新操作，它忽略数据的修改继续从版本化的行读取数据。也就是说，读取到的是数据修改前的版本。但是，当快照事务尝试修改已由其他事务修改的数据时，快照事务将生成错误并终止。
--在会话 1 上：
USE AdventureWorks;
GO

-- Enable snapshot isolation on the database.
ALTER DATABASE AdventureWorks
    SET ALLOW_SNAPSHOT_ISOLATION ON;
GO

-- 设置使用快照隔离级别
SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
GO

BEGIN TRANSACTION;
    -- 查询1
-- 查询返回员工有48小时假期
    SELECT EmployeeID, VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;
--在会话 2 上：
USE AdventureWorks;
GO

-- Start a transaction
BEGIN TRANSACTION;
-- 修改1
-- 假期时间减8
-- 修改不会被会话1阻塞
    UPDATE HumanResources.Employee
        SET VacationHours = VacationHours - 8
        WHERE EmployeeID = 4;

    -- 查询1
-- 确认值已经被改成40
    SELECT VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;
--在会话 1 上：
-- 查询2
-- 再次运行查询语句
-- 还是会返回48（修改前的值），因为会话1是从版本化的行读取数据
SELECT EmployeeID, VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;
--在会话 2 上：
-- 提交事务.
COMMIT TRANSACTION;
GO
--在会话 1 上：
-- 查询3
-- 再次运行查询语句
-- 还是会返回48（修改前的值），因为会话1还是从版本化的行读取数据
SELECT EmployeeID, VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;

-- 修改2
-- 因为数据已经被会话2修改过，会话1想再做任何修改时，
-- 会遇到3960错误
-- 事务会自动回滚
    UPDATE HumanResources.Employee
        SET SickLeaveHours = SickLeaveHours - 8
        WHERE EmployeeID = 4;

-- 会话1的修改会回滚
-- 会话2的修改不会回滚
ROLLBACK TRANSACTION
GO


C. 使用通过行版本控制的已提交读
--在此示例中，使用行版本控制的已提交读事务与其他事务并发运行。已提交读事务的行为与快照事务的行为有所不同。与快照事务相同的是，即使其他事务修改了数据，已提交读事务也将读取版本化的行。然而，与快照事务不同的是，已提交读将执行下列操作：
--•	在其他事务提交数据更改后，读取修改的数据。
--•	能够更新由其他事务修改的数据，而快照事务不能。
--在会话 1 上：
USE AdventureWorks;
GO

-- Enable READ_COMMITTED_SNAPSHOT on the database.
-- 注意运行这句话的时候，不可以有其它连接同时使用AdventureWorks
ALTER DATABASE AdventureWorks
    SET READ_COMMITTED_SNAPSHOT ON;
GO

-- 开启一个Snapshot的read committed事务
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
GO

BEGIN TRANSACTION;
    -- 查询1
-- 这里将返回初始值48
    SELECT EmployeeID, VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;
--在会话 2 上：
USE AdventureWorks;
GO

-- Start a transaction
BEGIN TRANSACTION;
-- 修改1
-- 假期时间减8
-- 修改不会被会话1阻塞
    UPDATE HumanResources.Employee
        SET VacationHours = VacationHours - 8
        WHERE EmployeeID = 4;
  -- 查询1
-- 确认值已经被修改为40
    SELECT VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;
--在会话 1 上：
-- 查询2
-- 再次运行查询语句
-- 还是会返回48（修改前的值），因为会话2还没有提交
-- 会话1是从版本化的行读取数据
SELECT EmployeeID, VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;
--在会话 2 上：
-- Commit the transaction
COMMIT TRANSACTION;
GO
--在会话 1 上：
-- 查询3
-- 这里和范例B不同，会话1始终返回已提交的值
-- 这里返回40，因为会话2已经提交了事务
    SELECT EmployeeID, VacationHours
        FROM HumanResources.Employee
        WHERE EmployeeID = 4;

    -- 修改2
-- 这里会成功.
    UPDATE HumanResources.Employee
        SET SickLeaveHours = SickLeaveHours - 8
        WHERE EmployeeID = 4;

-- 可以回滚会话1的修改
-- 会话2的修改不会受影响
ROLLBACK TRANSACTION;
GO
