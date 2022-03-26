FROM debian:11
LABEL maintainer="michaelbrucelin@gmail.com"
ENV REFRESHED_AT 2022-03-26

# 安装Jekyll
# RUN apt-get update -y && \
#     apt-get install -y gcc g++ make ruby-full build-essential && \
#     echo '# Install Ruby Gems to ~/gems' >> ~/.bashrc && \
#     echo 'export GEM_HOME="$HOME/gems"' >> ~/.bashrc && \
#     echo 'export PATH="$HOME/gems/bin:$PATH"' >> ~/.bashrc && \
#     source ~/.bashrc && \
#     gem install jekyll bundler && \
#     apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y
RUN apt-get update -y && \
    apt-get install -y gcc g++ make ruby-full build-essential && \
    export GEM_HOME="$HOME/gems" && \
    export PATH="$HOME/gems/bin:$PATH" && \
    gem install jekyll bundler && \
    apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y

VOLUME /data
VOLUME /var/myblog/jekyll
WORKDIR /data

ENTRYPOINT [ "jekyll", "build", "--destination=/var/mybolg/jekyll" ]