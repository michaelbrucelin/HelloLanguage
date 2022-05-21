co = coroutine.create(function() print("hi") end)
print(coroutine.status(co))

print(co)
print(coroutine.status(co))

coroutine.resume(co)
print(coroutine.status(co))
print()

co = coroutine.create(function()
    for i = 1, 10 do
        print("co", i)
        coroutine.yield()
    end
end)

coroutine.resume(co)  --> co 1
coroutine.resume(co)  --> co 2
coroutine.resume(co)  --> co 3

--[[
lua coroutine.lua
> suspended
> thread: 0x55ee7823eab8
> suspended
> hi
> dead
> 
> co      1
> co      2
> co      3
--]]
