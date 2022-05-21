-- 如果一个函数的参数很多，记住参数的顺序显然不现实，那么可以使用命名参数来简化代码。
function Window(options)
    -- 检查必要的参数
    if type(options.title) ~= "string" then
        error("no title")
    elseif type(options.width) ~= "number" then
        error("no width")
    elseif type(options.height) ~= "number" then
        error("no height")
    end
    -- 其它参数都是可选的
    _Window(options.title,
        options.x or 0,                 -- 默认值
        options.y or 0,                 -- 默认值
        options.width, options.height,
        options.background or "white",  -- 默认值
        options.border                  -- 默认值为false (nil)
    )
end
