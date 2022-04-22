// fetchall并发获取URL并报告它们的时间和大小
package main

import (
	"fmt"
	"io"
	"io/ioutil"
	"net/http"
	"os"
	"time"
)

func main() {
	start := time.Now()
	ch := make(chan string)
	for _, url := range os.Args[1:] {
		go fetch(url, ch) // 启动一个goroutine
	}
	for range os.Args[1:] {
		fmt.Println(<-ch) // 从通道ch接收
	}
	fmt.Printf("%.2fs elapsed\n", time.Since(start).Seconds())
}

func fetch(url string, ch chan<- string) {
	start := time.Now()
	resp, err := http.Get(url)
	if err != nil {
		ch <- fmt.Sprint(err) // 发送到通道ch
		return
	}

	nbytes, err := io.Copy(ioutil.Discard, resp.Body)
	resp.Body.Close() // 不要泄露资源
	if err != nil {
		ch <- fmt.Sprintf("while reading %s: %v", url, err)
		return
	}
	secs := time.Since(start).Seconds()
	ch <- fmt.Sprintf("%.2fs  %7d  %s", secs, nbytes, url)
}

/*
Go语言最有意思并且最新奇的特性就是对并发编程的支持。
这个例子fetchall和前面小节的fetch程序所要做的工作基本一致，fetchall的特别之处在于它会同时去获取所有的URL，所以这个程序的总执行时间不会超过执行时间最长的那一个任务，前面的fetch程序执行时间则是所有任务执行时间之和。
fetchall程序只会打印获取的内容大小和经过的时间，不会像之前那样打印获取的内容。

go run fetchall.go https://golang.org http://gopl.io https://godoc.org
> 0.14s     6852  https://godoc.org
> 0.16s     7261  https://golang.org
> 0.48s     2475  http://gopl.io
> 0.48s elapsed

go run fetchall.go https://baidu.com https://cn.bing.com https://bing.com https://ifeng.com https://taobao.com
> 0.20s   351680  https://baidu.com
> 0.38s    74108  https://cn.bing.com
> 0.44s   367736  https://ifeng.com
> 0.56s    74122  https://bing.com
> 0.63s    86153  https://taobao.com
> 0.63s elapsed

go run fetchall.go https://baidu.com https://cn.bing.com https://bing.com https://ifeng.com https://taobao.com
> 0.20s   355440  https://baidu.com
> 0.48s   367736  https://ifeng.com
> 0.57s    86153  https://taobao.com
> 0.70s    74141  https://cn.bing.com
> 0.81s    74142  https://bing.com
> 0.81s elapsed

go run fetchall.go https://baidu.com https://cn.bing.com https://bing.com https://ifeng.com https://taobao.com
> 0.20s   355155  https://baidu.com
> 0.31s   367736  https://ifeng.com
> 0.58s    86153  https://taobao.com
> 0.78s    74141  https://cn.bing.com
> 0.80s    74142  https://bing.com
> 0.80s elapsed
*/
