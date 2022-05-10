-- if
if op == "+" then
    r = a + b
elseif op == "-" then
    r = a - b
elseif op == "*" then
    r = a * b
elseif op == "/" then
    r = a / b
else
    error("invalid operation")
end

-- while
local i = 1
while a[i] do
    print(a[i])
    i = i + 1
end

-- repeat
-- lua中的repeat相当于C中的do while循环，之所以没有沿用C中的do while循环，是因为在lua中，do end表示一个代码块，相当于C中的{ }
-- 打印输入的第一行不为空的内容
repeat
    line = io.read()
until line ~= ""
print(line)

-- 与其它大多数语言不同，一个声明在循环体内部的局部变量的作用域包括了条件测试部分
local sqr = x / 2
repeat
    sqr = (sqr + x / sqr) / 2
    local error = math.abs(sqr ^ 2 - x)
until error < x / 10000  -- 在此处仍然可以访问error
