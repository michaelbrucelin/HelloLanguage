// 包github提供了GitHub issue跟踪接口的Go API
// 详细查看 https://developer.github.com/v3/search/#search-issues
package github

import "time"

const IssuesURL = "https://api.github.com/search/issues"

type IssuesSearchResult struct {
	TotalCount int `json:"total_count"`
	Items      []*Issue
}

type Issue struct {
	Number    int
	HTMLURL   string `json:"html_url"`
	Title     string
	State     string
	User      *User
	CreatedAt time.Time `json:"created_at"`
	Body      string    // Markdown格式
}

type User struct {
	Login   string
	HTMLURL string `json:"html_url"`
}
