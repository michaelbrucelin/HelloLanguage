function MyResolve-ASNFromCymru() {
    param(
        [Parameter(Mandatory = $True, ValueFromPipeline = $True)]
        [String]$ip,
        [String]$DNSServer
    )

    $WHOIS = ".origin.asn.cymru.com"
    $ASNWHOIS = ".asn.cymru.com"

    if ($ip -notmatch "^(?:10|127|172\.(?:1[6-9]|2[0-9]|3[01])|192\.168)\..*") {
        # Don't waste a lookup on RFC1918 IPs
        $ipSplit = $ip.Split('.')
        $ipRev = $ipSplit[3] + '.' + $ipSplit[2] + '.' + $ipSplit[1] + '.' + $ipSplit[0]
        $ipASNRecord = Resolve-DnsName -Server $DNSServer -Type TXT -Name $ipRev$WHOIS -ErrorAction SilentlyContinue | Select-Object Strings
    }
    else {
        $ipASNRecord = $null
    }

    if ($ipASNRecord.Strings -AND $ipASNRecord.Strings.GetType().IsArray) {
        # Check for array;
        $ipASN = "AS" + $ipASNRecord.Strings[0].Split('|').Trim()[0]
        Write-Verbose "Object found $ipASN"
    }

    elseif ($ipASNRecord.Strings -AND $ipASNRecord.Strings.GetType().FullName -like "System.String") {
        # Check for string; normal case.
        $ipASN = "AS" + $ipASNRecord.Strings[0].Split('|').Trim()[0]
        Write-Verbose "String found $ipASN"
    }

    else {
        $ipASN = "-"
    }
}  # End MyResolve-ASN
