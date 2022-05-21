function norm(x, y)
    return (x ^ 2 + y ^ 2) ^ 0.5
end

function twice(x)
    return 2 * x
end

--[[
可以这样在交互式环境中使用lua脚本

lua
Lua 5.4.2  Copyright (C) 1994-2020 Lua.org, PUC-Rio
> dofile("lib1.lua")  -- 加载脚本
> n = norm(3.4, 1.0)
> print(twice(n))
7.0880180586677
> 
--]]