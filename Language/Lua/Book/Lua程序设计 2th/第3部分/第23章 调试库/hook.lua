local function hook()
    local f = debug.getinfo(2, "f").func
    if Counters[f] == nil then -- first time 'f' is called?
        Counters[f] = 1
        Names[f] = debug.getinfo(2, "Sn")
    else -- only increment the counter
        Counters[f] = Counters[f] + 1
    end
end
