<#
    记录SSD每天的写入量及其他关键性SMART信息
    本想用powershell命令去做，用powershell命令获取HDD的SMART信息时，体验不错，但是获取PCIE转M.2的NVME SSD时，体验不好，这里直接使用CrystalDiskInfo来抓取数据
    参考：https://www.cyberdrain.com/monitoring-with-powershell-smart-status-via-crystaldiskinfo/
    注意：需要使用pwsh.exe(powershell v7.3.0)调用，不能使用powershell.exe(powershell v5.1.19041.1682)调用，powershell v5中调用，Get-Content的结果中中文乱码，暂时不知道应该怎样处理。
    调用：pwsh /PATH/TO/MyRecord-SSDSmartHome.ps1    SATA
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

    Remove-Item -Path "$($DownloadLocation)\DiskInfo*" -Filter "DiskInfo*.ini" -Force
    Remove-Item -Path "$($DownloadLocation)\DiskInfo*" -Filter "DiskInfo*.txt" -Force

    # We start CrystalDiskInfo with the COPYEXIT parameter. This just collects the SMART information in DiskInfo.txt
    Start-Process "$($Env:OneDrive)\文档\powershell\CrystalDiskInfo\DiskInfo64.exe" -ArgumentList "/CopyExit" -Wait
    # $DiskInfoRaw = Get-Content "$($Env:OneDrive)\文档\powershell\CrystalDiskInfo\DiskInfo.txt" | Select-String "-- S.M.A.R.T. ----------" -Context 0, 16
    # $diskinfo = $DiskInfoRaw -Split "`n" | Select-Object -Skip 2 | Out-String | ConvertFrom-Csv -Delimiter " " -Header "NOTUSED1", "NOTUSED2", "ID", "RawValue" | Select-Object ID, RawValue
    $DiskInfoRaw = Get-Content "$($Env:OneDrive)\文档\powershell\CrystalDiskInfo\DiskInfo.txt" | Select-String "^ \(01\) Samsung SSD 870 EVO 1TB$" -Context 0, 41

    $LogLocation = "$($Env:OneDrive)\文档\powershell\log\SSDSmartRecord_home.csv"
    $TestlogLocation = Test-Path $LogLocation
    if (!$TestLogLocation) {
        New-Item $LogLocation -ItemType File -Force
        $RecordHeader  = "记录时间,PowerOnHours,PowerOnCount,HostWrites,WearLevelCount,Temperature,HealthStatus,APMLevel,AAMLevel,05-重新分配扇区计数,09-通电时间(小时),0C-通电次数,B1-闪存磨损平均计数,B3-已使用的保留块计数(总计),B5-编程失败计数(总计),B6-擦除失败计数(总计),B7-运行中的坏块(总计),BB-无法校正错误计数,BE-气流温度,C3-ECC错误率,C7-CRC错误计数,EB-电源恢复计数(意外断电的次数),F1-LBA(逻辑区块地址)写入量总计,FC-由厂商定义"
        $RecordHeader  | Out-File $LogLocation -Append -Encoding unicode
        $RecordHeader2 = "记录时间,PowerOnHours,PowerOnCount,HostWrites,WearLevelCount,Temperature,HealthStatus,APMLevel,AAMLevel,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues,Cur_Wor_Thr_RawValues"
        $RecordHeader2 | Out-File $LogLocation -Append -Encoding unicode
    }

    $record = @()
    $summary = $DiskInfoRaw -split "`n" | Select-Object -Skip 14 -First 9 | ForEach-Object { $_.Trim().Replace(" : ", ":") } | Out-String | ConvertFrom-Csv -Delimiter ":" -Header "Key", "Value"
    $record += Get-Date -Format 'yyyy-MM-dd HH:mm:ss'
    $record += ($summary | Where-Object { $_.Key -eq "Power On Hours" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Power On Count" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Host Writes" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Wear Level Count" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Temperature" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "Health Status" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "APM Level" }).Value
    $record += ($summary | Where-Object { $_.Key -eq "AAM Level" }).Value

    $smart = $DiskInfoRaw -split "`n" | Select-Object -Skip 27 | Out-String | ConvertFrom-Csv -Delimiter " " -Header "BLANK1", "BLANK2", "ID", "Cur", "Wor", "Thr", "RawValues", "Attribute" |
                ForEach-Object { $_.ID + "-" + $_.Attribute, "'"+$_.Cur+"_"+$_.Wor+"_"+$_.Thr+"_"+[int64]("0x"+$_.RawValues) } | Out-String | ConvertFrom-Csv -Delimiter " " -Header "Key", "Value"
    $record += ($smart | Where-Object { $_.Key -eq "05-重新分配扇区计数" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "09-通电时间(小时)" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "0C-通电次数" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "B1-闪存磨损平均计数" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "B3-已使用的保留块计数(总计)" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "B5-编程失败计数(总计)" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "B6-擦除失败计数(总计)" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "B7-运行中的坏块(总计)" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "BB-无法校正错误计数" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "BE-气流温度" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "C3-ECC" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "C7-CRC" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "EB-电源恢复计数(意外断电的次数)" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "F1-LBA(逻辑区块地址)写入量总计" }).Value.Replace("_"," ")
    $record += ($smart | Where-Object { $_.Key -eq "FC-由厂商定义" }).Value.Replace("_"," ")

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
