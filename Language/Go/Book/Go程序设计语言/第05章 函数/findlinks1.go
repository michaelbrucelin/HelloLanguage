// findlinks1输出从标准输入中读入的HTML文档中所有链接
package main

import (
	"fmt"
	"os"

	"golang.org/x/net/html"
)

func main() {
	doc, err := html.Parse(os.Stdin)
	if err != nil {
		fmt.Fprintf(os.Stderr, "findlinks1: %v\n", err)
		os.Exit(1)
	}
	for _, link := range visit(nil, doc) {
		fmt.Println(link)
	}
}

// visit函数会将n节点中的每个链接添加到结果中
func visit(links []string, n *html.Node) []string {
	if n.Type == html.ElementNode && n.Data == "a" {
		for _, a := range n.Attr {
			if a.Key == "href" {
				links = append(links, a.Val)
			}
		}
	}
	for c := n.FirstChild; c != nil; c = c.NextSibling {
		links = visit(links, c) // 递归
	}
	return links
}

/*
go get golang.org/x/net/html

curl https://go.dev | go run findlinks1.go
> /
> /solutions/
> /learn/
> /doc/
> https://pkg.go.dev
> /play/
> /blog/
> ... ...
> https://google.com

go run findlinks1.go
<div class="s_tab_inner">
    <b class="cur-tab">网页</b>
    <a href="https://www.baidu.com/s?rtt=1&bsst=1&cl=2&tn=news" wdfield="word" sync="true" class="s-tab-item s-tab-news">资讯</a>
    <a href="http://v.baidu.com/v?ct=301989888&rn=20&pn=0&db=0&s=25&ie=utf-8" wdfield="word" class="s-tab-item s-tab-video">视频</a>
    <a href="http://image.baidu.com/i?tn=baiduimage&ps=1&ct=201326592&lm=-1&cl=2&nc=1&ie=utf-8" wdfield="word" class="s-tab-item s-tab-pic">图片</a>
    <a href="http://zhidao.baidu.com/q?ct=17&pn=0&tn=ikaslist&rn=10&fr=wwwt" wdfield="word" class="s-tab-item s-tab-zhidao">知道</a>
    <a href="http://wenku.baidu.com/search?lm=0&od=0&ie=utf-8" wdfield="word" class="s-tab-item s-tab-wenku">文库</a>
    <a href="http://tieba.baidu.com/f?fr=wwwt" wdfield="kw" class="s-tab-item s-tab-tieba">贴吧</a>
    <a href="https://map.baidu.com/?newmap=1&ie=utf-8&s=s" class="s-tab-item s-tab-map">地图</a>
    <a href="https://b2b.baidu.com/s?fr=wwwt" wdfield="q" class="s-tab-item s-tab-b2b">采购</a>
    <a href="http://www.baidu.com/more/" class="s-tab-item s-tab-more">更多</a>
</div>https://www.baidu.com/s?rtt=1&bsst=1&cl=2&tn=news
[Ctrl+D]

> http://v.baidu.com/v?ct=301989888&rn=20&pn=0&db=0&s=25&ie=utf-8
> http://image.baidu.com/i?tn=baiduimage&ps=1&ct=201326592&lm=-1&cl=2&nc=1&ie=utf-8
> http://zhidao.baidu.com/q?ct=17&pn=0&tn=ikaslist&rn=10&fr=wwwt
> http://wenku.baidu.com/search?lm=0&od=0&ie=utf-8
> http://tieba.baidu.com/f?fr=wwwt
> https://map.baidu.com/?newmap=1&ie=utf-8&s=s
> https://b2b.baidu.com/s?fr=wwwt
> http://www.baidu.com/more/
*/

/*
package html

type Node struct {
	Type                    NodeType
	Data                    string
	Attr                    []Attribute
	FirstChild, NextSibling *Node
}

type NodeType int32

const (
	ErrorNode NodeType = iota
	TextNode
	DocumentNode
	ElementNode
	CommentNode
	DoctypeNode
)

type Attribute struct {
	Key, Val string
}

func Parse(r io.Reader) (*Node, error)
*/
