function traceback()
    for level = 1, math.huge do
        local info = debug.getinfo(level, "Sl")
        if not info then break end
        if info.what == "C" then -- is a C function?
            print(level, "C function")
        else -- a Lua function
            print(string.format("[%s]:%d", info.short_src,
                info.currentline))
        end
    end
end
