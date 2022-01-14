# Jupyterlab With Docker

## some to say

A simple (redundant) jupyterlab mirror for learning and testing various development languages.  
This mirroring is not perfect, please correct me(michaelbrucelin@gmail.com), thanks very much.

## integrated development language

- Python3
- .Net(C#)
- .Net(F#)
- .Net(PowerShell)
- Bash
- C
- C++11
- C++14
- C++17
- C++1z
- Go
- Intel
- Java
- JavaScript(Node.js)
- Julia
- Lua
- PHP
- Q#
- R
- Ruby

## how to use

```bash
docker pull michaelbrucelin/jupyterlab
docker run -d -p 8888:8888 --name mylab -v /PATH/TO/CODE:/home/playground michaelbrucelin/jupyterlab
```

## Dockerfile

[https://raw.githubusercontent.com/michaelbrucelin/HelloLanguage/main/DevOps/Docker/Template/JupyterLab/Dockerfile](https://raw.githubusercontent.com/michaelbrucelin/HelloLanguage/main/DevOps/Docker/Template/JupyterLab/Dockerfile)

## more info

[https://github.com/michaelbrucelin/HelloLanguage/tree/main/DevOps/Docker/Template/JupyterLab](https://github.com/michaelbrucelin/HelloLanguage/tree/main/DevOps/Docker/Template/JupyterLab)
