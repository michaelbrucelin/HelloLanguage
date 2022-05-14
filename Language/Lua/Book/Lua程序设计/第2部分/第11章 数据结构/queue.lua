--[[
在lua中实现队列的一种简单方法是使用table库的函数insert和remove。
这两个函数可以在一个数组的任意位置插入或删除元素，并且根据操作要求后移元素。
不过对于较大的结构，移动的开销是很大的。一种更高效实现是使用两个索引，分别用于首尾的两个元素：
--]]

List = {}
function List.new()
    return { first = 0, last = -1 }
end

function List.pushfirst(list, value)
    local first = list.first - 1
    list.first = first
    list[first] = value
end

function List.pushlast(list, value)
    local last = list.last + 1
    list.last = last
    list[last] = value
end

function List.popfirst(list)
    local first = list.first
    if first > list.last then error("list is empty") end
    local value = list[first]
    list[first] = nil  -- to allow garbage collection
    list.first = first + 1
    return value
end

function List.poplast(list)
    local last = list.last
    if list.first > last then error("list is empty") end
    local value = list[last]
    list[last] = nil  -- to allow garbage collection
    list.last = last - 1
    return value
end
