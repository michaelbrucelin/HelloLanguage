<#
Simple PowerShell, place into a folder, create a daily task in Windows Task Scheduler, script saves images at its run folder, then in your Desktop Background settings choose that folder as a background.
#>

[xml]$doc = (New-Object System.Net.WebClient).DownloadString("https://www.bing.com/HPImageArchive.aspx?format=xml&idx=0&n=1&mkt=ru-RU")
$url = $doc.images.image.url
$url = "https://www.bing.com/" + $url -replace "_1366x768","_1920x1200"

Write-Output $url

$fileName = Split-Path $url -leaf
$output = "$PSScriptRoot\$fileName"

$start_time = Get-Date
Invoke-WebRequest -Uri $url -OutFile $output
Write-Output "Saved to: $output Time taken: $((Get-Date).Subtract($start_time).Seconds) second(s)"

# or
Invoke-RestMethod "bing.com$((Invoke-RestMethod "bing.com/HPImageArchive.aspx?format=js&mkt=en-IN&n=1").images[0].url)" -OutFile bing.jpg