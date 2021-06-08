# 链接：https://docs.microsoft.com/zh-cn/archive/blogs/timid/getting-computer-memory-usage

function MyGet-ComputerMemory {
    param (
        [Parameter( 
            Position = 0,  
            ValueFromPipeline = $true, 
            ValueFromPipelineByPropertyName = $true 
        )] [String[]]$ComputerName = @($env:COMPUTERNAME.ToLower()),
        [int]$digits = 3
    );
    process {
        foreach ($computer in $ComputerName ) {
            $object = 1 | Select-Object ComputerName, TotalPhysicalMemoryGB, FreePhysicalMemoryGB, UsedPhysicalMemory, TotalVirtualMemoryGB, FreeVirtualMemoryGB, UsedVirtualMemory;
            
            Write-Progress "Get-WmiObject Win32_ComputerSystem" "-ComputerName $computer"
            $wmiCompSys = Get-WmiObject Win32_ComputerSystem -ComputerName $computer;
            if (!$wmiCompSys) { 
                Write-Warning "Unable to get Win32_ComputerSystem data from $computer"; 
            }

            Write-Progress "Get-WmiObject Win32_OperatingSystem" "-ComputerName $computer"
            $wmiOpSys = Get-WmiObject Win32_OperatingSystem -ComputerName $computer;
            if (!$wmiOpSys) {
                Write-Warning "Unable to get Win32_OperatingSystem data from $computer";
            }

            $object.ComputerName = $computer.ToLower();

            # normalize to GB. NOTE: Win32_OperatingSystem returns KB while Win32_ComputerSystem returns bytes.
            $totalPhys = $wmiCompSys.TotalPhysicalMemory / 1GB;
            $freePhys = $wmiOpSys.FreePhysicalMemory / 1MB;
            $totalVirt = $wmiOpSys.TotalVirtualMemorySize / 1MB;
            $freeVirt = $wmiOpSys.FreeVirtualMemory / 1MB
            
            $object.TotalPhysicalMemoryGB = ("{0:N$digits}" -f ($totalPhys + .5)) -as [float];
            $object.FreePhysicalMemoryGB = ("{0:N$digits}" -f ($freePhys + .5)) -as [float];
            $object.UsedPhysicalMemory = [int]((100 * (1 - ($freePhys / $totalPhys))) + .5);

            $object.TotalVirtualMemoryGB = ("{0:N$digits}" -f ($totalVirt + .5)) -as [float];
            $object.FreeVirtualMemoryGB = ("{0:N$digits}" -f ($freeVirt + .5)) -as [float];
            $object.UsedVirtualMemory = [int]((100 * (1 - ($freeVirt / $totalVirt))) + .5);

            $object;
        }
    }
}
