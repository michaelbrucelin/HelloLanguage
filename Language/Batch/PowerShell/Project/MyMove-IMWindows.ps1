# Install-Module -Name Wasp

function MyMove-IMWindows() {
    $modules = Get-Module
    if (!$modules.Name.Contains('Wasp')) {
        $execplcy = Get-ExecutionPolicy
        Set-ExecutionPolicy RemoteSigned -Force
        Import-Module Wasp
        Set-ExecutionPolicy $execplcy -Force
    }

    # RTX
    if ($rtx_p = Get-Process -Name 'rtx' -ErrorAction SilentlyContinue) {
        # 主窗体
        $rtx_w = Select-UIElement -PID $rtx_p.Id -ControlType Pane
        $rtx_w | Invoke-Transform.Move -x 1666 -y 5 -ErrorAction SilentlyContinue
        $rtx_w | Invoke-Transform.Resize -width 249 -height 739 -ErrorAction SilentlyContinue
        # 会话窗体
        $rtx_w = Select-UIElement -PID $rtx_p.Id -ControlType Window
        $rtx_w | Invoke-Transform.Move -x 1160 -y 108 -ErrorAction SilentlyContinue
        $rtx_w | Invoke-Transform.Resize -width 783 -height 783 -ErrorAction SilentlyContinue
    }

    # E-Mobile
    if ($em_p = Get-Process -Name 'E-Mobile' -ErrorAction SilentlyContinue) {
        $em_w = Select-UIElement -PID $em_p.Id -WindowName 'E-Mobile' -ControlType Window
        $em_w | Invoke-Transform.Move -x 923 -y 106 -ErrorAction SilentlyContinue
        $em_w | Invoke-Transform.Resize -width 1000 -height 788 -ErrorAction SilentlyContinue
    }

    # QQ
    if ($qq_p = Get-Process -Name 'QQ' -ErrorAction SilentlyContinue) {
        # 主窗体
        $qq_w = Select-UIElement -PID $qq_p.Id -ControlType Pane | Where-Object { $_.Name -eq 'QQ' }
        $qq_w | Invoke-Transform.Move -x 1624 -y -3 -ErrorAction SilentlyContinue
        $qq_w | Invoke-Transform.Resize -width 300 -height 777 -ErrorAction SilentlyContinue
        # 会话窗体
        $qq_w = Select-UIElement -PID $qq_p.Id -ControlType Pane | Where-Object { $_.Name -ne 'QQ' }
        $qq_w | Invoke-Transform.Move -x 1138 -y 103 -ErrorAction SilentlyContinue
        $qq_w | Invoke-Transform.Resize -width 826 -height 793 -ErrorAction SilentlyContinue
    }

    # WeChat
    if ($wc_p = Get-Process -Name 'WeChat' -ErrorAction SilentlyContinue) {
        $wc_w = Select-UIElement -PID $wc_p.Id -WindowName '微信' -ControlType Window
        $wc_w | Invoke-Transform.Move -x 923 -y 106 -ErrorAction SilentlyContinue
        $wc_w | Invoke-Transform.Resize -width 1000 -height 788 -ErrorAction SilentlyContinue
    }

    # WXWork
    if ($wc_p = Get-Process -Name 'WXWork' -ErrorAction SilentlyContinue) {
        $wc_w = Select-UIElement -PID $wc_p.Id -WindowName '企业微信' -ControlType Window
        $wc_w | Invoke-Transform.Move -x 923 -y 106 -ErrorAction SilentlyContinue
        $wc_w | Invoke-Transform.Resize -width 1000 -height 788 -ErrorAction SilentlyContinue
    }
}
