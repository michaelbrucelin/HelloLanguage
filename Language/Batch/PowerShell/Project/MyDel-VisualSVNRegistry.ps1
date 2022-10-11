function MyDel-VisualSVNRegistry() {
    $svns = Get-ChildItem HKCU:\Software\ -Recurse -Include visualsvn -ErrorAction SilentlyContinue
    while($svns -ne $null -and $svns.Count -lt 0)
    {
        $svns | Remove-Item -ErrorAction SilentlyContinue
        $svns = Get-ChildItem HKCU:\Software\ -Recurse -Include visualsvn -ErrorAction SilentlyContinue
    }
}