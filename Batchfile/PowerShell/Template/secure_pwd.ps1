# 脚本中的密码使用方法

# 方法一
# 这种方法安全性高，但是只能在生成pwd.txt文件的机器上使用这个文件

# 1. 生成并保存密码文件
# 从键盘读取密码并将密码加密后存入文件，推荐用法
Read-Host "Enter Password" -AsSecureString | ConvertFrom-SecureString | Out-File "D:\pwd.txt"
# 将明文密码加密后存入文件
ConvertFrom-SecureString (ConvertTo-SecureString "123456" -AsPlainText -Force) | Out-File "D:\pwd.txt"

# 2. 使用密码文件创建Credential信息
$userName = "UserName"
$fpwd = "D:\pwd.txt"
$cred = New-Object -TypeName System.Management.Automation.PSCredential `
                   -ArgumentList $userName, (Get-Content $fpwd | ConvertTo-SecureString)

# 方法二
# ConvertTo-SecureString和ConvertFrom-SecureString命令都支持选项-Key。在处理密码时通过使用-Key选项可以提供额外的安全性，并且允许在不同的环境中使用密码文件。
# 通过这种方法，把pwd.txt和aes.key文件拷贝到其它的机器上也是可以工作的。但是我们需要额外维护一个key文件的安全，这一般通过设置文件的访问权限就可以了。

# 1. 先生成32位的key并保存在文件aes.key中
$keyFile = "D:\aes.key"
$key = New-Object Byte[] 32
[Security.Cryptography.RNGCryptoServiceProvider]::Create().GetBytes($key)
$key | out-file $keyFile

# 2. 使用key生成并保存密码文件
Read-Host "Enter Password" -AsSecureString | ConvertFrom-SecureString -key $key | Out-File "D:\pwd.txt"

# 3. 使用密码文件和key文件创建Credential信息
$userName = "UserName"
$pwdFile = "D:\pwd.txt"
$keyFile = "D:\aes.key"
$key = Get-Content $keyFile
$cred = New-Object -TypeName System.Management.Automation.PSCredential `
                   -ArgumentList $userName, (Get-Content $pwdFile | ConvertTo-SecureString -Key $key)
