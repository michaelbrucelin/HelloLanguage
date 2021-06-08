# 链接：https://docs.microsoft.com/zh-cn/archive/blogs/timid/batch-getting-bios-serial-numbers

function Get-SerialNumber {
    param (
        [Parameter( 
            Position = 0,  
            ValueFromPipeline = $true, 
            ValueFromPipelineByPropertyName = $true 
        )][string[]]$ComputerName = @()
    );

    process {
        foreach ($computer in $ComputerName) {
            try {
                $wmi = Get-WmiObject -ComputerName $computer Win32_BIOS;
            }
            catch {
            }

            $SerialNumber = $wmi.SerialNumber;
            if (!$SerialNumber) { $SerialNumber = 'ERROR'; }
            1 | Select-Object -Property @{
                n = 'ComputerName';
                e = { $computer; }
            }, @{
                n = 'SerialNumber';
                e = { $SerialNumber; }
            }
        }
    }
}
