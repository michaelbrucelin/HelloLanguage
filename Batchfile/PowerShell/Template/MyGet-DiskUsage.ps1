function MyGet-DiskUsage() {
    param(
        [string]$path=".",
        [switch]$Recurse=$false
    )

    if($Recurse -eq $true)
    {
        Get-ChildItem $path | ForEach-Object { 
            $file = $_;
            Get-ChildItem $_.FullName -Recurse | Measure-Object -Property Length -Sum |
            Select-Object @{Name="Name"; Expression={$file.Name}}, Sum
        }
    }
    else
    {
        Get-ChildItem $path -Recurse | Measure-Object -Property Length -Sum |
        Select-Object @{Name="Name"; Expression={$path}}, Sum
    }
}