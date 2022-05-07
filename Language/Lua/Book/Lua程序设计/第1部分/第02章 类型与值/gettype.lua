print(type("Hello world"))  --> string
print(type(10.4 * 3))       --> number
print(type(print))          --> function
print(type(type))           --> function
print(type(true))           --> boolean，lua中除了false与nil表示假外，其余的所有值均为true，包括 0 与 "" 也表示true
print(type(nil))            --> nil
print(type(type(X)))        --> string，这一行无论X是什么类型都会输出string，因为type返回的是一个string类型
print()

print(type(a))              --> nil ('a' 尚未初始化)
a = 10
print(type(a))              --> number
a = "a string!!"
print(type(a))              --> string
a = print                   -- 是的, 这是合法的!
a(type(a))                  --> function

--[[
lua中一共只有8种基础数据类型，除了上面的5中外，还有userdata(自定义类型)，thread(线程)和table(表)

lua gettype.lua
> string
> number
> function
> function
> boolean
> nil
> string
> 
> nil
> number
> string
> function
--]]