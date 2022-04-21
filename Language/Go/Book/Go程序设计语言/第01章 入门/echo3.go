package main

import (
	"fmt"
	"os"
	"strings"
)

func main() {
	fmt.Println(strings.Join(os.Args[1:], " "))
}

/*
# go run echo3.go aa bb  cc    dd
aa bb cc dd
*/
