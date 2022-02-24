# Asterisk13镜像制作

```bash
docker build -t michaelbrucelin/asterisk:13 .

docker run -d -p 25678:5060 -p 10000-20000:10000-20000/udp --name asterisk13 \
           -v ... .... \
           michaelbrucelin/asterisk:13
```
