# Version 0.0.1
FROM debian:10
LABEL maintainer="michaelbrucelin@gmail.com"

RUN apt-get update -y
RUN apt-get install -y sudo vim wget curl gcc cmake git

# python3
RUN apt-get install -y python3 python3-dev python3-pip
RUN python3 -m pip install --upgrade pip
RUN python3 -m pip install ipython jupyterlab
RUN python3 -m pip cache purge

# python2
RUN apt-get install -y python python-pip
RUN python2 -m pip install --upgrade pip
RUN python2 -m pip install ipykernel
RUN python2 -m pip cache purge

# set default python
RUN ln -sf /usr/bin/python3 /usr/bin/python
RUN ln -sf /usr/local/bin/pip3 /usr/local/bin/pip

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

# Go
RUN wget https://dl.google.com/go/go1.17.5.linux-amd64.tar.gz
RUN rm -rf /usr/local/go && tar -C /usr/local -xzf go1.17.5.linux-amd64.tar.gz
ENV PATH="${PATH}:/usr/local/go/bin"
RUN rm -f go1.17.5.linux-amd64.tar.gz
# Go Jupyter
# RUN go env -w GOPROXY=https://goproxy.cn,direct  # Depends on the specific situation
RUN env GO111MODULE=on go get github.com/gopherdata/gophernotes
RUN mkdir -p ~/.local/share/jupyter/kernels/gophernotes
WORKDIR /root/.local/share/jupyter/kernels/gophernotes/
RUN cp "$(go env GOPATH)"/pkg/mod/github.com/gopherdata/gophernotes@v0.7.3/kernel/*  "."
RUN chmod +w ./kernel.json  # in case copied kernel.json has no write permission
RUN sed "s|gophernotes|$(go env GOPATH)/bin/gophernotes|" < kernel.json.in > kernel.json
WORKDIR /root/

# Java
RUN apt-get install -y default-jdk
# Java Jupyter
RUN git clone https://github.com/SpencerPark/IJava.git
WORKDIR /root/IJava/
RUN ./gradlew installKernel
WORKDIR /root/

# Assembly
RUN python3 -m pip install emu86
RUN python3 -m kernels.intel.install

# Bash
RUN python3 -m pip install bash_kernel
RUN python3 -m bash_kernel.install

# R
RUN apt-get install -y r-base r-base-dev
RUN Rscript -e 'install.packages("IRkernel")'
RUN Rscript -e 'IRkernel::installspec()'
# Jupyter plugin(for RStudio’s shortcuts: https://github.com/IRkernel/IRkernel)
RUN jupyter labextension install @techrah/text-shortcuts

# Julia
RUN wget https://julialang-s3.julialang.org/bin/linux/x64/1.7/julia-1.7.0-linux-x86_64.tar.gz
RUN rm -rf /usr/local/julia && tar -C /usr/local -xzf julia-1.7.0-linux-x86_64.tar.gz
RUN mv /usr/local/julia-1.7.0/ /usr/local/julia/
RUN rm -f julia-1.7.0-linux-x86_64.tar.gz
ENV PATH="$PATH:/usr/local/julia/bin"
# Julia Jupyter
RUN julia -e 'using Pkg; Pkg.add("IJulia")'

# NodeJS
RUN apt-get install -y nodejs npm
RUN npm cache clean -f
RUN npm install -g n
RUN n stable
ENV PATH="$PATH"
RUN npm install -g npm
# NodeJs Jupyter
RUN npm install -g --unsafe-perm ijavascript
RUN ijsinstall --install=global

# Ruby
RUN apt-get install -y libtool libffi-dev ruby ruby-dev make
RUN gem update --system
RUN gem install rake
RUN gem install iruby
RUN iruby register --force

# clean cache
RUN apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y

VOLUME /home/playground
WORKDIR /home/playground/

EXPOSE 8888

ENTRYPOINT [ "jupyter", "lab", "--allow-root", "--no-browser", "--ip", "0.0.0.0", "--port", "8888" ]
