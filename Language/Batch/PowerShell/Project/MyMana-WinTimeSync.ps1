# 切换域内主机是否自动同步时间，某些场景下需要改主机时间进行工作

<# 使用说明
1. 以管理员身份打开powershell
2. 将另一个txt中的脚本粘贴到powershell中
3. 
输入 MyMana-WinTimeSync -turn on  表示开始同步时间
输入 MyMana-WinTimeSync -turn off 表示禁止同步时间
#>

function MyMana-WinTimeSync() {
    param(
        [Parameter(Mandatory=$true)]
        [ValidateSet('on','off')]
        [string]$turn
    )

    if($turn -eq "off") {
        Set-Service W32Time -StartupType Disabled
        Stop-Service W32Time

        Write-Host "计算机已停止自动同步时间。"
    }
    else
    {
        Set-Service W32Time -StartupType Automatic
        Start-Service W32Time

        [int]$i=4
        while($i-- -gt 0){
            Write-Host $i
            Start-Sleep 1
        }
        w32tm /resync /rediscover

        Write-Host "计算机已恢复自动同步时间。"
    }
}