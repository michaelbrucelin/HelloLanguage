-- 返回一个日历

declare @month as varchar(10) = '2008-08-08'
set @month = DATEADD(MM,DATEDIFF(MM,0,@month),0)

;with c0 as(
select CONVERT(varchar(10),DATEADD(DD,n,@month),23) as [date]
from [dbo].[GetNums](0, 30)
),c1 as(
select RIGHT(' '+CONVERT(varchar(2),DAY([date])),2) as [day],DATEPART(WEEK,[date]) as [week]
       , DATEPART(WEEKDAY,[date]) as [weekday]
from c0
where DATEDIFF(MONTH,[date],@month) = 0
)
select   ISNULL([1],'') as [SUN]
       , ISNULL([2],'') as [MON]
       , ISNULL([3],'') as [TUE]
       , ISNULL([4],'') as [WED]
       , ISNULL([5],'') as [THU]
       , ISNULL([6],'') as [FRI]
       , ISNULL([7],'') as [SAT]
from c1
pivot (MAX([day]) for [weekday] in ([1],[2],[3],[4],[5],[6],[7])) as ptb
