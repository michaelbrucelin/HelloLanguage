# Version 0.0.1
FROM debian
LABEL maintainer="michaelbrucelin@gmail.com"

RUN apt-get update -y
RUN apt-get install -y git nodejs npm

WORKDIR /root/
RUN git clone https://github.com/Binaryify/NeteaseCloudMusicApi.git
WORKDIR /root/NeteaseCloudMusicApi/
RUN npm install

RUN apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y

ENV PORT=3000
EXPOSE 3000

ENTRYPOINT [ "node", "app.js" ]
