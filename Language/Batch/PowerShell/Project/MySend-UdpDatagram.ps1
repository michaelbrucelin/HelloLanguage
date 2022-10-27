<#
    发送udp报文。
#>
function MySend-UdpDatagram {
    Param (
        [string] $EndPoint,
        [int] $Port,
        [string] $Message
    )

    $IP = [System.Net.Dns]::GetHostAddresses($EndPoint)
    $Address = [System.Net.IPAddress]::Parse($IP)
    $EndPoints = New-Object System.Net.IPEndPoint($Address, $Port)

    $Socket = New-Object System.Net.Sockets.UDPClient
    $EncodedText = [Text.Encoding]::ASCII.GetBytes($Message)
    $SendMessage = $Socket.Send($EncodedText, $EncodedText.Length, $EndPoints)
    $Socket.Close()
}
