function MyEncrypt-String {
    Param(
        [Parameter(Mandatory = $True, Position = 0, ValueFromPipeLine = $true)]
        [Alias("String")]
        [String]$PlainTextString,

        [Parameter(Mandatory = $True, Position = 1)]
        [Alias("Key")]
        [String]$EncryptionKey
    )

    Try {
        $enc = @()
        for($i=0; $i -lt $PlainTextString.length; $i++){
            $key_c = $EncryptionKey[$i % $EncryptionKey.length]
            $enc_c = [char](([int][char]($PlainTextString[$i]) + [int][char]($key_c)) % 256)
            $enc += $enc_c
        }

        return $EncryptedString
    }
    Catch { Throw $_ }
}

function MyDecrypt-String {
    Param(
        [Parameter(Mandatory = $True, Position = 0, ValueFromPipeLine = $true)]
        [Alias("String")]
        [String]$EncryptedString,

        [Parameter(Mandatory = $True, Position = 1)]
        [Alias("Key")]
        [String]$EncryptionKey
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