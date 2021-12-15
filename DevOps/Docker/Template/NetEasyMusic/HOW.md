# 网易云音乐打卡机

网易云音乐自动打卡机，用来刷歌。  
使用项目：[https://github.com/Binaryify/NeteaseCloudMusicApi](https://github.com/Binaryify/NeteaseCloudMusicApi)。

```bash
docker build -t mlin/wymusic -f Dockerfile .
docker run -d -p 3000:3000 --name mymusic mlin/wymusic

# login
curl 'http://127.0.0.1:3000/login/cellphone?phone=15040611035&md5_password=675053bf6403c0a4531a65ac09717226'
```
