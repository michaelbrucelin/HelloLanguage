local a, b = 1, 10
if a < b then
    print(a)  --> 1     全局变量
    local a   -- 具有隐式的'= nil'
    print(a)  --> nil   局部变量
end           -- then块至此结束
print(a, b)   --> 1 10  全局变量
print()

-- 下面是lua中的一种惯用法
-- 在代码块中创建局部变量，并使用全局变量为其初始化，这样有两点好处：
--     1. 可以保证其它函数改变了全局变量的值不影响当前代码块（假定这事你想要的效果）
--     2. 而且还可以加速当前作用域对foo的访问（访问局部变量比全局变量更快？）
foo = "bar"          -- 全局变量
while (1 == 1) do
    local foo = foo  -- 局部变量
    print(foo)
end