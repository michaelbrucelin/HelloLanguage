# 网易云音乐打卡机

网易云音乐自动打卡机，用来刷歌。  
使用项目：[https://github.com/Binaryify/NeteaseCloudMusicApi](https://github.com/Binaryify/NeteaseCloudMusicApi)  
API说明：[https://neteasecloudmusicapi.vercel.app/#/?id=neteasecloudmusicapi](https://neteasecloudmusicapi.vercel.app/#/?id=neteasecloudmusicapi)

## TODO

1. 获取歌单
2. 获取歌单所有歌曲
3. 播放
4. 达到刷歌的目的

```bash
docker build -t mlin/wymusic -f Dockerfile .
docker run -d -p 3000:3000 --name mymusic mlin/wymusic

# 登录
# 建议使用手机号+md5密码登录的方式，邮箱账号是整个的网易通行证，范围太大。
curl -c ./cookiefile 'http://127.0.0.1:3000/login/cellphone?phone=13812345678&md5_password=675053bf6403c0a4531a65ac09717226' | jq

# 查看登录状态
curl -b ./cookiefile 'http://127.0.0.1:3000/login/status'

# 刷新登录
curl -b ./cookiefile 'http://127.0.0.1:3000/login/refresh'

# 获取用户详情
curl -b ./cookiefile 'http://127.0.0.1:3000/user/detail?uid=447977471' | jq

# 获取账号信息
curl -b ./cookiefile 'http://127.0.0.1:3000/user/account' | jq
```
