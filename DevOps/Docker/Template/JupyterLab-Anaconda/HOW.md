# JupyterLab in Dcoker

使用`Anaconda`构建的`JupyterLab`多语言环境。  
使用原生`python3-pip`安装的`jupyterlab`，但是`.net`(`C#`/`F#`/`PowerShell`)，`Q#`均使用`Anaconda`，其他的语言扩展还没测试，  
考虑到`jupyter`只是自己用来学习测试的环境，这里使用`Anaconda`重新构建JupyterLab。

## TODO

- 配置密码
- 常用配置，自动补全）等
- 配置`.net`, `C`, `go`等多语言环境
- 为每一种语言配置`hello world`示例文件

```bash
docker build -t michaelbrucelin/jupyterlab .

docker run -d -p 8888:8888 --name mylab michaelbrucelin/jupyterlab

docker logs mylab  # 查看登录的token
```
