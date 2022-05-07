// The urlvalues command demonstrates a map type with methods.
package main

/*
package url

// Values maps a string key to a list of values.
type Values map[string][]string

// Get returns the first value associated with the given key,
// or "" if there are none.
func (v Values) Get(key string) string {
	if vs := v[key]; len(vs) > 0 {
		return vs[0]
	}
	return ""
}

// Add adds the value to key.
// It appends to any existing values associated with key.
func (v Values) Add(key, value string) {
	v[key] = append(v[key], value)
}
*/

import (
	"fmt"
	"net/url"
)

func main() {
	m := url.Values{"lang": {"en"}} // 直接构造
	m.Add("item", "1")
	m.Add("item", "2")

	fmt.Println(m.Get("lang")) // "en"
	fmt.Println(m.Get("q"))    // ""
	fmt.Println(m.Get("item")) // "1"      (第一个值)
	fmt.Println(m["item"])     // "[1 2]"  (直接访问map)

	m = nil
	fmt.Println(m.Get("item")) // ""
	m.Add("item", "3")         // panic（宕机）: 赋值给空的map类型
}
