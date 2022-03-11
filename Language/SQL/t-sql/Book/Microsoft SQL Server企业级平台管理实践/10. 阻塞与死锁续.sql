10.1 阻塞问题定位方法及实例演示
首先在范例数据库上造出一个阻塞。用Management Studio建立两个连接。
连接一：
begin tran
update Employee_Demo_Heap
set Title = 'aaa'
where employeeId = 70
update Employee_Demo_btree
set title = 'aaa'
where employeeId = 70
连接二：
select EmployeeId, LoginID, Title 
from Employee_Demo_Heap
where EmployeeId in (3, 30, 200)

在哪个数据库上？
[检查]：这个一般检查dbid即可。得到dbid以后，可以运行以下查询得到数据库的名字。
select name, dbid from master.sys.sysdatabases

阻塞在哪个或者哪些个表格上？哪些资源上？
[检查]：这个可以运行sp_lock，在结果集中寻找状态是wait的锁资源。或者直接运行下面的查询，得到一样的效果。
select  convert (smallint, req_spid) As spid,  
  rsc_dbid As dbid,  
  rsc_objid As ObjId,  
  rsc_indid As IndId,  
  substring (v.name, 1, 4) As Type,  
  substring (rsc_text, 1, 32) as Resource,  
  substring (u.name, 1, 8) As Mode,  
  substring (x.name, 1, 5) As Status    
 from  master.dbo.syslockinfo,  
  master.dbo.spt_values v,  
  master.dbo.spt_values x,  
  master.dbo.spt_values u    
 where   master.dbo.syslockinfo.rsc_type = v.number  
   and v.type = 'LR'  
   and master.dbo.syslockinfo.req_status = x.number  
   and x.type = 'LS'  
   and master.dbo.syslockinfo.req_mode + 1 = u.number  
   and u.type = 'L'  
	and substring (x.name, 1, 5) = 'WAIT'
 order by spid  

--正在运行中的语句
下面这个查询可以返回所有正在运行中的连接和它正在运行的语句。如果一个连接处于空闲状态，那就不会被返回。
select p.session_id, p.request_id, p.start_time,
p.status, p.command,p.blocking_session_id, p.wait_type, p.Wait_time, p.wait_resource,
p.total_elapsed_time, p.open_transaction_count, p.transaction_isolation_level, 
		 substring(qt.text,p.statement_start_offset/2, 
			(case when p.statement_end_offset = -1 
			then len(convert(nvarchar(max), qt.text)) * 2 
			else p.statement_end_offset end -p.statement_start_offset)/2) 
		as "SQL statement"
		,p.statement_start_offset
		,p.statement_end_offset
		,batch=qt.text
from master.sys.dm_exec_requests p 
cross apply sys.dm_exec_sql_text(p.sql_handle) as qt
where p.session_id>50

10.2 常见阻塞原因与解决方法
类型2：由于一个未按预期提交的事务导致的阻塞。
这里可以用下面这个实验来模拟这个问题。在Management Studio里，建一个连接到SQL Server，运行下面批处理语句：
use AdventureWorks
go
BEGIN TRAN 
SELECT * FROM Person.Address with (HOLDLOCK)
SELECT * FROM SYSOBJECTS S1, SYSOBJECTS S2 
commit tran
由于使用HOLDLOCK参数，第一句SELECT会在运行结束后，还在表格上维持一个TAB的S锁。如果Batch全部做完，这个锁会在Commit Tran的时候释放。但是第二句SELECT会执行很久。请在等待3、4秒钟以后取消执行。然后运行下面语句，检查open_tran和lock的情况。
SELECT @@TRANCOUNT
go 
sp_lock
go


10.3.2 正常情况下连接池在SQL Server端的处理方式
下面用一个简单的VBScript脚本，使用ADO访问SQL Server，在SQL Server端用SQL Profiler来观察Connection Pooling是怎么实现的。在范例脚本里首先会创建一个"ADODB.Connection"对象和"ADODB.Command"对象。然后使用Connection对象向SQL Server做四次连接。每次连接都发一条查询。查询结束后，Connection会被Close掉。等待一秒钟以后，申请建立下一个连接。第一个和第三个连接application name是"A"，第二个和第四个连接的application name是”B”。其它连接属性都一样。第四个连接做完以后2秒钟，整个脚本结束，Connection对象被释放。

Dim objConn
Dim strsql  
 
On error resume next

