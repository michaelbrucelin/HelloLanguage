# Version 0.0.1
FROM debian:10
LABEL maintainer="michaelbrucelin@gmail.com"

RUN apt-get update -y
RUN apt-get install -y gcc
RUN apt-get install -y python3 python3-dev python3-pip

RUN python3 -m pip install -U pip
RUN python3 -m pip install ipython jupyterlab
RUN python3 -m pip install numpy scipy sympy scikit-learn pandas matplotlib seaborn
RUN python3 -m pip install pillow

VOLUME /home/playground
WORKDIR /home/playground

EXPOSE 8888

ENTRYPOINT [ "jupyter", "lab", "--allow-root", "--no-browser", "--ip", "0.0.0.0", "--port", "8888" ]
