function MyGet-BitmapDecimal() {
    param(
        [int64]$inputDec
    )
 
    $inputBinStr=[System.Convert]::ToString($inputDec, 2)
    $inputArray=$inputBinStr.ToCharArray()
    [System.Array]::Reverse($inputArray)

    $j=$inputArray.Count
    for($i=0; $i -lt $j; $i++){
        if($inputArray[$i] -eq '1'){
            $result+=$i.ToString()+','
        }
    }

    return $result.TrimEnd(',')
}