declare @v1 as ..., @v2 as ...
--定义一个游标
declare c cursor fast_forward for
select c1, c2
from [instance].[database].[schema].[table]

--打开游标
open c

--使用游标
fetch next from c into @v1, @v2

while(@@fetch_status = 0)
begin
    --代码部分
    fetch next from c into @v1, @v2
end

--关闭游标
close c

--释放游标
deallocate c
