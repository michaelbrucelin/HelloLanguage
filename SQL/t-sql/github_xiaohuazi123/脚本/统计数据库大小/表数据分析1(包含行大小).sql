

-- =============================================
-- Create date: <2014/4/18>
-- Description: ������������
-- =============================================





CREATE TABLE #tablespaceinfo
    (
      nameinfo VARCHAR(50) ,
      rowsinfo BIGINT ,
      reserved VARCHAR(20) ,
      datainfo VARCHAR(20) ,
      index_size VARCHAR(20) ,
      unused VARCHAR(20)
    )  
 
DECLARE @tablename VARCHAR(255);  
 
DECLARE Info_cursor CURSOR
FOR
    SELECT  '[' + [name] + ']'
    FROM    sys.tables
    WHERE   type = 'U';  
 
OPEN Info_cursor  
FETCH NEXT FROM Info_cursor INTO @tablename  
 
WHILE @@FETCH_STATUS = 0
    BEGIN 
        INSERT  INTO #tablespaceinfo
                EXEC sp_spaceused @tablename  
        FETCH NEXT FROM Info_cursor  
    INTO @tablename  
    END 
 
CLOSE Info_cursor  
DEALLOCATE Info_cursor  
 
--������ʱ��
CREATE TABLE [#tmptb]
    (
      TableName VARCHAR(50) ,
      DataInfo BIGINT ,
      RowsInfo BIGINT ,
      Spaceperrow  AS ( CASE RowsInfo
                         WHEN 0 THEN 0
                         ELSE CAST(DataInfo AS decimal(18,2))/CAST(RowsInfo AS decimal(18,2))
                       END ) PERSISTED
    )

--�������ݵ���ʱ��
INSERT  INTO [#tmptb]
        ( [TableName] ,
          [DataInfo] ,
          [RowsInfo]
        )
        SELECT  [nameinfo] ,
                CAST(REPLACE([datainfo], 'KB', '') AS BIGINT) AS 'datainfo' ,
                [rowsinfo]
        FROM    #tablespaceinfo
        ORDER BY CAST(REPLACE(reserved, 'KB', '') AS BIGINT) DESC  


--���ܼ�¼
SELECT  [tbspinfo].* ,
        [tmptb].[Spaceperrow] AS 'ÿ�м�¼���ռ�ÿռ䣨KB��'
FROM    [#tablespaceinfo] AS tbspinfo ,
        [#tmptb] AS tmptb
WHERE   [tbspinfo].[nameinfo] = [tmptb].[TableName]
ORDER BY CAST(REPLACE([tbspinfo].[reserved], 'KB', '') AS BIGINT) DESC  

DROP TABLE [#tablespaceinfo]
DROP TABLE [#tmptb]
