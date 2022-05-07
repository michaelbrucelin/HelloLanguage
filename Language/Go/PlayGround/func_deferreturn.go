package main

import "fmt"

func returnButDefer() (t int) { // t初始化0，并且作用域为该函数全域
	defer func() {
		t = t * 10
	}()

	return 2
}

func main() {
	fmt.Println(returnButDefer())
}

/*
go run func_deferreturn.go
> 20
*/
