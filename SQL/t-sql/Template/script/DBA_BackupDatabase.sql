-- 自动备份数据库
-- exec AUTOSQLBABEUP '2012MYT','D:\ERP-DateUP\','DZ'

--===============================
--自动备份角本
--@DataName 数据库,@Path 路径 eg 'D:D:\Backup\' @BackName 文件名
--===============================
CREATE PROCEDURE AUTOSQLBABEUP(@DataName varchar(100),@Path varchar(100),@BackName varchar(100))
AS
begin
    DECLARE @DataBase Nvarchar(100)
    DECLARE @DataPath Nvarchar(100)
    DECLARE @FileName Nvarchar(100)  
    DECLARE @BackupFileName Nvarchar(100)
    DECLARE @DataDescription Nvarchar(200)
    DECLARE @DataMediaName Nvarchar(50)
    DECLARE @DataMediaDescription Nvarchar(200)
    DECLARE @OkInfo Nvarchar(300)

    SET @DataBase =@DataName     -----数据库
    SET @DataPath = @Path        -----路径
    SET @FileName = @BackName    -----文件名
    SET @BackupFileName = @DataPath + @FileName
    SET @BackupFileName = @DataPath + @BackName +    -----实时备份自动产生文件名,格式[SQL_20050206_16_28]
    RTRIM(CONVERT(CHAR(10),GETDATE(),112)) + '_' +
    RTRIM(DATEPART(HOUR,GETDATE())) + '_' +
    LTRIM(DATEPART(MINUTE,GETDATE()))
    SET @DataDescription = 'SQL语句产生的备份,备份时间:' + CONVERT(CHAR(19),GETDATE(),121)     --描述
    SET @DataMediaName = 'Love_Computer Backup'     ---媒体
    SET @DataMediaDescription = 'Power by Love_Computer... Email: love_computer@163.com'   --媒体描述
    SET @OkInfo = '数据库 ' + @DataBase + ' 成功备份至 ' + @BackupFileName

    BACKUP DATABASE @DataBase TO DISK = @BackupFileName
    WITH NOINIT , NOUNLOAD , NOSKIP , STATS = 10 , NOFORMAT ,
    NAME = @DataBase , DESCRIPTION = @DataDescription ,
    MEDIANAME = @DataMediaName , MEDIADESCRIPTION = @DataMediaDescription

    PRINT @OkInfo
end

GO