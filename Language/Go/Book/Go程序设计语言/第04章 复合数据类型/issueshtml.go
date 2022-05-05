// Issueshtml prints an HTML table of issues matching the search terms.
package main

import (
	"log"
	"os"

	"html/template"

	"./github"
)

// 有jsp与asp.net的味道了，也可以理解为有简单逻辑的动态拼接字符串的技术
var issueList = template.Must(template.New("issuelist").Parse(`
<h1>{{.TotalCount}} issues</h1>
<table>
<tr style='text-align: left'>
  <th>#</th>
  <th>State</th>
  <th>User</th>
  <th>Title</th>
</tr>
{{range .Items}}
<tr>
  <td><a href='{{.HTMLURL}}'>{{.Number}}</a></td>
  <td>{{.State}}</td>
  <td><a href='{{.User.HTMLURL}}'>{{.User.Login}}</a></td>
  <td><a href='{{.HTMLURL}}'>{{.Title}}</a></td>
</tr>
{{end}}
</table>
`))

func main() {
	result, err := github.SearchIssues(os.Args[1:])
	if err != nil {
		log.Fatal(err)
	}
	if err := issueList.Execute(os.Stdout, result); err != nil {
		log.Fatal(err)
	}
}

/*
go run issueshtml.go repo:golang/go commenter:gopherbot json encoder > issueshtml.html
go run issueshtml.go repo:golang/go commenter:gopherbot json encoder

> <h1>66 issues</h1>
> <table>
> <tr style='text-align: left'>
>   <th>#</th>
>   <th>State</th>
>   <th>User</th>
>   <th>Title</th>
> </tr>
>
> <tr>
>   <td><a href='https://github.com/golang/go/issues/7872'>7872</a></td>
>   <td>open</td>
>   <td><a href='https://github.com/extemporalgenome'>extemporalgenome</a></td>
>   <td><a href='https://github.com/golang/go/issues/7872'>encoding/json: Encoder internally buffers full output</a></td>
> </tr>
>
> <tr>
>   <td><a href='https://github.com/golang/go/issues/5901'>5901</a></td>
>   <td>open</td>
>   <td><a href='https://github.com/rsc'>rsc</a></td>
>   <td><a href='https://github.com/golang/go/issues/5901'>encoding/json: allow per-Encoder/per-Decoder registration of marshal/unmarshal functions</a></td>
> </tr>
>
> ... ...
>
> <tr>
>   <td><a href='https://github.com/golang/go/issues/34235'>34235</a></td>
>   <td>closed</td>
>   <td><a href='https://github.com/wI2L'>wI2L</a></td>
>   <td><a href='https://github.com/golang/go/issues/34235'>encoding/json: marshaling a zero value encoding.TextMarshaler interface struct field panics</a></td>
> </tr>
>
> </table>
*/
