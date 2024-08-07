# The Go Programming Language

This repository provides the downloadable example programs
for the book, "The Go Programming Language"; see <http://www.gopl.io>.

You can download, build, and run the programs with the following commands:

```bash
$ export GOPATH=$HOME/gobook            # choose workspace directory
                                        # export GOPATH=/root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言
$ go get gopl.io/ch1/helloworld         # fetch, build, install
$ $GOPATH/bin/helloworld                # run
> Hello, 世界
```

```bash
# add my mlin
cd /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/
go mod init The_Go_Programming_Language

# go env -w GOPROXY=https://goproxy.cn,direct
go env -w GOPROXY=https://mirrors.aliyun.com/goproxy/,direct

go env -w GO111MODULE=auto
go get golang.org/x/net/html
go get ... ...
```

Many of the programs contain comments of the form `//!+` and `//!-`.
These comments bracket the parts of the programs that are excerpted in the
book; you can safely ignore them.  In a few cases, programs
have been reformatted in an unnatural way so that they can be presented
in stages in the book.
