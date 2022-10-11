# 递归查找所有文件夹，并添加权限
# 场景：将一块装有操作系统的磁盘，挂载到另一台电脑上，想要删除磁盘上原C盘的文件，但是删不掉，需要将当前用户设置为有文件夹的全部权限，才可以删除文件夹
# MyAdd-AccessRule -dir C:\Windows -identity DOMAIN\USER

function MyAdd-AccessRule() {
    param(
        [Parameter(Mandatory = $true)]
        [string]$dir,                   # $dir = 'C:\Users\Public\'
        [Parameter(Mandatory = $true)]
        [string]$identity               # $identity = 'BUILTIN\User'
    )

    $rights = 'FullControl'                           # Other options: [enum]::GetValues('System.Security.AccessControl.FileSystemRights')
    $inheritance = 'ContainerInherit, ObjectInherit'  # Other options: [enum]::GetValues('System.Security.AccessControl.Inheritance')
    $propagation = 'None'                             # Other options: [enum]::GetValues('System.Security.AccessControl.PropagationFlags')
    $type = 'Allow'                                   # Other options: [enum]::GetValues('System.Securit y.AccessControl.AccessControlType')
    $ACE = New-Object System.Security.AccessControl.FileSystemAccessRule($identity, $rights, $inheritance, $propagation, $type)

    # Get-ChildItem $dir -Directory -Recurse | Select-Object -ExcludeProperty FullName | ForEach-Object {
    Get-ChildItem $dir -Directory -Recurse | ForEach-Object {
            $ACL = Get-Acl -Path $_.FullName
            $ACL.AddAccessRule($ACE)
            Set-Acl -Path $_.FullName -AclObject $ACL
            Write-Host "$_.FullName is done."
        }
}
