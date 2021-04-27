
-- =============================================
-- Create date: <2014/4/18>
-- Description: 
  -- ���ܣ���������������ɾ�����񡢸ĸ߰�ȫͬ��ģʽ���ĸ������첽ģʽ
  -- ִ�У� ������ִ��
-- =============================================


-- ��������
DECLARE
	@sql AS	NVARCHAR(4000),
    @dbname  AS NVARCHAR(2000),
	@dbnamePrefix AS NVARCHAR(100);

-- ��ʼ����
SET @dbnamePrefix=''
    
-- �����α�
-- �б��������ݿ�
DECLARE dbn CURSOR LOCAL FOR
SELECT name FROM master..sysdatabases WHERE name not in('master','tempdb','model','msdb')
AND [Name] LIKE @dbnamePrefix+'%'
ORDER BY name
    
OPEN dbn;

-- ȡ��һ����¼
FETCH NEXT FROM dbn INTO @dbname;

WHILE @@FETCH_STATUS=0
BEGIN
    -- ����
    SET @sql = 'USE master;'
--�߰�ȫ��ͬ��ģʽ			 
--			 + 'ALTER DATABASE ' + @dbname + ' SET PARTNER SAFETY FULL;'	
--�����ܣ��첽ģʽ			 
--			 + 'ALTER DATABASE ' + @dbname + ' SET PARTNER SAFETY OFF;'
--��������
--			 + 'ALTER DATABASE ' + @dbname + ' SET PARTNER FAILOVER;'
--ɾ������
			 + 'ALTER DATABASE ' + @dbname + ' SET PARTNER OFF;'	

	print (@sql)	
    
    -- ȡ��һ����¼
    FETCH NEXT FROM dbn INTO @dbname;
END

-- �ر��α�
CLOSE dbn;

-- �ͷ��α�
DEALLOCATE dbn;