function Test-Job1() {
    Write-Host 'from job1.'

    . D:\installer\Test-Job11.ps1
    Test-Job11

    . D:\installer\Test-Job12.ps1
    Test-Job12

    Write-Host "Press any key to continue..."
    [void][System.Console]::ReadKey($true)
}
