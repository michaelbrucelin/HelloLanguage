

-- =============================================
-- Create date: <2014/4/18>
-- Description: ���򻷾������Զ�����ģ��
--���������򻷾�
-- =============================================





DECLARE @DBName NVARCHAR(255)
DECLARE @masterip NVARCHAR(255)
DECLARE @mirrorip NVARCHAR(255)
DECLARE @witness NVARCHAR(255)
DECLARE @masteriptail NVARCHAR(255)
DECLARE @mirroriptail NVARCHAR(255)
DECLARE @witnesstail NVARCHAR(255)
DECLARE @certpath NVARCHAR(MAX)
DECLARE @Restorepath NVARCHAR(MAX)
DECLARE @Restorepath1 NVARCHAR(MAX)
DECLARE @Restorepath2 NVARCHAR(MAX)
DECLARE @MKPASSWORD NVARCHAR(500)
DECLARE @LOGINPWD NVARCHAR(500)
DECLARE @SQL NVARCHAR(MAX)


if OBJECT_ID ('tempdb..#temp')is not null 
BEGIN 
 DROP TABLE #BackupFileList
END

CREATE TABLE #BackupFileList 
    (
      LogicalName NVARCHAR(100) ,
      PhysicalName NVARCHAR(100) ,
      BackupType CHAR(1) ,
      FileGroupName NVARCHAR(50) ,
      SIZE BIGINT ,
      MaxSize BIGINT ,
      FileID BIGINT ,
      CreateLSN BIGINT ,
      DropLSN BIGINT NULL ,
      UniqueID UNIQUEIDENTIFIER ,
      ReadOnlyLSN BIGINT NULL ,
      ReadWriteLSN BIGINT NULL ,
      BackupSizeInBytes BIGINT ,
      SourceBlockSize INT ,
      FileGroupID INT ,
      LogGroupGUID UNIQUEIDENTIFIER NULL ,
      DifferentialBaseLSN BIGINT NULL ,
      DifferentialBaseGUID UNIQUEIDENTIFIER ,
      IsReadOnly BIT ,
      IsPresent BIT ,
      TDEThumbprint NVARCHAR(100)
    )


SET NOCOUNT ON

SET @masterip='172.31.21.10'  --��Do ����ip
SET @mirrorip='172.31.38.85'   --��Do �ӿ�ip
SET @witness='172.31.33.6'   --��Do  ��֤ip
SET @certpath='D:\DBBackup\'   --��Do  ֤����·��
SET @Restorepath='D:\DBBackup\'   --��Do ���ݻ�ԭ·��
SET @DBName='testmirror'               --��Do Ҫ����������ݿ���
SET @MKPASSWORD='master@2015key123' --��Do  ֤������
SET @LOGINPWD='User_Pass@2015key123'  --��Do  �����¼�û�����




select @masteriptail= PARSENAME(@masterip,2)+'_'+PARSENAME(@masterip,1) 
select @mirroriptail= PARSENAME(@mirrorip,2)+'_'+PARSENAME(@mirrorip,1) 
select @witnesstail= PARSENAME(@witness,2)+'_'+PARSENAME(@witness,1) 


--------------------------------------------------------------------------------
DECLARE @stat NVARCHAR(MAX)

SET  @stat='--�Զ����ɾ���ű�V1 By huazai'
PRINT @stat
PRINT CHAR(13)+CHAR(13)




SET  @stat='--0������ȷ��Ҫ������Ŀ�Ļָ�ģʽΪ������������sql������鿴'+CHAR(13)
+'SELECT [name], [recovery_model_desc] FROM sys.[databases]'+CHAR(13)+CHAR(13)+CHAR(13)

PRINT '--����'+@masterip
PRINT '--����'+@mirrorip
PRINT '--��֤��'+@witness
PRINT CHAR(13)+CHAR(13)
PRINT @stat

--------------------------------------------------------------------
PRINT '-- ============================================='

SET  @stat='--1�� �����������;���������Ϻͼ�֤�������ϴ���Master Key ������֤�� '+CHAR(13)
+'--����'+CHAR(13)
+'USE master;
CREATE MASTER KEY ENCRYPTION BY PASSWORD = '''+@MKPASSWORD+''';'
+'CREATE CERTIFICATE HOST_'
+@masteriptail
+'_cert  WITH SUBJECT = ''HOST_'
+@masteriptail
+'_certificate'','+CHAR(13)
+'START_DATE = ''09/20/2010'',EXPIRY_DATE = ''01/01/2099'';'+CHAR(13)

