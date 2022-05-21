#!/usr/bin/ruby

# square定义在类或模块（module）之外，所以是一个全局函数（从技术上讲，也会成为Object类的私有方法）
def square(x)
  x * x  # 方法中最后一个被执行的表达式就是方法的返回值
end

# square定义在类或模块（module）之内，所以是一个方法
# ruby的类和模块是“开放的”，可以在运行时对其修改和扩展
def Math.square(x) # Define a class method of the Math module
  x * x
end
