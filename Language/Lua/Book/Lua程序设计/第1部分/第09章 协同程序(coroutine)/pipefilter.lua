--[[
生产者——消费者 模型
]]
--]]

function receive(prod)
    local status, value = coroutine.resume(prod)
    return value
end

function send(x)
    coroutine.yield(x)
end

function producer()
    return coroutine.create(function()
        while true do
            local x = io.read()  -- 产生新值
            send(x)
        end
    end)
end

function filter(prod)
    return coroutine.create(function()
        for line = 1, math.huge do
            local x = receive(prod)  -- 获取新值
            x = string.format("%5d %s", line, x)
            send(x)                  -- 将新值发送给消费者
        end
    end)
end

function consumer(prod)
    while true do
        local x = receive(prod)      -- 获取新值
        io.write(x, "\n")            -- 消费新值
    end
end

p = producer()
f = filter(p)
consumer(f)
-- or consumer(filter(producer()))
