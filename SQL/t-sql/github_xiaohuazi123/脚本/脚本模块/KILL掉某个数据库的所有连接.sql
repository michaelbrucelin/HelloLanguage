


-- =============================================
-- Create date: <2014/4/18>
-- Description: KILL��ĳ�����ݿ����������
-- =============================================

DECLARE @DBNAME NVARCHAR(100)
DECLARE @SQL NVARCHAR(MAX)
DECLARE @SPID NVARCHAR(100)

SET @DBNAME='dbname'  --��Do Ҫkill�����ӵ����ݿ���


DECLARE CurDBName CURSOR
FOR
    SELECT  [spid]
    FROM    sys.sysprocesses WHERE [spid]>=50 
    AND   DBID =DB_ID(@DBNAME)

OPEN CurDBName
FETCH NEXT FROM CurDBName INTO @SPID

WHILE @@FETCH_STATUS = 0
    BEGIN  
        --kill process
        SET @SQL = N'kill '+@SPID
        EXEC (@SQL)

        FETCH NEXT FROM CurDBName INTO @SPID
    END
CLOSE CurDBName
DEALLOCATE CurDBName
