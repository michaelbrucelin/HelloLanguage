# 字符串与base64转换
[System.Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes("SecretMessage"))
[System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String("U2VjcmV0TWVzc2FnZQ=="))