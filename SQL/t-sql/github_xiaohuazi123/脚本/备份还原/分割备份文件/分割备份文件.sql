
-- =============================================
-- Create date: <2014/4/18>
-- Description: �ָ���ļ����ֿ���������TO DISK�������ļ��ͻ�ֿ����
-- =============================================



DECLARE @CurrentTime VARCHAR(50), @FileName VARCHAR(200),@FileName2 VARCHAR(200)
SET @CurrentTime = REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, GETDATE(), 120 ),'-','_'),' ','_'),':','')

        
--(Temp2 ���ݿ���������)
SET @FileName = 'D:\Temp2_FullBackup_Partial1_' + @CurrentTime+'.bak'
SET @FileName2 = 'D:\Temp2_FullBackup_Partial2_' + @CurrentTime+'.bak'

BACKUP DATABASE [Temp2]
TO 
DISK=@FileName,
DISK=@FileName2
WITH FORMAT 


