# Jupyterlab With Docker

## some to say

A simple (redundant) jupyterlab mirror for learning and testing various development languages.  
This mirroring is not perfect, please correct me(michaelbrucelin@gmail.com), thanks very much.

## Dockerfile

[https://github.com/michaelbrucelin/HelloLanguage/tree/main/DevOps/Docker/Template/JupyterLab](https://github.com/michaelbrucelin/HelloLanguage/tree/main/DevOps/Docker/Template/JupyterLab)

## why two tags

The reason for making two tags: `nocpp` and `cpp` is because the `cpp` version integrates the C++ is too big.  
The C++ environment is [https://github.com/root-project/cling](https://github.com/root-project/cling), but this environment increases the size of the entire image by 47.5GB, I just did the installation instructions as follows:  

```bash
WORKDIR /usr/local
RUN wget https://raw.githubusercontent.com/root-project/cling/master/tools/packaging/cpt.py
RUN chmod +x cpt.py
RUN /bin/bash -c '/bin/echo -e "yes" | ./cpt.py --check-requirements && ./cpt.py --create-dev-env Debug --with-workdir=./cling-build/'; exit 0
ENV PATH="${PATH}:/usr/local/cling-build/builddir/bin"
WORKDIR /usr/local/cling-build/cling-src/tools/cling/tools/Jupyter/kernel
RUN python3 -m pip install -e .
RUN jupyter-kernelspec install cling-cpp17
RUN jupyter-kernelspec install cling-cpp1z
RUN jupyter-kernelspec install cling-cpp14
RUN jupyter-kernelspec install cling-cpp11
```

Even though it’s just a test container, I don’t care about the size of the image that much, but 47.5GB is still too big. I don’t know how to reduce the size of the image, so I made two versions.  
If anyone knows How to solve this problem, please advise, `michaelbrucelin@gmail.com`, thanks very much.

## how to use

```bash
docker pull michaelbrucelin/jupyterlab:[no]cpp
docker run -d -p 8888:8888 --name mylab -v /PATH/TO/CODE:/home/playground michaelbrucelin/jupyterlab:[no]cpp
```
