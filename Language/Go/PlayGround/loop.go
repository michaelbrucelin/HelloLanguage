package main

import "fmt"

func main() {
	// for 是 go 语言中唯一的循环语句，使用方式与其他语言差不多
	for i := 0; i < 10; i++ {
		fmt.Print(i)
	}
	fmt.Println()

	// 使用 for 模拟传统的 while 循环
	ii := 0
	for ii < 10 {
		fmt.Print(ii)
		ii++
	}
	fmt.Println()

	// 使用 for 模拟传统的无限循环
	jj := 0
	for {
		if jj >= 10 {
			break
		}
		fmt.Print(jj)
		jj++
	}
	fmt.Println()

	// for循环的另一种形式，在某种数据类型的区间（range）上遍历，如字符串或切片。
	// 类似于C#中的foreach循环
}

/*
# go run loop.go
0123456789
0123456789
0123456789
*/
