-- 在整个数据库所有视图中查找某个字符串

-- 查询视图的定义的方法
SELECT OBJECT_DEFINITION (OBJECT_ID('[dbo].[vw_XXXX]')) AS ObjectDefinition;

SELECT definition, uses_ansi_nulls, uses_quoted_identifier, is_schema_bound 
FROM sys.sql_modules 
WHERE object_id = OBJECT_ID('[dbo].[vw_XXXX]')

EXEC sp_helptext '[dbo].[vw_XXXX]'


-- 查找含有指定关键字的视图
;with c0 as(
select TABLE_SCHEMA+'.'+TABLE_NAME as ViewName,
       OBJECT_DEFINITION (OBJECT_ID(TABLE_SCHEMA+'.'+TABLE_NAME)) as ObjectDefinition
from INFORMATION_SCHEMA.TABLES
where TABLE_TYPE = 'VIEW'
)
select * from c0 where ObjectDefinition like '%关键字%'
