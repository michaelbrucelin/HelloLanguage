-- 查询sql server库中的所有对象

select * from sys.all_objects
-- 例如，查询所有函数
select * from sys.all_objects where type in ('FN','AF','FS','FT','IF','TF')

-- Here are the types:
-- AF = Aggregate function (CLR)
-- C = CHECK constraint
-- D = DEFAULT (constraint or stand-alone)
-- F = FOREIGN KEY constraint
-- PK = PRIMARY KEY constraint
-- P = SQL stored procedure
-- PC = Assembly (CLR) stored procedure
-- FN = SQL scalar-function
-- FS = Assembly (CLR) scalar function
-- FT = Assembly (CLR) table-valued function
-- R = Rule (old-style, stand-alone)
-- RF = Replication filter procedure
-- SN = Synonym
-- SQ = Service queue
-- TA = Assembly (CLR) trigger
-- TR = SQL trigger 
-- IF = SQL inlined table-valued function
-- TF = SQL table-valued function
-- U = Table (user-defined)
-- UQ = UNIQUE constraint
-- V = View
-- X = Extended stored procedure
-- IT = Internal table
