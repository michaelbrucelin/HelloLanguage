# 启动服务器前先递归启动依赖的服务
function MyStart-Service() {
    param(
        [string]$name
    )

    $dependents = Get-Service $name |
    Select-Object -ExpandProperty RequiredServices |
    Where-Object { $_.Status -eq "Stopped" } |
    Select-Object Name

    $dependents.ForEach{ MyStart-Service $_.Name }

    Start-Service -Name $name
}

# 启动Exchange 2010相关的服务
try {
    # 如果Test-ServiceHealth可以正确执行
    $SvrTiJian = Test-ServiceHealth
    $ExChSvrNotRunning = $SvrTiJian.ServicesNotRunning | Sort-Object | Get-Unique
    $ExChSvrNotRunning.ForEach{ MyStart-Service $_ }
}
catch {
    # 如果Test-ServiceHealth执行失败，执行下面的命令
    # 如果为了保险，也可以直接执行重启（Restart-Computer），不行，这样脚本一旦有bug可能会导致无限重启服务器
    MyStart-Service IISAdmin
    MyStart-Service MSExchangeAB
    MyStart-Service MSExchangeADTopology
    MyStart-Service MSExchangeEdgeSync
    MyStart-Service MSExchangeFBA
    MyStart-Service MSExchangeFDS
    MyStart-Service MSExchangeIS
    MyStart-Service MSExchangeMailboxAssistants
    MyStart-Service MSExchangeMailboxReplication
    MyStart-Service MSExchangeMailSubmission
    MyStart-Service MSExchangeProtectedServiceHost
    MyStart-Service MSExchangeRepl
    MyStart-Service MSExchangeRPC
    MyStart-Service MSExchangeSA
    MyStart-Service MSExchangeSearch
    MyStart-Service MSExchangeServiceHost
    MyStart-Service MSExchangeThrottling
    MyStart-Service MSExchangeTransport
    MyStart-Service MSExchangeTransportLogSearch
    MyStart-Service W3Svc
    MyStart-Service WinRM
}