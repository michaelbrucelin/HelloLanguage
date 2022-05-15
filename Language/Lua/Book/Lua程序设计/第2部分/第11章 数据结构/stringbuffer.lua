--[[
由于字符串的不可变性，如果大量的字符串拼接，会导致性能低下
下面的代码，如果读取的是一个350KB的文件（每行20个字节），尽管文件总共只有350KB，lua在内存中却至少需要移动50GB的数据（书中给出的结论）
--]]
local buff = ""
for line in io.lines() do
    buff = buff .. line .. "\n"
end

--[[
这种情况下，我们可以就lua中的一个table作为字符串缓冲，然后使table.concat()将table中的字符串拼接起来
有些类似于C#或Java中的StringBuilder
--]]
local t = {}
for line in io.lines() do
    t[#t + 1] = line .. "\n"
end
local s = table.concat(t)

local t = {}
for line in io.lines() do
    t[#t + 1] = line
end
s = table.concat(t, "\n") .. "\n"

local t = {}
for line in io.lines() do
    t[#t + 1] = line
end
t[#t + 1] = ""
s = table.concat(t, "\n")

--[[
如果只是想要读取一个文本文件，不需要像上面这样操作，直接读取整个文件就可以了
--]]
io.read("*all")

--[[
lua库拼接字符串的算法
--]]
function addString(stack, s)
    stack[#stack + 1] = s  -- push 's' into the the stack
    for i = #stack - 1, 1, -1 do
        if #stack[i] > #stack[i + 1] then
            break
        end
        stack[i] = stack[i] .. stack[i + 1]
        stack[i + 1] = nil
    end
end
