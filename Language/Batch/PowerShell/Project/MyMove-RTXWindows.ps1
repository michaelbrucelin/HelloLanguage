# Install-Module -Name Wasp

function MyMove-RTXWindows() {
    $modules = Get-Module
    if (!$modules.Name.Contains('Wasp')) {
        $execplcy = Get-ExecutionPolicy
        Set-ExecutionPolicy RemoteSigned -Force
        Import-Module Wasp
        Set-ExecutionPolicy $execplcy -Force
    }

    if ($rtx_p = Get-Process -Name rtx -ErrorAction SilentlyContinue) {
        $rtx_w = Select-UIElement -PID $rtx_p.Id -ControlType Window
        $rtx_w | Invoke-Transform.Move -x 1160 -y 108 -ErrorAction SilentlyContinue
        $rtx_w | Invoke-Transform.Resize -width 783 -height 783 -ErrorAction SilentlyContinue
    }

    if ($em_p = Get-Process -Name E-Mobile -ErrorAction SilentlyContinue) {
        $em_w = Select-UIElement -PID $em_p.Id -WindowName E-Mobile -ControlType Window
        $em_w | Invoke-Transform.Move -x 923 -y 106 -ErrorAction SilentlyContinue
        $em_w | Invoke-Transform.Resize -width 1000 -height 788 -ErrorAction SilentlyContinue
    }

    if ($qq_p = Get-Process -Name QQ -ErrorAction SilentlyContinue) {
        $qq_w = Select-UIElement -PID $qq_p.Id -ControlType Pane | Where-Object { $_.Name -ne 'QQ' }
        $qq_w | Invoke-Transform.Move -x 1138 -y 103 -ErrorAction SilentlyContinue
        $qq_w | Invoke-Transform.Resize -width 826 -height 793 -ErrorAction SilentlyContinue
    }
}