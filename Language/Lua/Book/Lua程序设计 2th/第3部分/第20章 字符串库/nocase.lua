function nocase(s)
    s = string.gsub(s, "%a", function(c)
        return "[" .. string.lower(c) .. string.upper(c) .. "]"
    end)
    return s
end

print(nocase("Hi there!")) --> [hH][iI] [tT][hH][eE][rR][eE]!
