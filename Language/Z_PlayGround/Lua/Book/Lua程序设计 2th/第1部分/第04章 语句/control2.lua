-- for语句有两种形式：数字型for（numeric for）与泛型for（generic for）。
-- numeric for
for i = 10, 1, -2 do
    print(i)
end
print()

-- math.huge是C中的HUGE_VAL，而C中的HUGE_VAL则为double的最大值，可以理解为一个大于任何整数的值，即循环没有上限
-- 没有指定步长，默认步长为1
for i = 1, math.huge do
    if (0.3 * i ^ 3 - 20 * i ^ 2 - 500 >= 0) then
        print(i)
        break
    end
end
print()

-- generic for
-- ipairs是lua提供的用于迭代的函数
days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" }
for i, v in ipairs(days) do
    print(i, v)
end

--[[
lua control2.lua
> 10
> 8
> 6
> 4
> 2
> 
> 68
> 
> 1       Sunday
> 2       Monday
> 3       Tuesday
> 4       Wednesday
> 5       Thursday
> 6       Friday
> 7       Saturday
--]]
