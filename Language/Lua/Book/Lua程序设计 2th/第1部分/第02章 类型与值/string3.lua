-- 字符串自动转为数字
print("10" + 1)        --> 11
print("10 + 1")        --> 10 + 1
print("-5.3e-10"*"2")  --> -1.06e-09
-- print("hello" + 1)  -- ERROR (不能转换"hello")
print()

-- 数字自动转为字符串
print(10 .. 20)        --> 1020
print()

-- 最好还是不要依赖于自动转换，如果需要转换，还是手动转换可靠
-- 将字符串转换为数字
line = io.read()    -- 读取一行
n = tonumber(line)  -- 尝试将它转换为一个数字
if n == nil then
    error(line .. " is not a valid number")
else
    print(n*2)
end
print()

-- 将数字转换为字符串
print(tostring(10) == "10")  --> true
print(10 .. "" == "10")      --> true
print()

-- 获取字符串长度，start with v5.1
a = "hello"
print(#a)            --> 5
print(#"good\0bye")  --> 8

--[[
lua string3.lua
> 11
> 10 + 1
> -1.06e-09
> 
> 1020
> 
> 1024
> 2048
> 
> true
> true
> 
> 5
> 8
--]]