Set objConn = CreateObject("ADODB.Connection")
Set cmd = CreateObject("ADODB.Command")
strsql = "Provider=SQLOLEDB;Data Source=shasql90; Trusted_Connection=Yes;Initial Catalog=master;App=A"
'连接1
objConn.Open strsql
With cmd
.ActiveConnection = objConn
.CommandTimeout = 3
.CommandText = "select 1, * from sysprocesses"
.CommandType = adCmdText
.Execute
End With
objConn.close

wscript.Sleep 1000

strsql = "Provider=SQLOLEDB;Data Source=shasql90; Trusted_Connection=Yes;Initial Catalog=master;App=B"
'连接2
objConn.Open strsql
With cmd
.ActiveConnection = objConn
.CommandTimeout = 3
.CommandText = "select 2, * from sysprocesses"
.CommandType = adCmdText
.Execute
End With
objConn.close

wscript.Sleep 1000

strsql = "Provider=SQLOLEDB;Data Source=shasql90; Trusted_Connection=Yes;Initial Catalog=master;App=A"
'连接3
objConn.Open strsql
With cmd
.ActiveConnection = objConn
.CommandTimeout = 3
.CommandText = "select 3, * from sysprocesses"
.CommandType = adCmdText
.Execute
End With
objConn.close

wscript.Sleep 1000

strsql = "Provider=SQLOLEDB;Data Source=shasql90; Trusted_Connection=Yes;Initial Catalog=master;App=B"
'连接4
objConn.Open strsql
With cmd
.ActiveConnection = objConn
.CommandTimeout = 3
.CommandText = "select 4, * from sysprocesses"
.CommandType = adCmdText
.Execute
End With
objConn.close

wscript.Sleep 2000

Set objConn = nothing

10.3.3 程序端意外情况下SQL Server端可能导致的问题（1）：应用端超时
我们使用VBScript调用一个存储过程。这个存储过程会首先开启一个事务，然后会运行至少5秒钟（这里我们用waitfor delay来模拟），最后提交事务。
create proc Demo_Attention
as
begin tran
select count(*) from sys.objects
waitfor delay '0:0:5'
commit tran
go
	在脚本里，我们调用存储过程三次。第一次和第三次设置语句超时时间为10秒，这样存储过程能够顺利执行完。第二次设置超时时间为3秒，这样存储过程会遇到一个超时。三次调用之间都会有3秒钟的间隔。由于三次使用的连接字符串是一模一样的，三个连接会重用同一个物理连接。
Dim objConn
Dim strsql  
 
On error resume next
Set objConn = CreateObject("ADODB.Connection")
Set cmd = CreateObject("ADODB.Command")
strsql = "Provider=SQLOLEDB;Data Source=shasql90;Trusted_Connection=Yes;Initial Catalog=master;App=A;Timeout=15"
'连接1
objConn.Open strsql
With cmd
.ActiveConnection = objConn
.CommandTimeout = 10
.CommandText = "exec adventureworks..Demo_Attention"
.CommandType = adCmdText
.Execute
End With
objConn.close
wscript.Sleep 3000

strsql = "Provider=SQLOLEDB;Data Source=shasql90;Trusted_Connection=Yes;Initial Catalog=master;App=A;Timeout=15"
'连接2
objConn.Open strsql
With cmd
.ActiveConnection = objConn
.CommandTimeout = 3
.CommandText = "exec adventureworks..Demo_Attention"
.CommandType = adCmdText
.Execute
End With
objConn.close

wscript.Sleep 3000

strsql = "Provider=SQLOLEDB;Data Source=shasql90;Trusted_Connection=Yes;Initial Catalog=master;App=A;Timeout=15"
'连接3
objConn.Open strsql
With cmd
.ActiveConnection = objConn
.CommandTimeout = 10
.CommandText = "exec adventureworks..Demo_Attention"
.CommandType = adCmdText
.Execute
End With
objConn.close

wscript.Sleep 5000

Set objConn = nothing

10.3.4 程序端意外情况下SQL Server端可能导致的问题（2）：应用层事务未提交
和前面的脚本很类似的是，这个脚本也会建立三个连接，每个连接的连接串都一样，所以它们会重用一个物理连接。和前面例子不同的是，这里的第一个和第二个连接不是用TSQL语句打开事务，而是使用ADO的BeginTrans方法。第一个连接语句运行完以后，调用了CommitTrans方法，是一次正确的调用。第二个连接模拟程序出了某些意外，CommitTrans方法没有被调用到，连接直接被close了。第三个连接是一个一般的调用。每个连接之间都有4秒钟的间隔。第三个连接关闭后，程序等待了10秒钟后退出。
Dim objConn
Dim strsql  
On error resume next
Set objConn = CreateObject("ADODB.Connection")
Set cmd = CreateObject("ADODB.Command")

