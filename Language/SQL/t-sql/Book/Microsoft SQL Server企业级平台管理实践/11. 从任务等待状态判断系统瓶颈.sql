11.从等待状态判断系统资源瓶颈
在sys.sysprocesses和Sys.dm_exec_requests里，都能看到当前会话的状态。它们的常用查询可以是：
-- 对sysprocesses
select spid, kpis, blocked, waittype, waittime, lastwaittype,
waitresource,dbid, uid, cpu, physical_io, memusage,
login_time, last_batch, open_tran, status, hostname,
program_name, hostprocess, cmd net_library, loginname
from Sys.sysprocesses
where spid >50
-- 对Sys.dm_exec_requests
select s.session_id, s.status, s.login_time, s.host_name,
s.program_name, s.host_process_id, s.client_version, s.client_interface_name,
s.login_name, s.last_request_start_time, s.last_request_end_time,
c.connect_time, c.net_transport, c.net_packet_size, c.client_net_address,
r.request_id, r.start_time, r.status, r.command,
r.database_id, r.user_id, r.blocking_session_id, r.wait_type,
r.wait_time, r.last_wait_type, r.wait_resource, r.open_transaction_count,
r.transaction_id, r.percent_complete, r.cpu_time, r.reads, r.writes,
r.granted_query_memory 
from Sys.dm_exec_requests r 
right outer joinSys.dm_exec_sessions s
on r.session_id = s.session_id
right outer join Sys.dm_exec_connections c
on s.session_id = c.session_id
where s.session_id >50


11.3 PAGELATCH_x
如果有兴趣的话，可以作下面的实验，来体会一下Hot Page问题是什么样子的。
1.	设置SQL Server的最大线程数为350，以提高SQL Server的并发量。（这里只是做实验，在生产环境下这么做可得做测试，验证没有负面影响。）
sp_configure 'Max worker threads', 350
2.	创建一个测试数据库TestDB。在里面创建一张以Identity为属性的列做Clustered索引的表。
CREATE DATABASE [TestDB]
GO
USE [TestDB]
GO
CREATE TABLE [TestTable](
	[col1] [int] IDENTITY(1,1) NOT NULL,
	[col2] [varchar](50) NULL
) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [Idx1] ON [TestTable] ([col1])
GO
col1列的属性是Identity(1,1)，决定了每一条插入的数据值，都会严格地以一递增。上面又有一个Clustered索引，数据行将按照这一列的值排序存放。这两个条件加在一起，就意味着在一个时间点，只要页面当时还有空间，所有并发用户新插入的数据都将被严格地先后插入在同一个页面里。
3.	用OSTRESS压力测试工具，模拟400个并发用户，每个用户要连续插入2000条记录。
4.	这时候再去检查动态管理视图Sys.dm_exec_requests，就可以看到PAGELATCH的等待状态了。

