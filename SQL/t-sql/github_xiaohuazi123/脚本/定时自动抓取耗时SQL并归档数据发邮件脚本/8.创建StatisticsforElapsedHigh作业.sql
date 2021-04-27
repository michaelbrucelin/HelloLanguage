USE [msdb]
GO
/****** ����:  Job [��ʱͳ��[ElapsedHigh]������]    �ű�����: 07/29/2014 15:44:57 ******/
BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
/****** ����:  JobCategory [[Uncategorized (Local)]]]    �ű�����: 07/29/2014 15:44:57 ******/
IF NOT EXISTS (SELECT name FROM msdb.dbo.syscategories WHERE name=N'[Uncategorized (Local)]' AND category_class=1)
BEGIN
EXEC @ReturnCode = msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'[Uncategorized (Local)]'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

END

DECLARE @jobId BINARY(16)
EXEC @ReturnCode =  msdb.dbo.sp_add_job @job_name=N'StatisticsforElapsedHigh', 
        @enabled=1, 
        @notify_level_eventlog=0, 
        @notify_level_email=0, 
        @notify_level_netsend=0, 
        @notify_level_page=0, 
        @delete_level=0, 
        @description=N'ͳ��[MonitorElapsedHighSQL]�����[ElapsedHigh]���������', 
        @category_name=N'[Uncategorized (Local)]', 
        @owner_login_name=N'sa', @job_id = @jobId OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
/****** ����:  Step [execute usp_checkElapsedHighSQL script]    �ű�����: 07/29/2014 15:44:58 ******/
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep  @job_name=N'StatisticsforElapsedHigh', @step_name=N'execute usp_StatisticsTask script', 
        @step_id=1, 
        @cmdexec_success_code=0, 
        @on_success_action=1, 
        @on_success_step_id=0, 
        @on_fail_action=2, 
        @on_fail_step_id=0, 
        @retry_attempts=0, 
        @retry_interval=0, 
        @os_run_priority=0, @subsystem=N'TSQL', 
        @command=N'exec [dbo].[usp_StatisticsTask] ',  --���ô洢����
        @database_name=N'MonitorElapsedHighSQL', 
        @flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_name=N'StatisticsforElapsedHigh', @name=N'Scheduleusp_StatisticsTask', 
    @enabled=1, 
        @freq_type=4, 
        @freq_interval=1, 
        @freq_subday_type=1, 
        @freq_subday_interval=1, 
        @freq_relative_interval=0, 
        @freq_recurrence_factor=0, 
        @active_start_date=20110224, 
        @active_end_date=99991231, 
        @active_start_time=235000, 
        @active_end_time=235959
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_name=N'StatisticsforElapsedHigh', @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave: