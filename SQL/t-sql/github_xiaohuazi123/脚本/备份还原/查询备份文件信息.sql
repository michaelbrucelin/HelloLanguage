-- =============================================
-- Create date: <2014/4/18>
-- Description: ��ѯ�����ļ���Ϣ�������ļ�Ϊ��bak �� trn
-- =============================================


declare @DbBackFile nvarchar(4000)
set @DbBackFile=N'D:\�ļ�����\databases\testDB_log.trn' 

RESTORE LABELONLY
FROM DISK = @DbBackFile

RESTORE HEADERONLY
FROM DISK = @DbBackFile

RESTORE FILELISTONLY
FROM DISK = @DbBackFile
WITH FILE = 1