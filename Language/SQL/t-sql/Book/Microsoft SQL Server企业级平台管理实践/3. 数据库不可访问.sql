3.5 实例：修复Recovery失败的数据库
-- 请从文件PageNumber.bak中恢复数据库
如果运行下面的查询，会发现有许多被-3持有的锁，不但在Key上，还在很多的Page上。（图3-8）
use PageNumber
go
SELECT p.object_id,object_name(p.object_id) as object_name,
request_session_id,resource_type, resource_description,
request_mode,resource_associated_entity_id,
request_status
FROM sys.dm_tran_locks left join sys.partitions p
on sys.dm_tran_locks.resource_associated_entity_id = p.hobt_id
WHERE resource_database_id = db_id('PageNumber')
order by request_session_id, request_mode,
resource_type, resource_associated_entity_id

如果这时候运行下面的查询，就会被阻塞住。
SELECT * FROM PageNumber..Test
查询sys.sysprocesses视图，就能够看到连接被-3阻塞住了。（图3-9）
select * from sys.sysprocesses where spid > 50

在方法1：CHECKDB + REPAIR_ALLOW_DATA_LOSS：
这种方法操作比较简单，运行一系列的语句就可以。
ALTER DATABASE PageNumber SET EMERGENCY
--设置成紧急模式
go
ALTER DATABASE PageNumber SET SINGLE_USER
--设置成单用户模式
go
DBCC CHECKDB ('PageNumber', REPAIR_ALLOW_DATA_LOSS)
--修复数据库
go
ALTER DATABASE PageNumber SET MULTI_USER
--恢复多用户访问模式
go

方法2：做尾日志备份并恢复页面
	由于这个数据库是完全恢复模式，先前又做过完整备份，所以可以用页面恢复的方式，很快地恢复数据库到一个一致的状态。
	首先需要找到所有有问题的页面。查看errorlog里面的错误当然是一个方法。如果时间比较充裕，数据库不是很大的话，也可以在紧急模式下运行一次不带参数的CHECKDB，把所有有错的页面都打出来。
ALTER DATABASE PageNumber SET EMERGENCY
Go
DBCC CHECKDB ('PageNumber')
go
ALTER DATABASE PageNumber SET ONLINE
Go
	现在我们知道是1:200这个页面有问题，就只需恢复这个页面就可以了。
use master
go
RESTORE DATABASE PageNumber PAGE = '1:200' 
FROM DISK = 'PageNumberGood.bak'
这时候查询还是不能正常运行，因为那个事务还没有回滚。现在我们再做一次尾日志备份。
BACKUP LOG PageNumber TO DISK = 'PageNumberGood.trn'  WITH INIT , FORMAT
Go
然后我们把日志备份依次恢复。这里假设只有刚才做的一份。
RESTORE LOG PageNumber FROM DISK = 'PageNumberGood.trn' WITH RECOVERY
Go
