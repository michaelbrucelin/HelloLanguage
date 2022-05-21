function fsize(file)
    local current = file:seek() -- get current position
    local size = file:seek("end") -- get file size
    file:seek("set", current) -- restore position
    return size
end
