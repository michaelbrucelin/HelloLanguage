print("演示一下lua中的注释的惯用法")

-- print("hello comment")      -- 单行注释

--[[
    print("hello comment 01")  -- 这个是多行注释的标准写法，即以 --[[ 开始，以 ] ] 结束
    print("hello comment 02")  -- 注意，结尾的两个 ] 中间没有空格，上面之所以这么写，你猜？
    print("hello comment 03")
]]

--[[
    print("hello comment 01")  -- 这个是多行注释的惯用法，因为这样写的话，只需要在开头的 --[[ 前加一个 - 就可以打开多行注释
    print("hello comment 02")
    print("hello comment 03")
--]]

--[=[
    print("hello comment 01")  -- 这样也可以，只要前后的 = 的数量一直就可以
    print("hello comment 02")
    print("hello comment 03")
--]=]

---[[
    print("hello comment 01")
    print("hello comment 02")
    print("hello comment 03")
--]]  -- 此时的 ]] 成为了当行注释的内容了

--[[
lua comment.lua
> 演示一下lua中的注释的惯用法
> hello comment 01
> hello comment 02
> hello comment 03
--]]