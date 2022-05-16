-- The require function:
function require(name)
    if not package.loaded[name] then -- module not loaded yet?
        local loader = findloader(name)
        if loader == nil then
            error("unable to load module " .. name)
        end
        package.loaded[name] = true -- mark module as loaded
        local res = loader(name) -- initialize module
        if res ~= nil then
            package.loaded[name] = res
        end
    end
    return package.loaded[name]
end
