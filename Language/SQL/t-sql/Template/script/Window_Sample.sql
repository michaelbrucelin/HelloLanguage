-- 处理连续的数据
-- 如果后一条数据与前一条数据的时间差小于等于2min，则合并为一条数据

/* 原始数据
id  start_time  end_time
1   10:00:00    10:34:00
2   10:38:00    10:52:00
3   10:53:00    11:23:00
4   11:24:00    11:56:00
5   14:20:00    14:40:00
6   14:41:00    14:59:00
7   15:30:00    15:40:00
*/

/* 预期结果
id  start_time  end_time
1   10:00:00    10:34:00
2   10:38:00    11:56:00
5   14:20:00    14:59:00
7   15:30:00    15:40:00
*/

-- 测试数据
create table #temp(id int identity(1,1), start_time time, end_time time)
insert into #temp(start_time, end_time)
values  ('10:00:00', '10:34:00')
      , ('10:38:00', '10:52:00')
      , ('10:53:00', '11:23:00')
      , ('11:24:00', '11:56:00')
      , ('14:20:00', '14:40:00')
      , ('14:41:00', '14:59:00')
      , ('15:30:00', '15:40:00')

-- 解决方案1，使用window function
;with c0 as(
select *, LAG(end_time,1,'00:00:00') over (order by id) as lag_time
from #temp
), c1 as(
select *, case when DATEDIFF(MI, lag_time, start_time) <= 2 then 1 else -0 end as gflag
from c0
), c2 as(
select *, SUM(case when gflag=0 then 1 else 0 end) over(order by id) as gid
from c1
)
select MIN(id) as id, MIN(start_time) as start_time, MAX(end_time) as end_time
from c2
group by gid

-- 解决方案2，使用cte recursion
;with rcte as(
    -- anchor member
    select *, start_time as grp_start from #temp where id = 1
    union all
    -- recursive member
    select t.id, t.start_time, t.end_time
           , case when DATEDIFF(SECOND, r.end_time, t.start_time) <= 120
                      then r.grp_start
                  else t.start_time
             end as grp_start
    from #temp as t
    inner join rcte as r on t.id = r.id + 1
)
select MIN(id) as id, grp_start as start_time, MAX(end_time) as end_time
from rcte
group by grp_start
