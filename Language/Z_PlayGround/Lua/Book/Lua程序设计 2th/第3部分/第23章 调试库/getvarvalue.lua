-- Getting the value of a variable:
function getvarvalue(name)
    local value, found
    -- try local variables
    for i = 1, math.huge do
        local n, v = debug.getlocal(2, i)
        if not n then break end
        if n == name then
            value = v
            found = true
        end
    end
    if found then return value end
    -- try non-local variables
    local func = debug.getinfo(2, "f").func
    for i = 1, math.huge do
        local n, v = debug.getupvalue(func, i)
        if not n then break end
        if n == name then return v end
    end
    -- not found; get from the environment
    return getfenv(func)[name]
end
