select
    database_id,
    file_id,
    io_stall,
    io_pending_ms_ticks,
    scheduler_address
from sys.dm_io_virtual_file_stats(NULL, NULL)t1,
    sys.dm_io_pending_io_requests as t2
where t1.file_handle = t2.io_handle