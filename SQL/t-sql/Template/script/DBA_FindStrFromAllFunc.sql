-- 在整个数据库所有函数中查找某个字符串

-- 查询函数的定义的方法
select OBJECT_DEFINITION(OBJECT_ID('[dbo].[func_XXXX]')) as ObjectDefinition

select QUOTENAME(b.[name])+'.'+QUOTENAME(a.[name]) as FuncName
       , OBJECT_DEFINITION(object_id) as ObjectDefinition
from sys.all_objects as a
inner join sys.schemas as b on b.schema_id = a.schema_id
where type in ('FN','AF','FS','FT','IF','TF')

-- 查找含有指定关键字的函数
;with c0 as(
select QUOTENAME(b.[name])+'.'+QUOTENAME(a.[name]) as FuncName
       , OBJECT_DEFINITION(object_id) as ObjectDefinition
from sys.all_objects as a
inner join sys.schemas as b on b.schema_id = a.schema_id
where type in ('FN','AF','FS','FT','IF','TF')
)
select * from c0 where ObjectDefinition like '%关键字%'
