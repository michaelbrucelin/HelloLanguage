// echo1输出其命令行参数，go语言习惯在一个包声明之前使用注释从整体角度对程序做个描述。
package main

// 可以这样导入多个包，包导入顺序并不重要，gofmt工具格式化时按照字母顺序对包名排序。
import (
	"fmt"
	"os"
)

func main() {
	var s, sep string // 声明两个string类型的变量，如果变量在声明是没有被赋初值，string类型会默认被赋值为空字符串""，而不是null。
	// 符号 := 用于短变量声明（short variable declaration），这种语句声明一个或多个变量并根据初始化的值为这些变量赋予适当的类型。
	// go中的 i++ 是语句，而不是像其它C家族语言中的表达式，所以 j = i++ 非法，而且go中只有 i++，没有 ++i。
	for i := 1; i < len(os.Args); i++ {
		s += sep + os.Args[i]
		sep = " " // 在这里（循环内部）赋值，只是为了简化处理最后（或最前）的空格，对性能无益。这个问题在echo3.go中被解决。
	}
	fmt.Println(s)
}

/*
# go run echo1.go aa bb  cc    dd
aa bb cc dd
*/
