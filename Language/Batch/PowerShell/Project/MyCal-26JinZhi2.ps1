<#
    网上下载的某人写的Excel列头与10进制转换的函数。
    Excel 的列号是采用“A”、“B”……“Z”、“AA”、“AB”……的方式编号。但是我们在自动化操作中，往往希望用数字作为列号。我们可以用PowerShell来实现Excel的列号和数字之间的互相转换。
    算法分析
        Excel 列号 -> 数字
            用 ASCII 编码对输入的字符串解码，得到一个数字型数组。
            用 26 进制对数组进行处理（逐位 *= 26，然后累加）。
        数字 -> Excel 列号
            用 26 进制对数字进行处理（不断地 /= 26，取余数），得到数字型数组。
            将数字型数组顺序颠倒。
            用 ASCII 编码对数字型数组编码，得到 Excel 风格的列号。
#>
function ConvertFrom-ExcelColumn ($column) {
    $result = 0
    $ids = [System.Text.Encoding]::ASCII.GetBytes($column) | foreach {
        $result = $result * 26 + $_ - 64
    }
    return $result
}

function ConvertTo-ExcelColumn ($number) {
    $ids = while ($number -gt 0) {
        ($number - 1) % 26 + 1 + 64
        $number = [math]::Truncate(($number - 1) / 26)
    }

    [array]::Reverse($ids)
    return [System.Text.Encoding]::ASCII.GetString([array]$ids)
}
