function Test-Job1() {
    Write-Host 'from job1.'

    . D:\installer\Test-Job11.ps1
    Test-Job11

    . D:\installer\Test-Job12.ps1
    Test-Job12
}
