function MyGet-RandomTime() {
    # TODO 工作中时常需要获取随机时间，拟定一个函数，获取随机时间，未完成
    foreach ($i in 1..10) {
        Get-Date (Get-Date -Hour 09 -Minute 00 -Second 00).AddMinutes($(Get-Random -Minimum 0 -Maximum 180)) -UFormat "%H:%M"
    }
}