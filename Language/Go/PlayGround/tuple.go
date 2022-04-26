package main

func main() {
	x, y := 1, 2
	x, y = y, x // go中可以直接这样交换两个变量，与python一样（python用元组实现的，不清楚go是不是也用的元组）
}

// 这样赋值可以是代码更加优雅，例如：

// 求最大公约数
func gcd(x, y int) int {
	for y != 0 {
		x, y = y, x%y
	}
	return x
}

// 求斐波那契数列
func fib(n int) int {
	x, y := 0, 1
	for i := 0; i < n; i++ {
		x, y = y, x+y
	}
	return x
}
