/*
    建议编制计划任务，在数据库空闲时执行，否则收缩可能会失败
*/
use tempdb
go
--清除数据库中由BSERP程序创建的临时表
declare @strqry varchar(1000)
declare @temptable varchar(200)
declare @temtype varchar(200)

DECLARE Droptemptable CURSOR FOR 
SELECT name, xtype
FROM dbo.sysobjects
where name like '%BSTEMP%' or name like '%SPCBB%'

OPEN Droptemptable

FETCH NEXT FROM Droptemptable INTO @temptable,@temtype
WHILE @@FETCH_STATUS = 0
BEGIN
    if @temtype='V'
    begin
        SET @strqry=' DROP VIEW '+@temptable
        exec(@strqry)
    end
    if @temtype='U'
    begin
        SET @strqry=' DROP TABLE '+@temptable
        exec(@strqry)
    end

    FETCH NEXT FROM Droptemptable   INTO @temptable,@temtype
END

CLOSE Droptemptable
DEALLOCATE Droptemptable
go

--收缩数据文件
dbcc shrinkfile (tempdev, 0)
go

--收缩日志文件
dbcc shrinkfile (templog, 0)
go