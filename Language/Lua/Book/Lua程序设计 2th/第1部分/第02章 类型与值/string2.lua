-- 这样可以定义一个多行的字符串，类似于C#中的@""
page = [[
<html>
<head>
<title>An HTML Page</title>
</head>
<body>
<a href="http://www.lua.org">Lua</a>
</body>
</html>
]]

-- 由于字符串中含有 ]]，所以用上面的方式是不行的，只要在两端的分界符从添加 = 即可，只要两边添加相同数量的 = 就可以，= 的数量没有限制
page2 = [=[
<html>
<head>
<title>An HTML Page</title>
</head>
<body>
<a href="http://www.lua.org">Lua</a>
<span>a=b[c[i]]</span>
</body>
</html>
]=]

-- write(page)
-- write(page2)
print(page)
print()
print(page2)

--[==[
> lua string2.lua
> <html>
> <head>
> <title>An HTML Page</title>
> </head>
> <body>
> <a href="http://www.lua.org">Lua</a>
> </body>
> </html>
> 
> 
> <html>
> <head>
> <title>An HTML Page</title>
> </head>
> <body>
> <a href="http://www.lua.org">Lua</a>
> <span>a=b[c[i]]</span>
> </body>
> </html>
--]==]