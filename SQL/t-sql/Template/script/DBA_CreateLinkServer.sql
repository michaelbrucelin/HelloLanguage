-- 创建链接服务器

USE [master]
GO
EXEC master.dbo.sp_addlinkedserver @server = N'linkname', @srvproduct = N'SQL Server', @datasrc = N'12.34.56.78'
GO
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname = N'linkname', @locallogin = NULL , @useself = N'False', @rmtuser = N'sa', @rmtpassword = N'########'
GO

USE [master]
GO
EXEC master.dbo.sp_addlinkedserver @server = N'linkname', @provider = N'SQLNCLI', @datasrc = N'12.34.56.78'
GO
EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname = N'linkname', @locallogin = NULL , @useself = N'False', @rmtuser = N'sa', @rmtpassword = N'########'
GO
