function global:MyGet-Handle() {
    param(
        [string]$Name
    )

    $handleOut = handle64.exe
    foreach($line in $handleOut) {
        if($line -match '\S+\spid:') {
            $exe = $line
        } 
        elseif($line -match $Name) { 
            "$exe - $line"
        }
    }
}