// dup1输出标准输入中出现次数大于1的行，前面是次数
package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	// map存储了键/值（key/value）的集合，对集合元素，提供常数时间的存、取或测试操作。键可以是任意类型，只要其值能用==运算符比较，最常见的例子是字符串；值则可以是任意类型
	// 这个例子中的键是字符串，值是整数，内置函数make创建空map
	// 从功能和实现上说，Go的map类似于Java语言中的HashMap，Python语言中的dict，Lua语言中的table，通常使用hash实现
	counts := make(map[string]int)
	input := bufio.NewScanner(os.Stdin)
	for input.Scan() {
		counts[input.Text()]++ // map中不含某个键时不用担心，首次读到新行时，等号右边的表达式counts[line]的值将被计算为其类型的零值，对于int即0
	}
	// 注意：忽略input.Err()中可能的错误
	for line, n := range counts {
		if n > 1 {
			fmt.Printf("%d\t%s\n", n, line)
		}
	}
}

/*
# go run dup1.go
wo
wo
aa
ai
ai
bjtam
bjtam
                # 这里需要按Ctrl+D退出
2       wo
2       ai
2       bjtam
*/
