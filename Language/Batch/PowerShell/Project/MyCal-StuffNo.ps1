<#
    员工号简单加密并转16进制
#>
function MyCal-StuffNo() {
    param(
        [string]$stuffNo,
        [ValidateSet('Dec2Hex','Hex2Dec')]
        [string]$type
    )
    if($type -eq "Dec2Hex"){
        $temp = [System.Convert]::ToInt32($stuffNo)
        Write-Output ($temp*21+820).ToString("X")
    }
    else{
        $temp = [System.Convert]::ToInt32($stuffNo,16)
        Write-Output (($temp-820)/21)
    }
}
