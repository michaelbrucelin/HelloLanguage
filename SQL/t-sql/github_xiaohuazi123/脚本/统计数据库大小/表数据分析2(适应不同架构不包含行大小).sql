



-- =============================================
-- Create date: <2014/4/18>
-- Description: 
--����
--���������������ʺϲ�ͬ�ļܹ�dbo
--�����Ļ���������Щ�޸ģ��ʺϲ�ͬ�ļܹ�dbo
-- =============================================




IF OBJECT_ID('tempdb..#TablesSizes') IS NOT NULL
    DROP TABLE #TablesSizes

CREATE TABLE #TablesSizes
    (
      TableName sysname ,
      Rows BIGINT ,
      reserved VARCHAR(100) ,
      data VARCHAR(100) ,
      index_size VARCHAR(100) ,
      unused VARCHAR(100)
    )

DECLARE @sql VARCHAR(MAX)
SELECT  @sql = COALESCE(@sql, '') + '
INSERT INTO #TablesSizes execute sp_spaceused ''' + QUOTENAME(TABLE_SCHEMA,
                                                              '[]') + '.'
        + QUOTENAME(Table_Name, '[]') + ''''
FROM    INFORMATION_SCHEMA.TABLES
WHERE   TABLE_TYPE = 'BASE TABLE'

PRINT ( @SQL )
EXECUTE (@SQL)

SELECT  *
FROM    #TablesSizes
ORDER BY Rows DESC 

