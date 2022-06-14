Function MyGet-GeoIP {
    <#
.SYNOPSIS
    Display geographical location for a given IP address. Can also view your own ISP given address.
.DESCRIPTION
    Display geographical location for a given IP address. Can also view your own ISP given address. There is a possibility for this to fail if the web service being used is unavailable.
.PARAMETER Ip
    IP address to find country to origin
.PARAMETER ShowInternetIP
    Gets your internet IP address and country of origin
.PARAMETER Credential
    Use alternate credentials
.PARAMETER UseDefaultCredential
    Use default credentials
.NOTES
    Name: Get-GeoIP
    Author: Boe Prox
    DateCreated: 16Feb2011
.LINK
    http://www.webservicex.net/ws/default.aspx
.LINK
    http://boeprox.wordpress.com
.EXAMPLE
    Get-GeoIP -IP 192.168.1.1

Description
-----------
Returns the country of origin for the specified IP Address. In this case, United States

.EXAMPLE
    Get-GeoIP -ShowInternetIP

Description
-----------
Returns the Internet address from where this command was run.

#>
    [cmdletbinding(
        DefaultParameterSetName = 'Default',
        ConfirmImpact = 'low'
    )]
    Param(
        [Parameter(
            Mandatory = $False,
            Position = 0,
            ParameterSetName = '',
            ValueFromPipeline = $True)]
        [string]$Ip,
        [Parameter(
            Position = 1,
            Mandatory = $False,
            ParameterSetName = '')]
        [switch]$ShowInternetIP,
        [Parameter(
            Position = 2,
            Mandatory = $False,
            ParameterSetName = 'DefaultCred')]
        [switch]$UseDefaultCredental,
        [Parameter(
            Position = 3,
            Mandatory = $False,
            ParameterSetName = 'AltCred')]
        [System.Management.Automation.PSCredential]$Credential
    )
    Begin {
        $psBoundParameters.GetEnumerator() | % {
            Write-Verbose "Parameter: $_"
        }
        #Ensure that user is not using both -City and -ListCities parameters
        Write-Verbose "Verifying that both City and ListCities is not being used in same command."
        If ($PSBoundParameters.ContainsKey('ListCities') -AND $PSBoundParameters.ContainsKey('City')) {
            Write-Warning "You cannot use both -City and -ListCities in the same command!"
            Break
        }
        Switch ($PSCmdlet.ParameterSetName) {
            AltCred {
                Try {
                    #Make connection to known good geo ip service using DefaultCredentials
                    Write-Verbose "Create web proxy connection to geo ip service using Alternate Credentials"
                    $geoip = New-WebServiceProxy 'http://www.webservicex.net/geoipservice.asmx?WSDL' -Credential $credential
                }
                Catch {
                    Write-Warning "$($Error[0])"
                    Break
                }
            }
            DefaultCred {
                Try {
                    #Make connection to known good geo ip service using Alternate Credentials
                    Write-Verbose "Create web proxy connection to geo ip service using DefaultCredentials"
                    $geoip = New-WebServiceProxy 'http://www.webservicex.net/geoipservice.asmx?WSDL' -UseDefaultCredential
                }
                Catch {
                    Write-Warning "$($Error[0])"
                    Break
                }
            }
            Default {
                Try {
                    #Make connection to known good geo ip service
                    Write-Verbose "Create web proxy connection to geo ip service"
                    $geoip = New-WebServiceProxy 'http://www.webservicex.net/geoipservice.asmx?WSDL'
                }
                Catch {
                    Write-Warning "$($Error[0])"
                    Break
                }
            }
        }
    }
    Process {
        #Determine if we are only to list the cities for a given country or get the weather from a city
        If ($PSBoundParameters.ContainsKey('Ip')) {
            Try {
                #List all cities available to query for geo ip
                Write-Verbose "Retrieving location of IP: $($ip)"
                $geoip.GetGeoIP($ip)
                Break
            }
            Catch {
                Write-Warning "$($Error[0])"
                Break
            }
        }
        If ($PSBoundParameters.ContainsKey('ShowInternetIP')) {
            Try {
                #Get your Internet IP and geo location
                Write-Verbose "Retrieving internet IP and location"
                $geoip.GetGeoIPContext()
                Break
            }
            Catch {
                Write-Warning "$($Error[0])"
                Break
            }
        }
    }
    End {
        Write-Verbose "End function"
    }
}
