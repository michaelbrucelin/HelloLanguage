select top 5
    (total_logical_reads/execution_count) as avg_logical_reads,
    (total_logical_writes/execution_count) as avg_logical_writes,
    (total_physical_reads/execution_count) as avg_physical_reads,
    Execution_count, statement_start_offset, p.query_plan, q.text
from sys.dm_exec_query_stats
cross apply sys.dm_exec_query_plan(plan_handle) p
cross apply sys.dm_exec_sql_text(plan_handle) as q
order by (total_logical_reads + total_logical_writes)/execution_count Desc