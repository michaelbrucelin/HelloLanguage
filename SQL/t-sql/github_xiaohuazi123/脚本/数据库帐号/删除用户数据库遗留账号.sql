

-- =============================================
-- Create date: <2015/4/18>
-- Description: ɾ���������ݿ���û������˺�
-- ���ܣ�
-- @dbsauser Ҫɾ�������ݿ��û���
-- =============================================




-- ��������
SET NOCOUNT ON

DECLARE @sql		NVARCHAR(4000)
DECLARE @dbTable	TABLE (dbname SYSNAME,dblog SYSNAME,bkdbname SYSNAME)

DECLARE @dbsauser	SYSNAME

DECLARE @dbname		SYSNAME
DECLARE @dblog		SYSNAME
DECLARE @bkdbname	SYSNAME
DECLARE @dbnamePrefix		NVARCHAR(8)


-- ��ʼ����
SET @dbsauser='AWMntDBUser'



-- �б��������ݿ�
declare tb cursor local for
select [name] from master..sysdatabases where [name] not in('master','tempdb','model','msdb')
ORDER BY [name]

-- ��ѯ���ݿ����û���
open tb
fetch next from tb into @dbname
while @@fetch_status=0
begin
	 SET @sql =	'USE ' + @dbname + ';'
			  + 'IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'''+@dbsauser+''')'
			  + ' DROP USER '+@dbsauser+';';
	 EXEC (@sql)

	fetch next from tb into @dbname
end
close tb
deallocate tb

