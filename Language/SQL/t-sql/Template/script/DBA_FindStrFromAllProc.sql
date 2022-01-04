-- 在整个数据库所有存储过程中查找某个字符串

-- 查询存储过程的定义的方法
-- As long as you're not in the master database, system stored procedures won't be returned.
select SPECIFIC_SCHEMA+'.'+SPECIFIC_NAME as ProcName, ROUTINE_DEFINITION
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_TYPE = 'PROCEDURE'

-- If for some reason you had non-system stored procedures in the master database,
-- you could use the query (this will filter out MOST system stored procedures):
select SPECIFIC_SCHEMA+'.'+SPECIFIC_NAME as ProcName, ROUTINE_DEFINITION
from [master].INFORMATION_SCHEMA.ROUTINES
where          ROUTINE_TYPE = 'PROCEDURE' 
      AND LEFT(ROUTINE_NAME, 3) NOT IN ('sp_', 'xp_', 'ms_')

-- 查找含有指定关键字的存储过程
;with c0 as(
select SPECIFIC_SCHEMA+'.'+SPECIFIC_NAME as ProcName, ROUTINE_DEFINITION
from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_TYPE = 'PROCEDURE'
)
select * from c0 where ROUTINE_DEFINITION like '%关键字%'

-- 同时在存储过程和函数定义中查找关键字，未验证
select a.[name], a.[xtype], b.[text]
from sysobjects as a
inner join syscomments as b on b.id=a.id
where b.[text] like '%关键字%'
