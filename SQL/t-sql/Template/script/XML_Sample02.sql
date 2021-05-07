-- xml遍历并更改节点的值

declare @xml xml
set @xml='<items>
    <item>AAA</item>
    <item>BBB</item>
    <item>CCC</item>
</items>'
select @xml

declare @flag as int = 1

while(@flag < 4)
begin
    declare @value varchar(10)
    set @value = @flag
    set @xml.modify('replace value of (/items/item[sql:variable("@flag")]/text())[1] with sql:variable("@value")')

    set @flag = @flag + 1
end

select @xml
