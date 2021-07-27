function MyConvert-10ToBase() {
    # 将十进制的数字转成任意[2, 36]进制的数字
    # 例如将十进制的210转成12进制数字
    # PS C:\> ConvertTo-NumeralBase -Number 210 -Base 12

    [CmdletBinding()]
    [OutputType([string])]
    param(
        [Parameter(
            Position = 0,
            Mandatory,
            ValueFromPipelineByPropertyName)]
        [ValidateNotNullOrEmpty()]
        [int]$Number,
        [Parameter(
            Position = 1,
            Mandatory,
            ValueFromPipelineByPropertyName)]
        [ValidateNotNullOrEmpty()]
        [ValidateRange(2,36)]
        [int]$Base
    )
    
    $Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    while ($Number -gt 0)
    {
        $Remainder = $Number % $Base
        $CurrentCharacter = $Characters[$Remainder]
        $ResultNumber = "$CurrentCharacter$ResultNumber"
        $Number = ($Number - $Remainder) / $Base
    }

    $ResultNumber
}

function MyConvert-BaseTo10() {
    # 将任意[2, 36]进制的数字转成十进制的数字
    # 这里没有验证输入的字符串是否正确，比方说-Base 2 -Number 123，这里123不是二进制，但是函数不验证这个
    # 例如将12进制的156转成十进制的数字
    # PS C:\> ConvertFrom-NumeralBase -Number 156 -Base 12

    [CmdletBinding()]
    [OutputType([string])]
    param(
        [Parameter(
            Position = 0,
            Mandatory,
            ValueFromPipelineByPropertyName)]
        [ValidateNotNullOrEmpty()]
        [string]$Number,
        [Parameter(
            Position = 1,
            Mandatory,
            ValueFromPipelineByPropertyName)]
        [ValidateNotNullOrEmpty()]
        [ValidateRange(2,36)]
        [int]$Base
    )

    $Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    $NumberCharArray = $Number.ToUpper().ToCharArray()
    $NumberCharArray = $NumberCharArray[($NumberCharArray.Count)..0]

    [long]$DecimalNumber = 0
    $Position = 0

    foreach ($Character in $NumberCharArray)
    {
        $DecimalNumber += $Characters.IndexOf($Character) * [long][Math]::Pow($Base, $Position)
        $Position++
    }

    $DecimalNumber
}

function MyConvert-BaseToBase() {
    # 将任意[2, 36]进制的数字转成任意[2, 36]进制的数字
    # 例如将十进制的210转成12进制数字
    # PS C:\> ConvertTo-NumeralBase -Number 210 -Base 12

    param(
        [ValidateNotNullOrEmpty()]
        [Parameter(Mandatory=$true)]
        [string]$Number,
        [ValidateNotNullOrEmpty()]
        [ValidateRange(2,36)]
        [Parameter(Mandatory=$true)]
        [int]$BaseLeft,
        [ValidateNotNullOrEmpty()]
        [ValidateRange(2,36)]
        [Parameter(Mandatory=$true)]
        [int]$BaseRight
        )

    MyConvert-10ToBase -Base $BaseRight -Number (MyConvert-BaseTo10 -Base $BaseLeft -Number $Number)
}