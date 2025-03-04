# Asterisk13镜像

## 镜像制作

```bash
docker build -t michaelbrucelin/asterisk:13 .
```

## 运行

```bash
docker network create mybridge --subnet=172.18.0.0/16 --gateway 172.18.0.1

docker pull michaelbrucelin/asterisk:13

tmpid=$(docker create michaelbrucelin/asterisk:13)
docker cp $tmpid:/etc/asterisk/ /etc/
docker cp $tmpid:/var/log/asterisk/ /var/log/
docker rm -v $tmpid

docker run -d --name myasterisk \
           --net mybridge --ip 172.18.0.18 \
           -p 15678:5060/tcp -p 15678:5060/udp -p 10000-10099:10000-10099/udp \
           -v /etc/asterisk:/etc/asterisk -v /var/log/asterisk:/var/log/asterisk \
           michaelbrucelin/asterisk:13
```

## 查看日志

```bash
docker logs -f --tail 10 myasterisk
```
