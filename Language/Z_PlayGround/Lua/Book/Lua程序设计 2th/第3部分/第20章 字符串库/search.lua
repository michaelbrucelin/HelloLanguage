function search(modname, path)
    modname = string.gsub(modname, "%.", "/")
    for c in string.gmatch(path, "[^;]+") do
        local fname = string.gsub(c, "?", modname)
        local f = io.open(fname)
        if f then
            f:close()
            return fname
        end
    end
    return nil -- not found
end
