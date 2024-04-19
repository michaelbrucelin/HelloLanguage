function MyClear-History() {
    Clear-History
    Clear-Content $(Get-PSReadlineOption).HistorySavePath
    [Microsoft.PowerShell.PSConsoleReadLine]::ClearHistory()
    Clear-Host
}
