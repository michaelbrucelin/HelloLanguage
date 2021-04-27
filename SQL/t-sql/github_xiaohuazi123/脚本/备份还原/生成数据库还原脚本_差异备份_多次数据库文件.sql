

-- =============================================
-- Create date: <2015/4/18>
-- Description: 
-- ���ܣ�
-- 1) ���б��������ݿ���߼��ļ������߼���־�������ݿ�����
-- 2) ���������������� ƴ�ӳ� SQL ��ԭ�ű�
-- 3) ����˵����
--	  @BackupRootDir	�����ļ�Ŀ¼
--	  @MoveRootDir		���ݿ��ļ�Ŀ¼
--	  @IsDifferential	�Ƿ������ԭ����
--	  @IsDiffRestore	�Ƿ�������ԭ
--	  @IsLogRestore		�Ƿ���־��ԭ
--	  @IsMirrorRestore	�Ƿ���ԭ������ԭʱ��Ĭ�ϼ���������ԭ @IsDifferential = 1
--    @DBNamerestore    Ҫ��ԭ�ĵ������ݿ�����ݿ���
--    @IsRestoreSingleDB�Ƿ�ԭ�������ݿ⣬Ĭ�ϻ�ԭ�������ݿ� @IsRestoreSingleDB = 0
--	  
-- 4) ����������ڻָ�״̬�����ݿ⣬����ʹ�� RESTORE LOG [���ݿ���] WITH RECOVERY
--	  �޸ĳ�����״̬
--
-- 5) �����ݿ⸴���½�ʱ����Ҫ�������������ļ�����
-- =============================================


-- ��������
SET NOCOUNT ON

DECLARE @SQL				NVARCHAR(MAX)
DECLARE @tbDatabaseFields	TABLE ([file_id] INT, [type] INT, [logical_name] SYSNAME, [physical_name] SYSNAME, [backup_name] SYSNAME)
DECLARE @tbDatabases		TABLE ([name] SYSNAME)

DECLARE @BackupRootDir		NVARCHAR(MAX)
DECLARE @MoveRootDir		NVARCHAR(MAX)

DECLARE @FileID				INT
DECLARE @Type				INT
DECLARE @DbName				SYSNAME
DECLARE @LogicalName		SYSNAME
DECLARE @PhycialName		SYSNAME
DECLARE @BackupName			SYSNAME
DECLARE @DbNamePrefix		NVARCHAR(32)
DECLARE @DBNamerestore      NVARCHAR(60)

DECLARE @IsRestoreSingleDB  INT
DECLARE @IsDifferential		BIT
DECLARE @IsDiffRestore		BIT
DECLARE @IsLogRestore		BIT
DECLARE @IsMirrorRestore	BIT

-- ��ʼ��������ҪĿ¼������ָ����� \
SET @BackupRootDir			=	N'''C:\DBBackup\'
SET @MoveRootDir			=	N'''C:\DBBackup\'

-- ��ʼ����
SET @DbNamePrefix			=	''

-- �Ƿ�ԭ�������ݿ�
SET @IsRestoreSingleDB		=	0

-- Ҫ��ԭ�ĵ������ݿ�����ݿ���
SET @DBNamerestore			=	N'test'

-- �Ƿ������ԭ����: �� 1�� �� 0��
SET @IsDifferential			=	0

-- �Ƿ�������ԭ���� 1�� �� 0��
SET @IsDiffRestore			=	0

-- �Ƿ���־��ԭ���� 1�� �� 0��
SET @IsLogRestore			=	0

-- �Ƿ���ԭ���� 1�� �� 0��
-- ����ԭʱ��Ĭ�ϼ���������ԭ @IsDifferential = 1
SET @IsMirrorRestore		=	1


------------------------------------------------------------------------------------------------
-- ִ���߼�

-- ����ԭʱ��Ĭ�ϼ���������ԭ����Ϊ�������ݿ���봦�ڻ�ԭ
IF @IsMirrorRestore = 1 
BEGIN
	SET @IsDifferential = 1

	PRINT '-- ����ԭ�ű�'
END


