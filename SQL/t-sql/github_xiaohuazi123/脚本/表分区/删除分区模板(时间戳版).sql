-- =============================================
-- Create date: <2014/4/18>
-- Description: ɾ����������ģ�壬��ʱ�����������ͳһʹ��UTCʱ��
-- =============================================



DECLARE @begin INT --��ʼֵ
DECLARE @end INT --����ֵ
DECLARE @add INT --�����ֶ�ֵ����
DECLARE @next_time DATETIME 
DECLARE @utc_time DATETIME
DECLARE @sql NVARCHAR(max)
SET @begin = 1588262400 --��д��ʼɾ��ʱ���-����5�·ݵ�ʱ�����1588262400=2020-05-01 00:00:00.000
SET @end = 1593532800 --��д������ʱ���-��������������7�·ݵ�ʱ���1593532800=2020-07-01 00:00:00.000
SET @add = 0 --��������
set @utc_time='1970-01-01'

DECLARE @FunValueStr NVARCHAR(MAX) 
WHILE (@begin<@end)
BEGIN
	-- ʱ�����
	set @next_time=dateadd(mm,1,dateadd(hh,8,dateadd(ss,@begin,@utc_time))) --һ����һ���������ó���һ���µ��·�ʱ��
	set @add=datediff(ss, @utc_time,dateadd(hh,-8,@next_time))-@begin  --�ó��·� ת�����ʱ���ֵ
	
	SET @FunValueStr = convert(NVARCHAR(50),(@begin+@add))   --����+��һ��������
	SET @sql = 'ALTER PARTITION FUNCTION [Fun_Archive_Id]() MERGE RANGE('+@FunValueStr+')'
	PRINT @sql
	PRINT ('GO')
	PRINT CHAR(13)
	SET @begin=@begin+@add
END

