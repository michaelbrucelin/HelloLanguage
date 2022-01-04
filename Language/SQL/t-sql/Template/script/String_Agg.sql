-- 使用指定分隔符连接字符串

-- 测试数据
create table #temp(deptno int, ename varchar(32), empno int)
insert into #temp(deptno, ename, empno)
values   (10, 'CLARK', 1),   (10, 'KING', 6),  (10, 'MILLER', 7), (20, 'SMITH', 2)
       , (20, 'ADAMS', 5),   (20, 'FORD', 8),  (20, 'SCOTT', 11), (20, 'JONES', 12)
       , (30, 'ALLEN', 3),   (30, 'BLAKE', 4), (30, 'MARTIN', 9), (30, 'JAMES', 10)
       , (30, 'TURNER', 13), (30, 'WARD', 14)

-- select * from #temp
declare @sep as char(1) = ','

-- 1. SQL Server 2016+
select deptno
       , STRING_AGG(ename, @sep) within group(order by ename) as list
from #temp
group by deptno

-- 2. 使用for xml path()来实现
;with c0 as(
select distinct deptno from #temp
)
select deptno
       , (select ename+@sep as [text()]
          from #temp as a
          where a.deptno = c0.deptno
          order by ename
          for xml path('')) as list
from c0
order by deptno

-- 3. 使用cte递归来实现
;with c0(deptno, cnt, list, empno, [len]) as(
select deptno, COUNT(*) over(partition by deptno), CONVERT(varchar(32), ename), empno, 1 from #temp
union all
select c0.deptno, c0.cnt, CONVERT(varchar(32), c0.list+@sep+o.ename), o.empno, c0.[len]+1
from #temp as o
inner join c0
    on o.deptno = c0.deptno and o.empno > c0.empno
)
select deptno, list from c0 where [len] = cnt order by deptno

-- 4. 一种特殊的思路
declare @str0 as varchar(8000)
select @str0 = ISNULL(@str0+@sep, '')+[name] from sys.databases
select @str0 as list
/*原理：
select @str = col1 from table1 where ...
@str是查询出来的最后一条记录，真实的情况是，先查询出第一条，将第一条的结果复制给@str，然后查询第二条，将第二条复制给@str...
直到查询出最后一条，将最后一条的结果复制给@str
所以select @str += col1 from table1 where ...就变成了拼接字符串
*/
