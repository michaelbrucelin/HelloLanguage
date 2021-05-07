-- 测试数据
CREATE TABLE #temp([color] varchar(5), [size] varchar(5),[AQty] varchar(10),[BQty] varchar(10),[CQty] varchar(10),[DQty] varchar(10));
INSERT INTO #temp([color], [size], [AQty], [BQty],[CQty],[DQty])
VALUES   ('A1', 'L','1','2','3','4')
       , ('A1', 'M','1','2','3','4')
       , ('A1', 'S','1','2','3','4')
       , ('A1', 'XL','1','2','3','4')
       , ('B1', 'L','1','2','3','4')
       , ('B1', 'M','1','2','3','4')
       , ('B1', 'S','1','2','3','4')
       , ('B1', 'XL','1','2','3','4')
       , ('B1', 'XXL','1','2','3','4')
       , ('C1', 'L','1','2','3','4')
       , ('C1', 'S','1','2','3','4')

-- 示例代码1
select color, col as total, [L], [M], [S], [XL], [XXL]
from(
    select color, size, col, [value]
    from #temp
    cross apply (
    select 'AQty', cast(AQty as varchar(10)) union all
    select 'BQty', cast(BQty as varchar(10)) union all
    select 'CQty', cast(CQty as varchar(10)) union all
    select 'DQty', cast(DQty as varchar(10)) 
    ) t(col, [value])
) dt
pivot(
    max(value) for size in ([L], [M], [S], [XL], [XXL])
) pt
order by color, total

-- 示例代码2
declare @cols as varchar(max), @sql varchar(max)
select @cols = STRING_AGG(col, ', ') from (
    select distinct QUOTENAME(size) as col from #temp
) as t

set @sql = '
select color, col as total, ' + @cols + '
from(
    select color, size, col, [value]
    from #temp
    cross apply (
    select ''AQty'', cast(AQty as varchar(10)) union all
    select ''BQty'', cast(BQty as varchar(10)) union all
    select ''CQty'', cast(CQty as varchar(10)) union all
    select ''DQty'', cast(DQty as varchar(10)) 
    ) t(col, [value])
) dt
pivot(
    max(value) for size in (' + @cols + ')
) pt
order by color, total
'
exec(@sql)
