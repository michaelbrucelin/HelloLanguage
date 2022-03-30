function MyGet-RandomPassword() {
    param(
        [int]$count = 1,
        [int]$length = 36,
        [ValidateSet('digit', 'letter', 'LETTER', 'digit-letter', 'digit-LETTER', 'letter-LETTER', 'd-l-L', 'ascii', 'customize')]
        [string]$metaType = 'ascii',
        [char[]]$metaChar = [char[]]('')
    )
 
    if ($metaType -ceq "digit") {
        $metaChar = [char[]](48..57)
    }
    elseif ($metaType -ceq "letter") {
        $metaChar = [char[]](97..122)
    }
    elseif ($metaType -ceq "LETTER") {
        $metaChar = [char[]](65..90)
    }
    elseif ($metaType -ceq "digit-letter") {
        $metaChar = [char[]](48..57 + 97..122)
    }
    elseif ($metaType -ceq "digit-LETTER") {
        $metaChar = [char[]](48..57 + 65..90)
    }
    elseif ($metaType -ceq "letter-LETTER") {
        $metaChar = [char[]](65..90 + 97..122)
    }
    elseif ($metaType -ceq "d-l-L") {
        $metaChar = [char[]](48..57 + 65..90 + 97..122)
    }
    elseif ($metaType -ceq "ascii") {
        $metaChar = [char[]](48..57 + 65..90 + 97..122 + 35..37 + 43 + 45 + 60..64)
    }
    elseif ($metaType -ceq "customize") {
        if ($metaChar.Length -eq 0) {
            Write-Host -ForegroundColor Red '自定义时必须使用$metaChar参数指定可选的字符';
            return;
        }
    }

    $result = @()
    for ($i = 1; $i -le $count; $i++) {
        $item = ""
        for ($j = 1; $j -le $length; $j++) {
            $item += ($metaChar | Get-Random | % { [char]$_ })
        }
        $result += $item
    }

    return $result
}