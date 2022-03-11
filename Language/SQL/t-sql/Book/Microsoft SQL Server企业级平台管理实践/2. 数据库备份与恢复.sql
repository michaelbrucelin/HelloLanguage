2.3.1 数据库完整还原
--创建一个尾日志备份。
BACKUP LOG AdventureWorks 
TO DISK = 'c:\SQLServerBackups\AdventureWorks.bak'
   WITH NORECOVERY; 
GO
--从备份1从恢复一个全备份
RESTORE DATABASE AdventureWorks 
  FROM DISK = 'c:\SQLServerBackups\AdventureWorks.bak' 
  WITH FILE=1, 
    NORECOVERY;

--从备份2中恢复一个正常的日志备份
RESTORE LOG AdventureWorks 
  FROM DISK = 'Z:\SQLServerBackups\AdventureWorks.bak' 
  WITH FILE=2, 
    NORECOVERY;

--用STOPAT恢复尾日志备份
RESTORE LOG AdventureWorks 
  FROM DISK = 'c:\SQLServerBackups\AdventureWorks.bak'
  WITH FILE=3, STOPAT='XXXX xx:xx:xx',
   RECOVERY;
GO

2.3.2 文件还原
1.	在线还原文件 a1。 
RESTORE DATABASE adb FILE='a1' FROM backup 
WITH NORECOVERY
2.	此时，文件 a1 处于 RESTORING 状态，文件组 A 处于离线状态。 
3.	完成文件还原之后，数据库管理员进行新的日志备份以确保捕获到该文件离线时的点。（之前曾经做过两次日志备份。） 
BACKUP LOG adb TO log_backup3 WITH COPY_ONLY
4.	在线还原日志备份。 
RESTORE LOG adb FROM log_backup1 WITH NORECOVERY
RESTORE LOG adb FROM log_backup2 WITH NORECOVERY
RESTORE LOG adb FROM log_backup3 WITH RECOVERY
5.	文件 a1 现处于在线状态。数据库恢复完成。

2.3.3 页面还原
此示例中，文件 B 的文件 ID 为 1，损坏的页的页 ID 分别为 57、202、916 和 1016。 
RESTORE DATABASE <database> PAGE='1:57, 1:202, 1:916, 1:1016'
   FROM <file_backup_of_file_B> 
   WITH NORECOVERY;
RESTORE LOG <database> FROM <log_backup> 
   WITH NORECOVERY;
RESTORE LOG <database> FROM <log_backup> 
   WITH NORECOVERY; 
BACKUP LOG <database> TO <new_log_backup> 
RESTORE LOG <database> FROM <new_log_backup> WITH RECOVERY;
GO

2.3.4 段落还原
尾日志备份
在还原数据库之前，数据库管理员必须先备份日志尾部。由于数据库已损坏，因此创建尾日志备份需要使用 NO_TRUNCATE 选项：
BACKUP LOG adb TO tailLogBackup WITH NORECOVERY, NO_TRUNCATE
尾日志备份是后面还原顺序中将要应用的最后一个备份。
还原顺序
1.	部分还原主文件组和辅助文件组 A。 
RESTORE DATABASE adb FILEGROUP='Primary' FROM backup1 
   WITH PARTIAL, NORECOVERY
RESTORE DATABASE adb FILEGROUP='A' FROM backup2 
   WITH NORECOVERY
RESTORE LOG adb FROM backup3 WITH NORECOVERY
RESTORE LOG adb FROM backup4 WITH NORECOVERY
RESTORE LOG adb FROM backup5 WITH NORECOVERY
RESTORE LOG adb FROM tailLogBackup WITH RECOVERY
此时，主文件组和辅助文件组 A 处于在线状态。文件组 B 和 C 中的所有文件都处于恢复挂起状态，这两个文件组处于离线状态。 
步骤 1 中的最后一条 RESTORE LOG 语句的消息会指出：由于文件组 C 不可用，因此涉及此文件组的事务回滚已延迟。数据库可继续执行常规操作，但这些事务会在相应的页面上持有锁，阻止别人的访问和修改。
2.	在线还原文件组 C。
在第二个还原顺序中，数据库管理员将还原文件组 C，同时要把所有的日志备份再还原一遍：
	
