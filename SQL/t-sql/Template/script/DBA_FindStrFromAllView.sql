-- 在整个数据库所有视图中查找某个字符串

-- 查询视图的定义的方法
select TABLE_SCHEMA+'.'+TABLE_NAME as ViewName, VIEW_DEFINITION
from INFORMATION_SCHEMA.VIEWS where TABLE_NAME = '[dbo].[vw_XXXX]'

select OBJECT_DEFINITION(OBJECT_ID('[dbo].[vw_XXXX]')) as ObjectDefinition

select definition, uses_ansi_nulls, uses_quoted_identifier, is_schema_bound
from sys.sql_modules
where object_id = OBJECT_ID('[dbo].[vw_XXXX]')

exec sp_helptext '[dbo].[vw_XXXX]'


-- 查找含有指定关键字的视图
;with c0 as(
select TABLE_SCHEMA+'.'+TABLE_NAME as ViewName, VIEW_DEFINITION
from INFORMATION_SCHEMA.VIEWS where TABLE_NAME = '[dbo].[vw_XXXX]'
)
select * from c0 where VIEW_DEFINITION like '%关键字%'
