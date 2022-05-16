a = {}
b = { __mode = "k" }
setmetatable(a, b) -- now 'a' has weak keys, 现在a的key就是弱引用
key = {} -- creates first key
a[key] = 1
key = {} -- creates second key
a[key] = 2
collectgarbage() -- forces a garbage collection cycle, 强制进行一次垃圾回收
for k, v in pairs(a) do print(v) end
