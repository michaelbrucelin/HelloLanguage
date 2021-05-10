-- 输出杨辉三角

declare @rows int=10,  --行数，根据实际来控制
        @x int=1, @y int=1, @sql nvarchar(max), @cols int

set @cols = @rows*2-1
;with cte_n as(
select r from (select row_number() over(order by a.object_id) as r from sys.all_columns a) as x where r<=@rows*2
), cte_1 as(
select n.r, b.data_lse
from cte_n as n
cross apply(select 'select '+stuff((select ',rtrim('+isnull(F1.v+'/(('+F2.v+')*'+F3.v+')','''''') +') as '+quotename(isnull(nullif((m.r +(@rows-n.r)+(m.r-1)*1)%@cols,0),@cols))
                                    from cte_n as m
                                    outer apply(select stuff((select '*'+rtrim(i.r) from cte_n i where i.r<=isnull((nullif(n.r-1,0)),  1) for xml path('')),1,1,'') as v) as F1
                                    outer apply(select stuff((select '*'+rtrim(i.r) from cte_n i where i.r<=isnull((nullif(m.r-1,0)),  1) for xml path('')),1,1,'') as v) as F2
                                    outer apply(select stuff((select '*'+rtrim(i.r) from cte_n i where i.r<=isnull((nullif(n.r-m.r,0)),1) for xml path('')),1,1,'') as v) as F3
                                    where m.r<@rows*2
                                    order by isnull(nullif((m.r +(@rows-n.r)+(m.r-1)*1)%@cols,0),@cols) asc
                                    for xml path('')
                                   ),1,1,'') as data_lse
           ) as b
where n.r <=@rows
)
select @sql=isnull(@sql+' union all ','')+data_lse from cte_1

exec(@sql)
