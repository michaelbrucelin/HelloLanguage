<#
    自动查找并删除对应注册表的信息，有些软件试用期过后，卸载，清理注册表，重新安装即可再次试用，VisualSVN即是这样的；
#>
function MyDel-VisualSVNRegistry() {
    $svns = Get-ChildItem HKCU:\Software\ -Recurse -Include visualsvn -ErrorAction SilentlyContinue
    while ($svns -ne $null -and $svns.Count -lt 0) {
        $svns | Remove-Item -ErrorAction SilentlyContinue
        $svns = Get-ChildItem HKCU:\Software\ -Recurse -Include visualsvn -ErrorAction SilentlyContinue
    }
}
