function MySend-Arp {
    param(
        [string]$DstIpAddress,
        [string]$SrcIpAddress = 0
    )

    $signature = @"
[DllImport("iphlpapi.dll", ExactSpelling=true)]
    public static extern int SendARP(
        uint DestIP, uint SrcIP, byte[] pMacAddr, ref int PhyAddrLen);
"@

    Add-Type -MemberDefinition $signature -Name Utils -Namespace Network

    try {
        $DstIp = [System.Net.IPAddress]::Parse($DstIpAddress)
        $DstIp = [System.BitConverter]::ToInt32($DstIp.GetAddressBytes(), 0)
    }
    catch {
        Write-Error "Could not convert $($DstIpAddress) to an IpAddress type.  Please verify your value is in the proper format and try again."
        break
    }


    if ($SrcIpAddress -ne 0) {
        try {
            $SrcIp = [System.Net.IPAddress]::Parse($SrcIpAddress)
            $SrcIp = [System.BitConverter]::ToInt32($SrcIp.GetAddressBytes(), 0)
        }
        catch {
            Write-Error "Could not convert $($SrcIpAddress) to an IpAddress type.  Please verify your value is in the proper format and try again."
            break
        }
    }
    else {
        $SrcIp = $SrcIpAddress
    }

    $New = New-Object PSObject -Property @{
        IpAddress       = $DstIpAddress
        PhysicalAddress = ''
        Description     = ''
        ArpSuccess      = $true
    } | Select-Object IpAddress, PhysicalAddress, ArpSuccess, Description

    $MacAddress = New-Object Byte[] 6
    $MacAddressLength = [uint32]$MacAddress.Length

    $Ret = [Network.Utils]::SendARP($DstIp, $SrcIp, $MacAddress, [ref]$MacAddressLength)

    if ($Ret -ne 0) {
        $New.Description = "An error was returned from SendArp() with error code:  $($Ret)"
        $New.ArpSuccess = $false
    }
    else {
        $MacFinal = @()
        foreach ($b in $MacAddress) {
            $MacFinal += $b.ToString('X2')
        }

        $New.PhysicalAddress = ($MacFinal -join ':')
    }

    Write-Output $New
}
