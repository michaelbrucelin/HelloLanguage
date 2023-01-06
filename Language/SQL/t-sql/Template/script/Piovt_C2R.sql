-- 数据透视，列转行
-- unpivot是一种通过聚合和旋转把数据列转换成数据行的技术。unpivot需要确定3个要素：要在行（分组元素）中看到的元素，要在列（扩展元素）中看到的元素，要在数据部分（聚合元素）看到的元素。

-- 测试数据
create table #temp([name] varchar(16), [period] varchar(16), [数学] int, [语文] int, [音乐] int)

insert into #temp([name], [period], [数学], [语文], [音乐])
values   ('天雄星',   '第一学期', 90,  60,  80)
       , ('贝多芬',   '第一学期', 60,  85,  98)
       , ('大仲马',   '第一学期', 55,  95,  80)
       , ('爱因斯坦', '第一学期', 98,  70,  80)
       , ('天雄星',   '第二学期', 95,  75,  85)
       , ('贝多芬',   '第二学期', 75,  90,  100)
       , ('大仲马',   '第二学期', 65,  100, 85)
       , ('爱因斯坦', '第二学期', 100, 85,  95)

-- 解决方案1
select * from #temp unpivot(分数 for 课程 in (数学, 语文, 音乐)) as unpt
--for前后是两个新生成的列（分数、课程）
--for后面的“课程”列的值是in中的选项，选项一定是源表中的某几列（数学,语文,音乐），这几列有相同的数据类型
--for前面的“分数”列中的值就是源表中in选项中那几列的值
--表的整体相当于
--    源表行数增长为起始行数的n倍，n为in中选项的数量
--    源表的列为原有列除去in中选项剩余的列，新增2列，即for前后两列
--    新增两列的值为原先两边交叉位置的值
--即
--    对源表中in选项几列分别查询，然后union all的结果集

-- 解决方案2
select [name], [period], 数学 as 分数, '数学' as 课程 from #temp
union all
select [name], [period], 语文 as 分数, '语文' as 课程 from #temp
union all
select [name], [period], 音乐 as 分数, '音乐' as 课程 from #temp

-- 解决方案3
select a.[name], a.[period], b.课程
       , case b.课程 when '数学' then a.数学 when '语文' then a.语文 when '音乐' then a.音乐 end as 分数
from #temp as a
cross join (values('数学'),('语文'),('音乐')) as b(课程)
