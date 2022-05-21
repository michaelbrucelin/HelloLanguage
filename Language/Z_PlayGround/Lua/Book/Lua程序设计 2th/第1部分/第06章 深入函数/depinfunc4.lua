--[[
由于函数是一种“第一类值”，因此一个显而易见的推论就是，函数不仅仅可以存储在全局变量中，还可以存储在table的字段中和局部变量中。
--]]

-- 方式1
Lib = {}
Lib.foo = function(x, y) return x + y end
Lib.goo = function(x, y) return x - y end

-- 方式2
Lib = {
    foo = function(x, y) return x + y end,
    goo = function(x, y) return x - y end
}

-- 方式3
Lib = {}
function Lib.foo(x, y) return x + y end
function Lib.goo(x, y) return x - y end

--[[
lua中支持“尾递归”，具体使用方法这里不记录了。
--]]
