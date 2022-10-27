<#
    .SYNOPSIS
    Domain name WhoIs

    .DESCRIPTION
    Performs a domain name lookup and returns information such as
    domain availability (creation and expiration date),
    domain ownership, name servers, etc.

    .PARAMETER domain
    Specifies the domain name (enter the domain name without http:// and www (e.g. power-shell.com))

    .EXAMPLE
    WhoIs -domain power-shell.com 
    whois power-shell.com

    .NOTES
    File Name: whois.ps1
    Author: Nikolay Petkov
    Blog: http://power-shell.com
    Last Edit: 12/20/2014
    Made by: KornKolio (https://gallery.technet.microsoft.com/WHOIS-PowerShell-Function-ed69fde6)
    Add it to your $profile, line: . PATH\whois.ps1
    Or dot-source it: . PATH\whois.ps1
    You may need to Set-ExecutionPolicy

    .LINK
    http://power-shell.com
#>
# 链接：https://gist.github.com/DarthJahus/b4eeef67b77da99d500eab90dd4d87c0
# 其实就是调用了一个web services
Function WhoIs {
    param (
        [
        Parameter(
            Mandatory = $True,
            HelpMessage = 'Please enter domain name (e.g. microsoft.com)'
        )
        ]
        [string]$domain
    )
    Write-Host "Connecting to Web Services URL..." -ForegroundColor Green
    try {
        # Retrieve the data from web service WSDL
        If ($whois = New-WebServiceProxy -uri "http://www.webservicex.net/whois.asmx?WSDL") {
            Write-Host "Ok" -ForegroundColor Green
        }
        else {
            Write-Host "Error" -ForegroundColor Red
        }
        Write-Host "Gathering $domain data..." -ForegroundColor Green
        # Return the data
        (
			($whois.getwhois("=$domain")).Split("<<<")[0]
        )
    }
    catch {
        Write-Host "Please enter valid domain name (e.g. microsoft.com)." -ForegroundColor Red
    }
}
# end function WhoIs
