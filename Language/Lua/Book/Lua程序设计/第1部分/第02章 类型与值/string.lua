a = "one string"
b = string.gsub(a, "one", "another") -- 修改字符串的一部分
print(a) --> one string
print(b) --> another string
print()

print("one line\nnext line\n\"in quotes\", 'in quotes'")
print()

print('a backslash inside quotes: \'\\\'')
print()

print("a simpler way: '\\'")
print()

print("alo\n123\"")
print('\97lo\10\04923"')

--[[
lua与java C#类似，不能像C那样直接更改字符串，而是创建一个新的字符串，至于有没有字符串池，暂时不清楚

lua string.lua
> one string
> another string
> 
> one line
> next line
> "in quotes", 'in quotes'
> 
> a backslash inside quotes: '\'
> 
> a simpler way: '\'
> 
> alo
> 123"
> alo
> 123"
--]]