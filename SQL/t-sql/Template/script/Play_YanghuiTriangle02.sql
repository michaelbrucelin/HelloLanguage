-- 输出杨辉三角

declare @SQL varchar(max)
declare @INSERT varchar(max)
declare @Update varchar(max)
declare @n int
set @n=10

set @SQL='SELECT'
set @INSERT=''
set @Update=''

select @SQL=@SQL+C,@INSERT=@INSERT+I 
from(select case when number<>@n+1 then ' NULL as ['+CAST(number as varchar)+'],' else ' 1 as ['+CAST(number as varchar)+'],' end as C,
            case when (@n+1-number)>0 then ' INSERT INTO #t(['+CAST(@n+1-number as varchar)+'],['+CAST(@n+1+number as varchar)+'],ID) VALUES(1,1,'+CAST(number+1 as varchar)+')' else '' end as I
     from master..spt_values where type='P' and number BETWEEN 1 and @n*2+1
) as a

select @Update=@Update+' Update #T set '
                      +(select '['+CAST(number as varchar)+']=(select top 1 (CAST(['+CAST(number-1 as varchar)+'] as int)+CAST(['+CAST(number+1 as varchar)+'] as int)) from #t a where a.ID=#t.ID-1),'+''
                        from master..spt_values a
                        where type='P' and number BETWEEN aa.Min and aa.Max 
                        order by number desc for xml path('')
                       )+' ID=ID where ID='+CAST(number as varchar)
from(select number+3 as number,
            case when (@n+1-number)>0 then @n+1-number else '' end as Min,
            case when (@n+1-number)>0 then @n+1+number else '' end as Max
     from master..spt_values
     where type='P' and number+3  BETWEEN 0 and @n+2-1
) as aa
set @SQL=@SQL+' 1 as ID INTO #t alter table #t alter column ['+CAST(@n+1 as varchar)+'] Int '+@INSERT+' '+@Update+' select * from #t order by ID'

exec(@SQL)
