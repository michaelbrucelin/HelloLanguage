# 链接：https://docs.microsoft.com/zh-cn/archive/blogs/timid/batch-getting-ip-addresses

function Get-IPAddress2 {
    param (
        [Parameter( 
            Position = 0,  
            ValueFromPipeline = $true, 
            ValueFromPipelineByPropertyName = $true 
        )][string[]]$ComputerName = @()
    );

    process {
        foreach ($computer in $ComputerName) {
            try { $AddressList = [System.Net.Dns]::GetHostEntry($computer).AddressList; }
            catch { $AddressList = @('ERROR'); }

            foreach ($address in $AddressList) {
                1 | Select-Object -Property @{
                    n = 'ComputerName';
                    e = { $computer; }
                }, @{
                    n = 'IPAddress';
                    e = { 
                        if ($address.GetType().Name -ne 'IPAddress') { 
                            'ERROR';
                        }
                        else {
                            $address.IpAddressToString; 
                        }
                    }
                }
            }
        } 
    }
}
