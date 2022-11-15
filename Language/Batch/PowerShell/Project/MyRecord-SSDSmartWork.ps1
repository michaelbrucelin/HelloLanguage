<#
    记录SSD每天的写入量及其他关键性SMART信息
    本想用powershell命令去做，用powershell命令获取HDD的SMART信息时，体验不错，但是获取PCIE转M.2的NVME SSD时，体验不好，这里直接使用CrystalDiskInfo来抓取数据
    参考：https://www.cyberdrain.com/monitoring-with-powershell-smart-status-via-crystaldiskinfo/
    注意：需要使用pwsh.exe(powershell v7.3.0)调用，不能使用powershell.exe(powershell v5.1.19041.1682)调用，powershell v5中调用，Get-Content的结果中中文乱码，暂时不知道应该怎样处理。
    调用：pwsh /PATH/TO/MyRecord-SSDSmartWork.ps1    PCIE 3.0
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
    # $DiskInfoRaw = Get-Content "$($Env:OneDrive)\文档\powershell\CrystalDiskInfo\DiskInfo.txt" | Select-String "-- S.M.A.R.T. ----------" -Context 0, 16
    # $diskinfo = $DiskInfoRaw -Split "`n" | Select-Object -Skip 2 | Out-String | ConvertFrom-Csv -Delimiter " " -Header "NOTUSED1", "NOTUSED2", "ID", "RawValue" | Select-Object ID, RawValue
    $DiskInfoRaw = Get-Content "$($Env:OneDrive)\文档\powershell\CrystalDiskInfo\DiskInfo.txt" | Select-String "^ \(02\) Samsung SSD 970 EVO Plus 1TB$" -Context 0, 34

    $LogLocation = "$($Env:OneDrive)\文档\powershell\log\SSDSmartRecord_work.csv"
    $TestlogLocation = Test-Path $LogLocation
    if (!$TestLogLocation) {
        New-Item $LogLocation -ItemType File -Force
        $RecordHeader = "记录时间,PowerOnHours,PowerOnCount,HostReads,HostWrites,Temperature,HealthStatus,01-严重警告标志,02-综合温度,03-可用备用空间,04-可用备用空间阈值,05-已用寿命百分比,06-读取单位计数,07-写入单位计数,08-主机读命令计数,09-主机写命令计数,0A-控制器忙状态时间,0B-启动-关闭循环次数,0C-通电时间(小时),0D-不安全关机计数,0E-媒体与数据完整性错误计数,0F-错误日志项数"
        $RecordHeader | Out-File $LogLocation -Append -Encoding unicode
    }

    $record = @()
    $summary = $DiskInfoRaw -split "`n" | Select-Object -Skip 9 -First 6 | ForEach-Object { $_.Trim().Replace(" : ", ":") } | Out-String | ConvertFrom-Csv -Delimiter ":" -Header "Key", "Value"
    $record += Get-Date -Format 'yyyy-MM-dd HH:mm:ss'
    $record += ($summary | Where-Object { $_.Key -eq "Power On Hours" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Power On Count" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Host Reads" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Host Writes" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Temperature" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Health Status" }).Value

    $smart = $DiskInfoRaw -split "`n" | Select-Object -Skip 20 | Out-String | ConvertFrom-Csv -Delimiter " " -Header "BLANK1", "BLANK2", "ID", "RawValues", "Attribute" |
                ForEach-Object { $_.ID + "-" + $_.Attribute, $_.RawValues } | Out-String | ConvertFrom-Csv -Delimiter " " -Header "Key", "Value"
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "01-严重警告标志" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "02-综合温度" }).Value - 273.15)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "03-可用备用空间" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "04-可用备用空间阈值" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "05-已用寿命百分比" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "06-读取单位计数" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "07-写入单位计数" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "08-主机读命令计数" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "09-主机写命令计数" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "0A-控制器忙状态时间" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "0B-启动-关闭循环次数" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "0C-通电时间(小时)" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "0D-不安全关机计数" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "0E-媒体与数据完整性错误计数" }).Value)
    $record += [int64]("0x" + ($smart | Where-Object { $_.Key -eq "0F-错误日志项数" }).Value)

    $record_str = $record -join ','
    $record_str | Out-File $LogLocation -Append -Encoding unicode

    # [int64]$CriticalWarnings = "0x" + ($diskinfo | Where-Object { $_.ID -eq "01" }).rawvalue
    # [int64]$CompositeTemp = "0x" + ($diskinfo | Where-Object { $_.ID -eq "02" }).rawvalue - 273.15
    # [int64]$AvailableSpare = "0x" + ($diskinfo | Where-Object { $_.ID -eq "03" }).rawvalue
    # [int64]$ControllerBusyTime = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0A" }).rawvalue
    # [int64]$PowerCycles = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0B" }).rawvalue
    # [int64]$PowerOnHours = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0C" }).rawvalue
    # [int64]$UnsafeShutdowns = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0D" }).rawvalue
    # [int64]$IntegrityErrors = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0E" }).rawvalue
    # [int64]$InformationLogEntries = "0x" + ($diskinfo | Where-Object { $_.ID -eq "0F" }).rawvalue
}

MyRecord-SSDSmart
