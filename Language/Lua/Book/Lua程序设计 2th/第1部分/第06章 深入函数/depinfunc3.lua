--[[
闭包2
从技术上讲，lua中只有closure，而不存在“函数”。因为，函数本身就是一种特殊的closure。
closure是指一个函数及一系列这个函数会访问到的“非局部变量（或upvalue）”，因此如果一个closure没有那些会访问的“非局部变量”，那它就是一个传统概念中的“函数”，所以说函数就是closure的一种特殊情况。
另外在lua的C API中，所有关于“lua中的函数”的核心API都是以closure（而非function）来命名的，也可以视为这一观点的延续。

--------> 个人还是觉得lua中的闭包，就是一个简化版的“类”，类似于Java中的匿名函数（记忆中java中的匿名函数就是一个匿名内部类）？ <--------
--]]

--[[
closure有很多好用的应用场景，这里只举一个示例：
场景：将lua中的函数存储到变量中，然后重新定义这个函数，通常在重新定义一个函数时，会在新的实现内部调用原来那个函数。
            这样甚至可以创建一个“沙盒”
例如：如果想要限制一个程序访问文件的话，只需使用closure来重新定义函数io.open就可以了，代码如下：
--]]

do
    local oldOpen = io.open
    local access_OK = function(filename, mode)
        -- <check access（检查访问权限）>
    end
    io.open = function(filename, mode)
        if access_OK(filename, mode) then
            return oldOpen(filename, mode)
        else
            return nil, "access denied"
        end
    end
end

--[[
这样经过重新定义后，一个程序就只能通过新的受限版本来调用原先那个未受限的open函数了。
代码将原来的不安全的版本保存到了closure的一个私有变量中，从而使得外部再也无法直接访问到原来的版本了。
通过这种技术，lua可以在语言的层面上就构建出一个安全的运行环境，且不失简易性和灵活性。
--]]