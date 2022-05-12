--[[
在lua中，函数是一种“第一类值”，它们具有特定的词法域（Lexical Scoping）。
“第一类值”表示在lua中函数与传统类型的值（数字、字符串等）具有相同的权利。
    函数可以存储在变量中（无论全局变量还是局部变量）或table中，也可以作为实参传递给其它函数，还可以作为其它函数的返回值。
“词法域”表示一个函数可以嵌套在另一个函数中，内部的函数可以访问外部函数的变量。

在lua中，函数与其他所有值（数字、字符串等）一样都是匿名的，即它们都没有名称。
当讨论一个函数时（例如print），实际上是在讨论一个持有某函数的变量，这与其它变量持有各种值是一个道理。

function foo (x) return 2*x end    -- 这种写法只是一种语法糖，是下面写法的简写而已
foo = function (x) return 2*x end  -- 这种写法是本质，所以说函数在lua中是值
--]]

a = { p = print }        --
a.p("Hello World!")      --> Hello World!
print = math.sin         -- 'print'现在引用了正弦函数
a.p(print(math.pi / 2))  --> 1.0
sin = a.p                -- 'sin'现在引用了print函数
sin(10, 20)              --> 10      20

--[[
lua depinfunc.lua
> Hello World!
> 1.0
> 10      20
--]]
