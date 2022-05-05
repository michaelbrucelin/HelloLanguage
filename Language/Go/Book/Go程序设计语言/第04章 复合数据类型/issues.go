// 将符合搜索条件的issue输出为一个表格
package main

import (
	"fmt"
	"log"
	"os"

	"./github"
)

func main() {
	result, err := github.SearchIssues(os.Args[1:])
	if err != nil {
		log.Fatal(err)
	}
	fmt.Printf("%d issues:\n", result.TotalCount)
	for _, item := range result.Items {
		fmt.Printf("#%-5d %9.9s %.55s\n",
			item.Number, item.User.Login, item.Title)
	}
}

/*
go run issues.go repo:golang/go is:open json decoder
> 63 issues:
> #48298     dsnet encoding/json: add Decoder.DisallowDuplicateFields
> #42571     dsnet encoding/json: clarify Decoder.InputOffset semantics
> #11046     kurin encoding/json: Decoder internally buffers full input
> #43716 ggaaooppe encoding/json: increment byte counter when using decode
> #5901        rsc encoding/json: allow per-Encoder/per-Decoder registrati
> #34543  maxatome encoding/json: Unmarshal & json.(*Decoder).Token report
> #48950 Alexander encoding/json: calculate correct SyntaxError.Offset in
> #36225     dsnet encoding/json: the Decoder.Decode API lends itself to m
> #26946    deuill encoding/json: clarify what happens when unmarshaling i
> #29035    jaswdr proposal: encoding/json: add error var to compare  the
> #32779       rsc encoding/json: memoize strings during decode
> #40128  rogpeppe proposal: encoding/json: garbage-free reading of tokens
> #43401  opennota encoding/csv: add Reader.InputOffset method
> #31701    lr1980 encoding/json: second decode after error impossible
> #28923     mvdan encoding/json: speed up the decoding scanner
> #51734  mdempsky cmd/compile: cleanup code paths that aren't needed now
> #40982   Segflow encoding/json: use different error type for unknown fie
> #16212 josharian encoding/json: do all reflect work before decoding
> #6647    btracey x/tools/cmd/godoc: display type kind of each named type
> #41144 alvaroale encoding/json: Unmarshaler breaks DisallowUnknownFields
> #14750 cyberphon encoding/json: parser ignores the case of member names
> #40127  rogpeppe encoding/json: add Encoder.EncodeToken method
> #34564  mdempsky go/internal/gcimporter: single source of truth for deco
> #48277 Windsooon encoding/json: add an example for InputOffset() functio
> #33854     Qhesz encoding/json: unmarshal option to treat omitted fields
> #28143    arp242 proposal: encoding/json: add "readonly" tag
> #48646    piersy encoding/json: unclear documentation for how `json.Unma
> #22752  buyology proposal: encoding/json: add access to the underlying d
> #43513 Alexander encoding/json: add line number to SyntaxError
> #33835     Qhesz encoding/json: unmarshalling null into non-nullable gol
*/
