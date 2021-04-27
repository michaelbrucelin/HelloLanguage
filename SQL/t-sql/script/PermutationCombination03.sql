-- t-sql进行组合汇总，具体见源数据和查询结果
-- 使用程序的思维去实现，循环，一层一层的添加（逼近）结果

--源数据
create table #temp_source(item varchar(32), total int, cnt int)
insert into #temp_source(item, total, cnt)
values   ('12', 8639,  29)
       , ('13', 18400, 72)
       , ('14', 23073, 66)
       , ('15', 13730, 76)
       , ('16', 39279, 135)
       , ('17', 28747, 118)
       , ('18', 13963, 42)
       , ('19', 15875, 91)

--select * from #temp_source

--计算
create table #temp_result_swap(items varchar(1024), total int, cnt int)
create table #temp_result(items varchar(1024), total int, cnt int)

--1. 写入初始化数据，即选择一项的数据
insert into #temp_result(items, total, cnt)
select ','+item+',', total, cnt from #temp_source

--2. 逐层增加数据
declare @i as int = 7  --添加的层数

while(@i > 0)
begin
    ;with c0 as(
    select item, total, cnt from #temp_source
    union all select '00', 0, 0
    ), c1 as(
    select items, total, cnt from #temp_result
    )
    insert into #temp_result_swap(items, total, cnt)
    select distinct
           (','+(select element+',' as [text()] from dbo.fn_SplitCLR(t1.items+','+t2.item, ',')
                 where element <> '00' order by element for xml path(''))) as items
           , t1.total+t2.total as total, t1.cnt+t2.cnt as cnt
    from c1 as t1 cross join c0 as t2
    where not t1.items like '%,'+t2.item+',%'

    truncate table #temp_result
    insert into #temp_result(items, total, cnt) select items, total, cnt from #temp_result_swap
    truncate table #temp_result_swap
    set @i = @i - 1
end

--结果
select LEN(items)-LEN(REPLACE(items,',',''))-1 as itemcnt, dbo.fn_Trim(items, ',') as items
        , total, cnt, 1.0*total/cnt as [avg]
from #temp_result
order by itemcnt, items

--drop table #temp_source, #temp_result_swap, #temp_result