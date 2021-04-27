USE [master]
GO

CREATE DATABASE [MonitorElapsedHighSQL]
GO
--����

USE [MonitorElapsedHighSQL]
GO


 --1����[SQLCountStatisticsByDay]
  --ץȡ����sql�������
CREATE TABLE [dbo].[SQLCountStatisticsByDay]
    (
      id INT IDENTITY(1, 1)  PRIMARY KEY ,
      [SQLCount] INT ,
      [gettime] DATETIME
    )

CREATE INDEX [Idx_SQLCountStatisticsByDay_SQLCount] ON [MonitorElapsedHighSQL].[dbo].[SQLCountStatisticsByDay]([SQLCount])
CREATE INDEX [Idx_SQLCountStatisticsByDay_gettime] ON [MonitorElapsedHighSQL].[dbo].[SQLCountStatisticsByDay]([gettime])
GO



 --2����[MostElapsedStatisticsByDay]
 --ÿ����ͬ��sql��ʱ���
CREATE TABLE [dbo].[MostElapsedStatisticsByDay]
    (
      id INT IDENTITY(1, 1)
             PRIMARY KEY ,
      [ElapsedMS] INT ,
      [IOReads] BIGINT ,
      [IOWrites] BIGINT ,
      [DBName] NVARCHAR(128) ,
      [paramlist] NVARCHAR(MAX) ,
      [planstmttext] NVARCHAR(MAX) ,
      [stmttext] NVARCHAR(MAX) ,
      [xmlplan] XML ,
      [gettime] DATETIME
    )

CREATE INDEX [Idx_MostElapsedStatisticsByDay_ElapsedMS] ON [MonitorElapsedHighSQL].[dbo].[MostElapsedStatisticsByDay]([ElapsedMS])
CREATE INDEX [Idx_MostElapsedStatisticsByDay_gettime] ON [MonitorElapsedHighSQL].[dbo].[MostElapsedStatisticsByDay]([gettime])
GO


 --3����[MostIOReadStatisticsByDay]
--ÿ����ͬ��sql��IOread���
CREATE TABLE [dbo].[MostIOReadStatisticsByDay]
    (
      id INT IDENTITY(1, 1)
             PRIMARY KEY ,
      [IOReads] BIGINT ,
      [DBName] NVARCHAR(128) ,
      [paramlist] NVARCHAR(MAX) ,
      [planstmttext] NVARCHAR(MAX) ,
      [stmttext] NVARCHAR(MAX) ,
      [xmlplan] XML ,
      [gettime] DATETIME
    )

CREATE INDEX [Idx_MostIOReadStatisticsByDay_IOReads] ON [MonitorElapsedHighSQL].[dbo].[MostIOReadStatisticsByDay]([IOReads])
CREATE INDEX [Idx_MostIOReadStatisticsByDay_gettime] ON [MonitorElapsedHighSQL].[dbo].[MostIOReadStatisticsByDay]([gettime])
GO


 --4����[MostIOWriteStatisticsByDay]
--ÿ����ͬ��sql��IOwrite���
CREATE TABLE [dbo].[MostIOWriteStatisticsByDay]
    (
      id INT IDENTITY(1, 1)
             PRIMARY KEY ,
      [IOWrites] BIGINT ,
      [DBName] NVARCHAR(128) ,
      [paramlist] NVARCHAR(MAX) ,
      [planstmttext] NVARCHAR(MAX) ,
      [stmttext] NVARCHAR(MAX) ,
      [xmlplan] XML ,
      [gettime] DATETIME
    )

CREATE INDEX [Idx_MostIOWriteStatisticsByDay_IOWrites] ON [MonitorElapsedHighSQL].[dbo].[MostIOWriteStatisticsByDay]([IOWrites])
CREATE INDEX [Idx_MostIOWriteStatisticsByDay_gettime] ON [MonitorElapsedHighSQL].[dbo].[MostIOWriteStatisticsByDay]([gettime])
GO


 --5����[sp_executesqlCountStatisticsByDay]
--ʹ��sp_executesql��sql�ж�����
CREATE TABLE [dbo].[sp_executesqlCountStatisticsByDay]
    (
      id INT IDENTITY(1, 1)
             PRIMARY KEY ,
      [sp_executesqlCount] INT ,
      [DBName] NVARCHAR(128) ,
      [planstmttext] NVARCHAR(MAX) ,
      [gettime] DATETIME
    )

CREATE INDEX [Idx_sp_executesqlCountStatisticsByDay_sp_executesqlCount] ON [MonitorElapsedHighSQL].[dbo].[sp_executesqlCountStatisticsByDay]([sp_executesqlCount])
CREATE INDEX [Idx_sp_executesqlCountStatisticsByDay_gettime] ON [MonitorElapsedHighSQL].[dbo].[sp_executesqlCountStatisticsByDay]([gettime])
GO