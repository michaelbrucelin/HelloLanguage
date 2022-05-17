-- lua的函数与python一样，可以返回多个值
function maximum(a)
    local mi = 1     -- 最大值的索引
    local m = a[mi]  -- 最大值
    for i, val in ipairs(a) do
        if val > m then
            mi = i;
            m = val
        end
    end
    return m, mi
end

print(maximum({ 8, 10, 23, 12, 5 }))  --> 23 3

--[[
lua returnvalue.lua
> 23      3
--]]
