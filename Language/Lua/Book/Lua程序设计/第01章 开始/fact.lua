-- 定义一个阶乘函数

function fact(n)
    if n == 0 then
        return 1
    else
        return n * fact(n - 1)
    end
end

print("enter a number:")
a = io.read("*number")  -- 读取一个数字
print(fact(a))

--[[
lua fact.lua
> enter a number:
> 8
> 40320
--]]