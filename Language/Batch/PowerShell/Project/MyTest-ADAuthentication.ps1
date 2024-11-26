function Test-ADAuthentication {
    param(
        $username,
        $password
    )
    
    (New-Object DirectoryServices.DirectoryEntry "", $username, $password).psbase.name -ne $null
}

function Test-ADAuthentication {
    Param(
        [Parameter(Mandatory)]
        [string]$User,
        [Parameter(Mandatory)]
        $Password,
        [Parameter(Mandatory = $false)]
        $Server,
        [Parameter(Mandatory = $false)]
        [string]$Domain = $env:USERDOMAIN
    )

    Add-Type -AssemblyName System.DirectoryServices.AccountManagement
	
    $contextType = [System.DirectoryServices.AccountManagement.ContextType]::Domain
	
    $argumentList = New-Object -TypeName "System.Collections.ArrayList"
    $null = $argumentList.Add($contextType)
    $null = $argumentList.Add($Domain)

    if ($null -ne $Server) {
        $argumentList.Add($Server)
    }
	
    $principalContext = New-Object System.DirectoryServices.AccountManagement.PrincipalContext -ArgumentList $argumentList -ErrorAction SilentlyContinue

    if ($null -eq $principalContext) {
        Write-Warning "$Domain\$User - AD Authentication failed"
        return $false
    }
	
    if ($principalContext.ValidateCredentials($User, $Password)) {
        Write-Host -ForegroundColor green "$Domain\$User - AD Authentication OK"
        return $true
    }
    else {
        Write-Warning "$Domain\$User - AD Authentication failed"
        return $false
    }
}

# Test-ADAuthentication -User toto -Password passXX
# Test-ADAuthentication -User toto -Password passXX -Server xxx.domain.com
