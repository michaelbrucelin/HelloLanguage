# Version 0.0.1
FROM debian:10
LABEL maintainer="michaelbrucelin@gmail.com"

RUN apt-get update -y
RUN apt-get install -y wget curl gcc

# python3
RUN apt-get install -y python3 python3-dev python3-pip
RUN python3 -m pip install --upgrade pip
RUN python3 -m pip install ipython jupyterlab
RUN python3 -m pip install numpy scipy sympy scikit-learn pandas matplotlib seaborn
RUN python3 -m pip install pillow
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

# NodeJS
RUN apt-get install -y nodejs npm

# clean cache
RUN apt-get autoremove -y && apt-get autoclean -y && apt-get clean -y

VOLUME /home/playground
WORKDIR /home/playground

EXPOSE 8888

ENTRYPOINT [ "jupyter", "lab", "--allow-root", "--no-browser", "--ip", "0.0.0.0", "--port", "8888" ]
