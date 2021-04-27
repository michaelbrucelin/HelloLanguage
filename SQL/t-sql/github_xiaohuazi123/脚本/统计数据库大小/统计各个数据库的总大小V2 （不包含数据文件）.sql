

-- =============================================
-- Create date: <2014/4/18>
-- Description: ͳ�Ƹ������ݿ���ܴ�СV2 �����������ļ�
-- =============================================


SET NOCOUNT ON 
USE master
GO

DECLARE @DBNAME NVARCHAR(MAX)
DECLARE @SQL NVARCHAR(MAX)



--��ʱ��������
CREATE TABLE #DataBaseServerData
(
  ID INT IDENTITY(1, 1) ,
  DBNAME NVARCHAR(MAX) ,
  Log_Total_MB DECIMAL(18, 1) NOT NULL ,
  Log_FREE_SPACE_MB DECIMAL(18, 1) NOT NULL 
)



--�α�
DECLARE @itemCur CURSOR
SET 
@itemCur = CURSOR FOR 
SELECT name from   SYS.[databases] WHERE [name] NOT IN ('MASTER','MODEL','TEMPDB','MSDB','ReportServer','ReportServerTempDB')
AND [state]=0


OPEN @itemCur
FETCH NEXT FROM @itemCur INTO @DBNAME
WHILE @@FETCH_STATUS = 0
    BEGIN
    SET @SQL=N'USE ['+@DBNAME+'];'+CHAR(10)
    +
    'INSERT  [#DataBaseServerData]
                ( [DBNAME] ,
                  [Log_Total_MB] ,
		  [Log_FREE_SPACE_MB ] 
		        )
                SELECT '''+@DBNAME+''', str(sum(convert(dec(17,2),sysfiles.size)) / 128,10,2) AS Total_MB,
				SUM(( database_files.size - FILEPROPERTY(database_files.name, ''SpaceUsed'') )) / 128.0 AS free_space_mb
                FROM    dbo.sysfiles as sysfiles INNER JOIN sys.database_files as database_files ON sysfiles.[fileid]=database_files.[file_id] WHERE sysfiles.[groupid]  =0
				AND database_files.[type] = 1;'
        EXEC (@SQL)
        FETCH NEXT FROM @itemCur INTO @DBNAME
    END 

CLOSE @itemCur
DEALLOCATE @itemCur

SELECT  *  FROM    [#DataBaseServerData]
DROP TABLE [#DataBaseServerData]