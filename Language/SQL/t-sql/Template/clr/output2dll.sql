/*
将数据库中的Assembly导出为DLL文件
参考：https://stackoverflow.com/questions/4244482/retrieve-clr-dll-from-sql-server
*/

-- 将数据库中的Assembly导出为DLL文件
DECLARE @IMG_PATH VARBINARY(MAX)
DECLARE @ObjectToken INT

SELECT @IMG_PATH = content FROM sys.assembly_files WHERE assembly_id = 65536

EXEC sp_OACreate 'ADODB.Stream', @ObjectToken OUTPUT
EXEC sp_OASetProperty @ObjectToken, 'Type', 1
EXEC sp_OAMethod @ObjectToken, 'Open'
EXEC sp_OAMethod @ObjectToken, 'Write', NULL, @IMG_PATH
EXEC sp_OAMethod @ObjectToken, 'SaveToFile', NULL, 'D:\SqlServerCLR.dll', 2
EXEC sp_OAMethod @ObjectToken, 'Close'
EXEC sp_OADestroy @ObjectToken
GO

/* 如果执行报错，需要启用OLE Automation Procedures
消息 15281，级别 16，状态 1，过程 sp_OACreate，行 1 [批起始行 0]
SQL Server 阻止了对组件“Ole Automation Procedures”的 过程“sys.sp_OACreate”的访问，因为此组件已作为此服务器安全配置的一部分而被关闭。系统管理员可以通过使用 sp_configure 启用“Ole Automation Procedures”。有关启用“Ole Automation Procedures”的详细信息，请搜索 SQL Server 联机丛书中的“Ole Automation Procedures”。
消息 15281，级别 16，状态 1，过程 sp_OASetProperty，行 1 [批起始行 0]
SQL Server 阻止了对组件“Ole Automation Procedures”的 过程“sys.sp_OASetProperty”的访问，因为此组件已作为此服务器安全配置的一部分而被关闭。系统管理员可以通过使用 sp_configure 启用“Ole Automation Procedures”。有关启用“Ole Automation Procedures”的详细信息，请搜索 SQL Server 联机丛书中的“Ole Automation Procedures”。
消息 15281，级别 16，状态 1，过程 sp_OAMethod，行 1 [批起始行 0]
SQL Server 阻止了对组件“Ole Automation Procedures”的 过程“sys.sp_OAMethod”的访问，因为此组件已作为此服务器安全配置的一部分而被关闭。系统管理员可以通过使用 sp_configure 启用“Ole Automation Procedures”。有关启用“Ole Automation Procedures”的详细信息，请搜索 SQL Server 联机丛书中的“Ole Automation Procedures”。
消息 15281，级别 16，状态 1，过程 sp_OAMethod，行 1 [批起始行 0]
SQL Server 阻止了对组件“Ole Automation Procedures”的 过程“sys.sp_OAMethod”的访问，因为此组件已作为此服务器安全配置的一部分而被关闭。系统管理员可以通过使用 sp_configure 启用“Ole Automation Procedures”。有关启用“Ole Automation Procedures”的详细信息，请搜索 SQL Server 联机丛书中的“Ole Automation Procedures”。
消息 15281，级别 16，状态 1，过程 sp_OAMethod，行 1 [批起始行 0]
SQL Server 阻止了对组件“Ole Automation Procedures”的 过程“sys.sp_OAMethod”的访问，因为此组件已作为此服务器安全配置的一部分而被关闭。系统管理员可以通过使用 sp_configure 启用“Ole Automation Procedures”。有关启用“Ole Automation Procedures”的详细信息，请搜索 SQL Server 联机丛书中的“Ole Automation Procedures”。
消息 15281，级别 16，状态 1，过程 sp_OAMethod，行 1 [批起始行 0]
SQL Server 阻止了对组件“Ole Automation Procedures”的 过程“sys.sp_OAMethod”的访问，因为此组件已作为此服务器安全配置的一部分而被关闭。系统管理员可以通过使用 sp_configure 启用“Ole Automation Procedures”。有关启用“Ole Automation Procedures”的详细信息，请搜索 SQL Server 联机丛书中的“Ole Automation Procedures”。
消息 15281，级别 16，状态 1，过程 sp_OADestroy，行 1 [批起始行 0]
SQL Server 阻止了对组件“Ole Automation Procedures”的 过程“sys.sp_OADestroy”的访问，因为此组件已作为此服务器安全配置的一部分而被关闭。系统管理员可以通过使用 sp_configure 启用“Ole Automation Procedures”。有关启用“Ole Automation Procedures”的详细信息，请搜索 SQL Server 联机丛书中的“Ole Automation Procedures”。
*/

-- 开启 Ole Automation Procedures
sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
sp_configure 'Ole Automation Procedures', 1;
GO
RECONFIGURE;
GO
EXEC sp_configure 'Ole Automation Procedures';
GO

-- 关闭 Ole Automation Procedures
sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
sp_configure 'Ole Automation Procedures', 1;
GO
RECONFIGURE;
GO
EXEC sp_configure 'Ole Automation Procedures';
GO

-- 关闭高级选项
sp_configure 'show advanced options', 0;
GO
RECONFIGURE;
GO
