declare @strqry varchar(1000)
declare @temptable varchar(200)
declare @temtype varchar(200)

DECLARE Droptemptable CURSOR FOR 
SELECT name, xtype
FROM dbo.sysobjects
where name like 'BSTemp%'

OPEN Droptemptable

FETCH NEXT FROM Droptemptable INTO @temptable,@temtype
WHILE @@FETCH_STATUS = 0
BEGIN
    if @temtype='U'
    begin
        SET @strqry=' DROP TABLE '+@temptable
        exec(@strqry)
    end


    FETCH NEXT FROM Droptemptable   INTO @temptable,@temtype
END

CLOSE Droptemptable
DEALLOCATE Droptemptable