// outline使用递归遍历所有HTML文本中的节点树，并输出树的结构。
// 当递归遇到每个元素时，它都会将元素标签压入栈，然后输出栈。
package main

import (
	"fmt"
	"os"

	"golang.org/x/net/html"
)

func main() {
	doc, err := html.Parse(os.Stdin)
	if err != nil {
		fmt.Fprintf(os.Stderr, "outline: %v\n", err)
		os.Exit(1)
	}
	outline(nil, doc)
}

func outline(stack []string, n *html.Node) {
	if n.Type == html.ElementNode {
		stack = append(stack, n.Data) // 把标签压入栈
		fmt.Println(stack)
	}
	for c := n.FirstChild; c != nil; c = c.NextSibling {
		outline(stack, c)
	}
}

/*
curl https://go.dev | go run outline.go
> [html]
> [html head]
> [html head link]
> [html head script]
> [html head meta]
> [html head meta]
> ... ...
> [html body footer script]
*/
