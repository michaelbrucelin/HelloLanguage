-- xml遍历读取

-- 利用cross apply可以遍历xml，将xml结果完整展开。就是使用“局部根节点”与其下面的子节点cross apply将数据展开。
-- 参考：
-- https://docs.microsoft.com/en-us/sql/t-sql/xml/nodes-method-xml-data-type?view=sql-server-ver15
-- https://stackoverflow.com/questions/22143566/loop-on-xml-in-sql-server
-- https://stackoverflow.com/questions/14712864/how-to-query-values-from-xml-nodes

-- 示例1
declare @x as xml ='<?xml version="1.0" encoding="ISO-8859-1"?>
<root>
    <html>
        <header>
            <h1>headerA</h1>
            <h2>headerB</h2>
        </header>
        <body>
            <div Unit="Unit 1">
                <p1>a1</p1>
                <p2>b1</p2>
            </div>
            <div Unit="Unit 2">
                <p1>a2</p1>
                <p2>b2</p2>
            </div>
            <div Unit="Unit 3">
                <p1>a3</p1>
                <p2>b3</p2>
            </div>
        </body>
    </html>
</root>'

select html.value('(header/h1)[1]', 'varchar(255)') as h1,
       html.value('(header/h2)[1]', 'varchar(255)') as h2,
       div.value('@Unit', 'varchar(255)') as unit,
       div.value('(p1)[1]', 'varchar(255)') as p1,
       div.value('(p2)[1]', 'varchar(255)') as p2
from @x.nodes('/root/html') as xmlt1(html)
cross apply html.nodes('body/div') as xmlt2(div)

/*
h1       |  h2       |  unit    |  p1  |  p2
headerA  |  headerB  |  Unit 1  |  a1  |  b1
headerA  |  headerB  |  Unit 2  |  a2  |  b2
headerA  |  headerB  |  Unit 3  |  a3  |  b3
*/

-- 示例2
create table #test(data xml);
insert into #test values('<?xml version="1.0" encoding="ISO-8859-1"?>
<root>
    <html>
        <header>
            <h1>headerA</h1>
            <h2>headerB</h2>
        </header>
        <body>
            <div Unit="Unit 1">
                <p1>a1</p1>
                <p2>b1</p2>
            </div>
            <div Unit="Unit 2">
                <p1>a2</p1>
                <p2>b2</p2>
            </div>
            <div Unit="Unit 3">
                <p1>a3</p1>
                <p2>b3</p2>
            </div>
        </body>
    </html>
</root>')

select data.value('(/root/html/header/h1)[1]', 'varchar(255)') as h1,
       data.value('(/root/html/header/h2)[1]', 'varchar(255)') as h2,
       div.value('@Unit', 'varchar(255)') as unit,
       div.value('(p1)[1]', 'varchar(255)') as p1,
       div.value('(p2)[1]', 'varchar(255)') as p2
from #test
cross apply data.nodes('/root/html/body/div') as xt(div)

/*
h1       |  h2       |  unit    |  p1  |  p2
headerA  |  headerB  |  Unit 1  |  a1  |  b1
headerA  |  headerB  |  Unit 2  |  a2  |  b2
headerA  |  headerB  |  Unit 3  |  a3  |  b3
*/
