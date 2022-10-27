<#
    使用powershell，模仿黑客帝国的“数码雨”。
#>
## Prepare the screen
$host.UI.RawUI.BackgroundColor = "Black"
$host.UI.RawUI.ForegroundColor = "Green"

$charSet = '0123456789'.ToCharArray()

$width = 75
$height = [Console]::WindowHeight
$maxStringLength = 7
$minStringLength = 2
$maxSpaceLength = 20
$minSpaceLength = 6

$lines = New-Object System.Collections.ArrayList
$symbols = @()

for ($i = 0; $i -lt $width; $i++) {
    $symbols += ''
}

function AddLine([string]$line) {
    $lines.insert(0, $line)
    if ($lines.Count -eq $height) {
        $lines.RemoveAt($lines.Count - 1)
    }
}

function ShowFrame() {
    Write-Host ($lines.ToArray() -join "`n")
}

function TryGenerateSymbol() {
    for ($i = 0; $i -lt $width; $i++) {
        $column = $symbols[$i]
        if ($column -eq '') {
            # initial state, generate spaces
            $symbols[$i] = New-Object String ' ', (Get-Random -Minimum $minSpaceLength -Maximum $maxSpaceLength)
        }
        elseif ($column -eq ' ') {
            # last space
            $randomCount = Get-Random -Minimum $minStringLength -Maximum $maxStringLength
            $chars = Get-Random -InputObject $charSet -Count $randomCount
            $symbols[$i] = $column + ($chars -join '')
        }
        elseif ($column.Length -eq 1) {
            # last char
            $symbols[$i] = $column + (New-Object String ' ', (Get-Random -Minimum $minSpaceLength -Maximum $maxSpaceLength))
        }
    }
}

function UpdateFrame() {
    TryGenerateSymbol

    $line = @()
    for ($i = 0; $i -lt $width; $i++) {
        $column = $symbols[$i]
        $line += $column[0]
        $symbols[$i] = $column.Substring(1, $column.Length - 1)
    }
    $line = $line -join ''
    AddLine $line
}

try {
    $host.UI.RawUI.WindowSize = New-Object System.Management.Automation.Host.Size $width + 1, $height + 1
}
catch {}

try {
    $host.UI.RawUI.BufferSize = New-Object System.Management.Automation.Host.Size $width + 1, $height + 1
}
catch {}

try {
    while ($true) {
        if ([Console]::KeyAvailable) {
            $key = [Console]::ReadKey()
            if (($key.Key -eq 'Escape') -or
                ($key.Key -eq 'Q') -or
                ($key.Key -eq 'C')) {
                break
            }
        }

        #       Clear-Host

        $host.UI.RawUI.CursorPosition = New-Object System.Management.Automation.Host.Coordinates 0, 0

        UpdateFrame
        ShowFrame

        $host.UI.RawUI.CursorPosition = New-Object System.Management.Automation.Host.Coordinates `
            0, ([Console]::WindowHeight - 1)
        Write-Host -NoNewLine 'Q or ESC to Quit'

        Start-Sleep -m 100
    }
}
finally {
    ## Clean up, display exit screen
    Clear-Host
    "`n"
    "                        Happy Scripting from PowerShell..."
    "                                 by Victor.Woo!"
    "`n`n`n"
}
