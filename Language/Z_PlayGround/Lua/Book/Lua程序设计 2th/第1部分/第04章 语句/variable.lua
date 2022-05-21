a, b = 10, 20               -- 与python一样的元组赋值的用法
print("a =", a, "b =", b)
a, b = b, a
print("a =", a, "b =", b)   -- 与python一样的元组交换变量的用法
print()

a, b, c = 0, 1
print(a, b, c)              --> 0 1 nil
a, b = a + 1, b + 1, b + 2  -- value of b+2 is ignored
print(a, b)                 --> 1 2
a, b, c = 0                 -- 不要想成是c = 0，a, b = nil了
print(a, b, c)              --> 0 nil nil
print()

j = 10       -- 全局变量
local i = 1  -- 局部变量

x = 10
local i = 1          -- 程序块中的局部变量
while i <= x do
    local x = i * 2  -- while循环体中的局部变量
    print(x)         --> 2, 4, 6, 8, ...
    i = i + 1
end
print()

if i > 20 then
    local x          -- then中的局部变量
    x = 20
    print(x + 2)     -- 如果测试成功会打印22
else
    print(x)         --> 10 (全局变量)
end
print(x)             --> 10 (全局变量)

--[[
lua variable.lua
a =     10      b =     20
a =     20      b =     10

0       1       nil
1       2
0       nil     nil

2
4
6
8
10
12
14
16
18
20

10
10
--]]