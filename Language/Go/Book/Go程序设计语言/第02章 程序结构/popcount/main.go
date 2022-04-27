package popcount

// pc[i]是i的种群统计
var pc [256]byte

func init() {
	for i := range pc {
		pc[i] = pc[i/2] + byte(i&1)
	}
}

// PopCount返回x的种群统计（置位的个数）
func PopCount(x uint64) int {
	return int(pc[byte(x>>(0*8))] +
		pc[byte(x>>(1*8))] +
		pc[byte(x>>(2*8))] +
		pc[byte(x>>(3*8))] +
		pc[byte(x>>(4*8))] +
		pc[byte(x>>(5*8))] +
		pc[byte(x>>(6*8))] +
		pc[byte(x>>(7*8))])
}

/*
上面的代码定义了一个PopCount函数，用于返回一个数字中含二进制1bit的个数。
它使用init初始化函数来生成辅助表格pc，pc表格用于处理每个8bit宽度的数字含二进制的1bit的bit个数，这样的话在处理64bit宽度的数字时就没有必要循环64次，只需要8次查表就可以了。
这并不是最快的统计1bit数目的算法，但是它可以方便演示init函数的用法，并且演示了如何预生成辅助表格，这是编程中常用的技术。

就是用空间换时间。
func init() {
	for i := range pc {
		pc[i] = pc[i/2] + byte(i&1)
	}
}
这个函数用来初始化pc，其中pc[i] = pc[i/2] + byte(i&1)，有递归的味道（从0向上，不是递归），
它充分利用了二进制的规律，统计一个二进制中1的个数，先把这个二进制拆成2两部分，最后一位与前面的所有位，最后一位就是pc[i/2]，已经知道结果了，最后一位就是byte(i&1)，也好计算，直接把O(n)降为O(1)。

对于pc这类需要复杂处理的初始化，可以通过将初始化逻辑包装为一个匿名函数处理，像下面这样：
var pc [256]byte = func() (pc [256]byte) {
    for i := range pc {
        pc[i] = pc[i/2] + byte(i&1)
    }
    return
}()
*/
