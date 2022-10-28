<#
    查询指定文件被哪些进程打开
    相当于实现了bash中的fuser，利用了handle程序查询所有句柄，然后正则表达式过滤结果。
    1、下载handle.exe: https://docs.microsoft.com/zh-cn/sysinternals/downloads/handle
    2、解压将handle64.exe（选择32位还是64位版本）拷贝到C:\Windows\System32目录下
    3、编写powershell脚本
    4、执行，这里181017是一个文件夹
    MyGet-Handle -Name 181017
    > OfficeClickToRun.exe pid: 2440 NT AUTHORITY\SYSTEM -   1A4: File  (R--)   C:\Windows\Temp\Q1953-20160308-20181017-0701.log
    > OfficeClickToRun.exe pid: 2440 NT AUTHORITY\SYSTEM -   2B8: File  (R--)   C:\Windows\Temp\officeclicktorun.exe_streamserver(201810170
    > 70153988).log
    > explorer.exe pid: 6248 QUICKCOMGLOBAL\Q1953 -  1A30: File  (RWD)   C:\Users\Q0089\Desktop\desktop\181017
    > explorer.exe pid: 6248 QUICKCOMGLOBAL\Q1953 -  1A84: File  (RWD)   C:\Users\Q0089\Desktop\desktop\181017
    > RTX.exe pid: 5748 QUICKCOMGLOBAL\Q1953 -  1688: File  (RW-)   C:\Users\Q0089\Desktop\desktop\181017
    > OUTLOOK.EXE pid: 13380 QUICKCOMGLOBAL\Q1953 -   D54: File  (R-D)   C:\Users\Q0089\AppData\Local\Temp\Outlook Logging\Outlook-20181017
    > T1002110425.etl
#>
function global:MyGet-Handle() {
    param(
        [string]$Name
    )

    $handleOut = handle64.exe
    foreach ($line in $handleOut) {
        if ($line -match '\S+\spid:') {
            $exe = $line
        } 
        elseif ($line -match $Name) {
            "$exe - $line"
        }
    }
}
