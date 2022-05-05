// Issuesreport prints a report of issues matching the search terms.
package main

import (
	"log"
	"os"
	"text/template"
	"time"

	"./github"
)

// 有jsp与asp.net的味道了，也可以理解为有简单逻辑的动态拼接字符串的技术
const templ = `{{.TotalCount}} issues:
{{range .Items}}----------------------------------------
Number: {{.Number}}
User:   {{.User.Login}}
Title:  {{.Title | printf "%.64s"}}
Age:    {{.CreatedAt | daysAgo}} days
{{end}}`

func daysAgo(t time.Time) int {
	return int(time.Since(t).Hours() / 24)
}

var report = template.Must(template.New("issuelist").
	Funcs(template.FuncMap{"daysAgo": daysAgo}).
	Parse(templ))

func main() {
	result, err := github.SearchIssues(os.Args[1:])
	if err != nil {
		log.Fatal(err)
	}
	if err := report.Execute(os.Stdout, result); err != nil {
		log.Fatal(err)
	}
}

func noMust() {
	report, err := template.New("report").
		Funcs(template.FuncMap{"daysAgo": daysAgo}).
		Parse(templ)
	if err != nil {
		log.Fatal(err)
	}
	result, err := github.SearchIssues(os.Args[1:])
	if err != nil {
		log.Fatal(err)
	}
	if err := report.Execute(os.Stdout, result); err != nil {
		log.Fatal(err)
	}
}

/*
go run issuesreport.go repo:golang/go is:open json decoder
> 63 issues:
> ----------------------------------------
> Number: 48298
> User:   dsnet
> Title:  encoding/json: add Decoder.DisallowDuplicateFields
> Age:    237 days
> ----------------------------------------
> Number: 42571
> User:   dsnet
> Title:  encoding/json: clarify Decoder.InputOffset semantics
> Age:    538 days
> ... ...
> ----------------------------------------
> Number: 33835
> User:   Qhesz
> Title:  encoding/json: unmarshalling null into non-nullable golang types
> Age:    982 days
*/
