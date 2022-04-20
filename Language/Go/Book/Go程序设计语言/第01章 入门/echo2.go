// echo2输出其命令行参数
package main

import (
	"fmt"
	"os"
)

func main() {
	s, sep := "", "" // 很像python中的元祖赋值方式
	// os.Args[1:]的使用方式类似于python中的切片
	for _, arg := range os.Args[1:] {
		s += sep + arg
		sep = " "
	}
	fmt.Println(s)
}

/*
# go run echo2.go aa bb  cc    dd
aa bb cc dd
*/
