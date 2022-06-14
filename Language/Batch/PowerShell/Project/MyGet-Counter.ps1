function MyGet-Counter() {
    <#
        统计常用的Windows系统计数器
        参考：https://bradleyschacht.com/collecting-server-performance-metrics-powershell/
    #>

    $outputDirectory = [Environment]::GetFolderPath("Desktop") + "\Performance Counters"  # Directory where the restult file will be stored.
    $computerName = ""                                                                    # Set the Computer from which to collect counters. Leave blank for local computer.
    $sampleInterval = 15                                                                  # Collection interval in seconds.
    $maxSamples = 240                                                                     # How many samples should be collected at the interval specified. Set to 0 for continuous collection.

    # Check to see if the output directory exists. If not, create it.
    if (-not(Test-Path $outputDirectory)) {
        Write-Host "Output directory does not exist. Directory will be created."
        $null = New-Item -Path $outputDirectory -ItemType Directory
        Write-Host "Output directory created."
    }
    # Strip the \ off the end of the directory if necessary.
    if ($outputDirectory.EndsWith("\")) {
        $outputDirectory = $outputDirectory.Substring(0, $outputDirectory.Length - 1)
    }
    # Create the name of the output file in the format of "computer date time.csv".
    $outputFile = "$outputDirectory\$(if($computerName -eq ''){$env:COMPUTERNAME} else {$computerName}) $(Get-Date -Format "yyyy_MM_dd HH_mm_ss").csv"

    # Write the parameters to the screen.
    Write-Host "
Collecting counters...
Press Ctrl+C to exit."
    # Specify the list of performance counters to collect.
    $counters = @(`
            "\Processor(_Total)\% Processor Time" `
            , "\Memory\Available MBytes" `
            , "\Paging File(_Total)\% Usage" `
            , "\PhysicalDisk(*)\Current Disk Queue Length" `
            , "\PhysicalDisk(*)\Avg. Disk Bytes/Read" `
            , "\PhysicalDisk(*)\Avg. Disk Bytes/Write" `
            , "\PhysicalDisk(*)\Avg. Disk sec/Read" `
            , "\PhysicalDisk(*)\Avg. Disk sec/Write" `
            , "\PhysicalDisk(*)\Disk Read Bytes/sec" `
            , "\PhysicalDisk(*)\Disk Write Bytes/sec" `
            , "\PhysicalDisk(*)\Disk Reads/sec" `
            , "\PhysicalDisk(*)\Disk Writes/sec"
    )

    # Set the variables for the Get-Counter cmdlet.
    $variables = @{
        SampleInterval = $sampleInterval
        Counter        = $counters
    }

    # Add the computer name if it was not blank.
    if ($computerName -ne "") {
        $variables.Add("ComputerName", "$computerName")
    }
    # Either set the sample interval or specify to collect continuous.
    if ($maxSamples -eq 0) {
        $variables.Add("Continuous", 1) 
    }
    else {
        $variables.Add("MaxSamples", "$maxSamples")
    }

    # Show the variables then execute the command while storing the results in a file.
    $variables
    Get-Counter @Variables | Export-Counter -FileFormat csv -Path $outputFile -Force
}
