declare @tabname varchar(150)
declare @info int
set @info=1
declare cur_temp cursor for select name
from dbo.sysobjects
where xtype='V' and name like '%BSTemp%'
open cur_temp
fetch next from cur_temp into @tabname
while @@fetch_status = 0
begin
    exec('drop view '+@tabname)
    if @@error<> 0 
    begin
        set @info=3
        goto  end_
    end
    fetch next from cur_temp into @tabname
end
end_:
close cur_temp
deallocate cur_temp
select @info
return