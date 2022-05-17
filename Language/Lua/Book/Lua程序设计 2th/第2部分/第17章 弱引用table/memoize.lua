--[[
loadstring是一个非常昂贵的函数，所以可以像下面代码一样，创建一个备忘录（memoize）函数来优化，就是“用空间换时间”的思想。
与数据库连接池一个道理。
--]]
local results = {}
setmetatable(results, {__mode = "v"})  -- 使value成为弱引用
function mem_loadstring(s)
    local res = results[s]
    if res == nil then                 -- 是否已记录过
        res = assert(loadstring(s))    -- 计算新结果
        results[s] = res               -- 存下以备之后复用
    end
    return res
end
