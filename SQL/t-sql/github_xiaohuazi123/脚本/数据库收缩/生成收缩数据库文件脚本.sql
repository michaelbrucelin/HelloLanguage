
-- =============================================
-- Create date: <2014/4/18>
-- Description: �Զ������������ݿ��ļ��ű�
-- =============================================


USE [dbname]   --��Do ����Ҫ���������ݿ�
GO
SET nocount ON
CREATE TABLE #Data
    (
      ID INT IDENTITY(1, 1) ,
      DBNAME NVARCHAR(30) ,
      FileID INT NOT NULL ,
      [FileGroupId] INT NOT NULL ,
      TotalExtents INT NOT NULL ,
      UsedExtents INT NOT NULL ,
      [FileName] SYSNAME NOT NULL ,
      [FilePath] NVARCHAR(MAX) NOT NULL ,
      [FileGroup] NVARCHAR(MAX) NULL
    )

INSERT  #Data
        ( FileID ,
          [FileGroupId] ,
          TotalExtents ,
          UsedExtents ,
          [FileName] ,
          [FilePath]
        )
        EXEC ( 'DBCC showfilestats WITH NO_INFOMSGS'
            )

UPDATE  #Data
SET     #Data.FileGroup = sysfilegroups.groupname ,
        [#Data].[DBNAME] = DB_NAME()
FROM    #Data ,
        sysfilegroups
WHERE   #Data.FileGroupId = sysfilegroups.groupid

SELECT  ID ,
        DBNAME ,
        [FileGroup] ,
        'Data' FileType ,
        [FileName] ,
        TotalExtents * 64. / 1024 TotalMB ,
        UsedExtents * 64. / 1024 UsedMB ,
        [FilePath] ,
        FileID
FROM    #Data
ORDER BY [ID]



DECLARE @i INT
 --����ѭ��
SET @i = 1
DECLARE @dbname NVARCHAR(100)
DECLARE @filegroup NVARCHAR(200)
DECLARE @filename NVARCHAR(200)
DECLARE @fileid NVARCHAR(10)
DECLARE @totalMB DECIMAL(20, 1)
 --�ܴ�С
DECLARE @UsedMB DECIMAL(20, 1)
  --��ʹ�ô�С
DECLARE @CanshrinkSize NVARCHAR(100)
 --���������Ĵ�С

DECLARE @COUNT INT
  --����#Data���������ֵ

--��ȡ#Data���������
SELECT  @COUNT = COUNT(*)
FROM    #Data

SELECT TOP 1
        @dbname = [DBNAME]
FROM    [#Data] 
PRINT 'USE [' + @dbname+']'
PRINT 'GO'
WHILE @i <= @COUNT
    BEGIN
        SELECT  @filegroup = [FileGroup] ,
                @filename = [FileName] ,
                @fileid = [FileID] ,
                @totalMB = TotalExtents * 64. / 1024 ,
                @UsedMB = UsedExtents * 64. / 1024
        FROM    #Data
        WHERE   [ID] = @i
        PRINT '--�ļ���:' + @filegroup + ';�ļ�id:' + @fileid + ';�ܴ�С:'
            + CAST(@totalMB AS VARCHAR(100)) + 'MB;��ʹ�ô�С:'
            + CAST(@UsedMB AS VARCHAR(100)) + 'MB;'
        SET @CanshrinkSize = CAST(CAST(@UsedMB + 1024 AS INT) AS NVARCHAR(100))
        PRINT 'DBCC SHRINKFILE ([' + @filename + '],' + @CanshrinkSize + ')'
            + '   --����������ֵΪ��ʹ�õĴ�С��1G' + CHAR(10)
        SET @i = @i + 1
    END

DROP TABLE #Data
