<#
    记录SSD每天的写入量及其他关键性SMART信息
    本想用powershell命令去做，用powershell命令获取HDD的SMART信息时，体验不错，但是获取PCIE转M.2的NVME SSD时，体验不好，这里直接使用CrystalDiskInfo来抓取数据
    参考：https://www.cyberdrain.com/monitoring-with-powershell-smart-status-via-crystaldiskinfo/
#>
function MyRecord-SSDSmart() {

    # Replace the Download URL to where you've uploaded the ZIP file yourself. We will only download this file once.
    $DownloadURL = "https://free.nchc.org.tw/osdn//crystaldiskinfo/77877/CrystalDiskInfo8_17_8.zip"
    $DownloadLocation = "$($Env:OneDrive)\文档\powershell\CrystalDiskInfo"

    # Script:
    $TestDownloadLocation = Test-Path $DownloadLocation
    if (!$TestDownloadLocation) {
        New-Item $DownloadLocation -ItemType Directory -Force
        Invoke-WebRequest -Uri $DownloadURL -OutFile "$($DownloadLocation)\CrystalDiskInfo.zip"
        Expand-Archive "$($DownloadLocation)\CrystalDiskInfo.zip" -DestinationPath $DownloadLocation -Force
    }

    # We start CrystalDiskInfo with the COPYEXIT parameter. This just collects the SMART information in DiskInfo.txt
    Start-Process "$($Env:OneDrive)\文档\powershell\CrystalDiskInfo\DiskInfo64.exe" -ArgumentList "/CopyExit" -Wait
    $DiskInfoRaw = Get-Content "$($Env:OneDrive)\文档\powershell\CrystalDiskInfo\DiskInfo.txt" | Select-String "-- S.M.A.R.T. --------------------------------------------------------------" -Context 0, 16
    $diskinfo = $DiskInfoRaw -Split "`n" | Select-Object -Skip 2 | Out-String | ConvertFrom-Csv -Delimiter " " -Header "NOTUSED1", "NOTUSED2", "ID", "RawValue" | Select-Object ID, RawValue

    [int64]$CriticalWarnings = "0x" + ($diskinfo | Where-Object { $_.ID -eq "01" }).rawvalue
    [int64]$CompositeTemp = "0x" + ($diskinfo | Where-Object { $_.ID -eq "02" }).rawvalue - 273.15
    [int64]$AvailableSpare = "0x" + ($diskinfo | Where-Object { $_.ID -eq "03" }).rawvalue
    [int64]$ControllerBusyTime = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0A" }).rawvalue
    [int64]$PowerCycles = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0B" }).rawvalue
    [int64]$PowerOnHours = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0C" }).rawvalue
    [int64]$UnsafeShutdowns = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0D" }).rawvalue
    [int64]$IntegrityErrors = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0E" }).rawvalue
    [int64]$InformationLogEntries = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0F" }).rawvalue
}

MyRecord-SSDSmart
