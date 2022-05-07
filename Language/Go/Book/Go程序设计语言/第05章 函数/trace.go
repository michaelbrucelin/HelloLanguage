// The trace program uses defer to add entry/exit diagnostics to a function.
package main

import (
	"log"
	"time"
)

func bigSlowOperation() {
	defer trace("bigSlowOperation")() // 别忘记这对圆括号
	// ...这里是一些慢操作...
	time.Sleep(10 * time.Second) // 通过休眠仿真慢操作
}

func trace(msg string) func() {
	start := time.Now()
	log.Printf("enter %s", msg)
	return func() { log.Printf("exit %s (%s)", msg, time.Since(start)) }
}

func main() {
	bigSlowOperation()
}

/*
go run trace.go
2022/05/07 05:51:46 enter bigSlowOperation
2022/05/07 05:51:56 exit bigSlowOperation (10.009184896s)
*/
