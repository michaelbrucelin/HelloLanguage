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

        return [System.Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes(-join $enc))
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
        $dec = @()
        $enc = [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($EncryptedString))
        for($i=0; $i -lt $enc.length; $i++){
            $key_c = $EncryptionKey[$i % $EncryptionKey.length]
            $dec_c = [char]((256 + [int][char]($enc[$i]) - [int][char]($key_c)) % 256)
            $dec += $dec_c
        }

        Return (-join $dec)
    }
    Catch { Throw $_ }
}