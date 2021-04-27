
-- =============================================
-- Create date: <2014/4/18>
-- Description: �ٱ�������ű�
-- =============================================
DECLARE @DBNAME NVARCHAR(100)
DECLARE @SQL NVARCHAR(MAX)


DECLARE CurDBName CURSOR
FOR
    SELECT  name
    FROM    sys.[databases]
    WHERE   [name] NOT IN ('MASTER','MODEL','TEMPDB','MSDB','ReportServer','ReportServerTempDB','distribution')
    

OPEN CurDBName
FETCH NEXT FROM CurDBName INTO @DBNAME

WHILE @@FETCH_STATUS = 0
    BEGIN  
        SET @SQL = N' ALTER DATABASE ['+@DBNAME+'] SET RECOVERY SIMPLE'  --��Do ����Ҫִ�е������޸�
        PRINT(@SQL)
        FETCH NEXT FROM CurDBName INTO @DBNAME
    END
CLOSE CurDBName
DEALLOCATE CurDBName