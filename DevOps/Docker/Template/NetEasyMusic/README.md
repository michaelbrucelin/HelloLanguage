# 网易云音乐打卡机

网易云音乐自动打卡机，用来刷歌。  
使用项目：[https://github.com/Binaryify/NeteaseCloudMusicApi](https://github.com/Binaryify/NeteaseCloudMusicApi)  
API说明：[https://neteasecloudmusicapi.vercel.app/#/?id=neteasecloudmusicapi](https://neteasecloudmusicapi.vercel.app/#/?id=neteasecloudmusicapi)

## TODO

1. Linux任务自动打卡。

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

## 运行服务

```bash
docker pull michaelbrucelin/wymusic
docker run -d -p 3000:3000 --name mymusic michaelbrucelin/wymusic
```

## 客户机环境

```bash
apt-get install curl jq moreutils
yum install curl jq moreutils
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

## 每天自动签到、听歌打卡

需要修改脚本中的账号与密码。

TODO

1. 检验登录状态，如果没有登录，重新登录。
2. 通过`/user/level`接口自动计算，当刷到300时，跳出循环。

```bash
# 脚本在Debian11 bash v5.1.4(1)测试可用
mkdir -p /root/PlayGround/wymusic && cd /root/PlayGround/wymusic/
wget https://raw.githubusercontent.com/michaelbrucelin/HelloLanguage/main/DevOps/Docker/Template/NetEasyMusic/wymusic.sh

# 在CentOS7中设置例行任务
echo 'CRON_TZ=Asia/Shanghai' >> /var/spool/cron/root
echo '08 08 * * * /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --qiandao | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 08 * * 1 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 09 * * 2 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 10 * * 3 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 11 * * 4 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 12 * * 5 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 13 * * 6 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 14 * * 7 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 15 * * 1 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 16 * * 2 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 17 * * 3 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 18 * * 4 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 19 * * 5 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 20 * * 6 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
echo '18 21 * * 7 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/root
# systemctl start crond.service

# 在Debian11中设置例行任务
# echo '???=Asia/Shanghai' >> /var/spool/cron/crontabs/root  # Debian 11中测试没通过，手动计算时间吧
echo '08 08 * * * /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --qiandao | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 08 * * 1 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 09 * * 2 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 10 * * 3 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 11 * * 4 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 12 * * 5 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 13 * * 6 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 14 * * 7 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 15 * * 1 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 16 * * 2 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 17 * * 3 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 18 * * 4 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 19 * * 5 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 20 * * 6 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
echo '18 21 * * 7 /usr/bin/bash /root/PlayGround/wymusic/wymusic.sh --daka | /usr/bin/ts >> /root/PlayGround/wymusic/log.txt 2>&1' >> /var/spool/cron/crontabs/root
# systemctl start cron.service
```

## 手动签到、听歌打卡

逻辑：获取每日推荐的歌单，通过歌单id获取歌单内的歌曲id，遍历播放。  
需要修改脚本中的账号与密码。

```bash
# 脚本在CentOS7 bash v4.2.46(2)测试可用
curl -c ./cookiefile 'http://127.0.0.1:3000/login/cellphone?phone=13812345678&md5_password=675053bf6403c0a4531a65ac09717226' | jq
curl -b ./cookiefile 'http://127.0.0.1:3000/daily_signin?type=0' | jq

lists=$(curl -b ./cookiefile 'http://127.0.0.1:3000/recommend/resource' | jq '.recommend[].id' | xargs)
IFS=' ' read -r -a listarr <<< ${lists}   # 播放每日推荐的歌曲
# declare -a listarr=("id1" "id2" "id3")  # 播放指定歌单的歌曲
declare -i i=0
for list in "${listarr[@]}"; do
    # 据说每天上限300首，这里每个歌单只获取310首
    songs=$(curl -b ./cookiefile 'http://127.0.0.1:3000/playlist/track/all?id='"${list}"'&limit=310' | jq '.songs[].id' | xargs)
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
