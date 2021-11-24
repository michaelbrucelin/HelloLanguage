# Docker用于持续集成

## 构建Docker-Jenkins镜像

```bash
docker build -t mlin/dockerjenkins .
# ... ...
# Successfully built 2956c85daeef
# Successfully tagged mlin/dockerjenkins:latest
```

## 运行Docker-Jenkins镜像

`--privileged`标志可以启动`Docker`的特权模式，这是让我们可以在`Docker`中运行`Docker`必要的魔法。

让`Docker`运行在`--privileged`特权模式会有一些安全风险。在这种模式下运行容器对`Docker`宿主机拥有`root`访问权限。  
确保已经对`Docker`宿主机进行了恰当的安全保护，并且只在确实可信的域里使用特权访问`Docker`宿主机，或者仅在有类似信任的情况下运行容器。

```bash
docker run -p 8080:8080 --name jenkins --privileged -d mlin/dockerjenkins
# 055c3caf897f3cc4efbe3345557d723e89ac9bb29e2e72d9c6a69422e2d04725
```

## 检查Jenkins的启动和执行

先检查Docker Jenkins容器的日志，直至出现第一次使用的密码，然后在浏览器中打开[http://ip:8080](http://ip:8080)，输入那个密码即可。

```bash
# 检查Docker Jenkins容器的日志
docker logs -f jenkins
# Running from: /usr/share/jenkins/jenkins.war
# webroot: EnvVars.masterEnvVars.get("JENKINS_HOME")
# 2021-11-24 00:26:50.488+0000 [id=1]     INFO    org.eclipse.jetty.util.log ... ...
# ... ...
# Jenkins initial setup is required. An admin user has been created and a password generated.
# Please use the following password to proceed to installation:
# 
# 214275d247194bd5b973546aab1ff7cc
# 
# This may also be found at: /var/jenkins_home/secrets/initialAdminPassword
# ... ...
```

## 创建新的Jenkins作业
