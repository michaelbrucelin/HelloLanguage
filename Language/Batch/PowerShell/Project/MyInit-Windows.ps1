<#
    将此脚本的调用放到主机的“任务计划程序”中，当用户登录系统时调用，初始化一些操作系统的配置。
    调用：pwsh /PATH/TO/MyInit-Windows.ps1
#>

# 1. 禁用Adobe Acrobat的升级任务，否则已经做好的破解，可能会掉
$service = New-Object -ComObject("Schedule.Service")
$service.Connect($env:COMPUTERNAME)
$folder = $service.GetFolder("\")
$task = $folder.GetTask("Adobe Acrobat Update Task")
$task.Enabled = $False

# 2. 禁用Adobe Acrobat Update Service，否则已经做好的破解，可能会掉
# Get-Service AdobeARMservice
Stop-Service AdobeARMservice
Set-Service AdobeARMservice -StartupType Disabled
Stop-Service AdobeARMservice

# 3. 禁用AdobeUpdateService，否则已经做好的破解，可能会掉
# Get-Service AdobeUpdateService
Stop-Service AdobeUpdateService
Set-Service AdobeUpdateService -StartupType Disabled
Stop-Service AdobeUpdateService

# 4. 更新我的文档中的文件，用于阿里云盘自动同步用
$MyDocPath='C:\Users\Q1953\Documents\'
$DateStr=Get-Date -Format 'yyyyMMdd'
Get-ChildItem -Path $MyDocPath -Filter aaliyppj*.txt | ForEach-Object { Remove-Item $_.FullName }
Get-Date    > $MyDocPath'aaliyppj_date_'$DateStr'.txt'
Get-Service > $MyDocPath'aaliyppj_service_'$DateStr'.txt'
Get-Process > $MyDocPath'aaliyppj_process_'$DateStr'.txt'
