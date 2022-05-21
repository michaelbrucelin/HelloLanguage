function escape(s)
    s = string.gsub(s, "[&=+%%%c]", function(c)
        return string.format("%%%02X", string.byte(c))
    end)
    s = string.gsub(s, " ", "+")
    return s
end
