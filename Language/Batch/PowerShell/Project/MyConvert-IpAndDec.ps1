<#
    ip地址与十进制转换。
#>
function MyConvert-IpAndDec() {
    param(
        [string]$InputVal
    )

    $patternIp = "^(?=(\b|\D))(((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))(?=(\b|\D))$"
    $patternDec = "^[+-]?\d*$"

    if ([regex]::IsMatch($InputVal, $patternIp)) {
        $ipArr = $InputVal.Split('.')
        $ip1 = "00000000" + [System.Convert]::ToString($ipArr[0], 2)
        $ip1 = $ip1.Substring($ip1.Length - 8, 8)
        $ip2 = "00000000" + [System.Convert]::ToString($ipArr[1], 2)
        $ip2 = $ip2.Substring($ip2.Length - 8, 8)
        $ip3 = "00000000" + [System.Convert]::ToString($ipArr[2], 2)
        $ip3 = $ip3.Substring($ip3.Length - 8, 8)
        $ip4 = "00000000" + [System.Convert]::ToString($ipArr[3], 2)
        $ip4 = $ip4.Substring($ip4.Length - 8, 8)

        Write-Output ([System.Convert]::ToInt64($ip1 + $ip2 + $ip3 + $ip4, 2))
    }
    elseif ([regex]::IsMatch($InputVal, $patternDec)) {
        # 4294967295 is pow(2, 64)
        if ([int64]$InputVal -ge 0 -and [int64]$InputVal -le 4294967295) {
            $Hex = [System.Convert]::ToString($InputVal, 2)
            $Hex = "00000000000000000000000000000000" + $Hex
            [int]$i = $Hex.Length - 32
            $Hex1 = [System.Convert]::ToInt32($Hex.Substring($i, 8), 2)
            $Hex2 = [System.Convert]::ToInt32($Hex.Substring($i + 8, 8), 2)
            $Hex3 = [System.Convert]::ToInt32($Hex.Substring($i + 16, 8), 2)
            $Hex4 = [System.Convert]::ToInt32($Hex.Substring($i + 24, 8), 2)

            Write-Output ($Hex1.ToString() + "." + $Hex2.ToString() + "." + $Hex3.ToString() + "." + $Hex4.ToString())
        }
        else {
            Write-Output "Dec out of range."
        }
    }
    else {
        Write-Output "Invalid ip or Not a Dec."
    }
}
