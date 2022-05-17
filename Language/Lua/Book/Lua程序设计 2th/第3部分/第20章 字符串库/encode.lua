function encode(t)
    local b = {}
    for k, v in pairs(t) do
        b[#b + 1] = (escape(k) .. "=" .. escape(v))
    end
    return table.concat(b, "&")
end

t = { name = "al", query = "a+b = c", q = "yes or no" }
print(encode(t)) --> q=yes+or+no&query=a%2Bb+%3D+c&name=al
