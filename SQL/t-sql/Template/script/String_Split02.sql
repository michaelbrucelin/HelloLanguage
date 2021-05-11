-- 按固定长度将字符串分割为数组
-- 推荐在程序中去解读数组，如果一定要在数据库中，推荐使用clr去实现

-- 测试数据
declare @str varchar(1024) = 'aaaabbbbccccddddee';

-- 1. 通过cte递归实现
declare @len as int = 4

;with c0(id, item, txt) as (
select 1, CONVERT(varchar(32), LEFT(@str, @len)), STUFF(@str, 1, @len, '')
UNION ALL
select id+1, CONVERT(varchar(32), LEFT(txt, @len)), STUFF(txt, 1, @len, '')
from c0
--where LEN(txt) >= @len
where LEN(txt) >= 1
)
select id, item from c0

-- 2. 利用t-sql集合思想拆分数组，ben-gan大神书中的方法
-- 可以使用生成数字序列的表值函数来替代master.dbo.spt_values
declare @len as int = 4

;with c0 as(
select @str as s
), c1 as(
select number as n from master.dbo.spt_values where type = 'P' and number > 0 and number%4 = 1
)
select SUBSTRING(c0.s, c1.n, @len) as item
       , ROW_NUMBER() over(order by c1.n) as pos
       , c0.s
from c0
inner join c1 on c1.n <= LEN(c0.s)
