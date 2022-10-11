<#
设置文件夹的位置和大小
列出所有过滤出来的窗口，然后交互式操作，每输入一个数字，就将对应的窗口移到相应的位置，并重置其大小，输入q退出
这个设计默认需要调整位置的文件夹不超过10个
BoundingRectangle      : 190,196,856,556
BoundingRectangle      : 215,221,856,556

Install-Module -Name Wasp
#>

function MyMove-DirWindows() {
    $modules = Get-Module
    if (!$modules.Name.Contains('Wasp')) {
        $execplcy = Get-ExecutionPolicy
        Set-ExecutionPolicy RemoteSigned -Force
        Import-Module Wasp
        Set-ExecutionPolicy $execplcy -Force
    }

    if ($explorer = Get-Process -Name explorer -ErrorAction SilentlyContinue) {
        [int]$width = 856; [int]$height = 556;
        [int]$startX = 190; [int]$startY = 196;
        [int]$moveX = 25; [int]$moveY = 25

        $curps = Select-UIElement -PID $PID
        $windows = Select-UIElement -PID $explorer.Id -ControlType Window -ClassName CabinetWClass
        if ($windows) {
            $windowslist = [System.Collections.Generic.List[System.Object]]$windows
            [int]$i = 0; [int]$index = -1;
            while ($windowslist.Count -gt 0) {
                $global:index = -1
                $windowslist | Format-Table -Property @{name = "ID"; expression = { $global:index; $global:index++ } }, Name

                Write-Host "input a directory window's index, input 'q' or 'Q' to quit."
                $key = $Host.UI.RawUI.ReadKey()
                if ($key.Character -ne 'q' -and $key.Character -ne 'Q') {
                    if ([int]$key.Character -lt 48 -and [int]$key.Character -gt 57) {
                        # if(($key.Character -isnot [int])) { 
                        Write-Host "`nYou did not provide a number as input." -ForegroundColor Red
                        continue
                    }
                    if ([int]([string]$key.Character) -lt [int]0 -or [int]([string]$key.Character) -ge $windowslist.Count) {
                        Write-Host "`nIndex was outside the bounds of the array." -ForegroundColor Red
                        continue
                    }

                    $windowslist[[int]([string]$key.Character)] | Invoke-Transform.Move -x ($startX + $moveX * $i) -y ($startY + $moveY * $i)
                    $windowslist[[int]([string]$key.Character)] | Invoke-Transform.Resize -width $width -height $height
                    $windowslist.RemoveAt([int]([string]$key.Character))
                    $curps | Invoke-Transform.Rotate -degrees 0 -ErrorAction SilentlyContinue  # 焦点回到powershell中，没有找到使某个程序获取焦点的命令，使用旋转的来伪实现此功能

                    $i++
                }
                else {
                    break
                }
            }
        }
    }
}
