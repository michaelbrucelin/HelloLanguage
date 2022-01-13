# Jupyterlab With Docker

## some to say

A simple (redundant) jupyterlab mirror for learning and testing various development languages.  
This mirroring is not perfect, please correct me(michaelbrucelin@gmail.com), thanks very much.

## Dockerfile

[https://github.com/michaelbrucelin/HelloLanguage/tree/main/DevOps/Docker/Template/JupyterLab](https://github.com/michaelbrucelin/HelloLanguage/tree/main/DevOps/Docker/Template/JupyterLab)

## how to use

```bash
docker pull michaelbrucelin/jupyterlab:
docker run -d -p 8888:8888 --name mylab -v /PATH/TO/CODE:/home/playground michaelbrucelin/jupyterlab
```
