-- =============================================-- Create date: <2014/4/18>-- Description: ���ͺͽ�����Ӧʱ��-- =============================================BEGIN TRANDECLARE @value BIGINTDECLARE @value2 BIGINTSELECT  @value = CONVERT
(BIGINT, cntr_value)
FROM    sys.dm_os_performance_counters
WHERE   counter_name = 'Send/Receive Ack Time'
        AND instance_name = '***';

WAITFOR DELAY '00:00:01'

SELECT  @value2 = CONVERT(BIGINT, cntr_value)
FROM    sys.dm_os_performance_counters
WHERE   counter_name = 'Send/Receive Ack Time'
        AND instance_name = '***';

SELECT  ( @value2 - @value ) AS 'Send/Receive Ack Time'

COMMIT TRAN