x = math.pi
print(x % 1)           -- x的小数部分
print(x - x % 1)       -- x的整数部分
print(x - x % 0.01)    -- x精确到小数点后2位的结果
print(x - x % 0.0001)  -- x精确到小数点后4位的结果，结果为3.1415，而不是3.1416
print()

print("Hello " .. "World")  -- 连接字符串
print(0 .. 1)

--[[
lua operator.lua
> 0.14159265358979
> 3.0
> 3.14
> 3.1415
> 
> Hello World
> 01
--]]