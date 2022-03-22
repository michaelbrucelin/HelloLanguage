/********************************
功能：获取表的空间分布情况  yCSoft 2005-07-13
**********************************/

if not exists (select *
from dbo.sysobjects
where id = object_id(N'[dbo].[tablespaceinfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
create table tablespaceinfo --创建结果存储表
(
    nameinfo varchar(50) ,
    rowsinfo int ,
    reserved varchar(20) ,
    datainfo varchar(20)  ,
    index_size varchar(20) ,
    unused varchar(20)
)

delete from tablespaceinfo
--清空数据表

declare @tablename varchar(255)
--表名称

declare @cmdsql varchar(500)

DECLARE Info_cursor CURSOR FOR 
select o.name
from dbo.sysobjects o
where OBJECTPROPERTY(o.id, N'IsTable') = 1
    and o.name not like N'#%%'
order by o.name

OPEN Info_cursor

FETCH NEXT FROM Info_cursor
INTO @tablename

WHILE @@FETCH_STATUS = 0
BEGIN

    if exists (select *
    from dbo.sysobjects
    where id = object_id(@tablename) and OBJECTPROPERTY(id, N'IsUserTable') = 1)
    execute sp_executesql 
        N'insert into tablespaceinfo  exec sp_spaceused @tbname',
        N'@tbname varchar(255)',
        @tbname = @tablename

    FETCH NEXT FROM Info_cursor INTO @tablename
END

CLOSE Info_cursor
DEALLOCATE Info_cursor
GO

--knowsky.com数据库信息
sp_spaceused @updateusage = 'TRUE'

--表信息
select *
from tablespaceinfo
order by cast(left(ltrim(rtrim(reserved)) , len(ltrim(rtrim(reserved)))-2) as int) desc
