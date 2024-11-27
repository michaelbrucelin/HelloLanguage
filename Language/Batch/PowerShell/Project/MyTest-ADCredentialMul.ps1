# 批量测试域用户的账户和密码，用于检测公司内谁的用户没有改初始密码
function Test-ADCredential {
    param(
        $username,
        $password
    )
    
    (New-Object DirectoryServices.DirectoryEntry "", $username, $password).psbase.name -ne $null
}

# 查询用户，下面这段脚本需要在域控制器上执行
$OU = "OU=ERP,DC=quickcomglobal,DC=com"
$IgnoreUsers = @("Q0000", "Q8888", "Q9999")
# Get-ADUser -SearchBase $OU -Filter * 
$USERS = Get-ADUser -SearchBase $OU -Filter {Enabled -eq $true} -Properties DisplayName |`
    Where-Object { $_.SamAccountName -notin $IgnoreUsers } |`
    Select-Object SamAccountName, DisplayName, DistinguishedName
$PWDS = @("123qweQWE", "123qweASD", "q1w2E#R$")

# 验证用户
$Results = @()
foreach ($user in $USERS) {
    foreach ($pwd in $PWDS) {
        if (Test-ADCredential -username $user.SamAccountName -password $pwd) {
            $Results += [PSCustomObject]@{
                SamAccountName = $user.SamAccountName
                DisplayName    = $user.DisplayName
                Password       = $pwd
            }
            break
        }
    }
}

# 输出结果并保存到文件
if ($Results.Count -gt 0) {
    $Results | Format-Table -AutoSize
    # $Results | Export-Csv -Path "MatchedUsers.csv" -NoTypeInformation -Encoding UTF8
} else {
    Write-Host "没有用户匹配提供的密码。" -ForegroundColor Yellow
}
