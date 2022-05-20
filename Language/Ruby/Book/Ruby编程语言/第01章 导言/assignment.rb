# ruby中有与python中类似的元组赋值语法
x, y = 1, 2          # Same as x = 1; y = 2
a, b = b, a          # Swap the value of two variables
x, y, z = [1, 2, 3]  # Array elements automatically assigned to variables

# 使用元组函数返回多个值
def polar(x, y)
  theta = Math.atan2(y, x)  # Compute the angle
  r = Math.hypot(x, y)      # Compute the distance
  [r, theta]                # The last expression is the return value
end

distance, angle = polar(2, 2)

# 以（=）结尾的方法比较特殊，因为ruby允许以赋值操作的语法来调用它们。
# 假设一个对象o拥有一个叫做x=的方法，那么下面两行代码是等价的：
o.x = (1)  # Normal method invocation syntax
o.x = 1    # Method invocation through assignment

=begin
在前面我们已经看到名称以 = 结尾的方法可以通过赋值调用表达式。
ruby方法也可以以问号或感叹号结尾。
问号用于标记谓词——返回布尔值的方法。
例如，Array和Hash类都定义了名为empty?的方法，那个测试数据结构是否有任何元素。
结尾的感叹号方法名称用于指示使用该方法时需要谨慎。
许多核心ruby类定义了具有相同名称的方法对，除了一个以感叹号结尾，一个没有。
通常，该方法没有感叹号返回调用它的对象的修改副本，并且带有感叹号的是一种改变对象的方法。
例如，Array类定义了方法sort和 sort!。

除了方法名称末尾的这些标点符号之外，您还会注意到ruby变量名开头的标点符号：
全局变量有前缀$，实例变量以@为前缀，类变量以@@为前缀。
这些前缀可能需要一点时间来适应，但过一段时间你可能会习惯感谢前缀告诉您变量的范围这一事实。
前缀是为了消除ruby非常灵活的语法的歧义。一种思考方式可变前缀是我们为能够省略括号而付出的一个代价围绕方法调用。
=end