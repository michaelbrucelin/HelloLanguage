// Defer2 demonstrates a deferred call to runtime.Stack during a panic.
package main

import (
	"fmt"
	"os"
	"runtime"
)

func main() {
	defer printStack()
	f(3)
}

func printStack() {
	var buf [4096]byte
	n := runtime.Stack(buf[:], false)
	os.Stdout.Write(buf[:n])
}

func f(x int) {
	fmt.Printf("f(%d)\n", x+0/x) // panics if x == 0
	defer fmt.Printf("defer %d\n", x)
	f(x - 1)
}

/*
go run defer2.go
> f(3)
> f(2)
> f(1)
> defer 1
> defer 2
> defer 3
> goroutine 1 [running]:
> main.printStack()
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:17 +0x39
> panic({0x489820, 0x51aef0})
>         /usr/local/go/src/runtime/panic.go:838 +0x207
> main.f(0x4b4318?)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:22 +0x114
> main.f(0x1)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:24 +0xf6
> main.f(0x2)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:24 +0xf6
> main.f(0x3)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:24 +0xf6
> main.main()
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:12 +0x45
> panic: runtime error: integer divide by zero
>
> goroutine 1 [running]:
> main.f(0x4b4318?)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:22 +0x114
> main.f(0x1)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:24 +0xf6
> main.f(0x2)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:24 +0xf6
> main.f(0x3)
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:24 +0xf6
> main.main()
>         /root/GithubProjects/HelloLanguage/Language/Go/Book/Go程序设计语言/第05章 函数/defer2.go:12 +0x45
> exit status 2
*/
