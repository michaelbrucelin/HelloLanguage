# 网易云音乐打卡机

网易云音乐自动打卡机，用来刷歌。  
使用项目：[https://github.com/Binaryify/NeteaseCloudMusicApi](https://github.com/Binaryify/NeteaseCloudMusicApi)  
API说明：[https://neteasecloudmusicapi.vercel.app/#/?id=neteasecloudmusicapi](https://neteasecloudmusicapi.vercel.app/#/?id=neteasecloudmusicapi)

## TODO

1. 获取歌单
2. 获取歌单所有歌曲
3. 播放
4. 达到刷歌的目的

## 镜像与容器

```bash
docker build -t michaelbrucelin/wymusic -f Dockerfile .

# 备份到dockerhub
docker login
docker push michaelbrucelin/wymusic
docker logout

# 备份到网盘
# 使用http服务（可以使用python内建的http server）供网盘离线下载
docker save -o /root/wymusic.docker.tar michaelbrucelin/wymusic
docker load < /root/wymusic.docker.tar

docker run -d -p 3000:3000 --name mymusic michaelbrucelin/wymusic
```

## 客户机环境

```bash
apt-get install curl jq
yum install curl jq
```

## 常用接口

```bash
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

# 获取用户等级信息
# 可以获取用户等级信息，包含当前登录天数、听歌次数、下一等级需要的登录天数和听歌次数、当前等级进度，对应：https://music.163.com/#/user/level
curl -b ./cookiefile 'http://127.0.0.1:3000/user/level' | jq
curl -b ./cookiefile 'http://127.0.0.1:3000/user/level' | jq | grep -v info

# 签到
# 貌似Android与web/PC不支持同时签到，而且Android签到积分更多
curl -b ./cookiefile 'http://127.0.0.1:3000/daily_signin?type=0' | jq  # Android签到，可以忽略type=0
curl -b ./cookiefile 'http://127.0.0.1:3000/daily_signin?type=1' | jq  # web/PC签到

# 获取每日推荐歌单
curl -b ./cookiefile 'http://127.0.0.1:3000/recommend/resource' | jq
curl -b ./cookiefile 'http://127.0.0.1:3000/recommend/resource' | jq '.recommend[].id'

# 获取每日推荐歌曲
curl -b ./cookiefile 'http://127.0.0.1:3000/recommend/songs' | jq

# 获取歌单所有歌曲
curl -b ./cookiefile 'http://127.0.0.1:3000/playlist/track/all?id=24381616&limit=310' | jq
curl -b ./cookiefile 'http://127.0.0.1:3000/playlist/track/all?id=24381616&limit=310' | jq '.songs[].id'

# 听歌打卡
# 必选参数：id: 歌曲 id, sourceid: 歌单或专辑 id
# 可选参数：time: 歌曲播放时间, 单位为秒
curl -b ./cookiefile 'http://127.0.0.1:3000/scrobble?id=3920358&sourceid=24381616&time=256'
```

## 听歌打卡

逻辑：获取每日推荐的歌单，通过歌单id获取歌单内的歌曲id，遍历播放。  

TODO

1. 检验登录状态，如果没有登录，重新登录。
2. 播放指定歌单的歌曲。
3. 通过`/user/level`接口自动计算，当刷到300时，跳出循环。

```bash
curl -c ./cookiefile 'http://127.0.0.1:3000/login/cellphone?phone=13812345678&md5_password=675053bf6403c0a4531a65ac09717226' | jq
curl -b ./cookiefile 'http://127.0.0.1:3000/daily_signin?type=0' | jq

lists=$(curl -b ./cookiefile 'http://127.0.0.1:3000/recommend/resource' | jq '.recommend[].id')
IFS=' ' read -r -a listarr <<< ${lists}
declare -i i=0
for list in "${listarr[@]}"; do
    # 据说每天上限300首，这里每个歌单只获取310首
    songs=$(curl -b ./cookiefile 'http://127.0.0.1:3000/playlist/track/all?id=24381616&limit=310' | jq '.songs[].id')
    IFS=' ' read -r -a songarr <<< ${songs}
    for song in "${songarr[@]}"; do
        echo $((++i))
        time=$((128 + 1 + $RANDOM % 128))  # random 129~256
        curl -b ./cookiefile 'http://127.0.0.1:3000/scrobble?id='"${song}"'&sourceid='"${list}"'&time='"${time}"
        sleep 1s
        echo
    done
done
```
