// Package geometry defines simple types for plane geometry.
package geometry

import "math"

type Point struct{ X, Y float64 }

// 普通的函数
func Distance(p, q Point) float64 {
	return math.Hypot(q.X-p.X, q.Y-p.Y)
}

// Point类型的方法
func (p Point) Distance(q Point) float64 {
	return math.Hypot(q.X-p.X, q.Y-p.Y)
}

// Path是连接多个点的直线段
type Path []Point

// Distance方法返回路径的长度
func (path Path) Distance() float64 {
	sum := 0.0
	for i := range path {
		if i > 0 {
			sum += path[i-1].Distance(path[i])
		}
	}
	return sum
}
