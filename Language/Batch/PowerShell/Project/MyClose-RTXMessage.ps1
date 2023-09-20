# 关闭RTX的流程提醒，就相当于一个按键精灵，不断的在窗口的关闭按钮的位置点击
# Install-Module -Name Wasp

function MyClose-RTXMessage() {
    $modules = Get-Module
    if (!$modules.Name.Contains('Wasp')) {
        $execplcy = Get-ExecutionPolicy
        Set-ExecutionPolicy RemoteSigned -Force
        Import-Module Wasp
        Set-ExecutionPolicy $execplcy -Force
    }

    $rtx=Get-Process -Name RTX
    $rtxmsg=Select-UIElement -ControlType 'Pane' -PID $rtx.id -ClassName Afx*

    $max=10  # 防止意外死循环
    while($rtxmsg -ne $null -and $max -gt 0) {
        $rtxmsg | ForEach-Object {
            # -ControlType 'Pane' 由于Pane类型的UI控件，无法获取焦点（不确认是Pane本身还是因为RTX的原因），所以模拟Alt+F4之前，需要先将鼠标移到UI的所在位置
            [System.Windows.Forms.Cursor]::Position = New-Object System.Drawing.Point(($_.GetClickablePoint()).X, ((($_.GetClickablePoint()).Y)+30))
            # 该类型控件没有Close方法，所以采用Alt+F4的方式关闭
            $null=Send-UIKeys -InputObject $_ -Keys "%{F4}"
        }
        $rtxmsg=Select-UIElement -ControlType 'Pane' -PID $rtx.id -ClassName Afx*
        $max--
    }
}
