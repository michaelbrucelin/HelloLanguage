-- t-sql进行组合汇总，具体见源数据和查询结果
-- 使用cte递归实现，同时支持排列和组合

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

--计算并输出结果
declare @i as int
select @i = COUNT(*) from #temp_source

;with c0(item, total, cnt, depth) as(
select item, total, cnt, 1 from #temp_source
), c1(item, total, cnt, depth) as(
select CONVERT(varchar(64), ','+item+',')
       , total, cnt, depth from c0
union all
select CONVERT(varchar(64), c1.item+c0.item+',')
       , c1.total+c0.total, c1.cnt+c0.cnt, c1.depth+1
from c1
inner join c0
    -- on c1.item not like '%,'+c0.item+',%'  --这个是排列的条件
    -- 下面是组合的条件，如果有同组合不同排列的数据，如ABC与ACB，那么至少有一项是逆序的，只保留正序的那一项即可
    on c0.item > [dbo].[temp_SplitMaxItem](c1.item, ',')
       and c1.depth < @i  --这个是结束递归的条件
)
select LEN(item)-LEN(REPLACE(item,',',''))-1 as itemcnt, dbo.fn_Trim(item, ',') as items
        , total, cnt, 1.0*total/cnt as [avg]
from c1
order by itemcnt, items


--当计算组合时，尽管下面函数一条语句就可以，但是直接写在语句中语法不过关
--cte递归中不允许使用group by、聚合函数等
USE [TempDatabase]
GO
/****** Object:  UserDefinedFunction [dbo].[temp_SplitMaxItem]    Script Date: 2021/4/9 14:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[temp_SplitMaxItem](@string [nvarchar](max), @separator [nchar](1))
RETURNS varchar(max)
AS
BEGIN
    declare @result as varchar(max)

    select @result = MAX(element) from dbo.fn_SplitCLR(@string, @separator)

    return @result
END