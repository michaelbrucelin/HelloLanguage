function MyStart-MultiPing() {
    param(
        [switch]$online,
        [switch]$offline,
        [switch]$loop
    )

    $filepath = Read-Host "Please enter the file location"
    $ComPList = Get-Content "$filepath"

    function script:Ping_Test {   
        <#
        The Process statement list runs one time for each object in the pipeline.
        While the Process block is running, each pipeline object is assigned to 
        the $_ automatic variable, one pipeline object at a time. 
        #>
        PROCESS {
            $results = Get-WmiObject -query "SELECT * FROM Win32_PingStatus WHERE Address = '$_'"
            #           $RT = $results.ResponseTime
            #           $TTL = $results.ResponseTimeToLive

            if ($results.StatusCode -eq 0) {
                if (($online -eq $true -and $offline -ne $true) -or ($online -ne $true -and $offline -ne $true))
                { Write-Host "$Server    Online!" -ForegroundColor Green }
            }
            else {
                if (($online -ne $true -and $offline -eq $true) -or ($online -ne $true -and $offline -ne $true))
                { Write-Host "$Server    Offline!" -ForegroundColor Red }
            }
        }
    }

    #call procedure output results
    do {   
        $time = Measure-Command {
            foreach ($Server in $ComPList) {
                $Server | Ping_Test
            }
        }
        Write-Host ">>>>>>>> SpendTime:"$time" <<<<<<<<<"  #add "" for $time variable can convert format to time.
    }
    while ($loop) # if Switch Parameters are active the statement block cycling
}
