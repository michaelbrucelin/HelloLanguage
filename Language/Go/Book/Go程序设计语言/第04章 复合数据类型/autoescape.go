// Autoescape demonstrates automatic HTML escaping in html/template.
package main

import (
	"html/template"
	"log"
	"os"
)

func main() {
	const templ = `<p>A: {{.A}}</p><p>B: {{.B}}</p>`
	t := template.Must(template.New("escape").Parse(templ))
	var data struct {
		A string        // 不受信任的纯文本
		B template.HTML // 受信任的HTML
	}
	data.A = "<b>Hello!</b>"
	data.B = "<b>Hello!</b>"
	if err := t.Execute(os.Stdout, data); err != nil {
		log.Fatal(err)
	}
}

/*
go run autoescape.go
> <p>A: &lt;b&gt;Hello!&lt;/b&gt;</p><p>B: <b>Hello!</b></p>

go run autoescape.go > autoescape.html
*/
