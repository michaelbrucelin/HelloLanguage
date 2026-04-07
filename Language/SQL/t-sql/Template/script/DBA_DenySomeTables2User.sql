-- 取消某一用户的对某些表的访问权限
-- 如果需要一个用户对某张表只有查询权限，那么需要具有“选择(SELECT)”权限，不要操作“控制(CONTROL)”权限，其余的权限全部DENY掉。
declare @sql as nvarchar(max), @table as nvarchar(max), @user as nvarchar(max) = 'user4dev'

declare c cursor fast_forward for
select TABLE_SCHEMA+'.'+TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_NAME like '%salary%'
open c
fetch next from c into @table
while(@@fetch_status = 0)
begin
    set @sql = 'DENY INSERT, VIEW DEFINITION, VIEW CHANGE TRACKING, UNMASK, ALTER, UPDATE, TAKE OWNERSHIP, CONTROL, DELETE, SELECT, REFERENCES ON '+@table+' TO '+@user
    exec sp_executesql @sql

    fetch next from c into @table
end

close c
deallocate c

-- 验证
select USER_NAME(dp.grantee_principal_id) as [user_name], dp.state_desc as permission_state, dp.permission_name, OBJECT_SCHEMA_NAME(dp.major_id) as schema_name, OBJECT_NAME(dp.major_id) as table_name
from sys.database_permissions dp
where dp.class = 1 and OBJECTPROPERTY(dp.major_id, 'IsUserTable') = 1
order by table_name, user_name;
