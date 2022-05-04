// embed演示了结构体字面量的两种初始化方式
package main

import "fmt"

type Point struct{ X, Y int }

type Circle struct {
	Point
	Radius int
}

type Wheel struct {
	Circle
	Spokes int
}

func main() {
	var w Wheel
	// 第一种初始化方式
	w = Wheel{Circle{Point{8, 8}, 5}, 20}

	// 第二种初始化方式
	w = Wheel{
		Circle: Circle{
			Point:  Point{X: 8, Y: 8},
			Radius: 5,
		},
		Spokes: 20, // 注意，尾部的逗号是必须的（Radius后面的逗号也一样）
	}

	fmt.Printf("%#v\n", w)
	// 输出
	// Wheel{Circle:Circle{Point:Point{X:8, Y:8}, Radius:5}, Spokes:20}

	w.X = 42

	fmt.Printf("%#v\n", w)
	// 输出
	// Wheel{Circle:Circle{Point:Point{X:42, Y:8}, Radius:5}, Spokes:20}
}
