14.4.1 SQL Trace文件的收集方法
生成的脚本大概长得是这个样子，比较重要的地方用黑体加注了：
-- Create a Queue
declare @rc int
declare @TraceID int
declare @maxfilesize bigint
set @maxfilesize = 5 
-- 请把它改成需要的最大大小
exec @rc = sp_trace_create @TraceID output, 2, N'C:\test.trc', @maxfilesize, NULL 
-- 请把它改成服务器上要存放Trace文件的地方
if (@rc != 0) goto error

-- Client side File and Table cannot be scripted

-- Set the events
declare @on bit
set @on = 1
exec sp_trace_setevent @TraceID, 14, 1, @on
exec sp_trace_setevent @TraceID, 14, 9, @on
exec sp_trace_setevent @TraceID, 14, 6, @on
exec sp_trace_setevent @TraceID, 14, 10, @on
exec sp_trace_setevent @TraceID, 14, 14, @on
-- 这里是在设置收取什么事件，以及它们的哪些数据字段
-- 如果选的事件比较多，会很长，不用去修改它们
……………………………………
-- Set the Filters
declare @intfilter int
declare @bigintfilter bigint

exec sp_trace_setfilter @TraceID, 10, 0, 7, N'SQL Server Profiler - 9e636f4c-7a9f-4dac-9703-1e506054706c'
-- 这里是设置过滤条件，也不用修改

-- Set the trace status to start
exec sp_trace_setstatus @TraceID, 1
-- 运行了这句话，Trace就被开启了

-- display trace id for future references
select TraceID=@TraceID
-- 这句话会返回一个数字，也就是这个Server Side Trace的编号，
-- 因为一个SQL可以开启多个Trace.
-- 一定要记录下这个编号，关闭Trace的时候要使用它
goto finish

error: 
select ErrorCode=@rc

finish: 
go

	如果要关闭这个Trace，需要运行下面的两句话：
exec sp_trace_setstatus <TraceID>, 0
-- 停止Trace
exec sp_trace_setstatus <TraceID>, 2
-- 完全关闭Trace，并且删除这个定义


14.4.2 SQL Trace文件的分析方法
例如下面的指令，可以将c:\trace\路径下的test.trc以及所有其后续文件中的RPC:Completed和SQL:BatchCompleted事件记录，保存在当前数据库的Sample表里。
select * into Sample
from fn_trace_gettable('c:\trace\test.trc',default)
where eventclass in (10, 12)

14.5 系统管理视图跟踪
对管理员比较有帮助的跟踪指令有下面这些。
	select * from sys.sysprocesses
-- 更精确地，是sys.dm_exec_sessions，sys.dm_exec_requests，sys.dm_os_tasks sys.dm_exec_connections这几张视图的联合结果。参见第10章讨论。
	dbcc sqlperf (waitstats)
-- SQL Server各种等待状态出现次数的统计。参见第11章的讨论
	dbcc sqlperf(umsstats)
-- 每个调度进程里的队列以及它们的状态信息。参见第8章的讨论
select 
	type,
	sum(virtual_memory_reserved_kb) as [VM Reserved],
	sum(virtual_memory_committed_kb) as [VM Committed],
	sum(awe_allocated_kb) as [AWE Allocated],
	sum(shared_memory_reserved_kb) as [SM Reserved], 
	sum(shared_memory_committed_kb) as [SM Committed],
	sum(multi_pages_kb) as [MultiPage Allocator],
	sum(single_pages_kb) as [SinlgePage Allocator]
from 
	sys.dm_os_memory_clerks 
group by type
order by type
-- 内存分配信息。参见第6章讨论

	跟踪脚本可以长得像这个样子。
SET NOCOUNT ON
GO
use master
go
DECLARE @i int
DECLARE @loops int
DECLARE @delayStr varchar(20)

-- 根据需求，可以调整@loops和@delayStr的值
set @loops = 60000
set @delayStr = '00:0:10'

dbcc sqlperf (waitstats, clear)
dbcc sqlperf (umsstats,clear)

set @i = 0
WHILE @i < @loops
BEGIN
	WAITFOR DELAY @delayStr
	print 'START TIME'
	select CURRENT_TIMESTAMP
	print 'END TIME'
	print ''

	print 'START SYSPROC'
	select * from sys.sysprocesses
	print 'END SYSPROC'
	print ''

	print 'START WAITSTATS'
	dbcc sqlperf (waitstats)
	print 'END WAITSTATS'
	print ''

	print 'START SYSSCHED'
	dbcc sqlperf(umsstats)
	print 'END SYSSCHED'
	print ''
…………..
-- 根据需求加入其它监视语句

	select @i = @i + 1
END

	管理员可以将这段脚本保存成一个叫queryprocess.sql的批处理文件，然后用osql，或者sqlcmd来调用。比如用osql，执行的命令可以是：
osql -E –S<server_name> -iqueryprocess.sql -oqueryprocess.out –w3000
注：
<server_name>是服务器的名字
queryprocess.sql是跟踪脚本文件名
queryprocess.out是输出文件名
