function expand(s)
    return (string.gsub(s, "$(%w+)", _G))
end

name = "Lua";
status = "great"
print(expand("$name is $status, isn't it?"))
--> Lua is great, isn't it?

print(expand("$othername is $status, isn't it?"))
--> $othername is great, isn't it?

function expand(s)
    return (string.gsub(s, "$(%w+)", function(n)
        return tostring(_G[n])
    end))
end

print(expand("print = $print; a = $a"))
--> print = function: 0x8050ce0; a = nil
