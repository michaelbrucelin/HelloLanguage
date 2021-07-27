function MyGet-IPAddress
{
    Get-CimInstance -ClassName Win32_NetworkAdapterConfiguration |
    Where-Object { $_.IPEnabled -eq $true } |
    # add two new properties for IPv4 and IPv6 at the end
    Select-Object -Property Description, MacAddress, IPAddress, IPAddressV4, IPAddressV6 |
    ForEach-Object {
        # add IP addresses that match the filter to the new properties
        $_.IPAddressV4 = $_.IPAddress | Where-Object { $_ -like '*.*.*.*' }
        $_.IPAddressV6 = $_.IPAddress | Where-Object { $_ -notlike '*.*.*.*' }
        # return the object
        $_
    } |
    # remove the property that holds all IP addresses
    Select-Object -Property Description, MacAddress, IPAddressV4, IPAddressV6
}