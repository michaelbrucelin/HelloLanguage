# Version 0.0.1
FROM debian:11
LABEL maintainer="michaelbrucelin@gmail.com"

RUN apt-get update -y
RUN apt-get install -y git nodejs npm

# upgrade nodejs
RUN npm cache clean -f
RUN npm install -g n
RUN n stable
ENV PATH="$PATH"
RUN npm install -g npm

WORKDIR /root/
RUN git clone https://github.com/Binaryify/NeteaseCloudMusicApi.git
WORKDIR /root/NeteaseCloudMusicApi/
RUN npm install

RUN apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y

ENV PORT=3000
EXPOSE 3000

ENTRYPOINT [ "node", "app.js" ]
