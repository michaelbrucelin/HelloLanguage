function MySend-MagicPacket {
    Param (
        [Parameter(Mandatory = $true, HelpMessage = 'format: XX-XX-XX-XX-XX-XX')]
        [ValidatePattern('^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$')]
        [string] $Mac
    )

    $IP = [System.Net.Dns]::GetHostAddresses("255.255.255.255")
    $Address = [System.Net.IPAddress]::Parse($IP)
    $EndPoints = New-Object System.Net.IPEndPoint($Address, 50000)

    $Message = "FFFFFFFFFFFF"
    $Mac = $Mac.Replace('-', '')
    for ($i = 0; $i -le 16; $i++) {
        $Message += $Mac
    }

    $Socket = New-Object System.Net.Sockets.UDPClient
    $EncodedText = [Text.Encoding]::ASCII.GetBytes($Message)
    $SendMessage = $Socket.Send($EncodedText, $EncodedText.Length, $EndPoints)
    $Socket.Close()
}