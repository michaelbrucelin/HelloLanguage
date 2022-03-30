# 声明list数据类型
function global:MyNew-GenericList([type] $type)
{
    $base = [System.Collections.Generic.List``1]
    $list = $base.MakeGenericType(@($type))
    New-Object $list
}

# 声明dictionary数据类型
function global:MyNew-GenericDictionary([type] $keyType, [type] $valueType)
{
    $base = [System.Collections.Generic.Dictionary``2]
    $dic = $base.MakeGenericType(($keyType, $valueType))
    New-Object $dic
}