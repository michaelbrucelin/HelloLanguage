function toxml(s)
    s = string.gsub(s, "\\(%a+)(%b{})", function(tag, body)
        body = string.sub(body, 2, -2) -- remove brackets
        body = toxml(body) -- handle nested commands
        return string.format("<%s>%s</%s>", tag, body, tag)
    end)
    return s
end

print(toxml("\\title{The \\bold{big} example}"))
--> <title>The <bold>big</bold> example</title>
