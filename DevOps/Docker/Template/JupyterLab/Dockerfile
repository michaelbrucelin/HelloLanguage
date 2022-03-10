# Version 0.0.2
FROM debian:11
LABEL maintainer="michaelbrucelin@gmail.com"

WORKDIR /root

RUN apt-get update -y && \
    apt-get install -y sudo vim wget curl cmake gcc g++ git build-essential gdb && \
    apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y

# python3
RUN apt-get install -y python3 python3-dev python3-pip && \
    python3 -m pip install --upgrade pip && \
    python3 -m pip install ipython jupyter jupyterlab ipywidgets qtconsole && \
    python3 -m pip cache purge

# .Net core
RUN wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    rm -f packages-microsoft-prod.deb && \
    apt-get install -y apt-transport-https && apt-get update -y && apt-get install -y dotnet-sdk-3.1 dotnet-sdk-6.0 && \
ENV PATH="${PATH}:/root/.dotnet/tools"

# C#/F#/PowerShell(Prerequisite: .NET Core SDK 6.0)
RUN dotnet tool install -g Microsoft.dotnet-interactive && \
    dotnet interactive jupyter install

# Q#(Prerequisite: .NET Core SDK 3.1)
RUN dotnet tool install -g Microsoft.Quantum.IQSharp && \
    dotnet iqsharp install

# C
RUN python3 -m pip install jupyter-c-kernel && \
    install_c_kernel

# C++
RUN cd /usr/local && \
    wget https://raw.githubusercontent.com/root-project/cling/master/tools/packaging/cpt.py && \
    chmod +x cpt.py && \
    /bin/bash -c '/bin/echo -e "yes" | ./cpt.py --check-requirements && ./cpt.py --create-dev-env release --with-workdir=./cling-build/'; exit 0
# 安装Cling Kernel
ENV PATH="${PATH}:/usr/local/cling-build/builddir/bin"
RUN cd /usr/local/cling-build/cling-src/tools/cling/tools/Jupyter/kernel && \
    python3 -m pip install -e . && \
    jupyter-kernelspec install cling-cpp17 && \
    jupyter-kernelspec install cling-cpp1z && \
    jupyter-kernelspec install cling-cpp14 && \
    jupyter-kernelspec install cling-cpp11
WORKDIR /root

# Go
RUN wget https://dl.google.com/go/go1.17.6.linux-amd64.tar.gz && \
    rm -rf /usr/local/go && tar -C /usr/local -xzf go1.17.6.linux-amd64.tar.gz && \
    rm -f go1.17.6.linux-amd64.tar.gz
ENV PATH="${PATH}:/usr/local/go/bin"
# Go Jupyter
# RUN go env -w GOPROXY=https://goproxy.cn,direct  # Depends on the specific situation
RUN env GO111MODULE=on go get github.com/gopherdata/gophernotes && \
    mkdir -p ~/.local/share/jupyter/kernels/gophernotes && \
    cd /root/.local/share/jupyter/kernels/gophernotes && \
    cp "$(go env GOPATH)"/pkg/mod/github.com/gopherdata/gophernotes@v0.7.4/kernel/*  "." && \
    chmod +w ./kernel.json  # in case copied kernel.json has no write permission && \
    sed "s|gophernotes|$(go env GOPATH)/bin/gophernotes|" < kernel.json.in > kernel.json
WORKDIR /root

# Java
RUN apt-get install -y default-jdk && \
# Java Jupyter
    git clone https://github.com/SpencerPark/IJava.git && \
    cd /root/IJava && \
    ./gradlew installKernel
WORKDIR /root

# Assembly
RUN python3 -m pip install emu86 && \
    python3 -m kernels.intel.install

# Bash
RUN python3 -m pip install bash_kernel && \
    python3 -m bash_kernel.install

# NodeJS
RUN apt-get install -y nodejs npm && \
    npm cache clean -f && \
    npm install -g n && \
    n stable
ENV PATH="${PATH}"
RUN npm install -g npm && \
# NodeJs Jupyter
    npm install -g --unsafe-perm ijavascript && \
    ijsinstall --install=global

# R
RUN apt-get install -y r-base r-base-dev && \
    Rscript -e 'install.packages("IRkernel")' && \
    Rscript -e 'IRkernel::installspec()' && \
# Jupyter plugin(for RStudio’s shortcuts: https://github.com/IRkernel/IRkernel)
# need node.js and npm
    jupyter labextension install @techrah/text-shortcuts

# php
# https://github.com/Rabrennie/jupyter-php-kernel
RUN apt-get install -y php php-dev php-common php-zmq && \
    curl -sS https://getcomposer.org/installer -o composer-setup.php && \
    php composer-setup.php --install-dir=/usr/local/bin --filename=composer
ENV PATH="${PATH}:/root/.config/composer/vendor/bin"
RUN composer global require rabrennie/jupyter-php-kernel && \
    jupyter-php-kernel --install && \
    composer clearcache

# Julia
RUN wget https://julialang-s3.julialang.org/bin/linux/x64/1.7/julia-1.7.0-linux-x86_64.tar.gz && \
    rm -rf /usr/local/julia && tar -C /usr/local -xzf julia-1.7.0-linux-x86_64.tar.gz && \
    mv /usr/local/julia-1.7.0/ /usr/local/julia/ && \
    rm -f julia-1.7.0-linux-x86_64.tar.gz
ENV PATH="${PATH}:/usr/local/julia/bin"
# Julia Jupyter
RUN julia -e 'using Pkg; Pkg.add("IJulia")'

# lua
# https://github.com/guysv/ilua
RUN apt-get install -y lua5.3 && \
    python3 -m pip install ilua

# Ruby
RUN apt-get install -y libtool libffi-dev ruby ruby-dev make && \
    gem update --system && \
    gem install rake && \
    gem install iruby && \
    iruby register --force

# clean cache
RUN apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y

VOLUME /home/playground
WORKDIR /home/playground

EXPOSE 8888

ENTRYPOINT [ "jupyter", "lab", "--allow-root", "--no-browser", "--ip", "0.0.0.0", "--port", "8888" ]
