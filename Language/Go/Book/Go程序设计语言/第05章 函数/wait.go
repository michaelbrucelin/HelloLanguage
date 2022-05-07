// The wait program waits for an HTTP server to start responding.
package main

import (
	"fmt"
	"log"
	"net/http"
	"os"
	"time"
)

// WaitForServer尝试连接URL对应的服务器
// 在一分钟内使用指数退避策略进行重试
// 所有的尝试失败后返回错误
func WaitForServer(url string) error {
	const timeout = 1 * time.Minute
	deadline := time.Now().Add(timeout)
	for tries := 0; time.Now().Before(deadline); tries++ {
		_, err := http.Head(url)
		if err == nil {
			return nil // 成功
		}
		log.Printf("server not responding (%s); retrying...", err)
		time.Sleep(time.Second << uint(tries)) // 指数退避策略
	}
	return fmt.Errorf("server %s failed to respond after %s", url, timeout)
}

func main() {
	if len(os.Args) != 2 {
		fmt.Fprintf(os.Stderr, "usage: wait url\n")
		os.Exit(1)
	}
	url := os.Args[1]
	// (In function main.)
	if err := WaitForServer(url); err != nil {
		fmt.Fprintf(os.Stderr, "Site is down: %v\n", err)
		os.Exit(1)
	}
}

/*
go run wait.go
> usage: wait url
> exit status 1

go run wait.go www.baidu.com
> 2022/05/07 02:09:16 server not responding (Head "www.baidu.com": unsupported protocol scheme ""); retrying...
> 2022/05/07 02:09:17 server not responding (Head "www.baidu.com": unsupported protocol scheme ""); retrying...
> 2022/05/07 02:09:19 server not responding (Head "www.baidu.com": unsupported protocol scheme ""); retrying...
> 2022/05/07 02:09:23 server not responding (Head "www.baidu.com": unsupported protocol scheme ""); retrying...
> 2022/05/07 02:09:31 server not responding (Head "www.baidu.com": unsupported protocol scheme ""); retrying...
> 2022/05/07 02:09:47 server not responding (Head "www.baidu.com": unsupported protocol scheme ""); retrying...
> Site is down: server www.baidu.com failed to respond after 1m0s
> exit status 1
*/