strsql = "Provider=SQLOLEDB;Data Source=shasql90;Trusted_Connection=Yes;Initial Catalog=master;App=A;Timeout=15"
'连接1
objConn.Open strsql
objConn.BeginTrans
'set implicit_transactions on 
With cmd
.ActiveConnection = objConn
.CommandTimeout = 3
.CommandText = "select 1"
.CommandType = adCmdText
.Execute
End With
wscript.Sleep 1000
objConn.CommitTrans
'IF @@TRANCOUNT > 0 COMMIT TRAN
objConn.close

wscript.Sleep 4000
strsql = "Provider=SQLOLEDB;Data Source=shasql90;Trusted_Connection=Yes;Initial Catalog=master;App=A;Timeout=15"
'连接2
objConn.Open strsql
'exec sp_reset_connection 
objConn.BeginTrans
'set implicit_transactions on 
With cmd
.ActiveConnection = objConn
.CommandTimeout = 3
.CommandText = "select 2"
.CommandType = adCmdText
.Execute
End With
wscript.Sleep 1000
'For some reason, the script hasn't called objConn.CommitTrans
objConn.close
'No IF @@TRANCOUNT > 0 COMMIT TRAN

wscript.Sleep 4000
strsql = "Provider=SQLOLEDB;Data Source=shasql90;Trusted_Connection=Yes;Initial Catalog=master;App=A;Timeout=15"
'连接3
objConn.Open strsql
'No exec sp_reset_connection 
With cmd
.ActiveConnection = objConn
.CommandTimeout = 3
.CommandText = "select 3"
.CommandType = adCmdText
.Execute
End With
objConn.close
'No IF @@TRANCOUNT > 0 COMMIT TRAN

wscript.Sleep 10000
Set objConn = nothing
'IF @@TRANCOUNT > 0 ROLLBACK TRAN
'Logout

10.4.4 案例分析
现在就用下面这组脚本模拟出一个死锁来。在一个连接里，运行下面的语句。反复开启事务。在这个事务里，先修改一条NationalIDNumber=‘480951955’的记录，然后再把它查询出来。做完以后，提交事务。
set nocount on
go
while 1=1
begin
begin tran
update dbo.Employee_Demo_Heap
set BirthDate = getdate()
where NationalIDNumber = '480951955'
select * from dbo.Employee_Demo_Heap
where NationalIDNumber = '480951955'
commit tran
end
	在另外一个连接里，也运行这些语句。唯一的差别是这次修改和查询的是另一条NationalIDNumber = ‘407505660’的记录。
set nocount on
go
while 1=1
begin
begin tran
update dbo.Employee_Demo_Heap
set BirthDate = getdate()
where NationalIDNumber = '407505660'
select * from dbo.Employee_Demo_Heap 
where NationalIDNumber = '407505660'
commit tran
end

1. 调整索引，以调整执行计划，减少锁的申请数目，从而消除死锁。
CREATE NONCLUSTERED INDEX [NationalIDNumber] 
ON [dbo].[Employee_Demo_Heap] 
(
	[NationalIDNumber] ASC
)  ON [PRIMARY]

2. 使用"nolock"参数，让SELECT语句不要申请S锁，减少锁的申请数目，从而消除死锁。
	例如上面那个例子，我们可以改成：
set nocount on
go
while 1=1
begin
begin tran
update dbo.Employee_Demo_Heap
set BirthDate = getdate()
where NationalIDNumber = '407505660'
select * from dbo.Employee_Demo_Heap with (nolock)
where NationalIDNumber = '407505660'
commit tran
end
和
set nocount on
go
while 1=1
begin
begin tran
update dbo.Employee_Demo_Heap
set BirthDate = getdate()
where NationalIDNumber = '480951955'
select * from dbo.Employee_Demo_Heap with (nolock)
where NationalIDNumber = '480951955'
commit tran
end

3. 升级锁的粒度，将死锁转化成一个阻塞问题。
set nocount on
go
while 1=1
begin
begin tran
update dbo.Employee_Demo_Heap with (PAGLOCK)
set BirthDate = getdate()
where NationalIDNumber = '407505660'
select * from dbo.Employee_Demo_Heap with (PAGLOCK)
where NationalIDNumber = '407505660'
commit tran
end
和
set nocount on
go
while 1=1
begin
begin tran
update dbo.Employee_Demo_Heap with (PAGLOCK)
set BirthDate = getdate()
where NationalIDNumber = '480951955'
select * from dbo.Employee_Demo_Heap with (PAGLOCK)
where NationalIDNumber = '480951955'
commit tran
end

