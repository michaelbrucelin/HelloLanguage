a = {}               -- 创建一个table，并将它的引用存储到a
k = "x"
a[k] = 10            -- 新条目，key="x"，value=10
a[20] = "great"      -- 新条目，key=20，value="great"
print(a["x"])        --> 10
k = 20
print(a[k])          --> "great"
a["x"] = a["x"] + 1  -- 递增条目"x"
print(a["x"])        --> 11
print()

a = {}
a["x"] = 10
b = a          -- b与a引用了同一个table
print(b["x"])  --> 10
b["x"] = 20
print(a["x"])  --> 20
a = nil        -- 现在只有b还在引用table
b = nil        -- 再也没有对table的引用了
-- 当一个程序再也没有对一个table的引用时，Lua的垃圾收集器（garbage collector）最终会删除该table，并复用它的内存。
print()

a = {}
a["x"] = 10
a.y = 20
print(a.x)     --> 10
print(a["y"])  --> 20
print(a.z)     --> nil
a["y"] = nil   -- 删除条目"y"

--[[
lua table.lua
> 10
> great
> 11
> 
> 10
> 20
> 
> 10
> 20
> nil
--]]