

-- =============================================
-- Create date: <2014/4/18>
-- Description: --��־�ļ����޸�
-- =============================================



--����һ
--REBUILD�ؽ�
ALTER DATABASE test SET EMERGENCY
ALTER DATABASE test REBUILD LOG ON
(NAME='test_LOG',FILENAME='D:\TEMP\test_LOG.LDF')
ALTER DATABASE test SET MULTI_USER



--������
--�Ƽ��������ַ����������ݿ��Ϊ��ģʽ���ض���־�����ٸ�Ϊ����ģʽ
USE [master]
GO
ALTER DATABASE [test] SET RECOVERY SIMPLE WITH NO_WAIT
GO


USE [master]
GO
ALTER DATABASE [test] SET RECOVERY FULL WITH NO_WAIT
GO
