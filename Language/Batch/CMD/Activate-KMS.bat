rem KMS Key获取链接：https://docs.microsoft.com/zh-cn/windows-server/get-started/kmsclientkeys

rem 激活命令
rem 每个命令执行后都会有一个弹窗，等弹窗出来后再执行下一个命令

rem 以管理员身份打开cmd
slmgr.vbs /upk              rem 卸载当前密钥
slmgr /ipk XXXXX-XXXXX-XXXXX-XXXXX-XXXXX    rem 指定新密钥，这不可以省略？
slmgr /skms your.kms.org    rem 指定KMS服务器
slmgr /ato                  rem 激活
slmgr /xpr                  rem 检查激活状态
slmgr /dlv                  rem 查看注册信息
