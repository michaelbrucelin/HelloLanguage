function MyCal-26JinZhi() {
    param(
        [string]$inputDigit,
        [ValidateSet('DecTo26','26ToDec')]
        [string]$type
    )

    if($type -eq "DecTo26") {

        [int[]] $result = @()    #$result = ""
        $temp = [System.Convert]::ToInt32($inputDigit)

        do {
            if(($temp%26) -eq 0) {
                $result += 26    #$result = "26," + $result
                $temp = [System.Math]::Floor($temp/26) - 1
            }
            else {
                $result += $temp%26    #$result = ($temp%26).ToString() + "," + $result
                $temp = [System.Math]::Floor($temp/26)
            }
        }
        while($temp -gt 26)

        if($temp -ne 0) {
            #$result = $temp.ToString() + "," + $result
            $result += $temp
        }

        # 反转数组
        $result = $result[($result.Count-1)..0]
        #$result = $result.Trim(",")

        for($i=0; $i -lt $result.Count; $i++){
            #转成ASCII
            $result[$i] = $result[$i]+64
        }

        Write-Output ([char[]]$result -join '')
    }
    else {
        [int] $result = 0

        $temp = $inputDigit.ToCharArray()
        $temp = [int[]]$temp
        for($i=0; $i -lt $temp.Count; $i++){
            #转成ASCII
            $temp[$i] = $temp[$i]-64
        }
        
        for($i=0; $i -lt $temp.Count; $i++){
            $result = $result + $temp[$i]*[System.Math]::Pow(26,$temp.Count-1-$i)
        }
        Write-Output $result
    }
}