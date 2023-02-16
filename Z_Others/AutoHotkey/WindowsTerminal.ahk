#HotIf WinActive("管理员: Windows PowerShell")
RButton::
{
    MsgBox "暂时停用鼠标右键。"
}

#HotIf WinActive("Administrator: PowerShell")
RButton::
{
    MsgBox "暂时停用鼠标右键。"
}

#HotIf WinActive("管理员: 命令提示符")
RButton::
{
    MsgBox "暂时停用鼠标右键。"
}
