
-- =============================================
-- Create date: <2014/6/18>
-- Description: �鿴��ǰ������Щ���Ƿ�����
-- =============================================

DECLARE @DBNAME NVARCHAR(MAX)
DECLARE @SQL NVARCHAR(MAX)

SET @DBNAME='dbname'  --��Do

SET @SQL='SELECT  so.[name]
FROM    ['+@DBNAME+'].sys.partitions sp ,
        ['+@DBNAME+'].sys.objects so
WHERE   sp.object_id = so.[object_id]
        AND partition_number != 1
GROUP BY [so].[name]'

EXEC(@SQL)




