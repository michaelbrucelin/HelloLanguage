module Sequences                   # Begin a new module
  def self.fromtoby(from, to, by)  # A singleton method of the module
    x = from
    while x <= to
      yield x
      x += by
    end
  end
end

=begin
如果只关心迭代器方法，可以指定以一个迭代器方法，而没必要定义整个类。
为了避免迭代器方法成为一个全局函数，这里将其定义在只属于它自己的模块中。

Sequences.fromtoby(1, 10, 2) {|x| print x }  # Prints "13579"
=end
