-- t-sql进行排列，具体见源数据和查询结果

declare @source varchar(25), @len int
set @source = 'ABCD'
set @len = LEN(@source)

;with c0(n) as (
select 1 union all select 1 union all
select 1 union all select 1 union all
select 1 union all select 1 union all
select 1 union all select 1 union all
select 1 union all select 1
), c1(n) as (
select ROW_NUMBER() over (order by (select null)) from c0
), c2 as (
select CONVERT(varchar(32), SUBSTRING(@source, n, 1)) as token
       , CONVERT(varchar(64), '.'+CONVERT(char(1), n)+'.') as permutation
       , CONVERT(int, 1) as iteration
from c1 where n <= @len
union all
select CONVERT(varchar(32), token+SUBSTRING(@source, n, 1)) as token
       , CONVERT(varchar(64), permutation+CONVERT(char(1), n)+'.') as permutation
       , s.iteration + 1 as iteration
from c2 as s
inner join c1 as n
    on s.permutation not like '%.'+CONVERT(char(1), n)+'.%'
       and s.iteration < @len
       and n <= @len
)
select token, permutation, iteration
from c2
where iteration = @len
order by permutation