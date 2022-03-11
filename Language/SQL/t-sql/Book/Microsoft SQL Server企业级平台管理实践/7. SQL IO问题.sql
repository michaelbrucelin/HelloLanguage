7.1 SQL的I/O操作

-- 数据文件里的碎片程度
use tempdb
go
drop table demo
go
create table demo (
a int,
b char(990))
go
create clustered index demo_index on demo (a)
go
--我们在表格里插入1000条记录。记录会占据125个页面。
declare @i int
set @i = 0
while @i < 1000
begin
insert into demo values (@i, 'abcd')
set @i = @i + 1
end
go
dbcc showcontig(demo)
go


--然后我们每8条记录删除7条记录。这样在每个页面里，只会保存有一条记录。这时候页面里的大部分空间都是空闲的。通常我们说这种页面里碎片比较严重。
declare @i numeric (6,2)
set @i = 0
while @i < 1000
begin
if @i/8 <> convert(int,@i/8)
delete demo where a = @i
set @i = @i + 1
end
go
select * from demo
go
dbcc showcontig(demo)
go

--现在我们运行对这个表格的查询，看看SQL Server需要读取多少个页面。
set statistics io on
go
select * from demo
go
set statistics io off
go


--现在我们做一次索引重建，消除表格上的碎片。
alter index demo_index on demo rebuild
go
--再跑同样的查询，结果会怎样呢？
set statistics io on
go
select * from demo
go
set statistics io off
go

7.3 IO问题的SQL内部分析
下面的DMV查询可以来检查当前所有的等待累积值。
Select  wait_type, 
        waiting_tasks_count, 
        wait_time_ms
from	 sys.dm_os_wait_stats  
where	wait_type like 'PAGEIOLATCH%'  
order by wait_type

可以通过运行下面的查询得到每个文件的信息，了解哪个文件经常要做读(num_of_reads/ num_of_bytes_read)，哪个经常要做写(num_of_writes/ num_of_bytes_written)，哪个文件的读写经常要等待(io_stall_read_ms/ io_stall_write_ms/ io_stall)。
select db.name as database_name, f.fileid as file_id,
f.filename as file_name,
i.num_of_reads, i.num_of_bytes_read, i.io_stall_read_ms, 
i.num_of_writes, i.num_of_bytes_written, i.io_stall_write_ms, 
i.io_stall, i.size_on_disk_bytes
from sys.databases db inner join
sys.sysaltfiles f on db.database_id = f.dbid
inner join sys.dm_io_virtual_file_stats(NULL, NULL) i 
on i.database_id = f.dbid and i.file_id = f.fileid

如果管理员检查SQL Server的时候正是I/O问题比较严重的时候，还有一个动态管理视图sys.dm_io_pending_io_requests，可以告诉管理员当前SQL Server中每个处于挂起状态的I/O请求。
select 
    database_id, 
    file_id, 
    io_stall,
    io_pending_ms_ticks,
    scheduler_address 
from	sys.dm_io_virtual_file_stats(NULL, NULL)t1,
        sys.dm_io_pending_io_requests as t2
where	t1.file_handle = t2.io_handle

7.4 硬盘压力测试
1.	Param.txt
--------内容范例---------------
c:\testfile.dat 2 0x0 100 
#d:\testfile.dat 2 0x0 100
-------------------------------------

2.	SQLIO.exe
由于测试需要覆盖不同IO类型，所以可以用下面这样的批处理文件来做一套测试。
（把下面的内容保存成一个testIO.bat文件）
sqlio -kW -s10 -frandom -o8 -b8 -LS -Fparam.txt
timeout /T 60
sqlio -kW -s360 -frandom -o8 -b64 -LS -Fparam.txt
timeout /T 60
sqlio -kW -s360 -frandom -o8 -b128 -LS -Fparam.txt
timeout /T 60
sqlio -kW -s360 -frandom -o8 -b256 -LS -Fparam.txt
timeout /T 60

sqlio -kW -s360 -fsequential -o8 -b8 -LS -Fparam.txt
timeout /T 60
sqlio -kW -s360 -fsequential -o8 -b64 -LS -Fparam.txt
timeout /T 60
sqlio -kW -s360 -fsequential -o8 -b128 -LS -Fparam.txt
timeout /T 60
sqlio -kW -s360 -fsequential -o8 -b256 -LS -Fparam.txt
timeout /T 60

sqlio -kR -s360 -frandom -o8 -b8 -LS -Fparam.txt
timeout /T 60
sqlio -kR -s360 -frandom -o8 -b64 -LS -Fparam.txt
timeout /T 60
sqlio -kR -s360 -frandom -o8 -b128 -LS -Fparam.txt
timeout /T 60
sqlio -kR -s360 -frandom -o8 -b256 -LS -Fparam.txt
timeout /T 60

sqlio -kR -s360 -fsequential -o8 -b8 -LS -Fparam.txt
timeout /T 60
sqlio -kR -s360 -fsequential -o8 -b64 -LS -Fparam.txt
timeout /T 60
sqlio -kR -s360 -fsequential -o8 -b128 -LS -Fparam.txt
timeout /T 60
sqlio -kR -s360 -fsequential -o8 -b256 -LS -Fparam.txt
