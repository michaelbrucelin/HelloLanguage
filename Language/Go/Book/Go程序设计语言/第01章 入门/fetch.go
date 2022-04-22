// fetch输入从URL获取的内容
package main

import (
	"fmt"
	"io/ioutil"
	"net/http"
	"os"
)

func main() {
	for _, url := range os.Args[1:] {
		resp, err := http.Get(url)
		if err != nil {
			fmt.Fprintf(os.Stderr, "fetch: %v\n", err)
			os.Exit(1)
		}
		b, err := ioutil.ReadAll(resp.Body)
		resp.Body.Close()
		if err != nil {
			fmt.Fprintf(os.Stderr, "fetch: reading %s: %v\n", url, err)
			os.Exit(1)
		}
		fmt.Printf("%s", b)
	}
}

/*
# 获取一个网页的内容
go run fetch.go http://gopl.io
> <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
>           "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
> <html xmlns="http://www.w3.org/1999/xhtml">
> <head>
> ... ...
> </td>
> </tr></table>
> </body>
> </html>

# 获取一个不存在的网页
go run fetch.go http://gopl1234567890.io
> fetch: Get "http://gopl1234567890.io": dial tcp: lookup gopl1234567890.io on 1.2.4.8:53: no such host
> exit status 1
*/
