# 启动服务器前先递归启动依赖的服务
function MyStart-Service() {
    param(
        [string]$name
    )

    $dependents=Get-Service $name |
        Select-Object -ExpandProperty RequiredServices |
        Where-Object { $_.Status -eq "Stopped" } |
        Select-Object Name

    $dependents.ForEach{ MyStart-Service $_.Name }

    Start-Service -Name $name
}