function Encrypt-String {
    Param(
        [Parameter(Mandatory = $True, Position = 0, ValueFromPipeLine = $true)]
        [Alias("String")]
        [String]$PlainTextString,
        
        [Parameter(Mandatory = $True, Position = 1)]
        [Alias("Key")]
        [byte[]]$EncryptionKey
    )

    Try {
        $secureString = Convertto-SecureString $PlainTextString -AsPlainText -Force
        $EncryptedString = ConvertFrom-SecureString -SecureString $secureString -Key $EncryptionKey

        return $EncryptedString
    }
    Catch { Throw $_ }
}

function Decrypt-String {
    Param(
        [Parameter(Mandatory = $True, Position = 0, ValueFromPipeLine = $true)]
        [Alias("String")]
        [String]$EncryptedString,
        
        [Parameter(Mandatory = $True, Position = 1)]
        [Alias("Key")]
        [byte[]]$EncryptionKey
    )

    Try {
        $SecureString = ConvertTo-SecureString $EncryptedString -Key $EncryptionKey
        $bstr = [Runtime.InteropServices.Marshal]::SecureStringToBSTR($SecureString)
        [string]$String = [Runtime.InteropServices.Marshal]::PtrToStringAuto($bstr)
        [Runtime.InteropServices.Marshal]::ZeroFreeBSTR($bstr)

        Return $String
    }
    Catch { Throw $_ }
}