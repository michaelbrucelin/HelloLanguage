// echo4输出其命令行参数
package main

import (
	"flag"
	"fmt"
	"strings"
)

// 变量n与var是指针变量
var n = flag.Bool("n", false, "omit trailing newline") // flag.Bool()函数将创建一个Boolean类型的标志参数变量，包含命令行标志参数对应的参数名、默认值、和描述信息。
var sep = flag.String("s", " ", "separator")           // flag.String()函数将创建一个对应字符串类型的标志参数变量，同样包含命令行标志参数对应的参数名、默认值、和描述信息。

func main() {
	flag.Parse()                               // flag.Parse()函数，用于更新每个标志参数对应变量的值（之前是默认值）。
	fmt.Print(strings.Join(flag.Args(), *sep)) // 非标志参数的普通命令行参数可以通过调用flag.Args()函数来访问，返回值对应一个字符串类型的slice。
	if !*n {
		fmt.Println()
	}
}

/*
go run echo4.go a bb  ccc    dddd
> a bb ccc dddd

go run echo4.go -s / a bb  ccc    dddd
> a/bb/ccc/dddd

go run echo4.go -n a bb  ccc    dddd
> a bb ccc dddd#

go run echo4.go -help
> Usage of /tmp/go-build3850544051/b001/exe/echo4:
>   -n    omit trailing newline
>   -s string
>         separator (default " ")
*/
