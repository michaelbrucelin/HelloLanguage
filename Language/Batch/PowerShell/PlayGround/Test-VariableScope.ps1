function test() {
    [string]$Script:logmsg = ''
    [string]$loginfo = ''

    # 打印消息并记录日志
    function printlog() {
        Param(
            [ValidateSet('host', 'warning')]
            [string]$type = 'host',
            [Parameter(Mandatory = $True, Position = 1, ValueFromPipeLine = $true)]
            [Alias("String")]
            [String]$info
        )

        $Script:logmsg += "$(Get-Date)`t$info`r`n"

        if ($type -eq 'warning') {
            Write-Warning $info
        }
        else {
            Write-Host $info
        }
    }

    $loginfo = "hello world 1001."
    printlog -type host -info $loginfo
    $loginfo = "hello world 1002."
    printlog -type host -info $loginfo
    $loginfo = "hello world 1003."
    printlog -type host -info $loginfo
    $loginfo = "hello world 1004."
    printlog -type host -info $loginfo

    $logmsg
}