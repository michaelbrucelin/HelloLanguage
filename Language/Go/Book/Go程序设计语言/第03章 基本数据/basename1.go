// 模仿Unix shell中的同名应用程序
package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	input := bufio.NewScanner(os.Stdin)
	for input.Scan() {
		fmt.Println(basename(input.Text()))
	}
	// NOTE: ignoring potential errors from input.Err()
}

// basename移除路径部分和 . 后缀
// 例如, a => a, a.go => a, a/b/c.go => c, a/b.c.go => b.c
func basename(s string) string {
	// 将最后一个 '/' 和之前的部分全部舍弃
	for i := len(s) - 1; i >= 0; i-- {
		if s[i] == '/' {
			s = s[i+1:]
			break
		}
	}
	// 保留最后一个 '.' 之前的全部内容
	for i := len(s) - 1; i >= 0; i-- {
		if s[i] == '.' {
			s = s[:i]
			break
		}
	}
	return s
}
