str = "i = i + 1"
f = loadstring(str)                        -- 这样慢，因为每次调用loadstring()时都会编译一次
-- 基本上等价于 f = function () i = i + 1 end，但是这样更快，因为只有在编译程序块时被编译一次

i = 0
f(); print(i)  --> 1
f(); print(i)  --> 2
print()

--上面之所以说两种写法基本上是等价的，是因为二者本质上并不等价，例如
i = 32
local i = 0
f = loadstring("i = i + 1; print(i)")    -- 这里操作的是全部变量 i，因为loadstring()总是在全局环境中编译它的字符串
g = function () i = i + 1; print(i) end  -- 这里会如期的使用局部变量 i
f()  --> 33
g()  --> 1

--[[
loadfile()和loadstring()分别从文件中和字符串中读取程序块，然后交给load()，load()负责编译与执行。
--]]

--[[
lua compile.lua
> 1
> 2
> 
> 33
> 1
--]]