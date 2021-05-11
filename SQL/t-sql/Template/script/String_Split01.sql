-- 按分隔符将字符串分割为数组
-- 推荐在程序中去解读数组，如果一定要在数据库中，推荐使用string_split()或clr去实现，方法2和3有被sql注入的风险

-- 测试数据
declare @str as nvarchar(max) = '北京,天津,河北,山西,内蒙古,辽宁,吉林,黑龙江,上海,江苏,浙江,安微,福建,江西,山东,河南,湖北,湖南,广东,广西,海南,重庆,四川,贵州,云南,西藏,陕西,甘肃,青海,宁夏,新疆,台湾,香港,澳门,国外'

-- 1. SQL Server 2016+
select ROW_NUMBER() over (order by (select null)) as id
       , [value] as item
from string_split(@str, ',')

-- 2. 通过动态sql语句实现，通过select+union all的方式形成派生表
set @str = 'select item = ''' + REPLACE(@str,',',''' union all select ''') + ''''
set @str = 'select item from (' + @str + ') as D'
exec(@str)

-- 3. 通过动态sql语句实现，通过行值构造函数的方式形成派生表
set @str = '(values (''' + REPLACE(@str,',',''' ),( ''') + ''')) as tb(item)'
set @str = 'select item from ' + @str
exec(@str)

-- 4. 通过cte递归实现
declare @sep as char(1) = ','

set @str = @str + @sep  -- 补一个结尾
;with c0(id, item, txt) as (
select 1, CONVERT(varchar(32), LEFT(@str, CHARINDEX(@sep, @str)-1)), STUFF(@str, 1, CHARINDEX(@sep, @str), '')
UNION ALL
select id+1, CONVERT(varchar(32), LEFT(txt, CHARINDEX(@sep, txt)-1)), STUFF(txt, 1, CHARINDEX(@sep, txt), '')
from c0
--where CHARINDEX(@sep, txt) > 0
where LEN(txt) > 0
)
select id, item from c0

-- 5. 利用t-sql集合思想拆分数组，ben-gan大神书中的方法
-- 可以使用生成数字序列的表值函数来替代master.dbo.spt_values
;with c0 as(
select @str as s
), c1 as(
select number as n from master.dbo.spt_values where type = 'P'
)
select SUBSTRING(c0.s, c1.n, CHARINDEX(',', c0.s+',', c1.n)-c1.n) as item,
       c1.n - LEN(REPLACE(LEFT(c0.s, c1.n), ',', '')) + 1 as pos1,
       ROW_NUMBER() over(order by c1.n) as pos2,
       c1.n, c0.s
from c0
inner join c1 on c1.n <= LEN(c0.s) and SUBSTRING(','+c0.s, c1.n, 1) = ','
