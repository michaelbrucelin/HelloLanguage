# JupyterLab in Dcoker

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
