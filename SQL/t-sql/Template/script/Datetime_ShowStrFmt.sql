-- 查看日期时间转字符串格式

declare @i int
declare @it table(id int, datestr varchar(100), datedate datetime)
set @i = 0
while @i <= 1000
begin
    begin try
        insert into @it
    select @i, CONVERT(varchar(100), GETDATE(), @i), GETDATE()
        set @i = @i + 1
    end try
    begin catch
        --insert into @it select @i,'no','1900-01-01'
        set @i = @i + 1
        continue
    end catch
end

select * from @it order by datestr
