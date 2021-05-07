-- xml连接字符串

declare @x as xml ='<root>
    <n1>hello world</n1>
    <n2>A0001</n2>
    <n2>A0002</n2>
    <n2>A0003</n2>
    <n2>A0004</n2>
</root>'

-- 1. text()的结果会把多个值直接连在一起
-- hello world  |  A0001A0002A0003A0004
select @x.value('(/root/n1/text())[1]', 'varchar(255)') as n1,
       @x.query('/root/n2/text()') as n2

-- 2. data()的结果也会把多个值连在一起，并且以空格连接，美中不足是不能自定义连接符
-- hello world  |  A0001 A0002 A0003 A0004
select @x.value('(/root/n1/text())[1]', 'nvarchar(255)') as n1,
       @x.query('data(/root/n2)').value('.', 'nvarchar(max)') as n2;

-- 3. 使用data()将结果连接在一起，然后将空格替换为指定的分隔符，如果xml值中含有空格，这个方法就错了
-- hello world  |  A0001,A0002,A0003,A0004
select @x.value('(/root/n1/text())[1]','nvarchar(255)') as n1,
       REPLACE(@x.query('data(/root/n2)').value('.','nvarchar(max)'), ' ', ',') as n2;

-- 4. 使用xquery指定分隔符将多个值连接在一起, 但是截取字符串的位置方法不通用
-- hello world  |  A0001,A0002,A0003,A0004
select @x.value('(/root/n1/text())[1]','nvarchar(255)') as n1,
       @x.query('for $n2 in /root/n2/text()
                 return <x>{concat(",",$n2)}</x>').value('substring(.,2,1000)', 'nvarchar(max)') as n2;

-- 5. 使用xquery指定分隔符将多个值连接在一起，通用方法
-- hello world  |  A0001,A0002,A0003,A0004
select @x.value('(/root/n1/text())[1]','nvarchar(255)') as n1,
       STUFF(@x.query('for $n2 in /root/n2/text()
                       return <x>{concat(",",$n2)}</x>').value('.','nvarchar(max)'), 1, 1, '') as n2;

-- 6. 当然也可以使用cross apply展开，然后使用for xml path或者STRING_AGG()拼接回去，但是代码不优雅
-- hello world  |  A0001,A0002,A0003,A0004
;with c0(n1, n2, n2order) as(
    select tbn1.c.value('(.)[1]', 'varchar(64)'),
           tbn2.c.value('(.)[1]', 'varchar(255)'),
           ROW_NUMBER() over (order by tbn2.c asc)
    from @x.nodes('root/n1') as tbn1(c)
    cross apply @x.nodes('root/n2') tbn2(c)
)
select distinct o.n1, node.n2
from c0 as o
cross apply(select STUFF((select ',' + n2 from c0 as i where i.n1 = o.n1
                          order by n2order for xml path(''), type
                         ).value('.', 'varchar(max)'),
                        1, 1, '')
) as node(n2);
