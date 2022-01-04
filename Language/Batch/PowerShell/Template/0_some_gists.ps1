# 脚本中从终端获取密码，并使用密码（Linux版powershell测试无效）
$pwdsecure = Read-Host "Enter a Password" -AsSecureString
[Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($pwdsecure))

# 清空powershell的history
function MyClear-History() {
    Clear-History
    Clear-Content $(Get-PSReadlineOption).HistorySavePath
    [Microsoft.PowerShell.PSConsoleReadLine]::ClearHistory()
    Clear-Host
}
