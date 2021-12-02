Function MyGet-Top() {
    # 实现类似于Linux中的top
    param(
        [int]$Lines = 30,
        [int]$Sleep = 2
    )

    while (1) {
        Get-Process | Sort-Object -Descending cpu | Select-Object -First $Lines; Start-Sleep -Seconds $Sleep; Clear-Host;
        Write-Host "Handles  NPM(K)    PM(K)      WS(K) VM(M)   CPU(s)     Id ProcessName";
        Write-Host "-------  ------    -----      ----- -----   ------     -- -----------";
        # Windows7 Write-Host "Handles  NPM(K)    PM(K)      WS(K)     CPU(s)     Id  SI ProcessName";
        # Windows7 Write-Host "-------  ------    -----      -----     ------     --  -- -----------";
    }
}
