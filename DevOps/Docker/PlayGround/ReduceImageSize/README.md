# 减小Docker镜像

## 初始镜像

通过一些手段，减小Docker镜像的体积，使用的基础镜像是centos:centos7。

```bash
docker pull centos:centos7
# centos7: Pulling from library/centos
# 2d473b07cdd5: Pull complete 
# Digest: sha256:c73f515d06b0fa07bb18d8202035e739a494ce760aa73129f60f4bf2bd22b407
# Status: Downloaded newer image for centos:centos7
# docker.io/library/centos:centos7

docker images
# REPOSITORY   TAG       IMAGE ID       CREATED        SIZE
# centos       centos7   eeb6ee3f44bd   5 months ago   204MB
```

## 通过清除yum缓存来减小镜像

### 没有清除yum缓存

```bash
docker build -t micha/centos7-basic -f Dockerfile_basic .
docker images
# REPOSITORY            TAG       IMAGE ID       CREATED          SIZE
# micha/centos7-basic   latest    0aedca87f240   45 seconds ago   359MB
```

### 清除yum缓存

```bash
docker build -t micha/centos7-yumcache .
docker images
# REPOSITORY               TAG       IMAGE ID       CREATED          SIZE
# micha/centos7-yumcache   latest    f3f263c5e47c   12 seconds ago   228MB
```

## 通过--squash来减小镜像

目前`--squash`还处于实验阶段，没有测试。
