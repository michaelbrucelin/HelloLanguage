# VLMCSD for Docker

Deploy vlmcsd service on Docker container

```bash
git clone https://github.com/Wind4/vlmcsd-docker.git vlmcsd
cd vlmcsd

# Use docker-compose service
docker-compose up -d

# or docker build image
docker build -t michaelbrucelin/vlmcsd .

docker login
docker push michaelbrucelin/vlmcsd
docker logout

docker pull michaelbrucelin/vlmcsd
docker run -idt -p 1688:1688 --name myvlmcsd michaelbrucelin/vlmcsd
```
