-- 数据统计
-- 统计每天有几个人请假

--请假里有：请假类别，开始时间、结束时间
--要求统计：在有人请假的日期中按照日期分组，统计出各个请假类别的人数
--张三  |  事假  |  2014.07.21  |  2014.07.23
--李四  |  事假  |  2014.07.22  |  2014.07.24
--王武  |  病假  |  2014.07.23  |  2014.07.24

--时间(从请假开始结束时间得出) 事假 病假
-- 2014.07.21  |  1人  |  0人
-- 2014.07.22  |  2人  |  0人
-- 2014.07.23  |  2人  |  1人
-- 2014.07.24  |  1人  |  1人

-- 测试数据
create table #temp([name] varchar(16), holiname varchar(16), dateStart datetime, dateEnd datetime)
insert into #temp([name], holiname, dateStart, dateEnd)
values   ('张三', '事假', '2014.07.21', '2014.07.23')
       , ('李四', '事假', '2014.07.22', '2014.07.24')
       , ('王武', '病假', '2014.07.23', '2014.07.24')

--select * from #temp

-- 查询
declare @maxlong int
select @maxlong = MAX(DATEDIFF(DD,dateStart,dateEnd)) from #temp

;with c0 as(
select a.[name], a.holiname, a.dateStart + b.number as dateholi
      from #temp as a
inner join (select number from master..spt_values where type = 'P' and number <= @maxlong) b
    on DATEDIFF(DD,a.dateStart,a.dateEnd) >= b.number
)
select dateholi
       , SUM(case when holiname = '事假' then 1 else 0 end) as [事假]
       , SUM(case when holiname = '病假' then 1 else 0 end) as [病假]
from c0
group by dateholi
