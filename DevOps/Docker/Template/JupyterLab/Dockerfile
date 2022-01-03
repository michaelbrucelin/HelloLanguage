# Version 0.0.1
FROM debian:10
LABEL maintainer="michaelbrucelin@gmail.com"

WORKDIR /root

RUN apt-get update -y
RUN apt-get install -y sudo vim wget curl cmake gcc g++ git build-essential gdb

# python3
RUN apt-get install -y python3 python3-dev python3-pip
RUN python3 -m pip install --upgrade pip
RUN python3 -m pip install ipython jupyter jupyterlab ipywidgets qtconsole
RUN python3 -m pip cache purge

# python2，Python2安装后有各种小问题，这里就不安装python2了
# RUN apt-get install -y python python-pip
# RUN python2 -m pip install --upgrade pip
# RUN python2 -m pip install ipykernel
# RUN python2 -m pip cache purge

# set default python
# RUN ln -sf /usr/bin/python3 /usr/bin/python
# RUN ln -sf /usr/local/bin/pip3 /usr/local/bin/pip
# RUN ln -sf /usr/local/bin/ipython3 /usr/local/bin/ipython

# .Net core
RUN wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN rm -f packages-microsoft-prod.deb
RUN apt-get install -y apt-transport-https && apt-get update -y && apt-get install -y dotnet-sdk-3.1 dotnet-sdk-6.0
ENV PATH="${PATH}:/root/.dotnet/tools"

# C#/F#/PowerShell(Prerequisite: .NET Core SDK 6.0)
RUN dotnet tool install -g Microsoft.dotnet-interactive
RUN dotnet interactive jupyter install

# Q#(Prerequisite: .NET Core SDK 3.1)
RUN dotnet tool install -g Microsoft.Quantum.IQSharp
RUN dotnet iqsharp install

# C
RUN python3 -m pip install jupyter-c-kernel
RUN install_c_kernel

# C++
# 编译LLVM时间太久，实在不行，可以考虑C++手动编译，然后使用docker commit提交
WORKDIR /usr/local
RUN wget https://raw.githubusercontent.com/root-project/cling/master/tools/packaging/cpt.py
RUN chmod +x cpt.py
# 自动应答yes，执行的返回值不为0，但是可以忽略，故使用exit 0来屏蔽
# RUN /bin/bash -c '/bin/echo -e "yes" | ./cpt.py --check-requirements && ./cpt.py --create-dev-env Debug --with-workdir=./cling-build/'; exit 0
RUN /bin/bash -c '/bin/echo -e "yes" | ./cpt.py --check-requirements && ./cpt.py --create-dev-env release --with-workdir=./cling-build/'; exit 0
# 安装Cling Kernel
ENV PATH="${PATH}:/usr/local/cling-build/builddir/bin"
WORKDIR /usr/local/cling-build/cling-src/tools/cling/tools/Jupyter/kernel
RUN python3 -m pip install -e .
RUN jupyter-kernelspec install cling-cpp17
RUN jupyter-kernelspec install cling-cpp1z
RUN jupyter-kernelspec install cling-cpp14
RUN jupyter-kernelspec install cling-cpp11
WORKDIR /root

# Go
RUN wget https://dl.google.com/go/go1.17.5.linux-amd64.tar.gz
RUN rm -rf /usr/local/go && tar -C /usr/local -xzf go1.17.5.linux-amd64.tar.gz
ENV PATH="${PATH}:/usr/local/go/bin"
RUN rm -f go1.17.5.linux-amd64.tar.gz
# Go Jupyter
# RUN go env -w GOPROXY=https://goproxy.cn,direct  # Depends on the specific situation
RUN env GO111MODULE=on go get github.com/gopherdata/gophernotes
RUN mkdir -p ~/.local/share/jupyter/kernels/gophernotes
WORKDIR /root/.local/share/jupyter/kernels/gophernotes
RUN cp "$(go env GOPATH)"/pkg/mod/github.com/gopherdata/gophernotes@v0.7.3/kernel/*  "."
RUN chmod +w ./kernel.json  # in case copied kernel.json has no write permission
RUN sed "s|gophernotes|$(go env GOPATH)/bin/gophernotes|" < kernel.json.in > kernel.json
WORKDIR /root

# Java
RUN apt-get install -y default-jdk
# Java Jupyter
RUN git clone https://github.com/SpencerPark/IJava.git
WORKDIR /root/IJava
RUN ./gradlew installKernel
WORKDIR /root

# Assembly
RUN python3 -m pip install emu86
RUN python3 -m kernels.intel.install

# Bash
RUN python3 -m pip install bash_kernel
RUN python3 -m bash_kernel.install

# NodeJS
RUN apt-get install -y nodejs npm
RUN npm cache clean -f
RUN npm install -g n
RUN n stable
ENV PATH="${PATH}"
RUN npm install -g npm
# NodeJs Jupyter
RUN npm install -g --unsafe-perm ijavascript
RUN ijsinstall --install=global

# R
RUN apt-get install -y r-base r-base-dev
RUN Rscript -e 'install.packages("IRkernel")'
RUN Rscript -e 'IRkernel::installspec()'
# Jupyter plugin(for RStudio’s shortcuts: https://github.com/IRkernel/IRkernel)
# need node.js and npm
RUN jupyter labextension install @techrah/text-shortcuts

# php
# 安装一直出现错误，没有解决：ERROR: Error while trying to download Jupyter-PHP dependencies with Composer.
# https://github.com/Litipk/Jupyter-PHP
# https://litipk.github.io/Jupyter-PHP-Installer/
# apt-get install -y php php-dev php-common php-zmq
# curl -sS https://getcomposer.org/installer | php
# mv composer.phar /usr/local/bin/composer
# wget https://litipk.github.io/Jupyter-PHP-Installer/dist/jupyter-php-installer.phar
# php jupyter-php-installer.phar install

# https://github.com/Rabrennie/jupyter-php-kernel
RUN apt-get install -y php php-dev php-common php-zmq
RUN curl -sS https://getcomposer.org/installer -o composer-setup.php
RUN php composer-setup.php --install-dir=/usr/local/bin --filename=composer
ENV PATH="${PATH}:/root/.config/composer/vendor/bin"
RUN composer global require rabrennie/jupyter-php-kernel
RUN jupyter-php-kernel --install
RUN composer clearcache

# Julia
RUN wget https://julialang-s3.julialang.org/bin/linux/x64/1.7/julia-1.7.0-linux-x86_64.tar.gz
RUN rm -rf /usr/local/julia && tar -C /usr/local -xzf julia-1.7.0-linux-x86_64.tar.gz
RUN mv /usr/local/julia-1.7.0/ /usr/local/julia/
RUN rm -f julia-1.7.0-linux-x86_64.tar.gz
ENV PATH="${PATH}:/usr/local/julia/bin"
# Julia Jupyter
RUN julia -e 'using Pkg; Pkg.add("IJulia")'

# lua
# https://github.com/guysv/ilua
RUN apt-get install -y lua5.3
RUN python3 -m pip install ilua

# Ruby
RUN apt-get install -y libtool libffi-dev ruby ruby-dev make
RUN gem update --system
RUN gem install rake
RUN gem install iruby
RUN iruby register --force

# clean cache
RUN apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y

VOLUME /home/playground
WORKDIR /home/playground

EXPOSE 8888

ENTRYPOINT [ "jupyter", "lab", "--allow-root", "--no-browser", "--ip", "0.0.0.0", "--port", "8888" ]
