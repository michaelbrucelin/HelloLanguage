# Version 0.0.2
FROM debian:11
LABEL maintainer="michaelbrucelin@gmail.com"

RUN apt-get update -y && \
    apt-get install -y git curl nodejs npm && \
    apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y && \
# upgrade nodejs
    npm cache clean -f && \
    npm install -g n && \
    n stable
ENV PATH="$PATH"
RUN npm install -g npm

WORKDIR /root/
RUN git clone https://github.com/Binaryify/NeteaseCloudMusicApi.git
WORKDIR /root/NeteaseCloudMusicApi/
RUN npm install

ENV PORT=3000
EXPOSE 3000

ENTRYPOINT [ "node", "app.js" ]
