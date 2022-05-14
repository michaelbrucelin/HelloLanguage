--[[
在lua中，可以使用table轻松模拟一个集合，其中table的索引就是集合的值，table的值为true（当然也可以是其它值）。
其实好多编程语言（例如Java）都是这么干的，只不过对用户额外做了一层包装而已。
--]]

reserved = {
    ["while"] = true,
    ["end"] = true,
    ["function"] = true,
    ["local"] = true,
}

for w in allwords() do
    if not reserved[w] then
        -- <do something with 'w'> -- 'w' is not a reserved word
    end
end

-- 可以创建一个辅助函数来创建集合
function Set(list)
    local set = {}
    for _, l in ipairs(list) do set[l] = true end
    return set
end

reserved = Set { "while", "end", "function", "local", }

--[[
包，有时也称为“多重集合（Multiset）”，与普通集合的不同之处在于每个元素可以出现多次。
在lua中表示包，只需要将上面集合的表示方式中，table的值改为索引的计数器即可。
--]]

function insert(bag, element)
    bag[element] = (bag[element] or 0) + 1
end

function remove(bag, element)
    local count = bag[element]
    bag[element] = (count and count > 1) and count - 1 or nil
end
