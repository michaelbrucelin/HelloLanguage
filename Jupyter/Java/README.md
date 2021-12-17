# 启动JupyterLab(Java)

## 1. 安装依赖

- Python 3.6 or later
- Jupyter Notebook
- Java JDK >= 9

```bash
apt-get install default-jdk
java --version
# openjdk 11.0.12 2021-07-20
# OpenJDK Runtime Environment (build 11.0.12+7-post-Debian-2deb10u1)
# OpenJDK 64-Bit Server VM (build 11.0.12+7-post-Debian-2deb10u1, mixed mode, sharing)

java --list-modules | grep "jdk.jshell"
# jdk.jshell@11.0.12
```

## 2. 查看jupyterlab支持的kernel

```bash
jupyter kernelspec list
Available kernels:
  python3    /usr/local/share/jupyter/kernels/python3
```

## 3. 安装Java Kernel

```bash
git clone https://github.com/SpencerPark/IJava.git
cd IJava/
./gradlew installKernel
```

## 4. 再次确认

```bash
jupyter kernelspec list
Available kernels:
  java               /root/.local/share/jupyter/kernels/java
  python3            /usr/local/share/jupyter/kernels/python3
```

[说明: https://github.com/SpencerPark/IJava](https://github.com/SpencerPark/IJava)
