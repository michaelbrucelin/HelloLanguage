



-- =============================================
-- Create date: <2014/4/18>
-- Description: 查询耗CPU的sql语句
-- =============================================



SELECT  t.[text] ,
        db_name(p.dbid) dbname,
        p.*
FROM    sys.sysprocesses p
        CROSS APPLY sys.dm_exec_sql_text(sql_handle) AS T
WHERE   p.spid > 49
ORDER BY cpu  desc