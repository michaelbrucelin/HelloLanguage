// The squares program demonstrates a function value with state.
package main

import "fmt"

// squares函数返回一个函数，后者包含下一次要用到的平方数
// the next square number each time it is called.
func squares() func() int {
	var x int
	return func() int {
		x++
		return x * x
	}
}

func main() {
	// 函数变量类似与使用闭包方法实现的变量，Go程序员通常把函数变量称为闭包
	f := squares()
	fmt.Println(f()) // "1"
	fmt.Println(f()) // "4"
	fmt.Println(f()) // "9"
	fmt.Println(f()) // "16"
}
