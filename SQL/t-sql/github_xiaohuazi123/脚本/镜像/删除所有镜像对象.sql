
-- =============================================
-- Create date: <2016/9/18>
-- Description: ����������񻷾�
-- =============================================
USE master;
GO



--ɾ������˵�
select * from sys.endpoints
drop endpoint Endpoint_Mirroring

-- ɾ������֤��
select * from sys.certificates
drop certificate HOST_A_cert
drop certificate HOST_B_cert

--ɾ��master key
select * from sys.symmetric_keys
drop master key

--ɾ����½��
select * from sys.syslogins
drop login HOST_B_login

--ɾ����½�û�
select * from sys.sysusers
--drop user HOST_A_user
drop user HOST_B_user


--ɾ������
alter database <dbname> set partner off

--�޸����ݿ⻹ԭ���ͣ�norecovery һֱ�ȴ���ԭ��
restore database <dbname> with recovery










