function MyRun-Dotnet() {
    param(
        [Parameter(Mandatory = $true, HelpMessage = 'XXXX.cs')]
        [ValidatePattern('^.+\.cs$')]
        [string]$CSFILE
    )

    <#
        dotnet core目前没有找到更好的方式去执行单个的 .cs 代码文件，这里使用powershell包装一个利用反射来实现。
    #>

    $ErrorActionPreference = "Stop"

    (Add-Type -Path "${CSFILE}" -PassThru)::Main()
}
