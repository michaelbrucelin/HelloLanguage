# 链接：https://docs.microsoft.com/zh-cn/archive/blogs/timid/getting-disk-usage

function Get-DiskUsage2 {
    param (
        [Parameter(ValueFromPipeline = $true)][string[]]$Path = (Get-Location).Path,
        [string]$CsvPath = "$env:TEMP\$($MyInvocation.MyCommand.Name) $($env:Computername) $(Get-Date -Format 'yyyy-MM-dd').csv",
        [long]$MinimumFileSize = 1MB,
        [int]$DisplayFolderCount = 4
    );

    begin {
        # create parent folder if not found
        if (!(Test-Path -Path (Split-Path -Path $CsvPath -Parent))) {
            New-Item -ItemType Directory -Path $CsvPath -ErrorAction SilentlyContinue -Force | Out-Null;
            Remove-Item -Path $CsvPath -Force -ErrorAction SilentlyContinue;
        } # if (!(Test-Path -Path (Split-Path -Path $CsvPath -Parent)))

        New-Item -ItemType File -Path $csvPath -ErrorAction SilentlyContinue -Force | Out-Null;
        if (!(Test-Path -Path $CsvPath)) {
            Write-Warning "$($MyInvocation.MyCommand.Name) -CsvPath '$csvPath' Unable to create.";
            return;
            break __outOfScript; # really, REALLY stop processing
        } # if (!(Test-Path -Path $CsvPath))
    } # begin

    process {
        & {
            foreach ($myPath in $Path) {
                if (Test-Path -Path $myPath) {
                    Write-Progress (Get-Date) "Recursing through '$myPath'";
                    Get-ChildItem -Path $myPath -Recurse -ErrorAction SilentlyContinue |
                    ? { !$_.PsIsContainer -and ($_.Length -ge $MinimumFileSize) } |
                    Sort-Object -Descending -Property Length |
                    Select-Object -Property Fullname, @{
                        n = 'MB_Size';
                        e = {
                            "{0:N3}" -f ($_.Length / 1MB);
                        } # n = 'MB_Size'
                    } |
                    % {
                        $object = $_;
                        if ($DisplayFolderCount -and $object.FullName) {
                            Add-Member -InputObject $object -MemberType ScriptMethod -Name AddMember -Value {
                                Add-Member -InputObject $this -MemberType NoteProperty -Name $args[0] -Value $args[1]
                            } # Add-Member -InputObject $object -MemberType ScriptMethod -Name AddMember -Value

                            $Folders = $object.Fullname.Split("`\", $DisplayFolderCount);

                            for ($i = 0; $i -lt $Folders.Count; $i++) {
                                $object.AddMember("Folder$i", $Folders[$i]);

                            } # # for ($i = 0; $i -lt $Folders.Count; $i++)
                        } # 

                        $object;
                    } # 
                } # 
                else {
                    Write-Warning "$($MyInvocation.MyCommand.Name) -Path '$myPath' not found.";
                } # 
            } # 
        } | Export-Csv -NoTypeInformation -Path $CsvPath -ErrorAction SilentlyContinue;
    } # process
    end {
        if (Test-Path -Path $CsvPath) {
            Write-Host -ForegroundColor Green -NoNewline "Output file: ";
            (Resolve-Path -Path $csvPath).ProviderPath;
        } # 
        else {
            Write-Warning "$($MyInvocation.MyCommand.Name) -CsvPath '$csvPath' Unable to create.";
            return;
            break __outOfScript; # really, REALLY stop processing
        } # 
    } # 
} # 
