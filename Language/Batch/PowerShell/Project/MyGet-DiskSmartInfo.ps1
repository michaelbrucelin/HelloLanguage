function MyGet-DiskSmartInfo() {
    <#
        .SYNOPSIS
        Reads SMART info from supporting hard drives. Requires ADMIN privileges to run!
        获取磁盘的Smart信息，测试对HDD可用，对三星SSD无效，另外，有现成的Module：Import-Module DiskSmartInfo，但是依然对三星SSD无效。

        .EXAMPLE
        Get-SMARTInfo | Select-Object -First 1 -ExpandProperty SMART | Out-GridView  # Shows SMART info for first hard drive present
        (Get-SMARTInfo)[0].SMART | Format-Table                                      # Shows SMART info for first hard drive present
    #>

    $disks = @(Get-WmiObject -Class Win32_DiskDrive | ForEach-Object {
        [PSCustomObject]@{
            Model = $_.Model
            SMART = [Collections.ArrayList]@()
            DriveInfo = $_
        }
    })

    $friendlynames = @{
        0x00="Invalid"
        0x01="Raw read error rate"
        0x02="Throughput performance"
        0x03="Spinup time"
        0x04="Start/Stop count"
        0x05="Reallocated sector count"
        0x06="Read channel margin"
        0x07="Seek error rate"
        0x08="Seek timer performance"
        0x09="Power-on hours count"
        0x0A="Spinup retry count"
        0x0B="Calibration retry count"
        0x0C="Power cycle count"
        0x0D="Soft read error rate"
        0x16="Current helium level"
        0xAA="Available reserved space"
        0xAB="Program fail count"
        0xAC="Erase fail count"
        0xAD="Wear leveling count"
        0xAE="Unexpected power loss count"
        0xAF="Power loss protection failure"
        0xB0="Erase fail count"
        0xB1="Wear range delta"
        0xB3="Used reserved block count"
        0xB4="Unused reserved block count"
        0xB5="Program fail count total / non-4K aligned access count"
        0xB6="Erase fail count"
        0xB7="SATA downshift error count / Runtime bad block"
        0xB8="End-to-End error"
        0xB9="Head stability"
        0xBA="Induced Op-vibration detection"
        0xBB="Reported uncorrectable errors"
        0xBC="Command timeout"
        0xBD="High fly writes"
        0xBE="Airflow Temperature Celsius"
        0xBF="G-sense error rate"
        0xC0="Power-off retract count"
        0xC1="Load/Unload cycle count"
        0xC2="HDD temperature"
        0xC3="Hardware ECC recovered"
        0xC4="Reallocation count"
        0xC5="Current pending sector count"
        0xC6="Offline scan uncorrectable count"
        0xC7="UDMA CRC error rate"
        0xC8="Write error rate"
        0xC9="Soft read error rate"
        0xCA="Data Address Mark errors"
        0xCB="Run out cancel"
        0xCC="Soft ECC correction"
        0xCD="Thermal asperity rate (TAR)"
        0xCE="Flying height"
        0xCF="Spin high current"
        0xD0="Spin buzz"
        0xD1="Offline seek performance"
        0xD2="Vibration during write"
        0xD3="Vibration during write"
        0xD4="Shock during write"
        0xDC="Disk shift"
        0xDD="G-sense error rate"
        0xDE="Loaded hours"
        0xDF="Load/unload retry count"
        0xE0="Load friction"
        0xE1="Load/Unload cycle count"
        0xE2="Load-in time"
        0xE3="Torque amplification count"
        0xE4="Power-off retract count"
        0xE6="GMR head amplitude"
        0xE7="Temperature"
        0xE8="Endurance remaining / available reserved space"
        0xE9="Power-on hours / media wearout indicator"
        0xEA="Average erase count / maximum erase count"
        0xEB="Good block count / System free block count"
        0xF0="Head flying hours"
        0xF1="Total LBAs written"
        0xF2="Total LBAs read"
        0xF3="Total LBAs written expanded"
        0xF4="Total LBAs read expanded"
        0xF9="NAND writes 1GiB"
        0xFA="Read error retry rate"
        0xFB="Minimum spares remaining"
        0xFC="Newly added bad flash block"
        0xFE="Free fall protection"
    }

    Get-WmiObject -Namespace root\wmi -class MSStorageDriver_FailurePredictStatus | ForEach-Object { $i = 0 } {
        $disks[$i] | Add-Member -MemberType NoteProperty -Name FailureImminent -Value $_.PredictFailure
        $i++
    }

    $threshHoldCollection = @(Get-WmiObject -Class MSStorageDriver_FailurePredictThresholds -Namespace root/wmi | ForEach-Object { $i = 0 } {
        $threshHolds = @{}
        $threshData = $_
        $bytes = $threshData.VendorSpecific
        for ($i = 0; $i -lt 30; $i++) {
            try {
                $idnumeric = [int]$bytes[$i*12 + 2]
                $thresh = $bytes[$i*12 + 3];
                $threshHolds[$idnumeric] = $thresh;
            }
            catch {
                # given key does not exist in attribute collection (attribute not in the dictionary of attributes)
            }
        }
        $threshHolds
    })

    Get-WmiObject -Class MSStorageDriver_FailurePredictData -Namespace root/wmi | ForEach-Object { $x = 0 } {
        $smartData = $_
        $bytes = $smartData.VendorSpecific
        for ($i = 0; $i -lt 30; $i++) {
            try {
                $idnumeric = [int]$bytes[$i*12 + 2]
                if ($idnumeric -eq 0) { continue };
                if ($friendlynames.ContainsKey($idnumeric)) {
                    $id = $friendlynames[$idnumeric]
                }
                else {
                    $id = "ID $idnumeric"
                }
                $attr = @{}
                $flags = $bytes[$i * 12 + 4]; # least significant status byte, +3 most significant byte, but not used so ignored.
                $advisory = ($flags -band 0x1) -eq 0x0;
                $failureImminent = ($flags -band 0x1) -eq 0x1;
                #bool onlineDataCollection = ($flags -band 0x2) == 0x2;

                $value = $bytes[$i*12 + 5];
                $worst = $bytes[$i*12 + 6];
                $vendordata = [BitConverter]::ToInt32($bytes, $i*12 + 7);
                $threshHold = $threshHoldCollection[$x][$idnumeric]
                $threshHoldUndefined = $threshHoldCollection[$x].ContainsKey($idnumeric) -eq $false
                if (!$threshHoldUndefined) {
                    $threshHold = $threshHoldCollection[$x][$idnumeric]
                } else {
                    $threshHold = $null
                }
                $null = $disks[$x].SMART.Add(
                    [PSCustomObject]@{
                        Name = $id
                        Current = $value;
                        Worst = $worst;
                        Data = $vendordata;
                        IsOK = $failureImminent -eq $false;
                        Threshold = $threshHolds[$idnumeric]
                        ThresholdUndefined = $threshHoldUndefined
                })
            }
            catch {
                # given key does not exist in attribute collection (attribute not in the dictionary of attributes)
            }
        }
        $x++
    }
    $disks
}
