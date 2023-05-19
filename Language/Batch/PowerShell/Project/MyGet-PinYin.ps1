<#
    微软已经有了一个库做了常用语言之类的类似的转换，下载如下，
    http://www.microsoft.com/en-us/download/details.aspx?id=15251
    对于powershell来说，唯一要用的就是ChnCharInfo.dll这个库文件
#>
function MyGet-PinYin() {
    param(
        [string]$InputStr
    )

    $dllpath = "$($Env:OneDrive)\文档\powershell\init\ChnCharInfo.dll"
    Import-Module $dllpath  # 加载微软的汉字转拼音的库

    $shortR = ""
    $allR = ""
    foreach ($c in $InputStr.Trim().ToCharArray()) {
        try {
            $chineseChar = [Microsoft.International.Converters.PinYinConverter.ChineseChar]::new($c)
            $shortR += $chineseChar.Pinyins[0].Substring(0, 1).ToLower() 
            $allR += $chineseChar.Pinyins[0].Substring(0, $chineseChar.Pinyins[0].Length - 1).ToLower() 
        }
        catch {
            $shortR += $c
            $allR += $c
        }
    }
    $shortR
    $allR
}
