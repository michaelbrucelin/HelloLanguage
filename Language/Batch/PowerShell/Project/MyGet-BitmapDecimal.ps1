<#
    计算位图的十进制权限值。
    MyGet-BitmapDecimal -inputDec 23
    > 0,1,2,4
    MyGet-BitmapDecimal -inputDec 535822336
    > 20,21,22,23,24,25,26,27,28
#>
function MyGet-BitmapDecimal() {
    param(
        [int64]$inputDec
    )

    $inputBinStr = [System.Convert]::ToString($inputDec, 2)
    $inputArray = $inputBinStr.ToCharArray()
    [System.Array]::Reverse($inputArray)

    $j = $inputArray.Count
    for ($i = 0; $i -lt $j; $i++) {
        if ($inputArray[$i] -eq '1') {
            $result += $i.ToString() + ','
        }
    }

    return $result.TrimEnd(',')
}
