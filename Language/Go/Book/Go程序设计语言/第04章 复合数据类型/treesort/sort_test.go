// 利用二叉树实现插入排序
package treesort_test

import (
	"math/rand"
	"sort"
	"testing"

	"./treesort"
)

func TestSort(t *testing.T) {
	data := make([]int, 50)
	for i := range data {
		data[i] = rand.Int() % 50
	}
	treesort.Sort(data)
	if !sort.IntsAreSorted(data) {
		t.Errorf("not sorted: %v", data)
	}
}