RESTORE DATABASE adb FILEGROUP='C' FROM backup2a WITH NORECOVERY
RESTORE LOG adb FROM backup3 WITH NORECOVERY
RESTORE LOG adb FROM backup4 WITH NORECOVERY
RESTORE LOG adb FROM backup5 WITH NORECOVERY
RESTORE LOG adb FROM tailLogBackup WITH RECOVERY
3.	此时主文件组及文件组 A 和 C 处于在线状态。文件组 B 中的文件处于恢复挂起状态，该文件组处于离线状态。解析延迟的事务后，日志被截断。 
4.	在线还原文件组 B。 
在第三个还原顺序中，数据库管理员将还原文件组 B。文件组 B 的备份是在该文件组变为只读状态之后进行的，因此，在恢复过程中无需再恢复日志备份。
RESTORE DATABASE adb FILEGROUP='B' FROM backup2b WITH RECOVERY
5.	所有文件组现在都处于在线状态。

2.3.6 孤立用户故障排除
若要检测孤立用户，可以执行下列 Transact-SQL 语句： 
USE <database_name>;
GO; 
sp_change_users_login @Action='Report';
GO;

修复：
USE <database_name>;
GO
sp_change_users_login @Action='update_one', @UserNamePattern='<database_user>', @LoginName='<login_name>';
GO

2.6 实例：将数据库系统在一台新服务器上恢复
下面是参考步骤。请注意，在命令行下运行的指令，是大小写敏感的。
1.	确认备用服务器的SQL Server版本和原服务器一致。
因为我们需要恢复系统数据库，需要保证我们恢复的master和msdb要能够和备用机的resource数据库一致。否则SQL Server将不能正常工作。所谓版本一致，指的是“select @@version”返回的号码必须完全一样。 

2.	在备用服务器的命令行窗口，用指令以单用户模式启动SQL Server服务。
NET START MSSQLSERVER /m

命令如果成功执行，应该返回如下信息：

The SQL Server (DR) service is starting..
The SQL Server (DR) service was started successfully.

3.	在命令行窗口，用sqlcmd这个命令行工具连接SQL Server。
sqlcmd -E -S sql2005pc

如果连接成功建立，应该返回下面的信息。

1>

4.	首先恢复Master数据库。
4.1 在sqlcmd的那个连接里，运行下面恢复语句（假设备份文件为'c:\lab\master.bak'）。
restore database master from disk = 'c:\lab\master.bak'
go

它应该返回类似于下面的信息：

Processed 360 pages for database 'master', file 'master' on file 1.
Processed 4 pages for database 'master', file 'mastlog' on file 1.
The master database has been successfully restored. Shutting down SQL Server.
SQL Server is terminating this process.

SQL Server服务自动停止了。

4.2 由于恢复的master数据库里记载的其他数据库的路径和现在的路径不一致，这时候重新启动SQL Server会失败。必须要用trace flag 3608来启动。
net start MSSQLSERVER /f /m /T3608

如果正常，应该返回下面的信息。
The SQL Server (DR) service is starting.
The SQL Server (DR) service was started successfully.

4.3 用sqlcmd连接修改其他数据库的文件路径到现有的正确路径（'C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\'）。
在命令行窗口，用sqlcmd再次作连接。

sqlcmd -E -S sql2005pc

用下面语句修改各个系统数据库的文件路径。

alter database mssqlsystemresource modify file (name =data, filename='C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\mssqlsystemresource.mdf');
go

如果正常，应该返回下面的信息。
The file "data" has been modified in the system catalog. The new path will be used the next time the database is started.

