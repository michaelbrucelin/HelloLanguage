// dup2打印输入中多次出现的行的个数和文本，它从stdin或指定的文件列表读取
// 流式操作
package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	counts := make(map[string]int)
	files := os.Args[1:]
	if len(files) == 0 {
		countLines(os.Stdin, counts)
	} else {
		for _, arg := range files {
			f, err := os.Open(arg)
			if err != nil {
				fmt.Fprintf(os.Stderr, "dup2: %v\n", err)
				continue
			}
			countLines(f, counts)
			f.Close()
		}
	}
	for line, n := range counts {
		if n > 1 {
			fmt.Printf("%d\t%s\n", n, line)
		}
	}
}

// 这里counts map[string]int是值传递，传递的是map引用的一个拷贝，与Java传递引用类型变量的机制相同
func countLines(f *os.File, counts map[string]int) {
	input := bufio.NewScanner(f)
	for input.Scan() { // 逐行读取，流式操作
		counts[input.Text()]++
	}
	// 注意：忽略input.Err()中可能的错误
}
