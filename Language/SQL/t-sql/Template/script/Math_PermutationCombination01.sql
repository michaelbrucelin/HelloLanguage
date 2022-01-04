-- t-sql进行排列，具体见源数据和查询结果

declare @source varchar(25), @len int
set @source = 'ABCD'
set @len = LEN(@source)

;with c1 as(
select element as token
       , CONVERT(varchar(64), '.'+CONVERT(char(1),pos)+'.') as permutation
       , CONVERT(int, 1) as iteration
from dbo.fn_SplitByChunk(@source, 1, 1)
union all
select c1.token + t0.element as token
       , CONVERT(varchar(64), c1.permutation+CONVERT(char(1),t0.pos)+'.') as permutation
       , c1.iteration + 1 as iteration
from c1
inner join dbo.fn_SplitByChunk(@source, 1, 1) as t0
    on c1.permutation not like '%'+CONVERT(char(1),t0.pos)+'%'
       and c1.iteration < @len
)
select token, permutation, iteration
from c1
where iteration = @len
order by permutation