alter database mssqlsystemresource modify file (name =log, filename='C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\mssqlsystemresource.ldf');
go

如果正常，应该返回下面的信息。
The file "log" has been modified in the system catalog. The new path will be used the next time the database is started.

alter database msdb modify file (name =MSDBData, filename='C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\msdbdata.mdf');
go

如果正常，应该返回下面的信息。
The file "MSDBData" has been modified in the system catalog. The new path will be used the next time the database is started.

alter database msdb modify file (name =MSDBLog, filename='C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\msdblog.ldf'); go

如果正常，应该返回下面的信息。
The file "MSDBLog" has been modified in the system catalog. The new path will be used the next time the database is started.

alter database model modify file (name =modeldev, filename='C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\model.mdf');
go

如果正常，应该返回下面的信息。
The file "modeldev" has been modified in the system catalog. The new path will be used the next time the database is started.

alter database model modify file (name =modellog, filename='C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\modellog.ldf');
go

如果正常，应该返回下面的信息。
The file "modellog" has been modified in the system catalog. The new path will be used the next time the database is started.

alter database tempdb modify file (name =tempdev, filename='C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\tempdb.mdf');
go

如果正常，应该返回下面的信息。
The file "tempdev" has been modified in the system catalog. The new path will be used the next time the database is started.

alter database tempdb modify file (name =templog, filename='C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\templog.ldf');
go

如果正常，应该返回下面的信息。
The file "templog" has been modified in the system catalog. The new path will be used the next time the database is started.

全部修改完毕后，运行“exit”命令退出sqlcmd连接。

4.4 关闭SQL Server。
net stop MSSQLSERVER 

如果正常，应该返回下面的信息。
The SQL Server (DR) service is stopping.
The SQL Server (DR) service was stopped successfully.

4.5 用正常模式启动SQL Server。
net start MSSQLSERVER 
这时，SQL Server可以正常启动。但是它使用的系统数据库除了master以外，都是原先备用服务器自己的。我们要用生产服务器上的备份来替换它们。

5.	恢复msdb.
在运行下面命令之前，要先关闭SQL Server Agent服务。然后用restore命令恢复mdsb，将其指向新的文件路径。 
restore database msdb from disk = 'c:\lab\msdb.bak'
with move 'MSDBData' to 'C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\msdbdata.mdf',
move 'MSDBLog' to 'C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\msdblog.ldf', replace

如果正常，应该返回下面的信息。
Processed 600 pages for database 'msdb', file 'MSDBData' on file 1.
Processed 7 pages for database 'msdb', file 'MSDBLog' on file 1.
RESTORE DATABASE successfully processed 607 pages in 0.841 seconds (5.907 MB/sec).

6.	恢复model.
restore database model from disk = 'c:\lab\model.bak'
with move 'modeldev' to 'C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\model.mdf',
move 'modellog' to 'C:\Program Files\Microsoft SQL Server\MSSQL.4\MSSQL\Data\modellog.ldf', replace

如果正常，应该返回下面的信息。
Processed 152 pages for database 'model', file 'modeldev' on file 1.
Processed 3 pages for database 'model', file 'modellog' on file 1.
RESTORE DATABASE successfully processed 155 pages in 0.174 seconds (7.273 MB/sec).

7.	修改服务器名称
7.1 运行下面的语句你会发现，返回的还是原先的服务器名字。这时因为master是从那台机器来的。 
Select @@servername

7.2 运行下面语句修改服务器名。

Sp_dropserver '<原先服务器名>'
Go
Sp_addserver 'SQL2005PC', 'local'
Go

7.3 重启SQL服务，再运行下面语句，就可以看到返回现在的服务器名字了。
Select @@servername
Go

做完这些操作后，原先SQL Server的所有配置都能够恢复到新的服务器上。只是用户数据库都是质疑状态，因为新服务器上没有它们的文件。接下来就可以使用前文介绍的恢复方法，将用户数据库依次恢复。
