function rconcat(l)
    if type(l) ~= "table" then return l end
    local res = {}
    for i = 1, #l do
        res[i] = rconcat(l[i])
    end
    return table.concat(res)
end

print(rconcat { { "a", { " nice" } }, " and", { { " long" }, { " list" } } })
--> a nice and long list
