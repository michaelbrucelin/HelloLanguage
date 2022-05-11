-- 可变参数
function add(...)
    local s = 0
    for i, v in ipairs { ... } do
        s = s + v
    end
    return s
end

print(add(3, 4, 10, 25, 12))        --> 54
print()

function test(...)
    for i = 1, select("#", ...) do  -- select("#", ...) 返回参数的个数
        print(select(i, ...))       -- select(i, ...)   返回第i个参数
    end
end

print(test("a", "b", "c", "d"))

--[[
lua variableargs.lua
> 54
> 
> a       b       c       d
> b       c       d
> c       d
> d
--]]
