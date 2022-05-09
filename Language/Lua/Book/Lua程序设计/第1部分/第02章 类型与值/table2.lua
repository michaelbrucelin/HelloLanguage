-- 用整数作为key，就可以模拟一个数组或list，不过需要注意的是，Lua不同于C，习惯于使用1作为第一个元素的索引，而不是0，而且有不少机制依赖于这个约定。
a = {}
for i=1,10 do a[i] = i^2 end
for i=1,#a do print(a[i]) end
print()

-- 依赖于数组索引从1开始的一些惯用法
print(a[#a])  -- 打印列表a的最后一个值
a[#a] = nil   -- 删除最后一个值
a[#a+1] = v   -- 将v添加到列表末尾
print()

a = {}
a[1] = 1
a[100] = 100
a[200] = 200
print(#a)     -- 1，这个有些类似于C中确认字符串长度的方法，table发现nil后，就认为到达了数组的边界，由于a[2]为nil，所以返回1。
-- print(table.maxn(a))  返回一个table的最大正索引值，Lua5.1支持，现已被废弃
print()

-- 注意下面的键值是不同的
i = 10; j = "10"; k = "+10"
a = {}
a[i] = "one value"
a[j] = "another value"
a[k] = "yet another value"
print(a[j])            --> another value
print(a[k])            --> yet another value
print(a[tonumber(j)])  --> one value
print(a[tonumber(k)])  --> one value

--[[
lua table2.lua
> 1.0
> 4.0
> 9.0
> 16.0
> 25.0
> 36.0
> 49.0
> 64.0
> 81.0
> 100.0
> 
> 100.0
> 
> 1
> 
> another value
> yet another value
> one value
> one value
--]]