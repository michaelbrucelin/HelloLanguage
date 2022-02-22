function MySend-WOL {
    # 发送魔术包，实现局域网远程开机
    Param (
        [Parameter(Mandatory = $true, HelpMessage = 'format: XX-XX-XX-XX-XX-XX|XX:XX:XX:XX:XX:XX|XX.XX.XX.XX.XX.XX|XXXXXXXXXXXX')]
        [ValidatePattern('^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$')]
        [string] $Mac,
        [string]$HostOrIp = "255.255.255.255"
    )

    $Boardcast = [System.Net.Dns]::GetHostAddresses($HostOrIp)
    $Address = [System.Net.IPAddress]::Parse($Boardcast)
    $EndPoints = New-Object System.Net.IPEndPoint($Address, 50000)

    $Message = "FFFFFFFFFFFF"
    $Mac = (($Mac.Replace(":", "")).replace("-", "")).replace(".", "").replace(" ", "")
    for ($i = 0; $i -le 16; $i++) {
        $Message += $Mac
    }

    $Socket = New-Object System.Net.Sockets.UDPClient
    $EncodedText = [Text.Encoding]::ASCII.GetBytes($Message)
    $SendMessage = $Socket.Send($EncodedText, $EncodedText.Length, $EndPoints)
    $Socket.Close()
}