IF @IsRestoreSingleDB = 1
    BEGIN
		IF NOT EXISTS (   SELECT name  FROM   sys.[databases]  WHERE  name = @DBNamerestore )
			RETURN;
		-- �������ݿ�
		INSERT INTO @tbDatabases ( [name] ) SELECT   [name]     FROM     master..sysdatabases
					WHERE    [name] NOT IN ( 'master', 'tempdb', 'model', 'msdb' )
							 AND [name] = @DBNamerestore
					ORDER BY [name];
    END;
ELSE
    BEGIN
        -- �б��������ݿ�
        INSERT INTO @tbDatabases ( [name] ) SELECT   [name]   FROM     master..sysdatabases
                    WHERE    [name] NOT IN ( 'master', 'tempdb', 'model', 'msdb' )
                             AND [name] LIKE @DbNamePrefix + '%'
                    ORDER BY [name];
    END;



DECLARE CUR_DbLogical_Names CURSOR LOCAL FORWARD_ONLY READ_ONLY FOR
SELECT [name] FROM @tbDatabases ORDER BY [name]

-- ��ѯ���ݿ��߼��ļ���
OPEN CUR_DbLogical_Names
FETCH NEXT FROM CUR_DbLogical_Names INTO @DbName
WHILE @@FETCH_STATUS=0
BEGIN
	 SET @SQL = 'USE '+@DbName+';'			  
			  + 'SELECT [file_id],  [type], [name], [physical_name], '''+@DbName+''' as backup_name '
			  + 'FROM sys.database_files'
	 INSERT @tbDatabaseFields([file_id],  [type], [logical_name], [physical_name], [backup_name])
	 EXEC (@SQL)

	FETCH NEXT FROM CUR_DbLogical_Names INTO @DbName
END
CLOSE CUR_DbLogical_Names
DEALLOCATE CUR_DbLogical_Names

/*
SELECT * FROM @tbDatabaseFields
*/

-- ���ɻ�ԭ�ű�
SET @SQL=
	'
	USE [Master]
	GO
	'
		PRINT @SQL
		
		

-- ��ԭ�ű�
DECLARE CUR_DbLogical_Names CURSOR LOCAL FORWARD_ONLY READ_ONLY FOR
SELECT [name] FROM @tbDatabases ORDER BY [name]

-- ��ѯ���ݿ��߼��ļ���
OPEN CUR_DbLogical_Names
FETCH NEXT FROM CUR_DbLogical_Names INTO @DbName
WHILE @@FETCH_STATUS=0
BEGIN
	
	SET @SQL = N''
	
	IF @IsLogRestore=0
	BEGIN	
        SET @SQL = 	@SQL +'--'+@DbName+char(13)
		SET @SQL = @SQL + REPLACE( REPLACE( 'RESTORE DATABASE {dbname} FROM  DISK = {backupRootDir}{dbname}.bak'' WITH  FILE = 1, ', '{dbname}', @DbName), '{backupRootDir}',  @BackupRootDir)
	END
	
	IF @IsLogRestore=1
	BEGIN
		SET @SQL = @SQL + REPLACE( 'RESTORE LOG {dbname} WITH RECOVERY', N'{dbname}', @DbName)
	END
	
	IF @IsDiffRestore=0 AND @IsLogRestore=0
	BEGIN
	
		
		-- �����ļ���
		DECLARE Cur_Database_Files CURSOR LOCAL FORWARD_ONLY FOR
			SELECT * FROM @tbDatabaseFields WHERE [backup_name]=@DbName ORDER BY [backup_name]		
					

		OPEN Cur_Database_Files
		FETCH NEXT FROM Cur_Database_Files INTO @FileID, @Type, @LogicalName, @PhycialName, @BackupName
		WHILE @@FETCH_STATUS=0
		BEGIN		
		 
			 IF @Type=1
			 BEGIN
			      IF @IsMirrorRestore = 1 
					  BEGIN
		 				  SET @SQL = @SQL + CHAR(10) + REPLICATE(' ', 4) + 'MOVE N''' + @LogicalName + ''' TO N' + '''' + @PhycialName + ''', '
					  END
				  ELSE
					  BEGIN
						  SET @PhycialName=REVERSE(SUBSTRING(REVERSE(@PhycialName),(CHARINDEX('fdl.',REVERSE(@PhycialName))+4),(CHARINDEX('\',REVERSE(@PhycialName)))-(CHARINDEX('fdl.',REVERSE(@PhycialName))+4)))
		 				  SET @SQL = @SQL + CHAR(10) + REPLICATE(' ', 4) + 'MOVE N''' + @LogicalName + ''' TO N' + @MoveRootDir + @PhycialName + '.ldf'', '
					  END
			 END
			 
			 IF @Type=0
			 BEGIN
		 		IF RIGHT(@PhycialName, 3)='mdf'
		 		BEGIN
				    IF @IsMirrorRestore = 1 
					  BEGIN
		 			        SET @SQL = @SQL + CHAR(10) + REPLICATE(' ', 4) + 'MOVE N''' + @LogicalName + ''' TO N' +  ''''  + @PhycialName + ''', '
					  END 
					ELSE
                       BEGIN
					      	SET @PhycialName=REVERSE(SUBSTRING(REVERSE(@PhycialName),(CHARINDEX('fdm.',REVERSE(@PhycialName))+4),(CHARINDEX('\',REVERSE(@PhycialName)))-(CHARINDEX('fdm.',REVERSE(@PhycialName))+4)))
		 			        SET @SQL = @SQL + CHAR(10) + REPLICATE(' ', 4) + 'MOVE N''' + @LogicalName + ''' TO N' + @MoveRootDir + @PhycialName + '.mdf'', '
					   END
		 		END
			 	
		 		IF RIGHT(@PhycialName, 3)='ndf'
		 		BEGIN
				      IF @IsMirrorRestore = 1 
						  BEGIN
		 						SET @SQL =@SQL + CHAR(10) + REPLICATE(' ', 4) + 'MOVE N''' + @LogicalName + ''' TO N' +  ''''  + @PhycialName + ''', '
						  END
					  ELSE
						  BEGIN
					   			SET @PhycialName=REVERSE(SUBSTRING(REVERSE(@PhycialName),(CHARINDEX('fdn.',REVERSE(@PhycialName))+4),(CHARINDEX('\',REVERSE(@PhycialName)))-(CHARINDEX('fdn.',REVERSE(@PhycialName))+4)))
		 						SET @SQL =@SQL + CHAR(10) + REPLICATE(' ', 4) + 'MOVE N''' + @LogicalName + ''' TO N' + @MoveRootDir + @PhycialName + '.ndf'', '
                      
						  END
		 		END
			 	
			 END
			
			--PRINT '1' + @LogicalName + ' ' + @PhycialName
			
			FETCH NEXT FROM Cur_Database_Files into @FileID, @Type, @LogicalName, @PhycialName, @BackupName
		END
		CLOSE Cur_Database_Files
		DEALLOCATE Cur_Database_Files
	
	END

	IF @IsLogRestore=0
	BEGIN
		
		-- ������ԭ��������	
		IF @IsDifferential=1
		BEGIN
			SET @SQL = @SQL + ' NORECOVERY, '
		END
		
			SET @SQL = @SQL + ' NOUNLOAD,  REPLACE,  STATS = 5 '
		
	END
	
	SET @SQL = @SQL + '
go
		'


	IF @IsMirrorRestore = 1
	BEGIN
		SET @SQL = @SQL + CHAR(10)
				 + '


					RESTORE LOG {dbname} FROM  DISK = {backupRootDir}{dbname}.trn'' WITH  FILE = 1,
						NOUNLOAD, NORECOVERY,  REPLACE,  STATS = 5
					
				   '
		SET @SQL = REPLACE( REPLACE(@SQL, N'{dbname}', @DbName), N'{backupRootDir}', @BackupRootDir)
	END

	PRINT @SQL
	PRINT ''


	FETCH NEXT FROM CUR_DbLogical_Names INTO @DbName
END
CLOSE CUR_DbLogical_Names
DEALLOCATE CUR_DbLogical_Names

GO