PRINT @stat


SET  @stat='--����'+CHAR(13)
+'USE master;
CREATE MASTER KEY ENCRYPTION BY PASSWORD = '''+@MKPASSWORD+''';'
+'CREATE CERTIFICATE HOST_'
+@mirroriptail
+'_cert  WITH SUBJECT = ''HOST_'
+@mirroriptail
+'_certificate'','+CHAR(13)
+'START_DATE = ''09/20/2010'',EXPIRY_DATE = ''01/01/2099'';'+CHAR(13)

PRINT @stat


SET  @stat='--��֤'+CHAR(13)
+'USE master;
CREATE MASTER KEY ENCRYPTION BY PASSWORD = '''+@MKPASSWORD+''';'
+'CREATE CERTIFICATE HOST_'
+@witnesstail
+'_cert  WITH SUBJECT = ''HOST_'
+@witnesstail
+'_certificate'','+CHAR(13)
+'START_DATE = ''09/20/2010'',EXPIRY_DATE = ''01/01/2099'';'+CHAR(13)+CHAR(13)+CHAR(13)+CHAR(13)

PRINT @stat

-----------------------------------------------------------

PRINT '-- ============================================='


SET  @stat='--2����������˵㣬ͬһ��ʵ����ֻ�ܴ���һ������˵�  '+CHAR(13)
+'--����'+CHAR(13)
+'CREATE ENDPOINT Endpoint_Mirroring 
STATE = STARTED 
AS 
TCP ( LISTENER_PORT=5022 , LISTENER_IP = ALL ) 
FOR 
DATABASE_MIRRORING 
( AUTHENTICATION = CERTIFICATE HOST_'
+@masteriptail
+'_cert  , ENCRYPTION = REQUIRED ALGORITHM AES , ROLE = ALL );'+CHAR(13)

PRINT @stat

SET  @stat='--����'+CHAR(13)
+'CREATE ENDPOINT Endpoint_Mirroring 
STATE = STARTED 
AS 
TCP ( LISTENER_PORT=5022 , LISTENER_IP = ALL ) 
FOR 
DATABASE_MIRRORING 
( AUTHENTICATION = CERTIFICATE HOST_'
+@mirroriptail
+'_cert  , ENCRYPTION = REQUIRED ALGORITHM AES , ROLE = ALL );'+CHAR(13)

PRINT @stat


SET  @stat='--��֤'+CHAR(13)
+'CREATE ENDPOINT Endpoint_Mirroring
STATE = STARTED
AS
TCP ( LISTENER_PORT=5022 , LISTENER_IP = ALL )
FOR
DATABASE_MIRRORING
( AUTHENTICATION = CERTIFICATE HOST_'
+@witnesstail
+'_cert  , ENCRYPTION = REQUIRED ALGORITHM AES , ROLE = ALL );'+CHAR(13)+CHAR(13)+CHAR(13)

PRINT @stat

----------------------------------------------------------------------------------------

PRINT '-- ============================================='


SET  @stat='--3������֤�飬Ȼ�󻥻�  '+CHAR(13)
+'--����'+CHAR(13)
+'BACKUP CERTIFICATE HOST_'
+@masteriptail
+'_cert TO FILE = '+''''+@certpath+'\HOST_'+@masteriptail+'_cert.cer'';'+CHAR(13)

PRINT @stat

SET  @stat='--����'+CHAR(13)
+'BACKUP CERTIFICATE HOST_'
+@mirroriptail
+'_cert TO FILE = '+''''+@certpath+'\HOST_'+@mirroriptail+'_cert.cer'';'+CHAR(13)

PRINT @stat


SET  @stat='--��֤'+CHAR(13)
+'BACKUP CERTIFICATE HOST_'
+@witnesstail
+'_cert TO FILE = '+''''+@certpath+'\HOST_'+@witnesstail+'_cert.cer'';'+CHAR(13)+CHAR(13)+CHAR(13)

PRINT @stat


----------------------------------------------------------------------------------

PRINT '-- ============================================='


SET  @stat='--4������������½�û�  '+CHAR(13)
+'--����'+CHAR(13)
+'CREATE LOGIN DB_02_Mirror WITH PASSWORD = '''+@LOGINPWD+'''; 
CREATE USER DB_02_Mirror FOR LOGIN DB_02_Mirror; 
CREATE CERTIFICATE HOST_'
+@mirroriptail
+'_cert AUTHORIZATION DB_02_Mirror FROM FILE ='''+@certpath+'HOST_'+@mirroriptail+'_cert.cer'';'
+'GRANT CONNECT ON ENDPOINT::Endpoint_Mirroring TO [DB_02_Mirror];'+CHAR(13)

PRINT @stat

SET  @stat='CREATE LOGIN DB_03_Mirror WITH PASSWORD = '''+@LOGINPWD+''';
CREATE USER DB_03_Mirror FOR LOGIN DB_03_Mirror;
CREATE CERTIFICATE HOST_'
+@witnesstail
+'_cert AUTHORIZATION DB_03_Mirror FROM FILE ='''+@certpath+'HOST_'+@witnesstail+'_cert.cer'';'
+'GRANT CONNECT ON ENDPOINT::Endpoint_Mirroring TO [DB_03_Mirror];'+CHAR(13)

PRINT @stat


SET  @stat='--����'+CHAR(13)
+'CREATE LOGIN DB_01_Mirror WITH PASSWORD = '''+@LOGINPWD+'''; 
CREATE USER DB_01_Mirror FOR LOGIN DB_01_Mirror; 
CREATE CERTIFICATE HOST_'
+@masteriptail
+'_cert AUTHORIZATION DB_01_Mirror FROM FILE ='''+@certpath+'HOST_'+@masteriptail+'_cert.cer'';'
+'GRANT CONNECT ON ENDPOINT::Endpoint_Mirroring TO [DB_01_Mirror];'+CHAR(13)

PRINT @stat

SET  @stat='CREATE LOGIN DB_03_Mirror WITH PASSWORD = '''+@LOGINPWD+''';
CREATE USER DB_03_Mirror FOR LOGIN DB_03_Mirror;
CREATE CERTIFICATE HOST_'
+@witnesstail
+'_cert AUTHORIZATION DB_03_Mirror FROM FILE ='''+@certpath+'HOST_'+@witnesstail+'_cert.cer'';'
+'GRANT CONNECT ON ENDPOINT::Endpoint_Mirroring TO [DB_03_Mirror];'+CHAR(13)

PRINT @stat


SET  @stat='--��֤'+CHAR(13)
+'CREATE LOGIN DB_01_Mirror WITH PASSWORD = '''+@LOGINPWD+'''; 
CREATE USER DB_01_Mirror FOR LOGIN DB_01_Mirror; 
CREATE CERTIFICATE HOST_'
+@masteriptail
+'_cert AUTHORIZATION DB_01_Mirror FROM FILE ='''+@certpath+'HOST_'+@masteriptail+'_cert.cer'';'
+'GRANT CONNECT ON ENDPOINT::Endpoint_Mirroring TO [DB_01_Mirror];'+CHAR(13)

PRINT @stat

SET  @stat='CREATE LOGIN DB_02_Mirror WITH PASSWORD = '''+@LOGINPWD+''';
CREATE USER DB_02_Mirror FOR LOGIN DB_02_Mirror;
CREATE CERTIFICATE HOST_'
+@mirroriptail
+'_cert AUTHORIZATION DB_02_Mirror FROM FILE ='''+@certpath+'HOST_'+@mirroriptail+'_cert.cer'';'
+'GRANT CONNECT ON ENDPOINT::Endpoint_Mirroring TO [DB_02_Mirror];'+CHAR(13)+CHAR(13)+CHAR(13)+CHAR(13)

PRINT @stat

------------------------------------------------------------------------------

PRINT '-- ============================================='



SET  @stat='--5����������������5022�˿ڣ�������telnet����5022�˿��Ƿ�ͨ �����������ű�����ճ����bat�ļ���'+CHAR(13)
PRINT @stat

SET  @stat='echo ����'+CHAR(13)
+'telnet '+@mirrorip+' 5022'+CHAR(13)
+'telnet '+@witness+' 5022'+CHAR(13)
+'pause'

PRINT @stat+CHAR(13)+CHAR(13)

SET  @stat='echo �����'+CHAR(13)
+'telnet '+@masterip+' 5022'+CHAR(13)
+'telnet '+@witness+' 5022'+CHAR(13)
+'pause'

PRINT @stat+CHAR(13)+CHAR(13)

SET  @stat='echo ��֤'+CHAR(13)
+'telnet '+@masterip+' 5022'+CHAR(13)
+'telnet '+@mirrorip+' 5022'+CHAR(13)
+'pause'

PRINT @stat+CHAR(13)+CHAR(13)+CHAR(13)


--------------------------------------------------------------

PRINT '-- ============================================='



SET  @stat='--6���������ݿ�(��������+������־����)'+CHAR(13)
PRINT @stat

SET  @stat='DECLARE @FileName NVARCHAR(MAX)'+CHAR(13)+CHAR(13)

PRINT @stat


SET  @stat='--('+@DBName+'���ݿ���������)'+CHAR(13)
+'SET @FileName = ''D:\DBBackup\'+@DBName+'_FullBackup_1.bak''
BACKUP DATABASE ['+@DBName+']
TO DISK=@FileName WITH FORMAT ,COMPRESSION'+CHAR(13)+CHAR(13)

PRINT @stat


SET  @stat='--('+@DBName+'���ݿ���־����)'+CHAR(13)
+'SET @FileName = ''D:\DBBackup\'+@DBName+'_logBackup_2.bak''
BACKUP DATABASE ['+@DBName+']
TO DISK=@FileName WITH FORMAT ,COMPRESSION'

PRINT @stat+CHAR(13)+CHAR(13)+CHAR(13)

------------------------------------------------------------------------------

PRINT '-- ============================================='


SET  @stat='--7����ԭ���ݿ�(ָ��norecovery��ʽ��ԭ)'+CHAR(13)
PRINT @stat

SET  @Restorepath1=''

SET @Restorepath2=@Restorepath+@DBName+'_FullBackup_1.bak'
SET @SQL = 'RESTORE FILELISTONLY  FROM DISK = '''+@Restorepath2+''''  

INSERT INTO #BackupFileList EXEC (@SQL);

 DECLARE @LNAME NVARCHAR(2000)
  DECLARE @PNAME NVARCHAR(2000)


        DECLARE CurTBName CURSOR
        FOR
            SELECT LogicalName,PhysicalName
            FROM    #BackupFileList  

        OPEN CurTBName
        FETCH NEXT FROM CurTBName INTO @LNAME,@PNAME

        WHILE @@FETCH_STATUS = 0
            BEGIN  
             SET  @Restorepath1=' MOVE N'''+@LNAME+''' TO N'''+@PNAME+''', '+CHAR(13)+@Restorepath1


                FETCH NEXT FROM CurTBName INTO  @LNAME,@PNAME
            END
        CLOSE CurTBName
        DEALLOCATE CurTBName




SET  @stat='USE [master]
RESTORE DATABASE '+@DBName+' FROM  DISK = N'''+@Restorepath+@DBName+'_FullBackup_1.bak'' WITH  FILE = 1,'+CHAR(13)
+@Restorepath1
+'NOUNLOAD,NORECOVERY,  REPLACE,  STATS = 5
GO'

SET  @stat='USE [master]
RESTORE LOG '+@DBName+' FROM  DISK = N'''+@Restorepath+@DBName+'_logBackup_2.bak'' WITH  FILE = 1,'+CHAR(13)
+'NOUNLOAD,NORECOVERY,  REPLACE,  STATS = 5
GO'



PRINT @stat+CHAR(13)+CHAR(13)

DROP TABLE #BackupFileList

--------------------------------------------------------------------------------

PRINT '-- ============================================='



SET  @stat='--8�����Ӿ����飬��Ҫ���ڱ�����ִ�У���ִ������������Ū��֮��Ĭ��Ϊ����ȫ�ȼ�ΪFULL'+CHAR(13)
PRINT @stat




SET  @stat='--������ִ��'+CHAR(13)
+'USE [master]
GO

ALTER DATABASE ['+@DBName+'] SET PARTNER = '''+'TCP://'+@masterip+':5022'';  --������������ip'+CHAR(13)+CHAR(13)

PRINT @stat


SET  @stat='--������ִ��'+CHAR(13)
+'USE [master]
GO

ALTER DATABASE ['+@DBName+'] SET PARTNER = '''+'TCP://'+@mirrorip+':5022'';  --�����������ip'+CHAR(13)+CHAR(13)

PRINT @stat

SET  @stat='ALTER DATABASE ['+@DBName+'] SET PARTNER = '''+'TCP://'+@witness+':5022'';  --��֤��������ip'+CHAR(13)+CHAR(13)

PRINT @stat