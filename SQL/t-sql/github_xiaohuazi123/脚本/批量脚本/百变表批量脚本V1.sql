
-- =============================================
-- Create date: <2015/2/18>
-- Description: �ٱ�������ű�
-- =============================================

use dbname --��Do �л���Ҫִ�е����ݿ�
GO

DECLARE @fromdb varchar(100)
DECLARE @todb varchar(100)
DECLARE @tablename varchar(100)
DECLARE @sql nvarchar(max)
SET @todb = 'dbname'  --��Do 

PRINT ('USE ['+@todb+']' +CHAR(10)+'GO'+CHAR(10))


DECLARE @itemCur CURSOR
SET @itemCur = CURSOR FOR 
    SELECT name from sys.tables WHERE type='U' order by name

OPEN @itemCur
FETCH NEXT FROM @itemCur INTO @tablename
WHILE @@FETCH_STATUS=0
BEGIN
	PRINT ('--'+@tablename)
	SET @sql = 'truncate table ['+@todb+'].[dbo].['+@tablename+']' --��Do ����Ҫִ�е������޸�
	PRINT(@sql)PRINT('GO')+CHAR(13)

    FETCH NEXT FROM @itemCur INTO @tablename
END 

CLOSE @itemCur
DEALLOCATE @itemCur
