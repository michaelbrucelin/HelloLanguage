// 函数nonempty可以从给定的一个字符串列表中去除空字符串并返回一个新的slice
package main

import "fmt"

// 函数nonempty可以从给定的一个字符串列表中去除空字符串并返回一个新的slice
// nonempty演示了slice的就地修改算法，在函数的调用过程中，底层数组的元素发生了改变
func nonempty(strings []string) []string {
	i := 0
	for _, s := range strings {
		if s != "" {
			strings[i] = s
			i++
		}
	}
	return strings[:i]
}

func main() {
	data := []string{"one", "", "three"}
	fmt.Printf("%q\n", nonempty(data)) // `["one" "three"]`
	fmt.Printf("%q\n", data)           // `["one" "three" "three"]`
}

func nonempty2(strings []string) []string {
	out := strings[:0] // 引用原始slice的新的零长度slice
	for _, s := range strings {
		if s != "" {
			out = append(out, s)
		}
	}
	return out
}
