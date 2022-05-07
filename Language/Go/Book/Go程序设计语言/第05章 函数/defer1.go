// Defer1 demonstrates a deferred call being invoked during a panic.
package main

import "fmt"

func main() {
	f(3)
}

func f(x int) {
	fmt.Printf("f(%d)\n", x+0/x) // panics if x == 0
	defer fmt.Printf("defer %d\n", x)
	f(x - 1)
}

/*
go run defer1.go
> f(3)
> f(2)
> f(1)
> defer 1
> defer 2
> defer 3
> panic: runtime error: integer divide by zero
>
> goroutine 1 [running]:
> main.f(0x4b4268?)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer1.go:11 +0x114
> main.f(0x1)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer1.go:13 +0xf6
> main.f(0x2)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer1.go:13 +0xf6
> main.f(0x3)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer1.go:13 +0xf6
> main.main()
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer1.go:7 +0x1e
> exit status 2
*/
