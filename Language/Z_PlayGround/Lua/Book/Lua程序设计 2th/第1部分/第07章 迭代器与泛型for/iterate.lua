--[[
迭代器
--]]

-- 一个返回“值”（而不是索引）的迭代器
function values(t)
    local i = 0
    return function()
        i = i + 1
        return t[i]
    end
end

t = { 10, 20, 30 }
iter = values(t)            -- 创建迭代器
while true do
    local element = iter()  -- 调用迭代器
    if element == nil then
        break
    end
    print(element)
end
print()

-- 直接使用for迭代器，类似于C#中的foreach
t = { 10, 20, 30 }
for element in values(t) do
    print(element)
end
print()

-- 一个更复杂的迭代器，遍历输入文件中所有单词的迭代器
function allwords()
    local line = io.read()                     -- current line
    local pos = 1                              -- current position in the line
    return function()                          -- iterator function
        while line do                          -- repeat while there are lines
            local s, e = string.find(line, "%w+", pos)
            if s then                          -- found a word?
                pos = e + 1                    -- next position is after this word
                return string.sub(line, s, e)  -- return the word
            else
                line = io.read()               -- word not found; try next line
                pos = 1                        -- restart from first position
            end
        end
        return nil                             -- no more lines: end of traversal
    end
end
