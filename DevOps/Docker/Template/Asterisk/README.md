# Asterisk13镜像

## 镜像制作

```bash
docker build -t michaelbrucelin/asterisk:13 .
```

## 运行

```bash
docker network create mybridge --subnet=172.18.0.0/16

docker run -d --name myasterisk \
           --net mybridge --ip 172.18.0.18
           -p 25678:5060/tcp -p 25678:5060/udp -p 10000-20000:10000-20000/udp \
           -v /var/log/asterisk:/var/log/asterisk -v /etc/asterisk:/etc/asterisk \
           michaelbrucelin/asterisk:13
```
