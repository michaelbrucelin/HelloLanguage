# %SystemRoot%\system32\WindowsPowerShell\v1.0\powershell.exe -noexit -command "Set-ExecutionPolicy RemoteSigned -Force;. 'C:\Users\Q0089\OneDrive\文档\powershell\MyInit-PowerShell.ps1';Set-ExecutionPolicy Restricted -Force"
# %SystemRoot%\system32\WindowsPowerShell\v1.0\powershell.exe -noexit -command "Set-ExecutionPolicy RemoteSigned -Force;. 'D:\我的文档\OneDrive\文档\powershell\MyInit-PowerShell.ps1';Set-ExecutionPolicy Restricted -Force"

Set-Location \
$my1drive = 'C:\Users\Q0089\OneDrive\'  # $my1drive = 'D:\我的文档\OneDrive\'
$mypath = "$my1drive" + '文档\powershell\init\*'
$myps = "$my1drive" + '文档\powershell\noinit'

Get-ChildItem -Path $mypath -Include *.ps1 | ForEach-Object { $(. $_.FullName) }

Set-Alias MyStart-Vim vim.bat
Set-Alias vim vim.bat

# 其他配置
Import-Module ImportExcel
# Import-Module -Name Packagemanagement
# Import-Module -Name PowerShellGet

# 配置shell提示符，只显示当前目录，而不是完整目录
function prompt {
    $p = Split-Path -leaf -path (Get-Location)
    "PS $p> "
}

Set-Location D:
