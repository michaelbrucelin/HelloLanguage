--[[
lua中图有多种实现，这里给出其中一种简单的面向对象的实现。
每个结点表示为一个table，这个table有两个字段：name（结点名称）和adj（相邻结点的集合）。
--]]

local function name2node(graph, name)
    if not graph[name] then
        -- node does not exist; create a new one
        graph[name] = { name = name, adj = {} }
    end
    return graph[name]
end

function readgraph()
    local graph = {}
    for line in io.lines() do
        -- split line in two names
        local namefrom, nameto = string.match(line, "(%S+)%s+(%S+)")
        -- find corresponding nodes
        local from = name2node(graph, namefrom)
        local to = name2node(graph, nameto)
        -- adds 'to' to the adjacent set of 'from'
        from.adj[to] = true
    end
    return graph
end

function findpath(curr, to, path, visited)
    path = path or {}
    visited = visited or {}
    if visited[curr] then -- node already visited?
        return nil -- no path here
    end
    visited[curr] = true -- mark node as visited
    path[#path + 1] = curr -- add it to path
    if curr == to then -- final node?
        return path
    end
    -- try all adjacent nodes
    for node in pairs(curr.adj) do
        local p = findpath(node, to, path, visited)
        if p then return p end
    end
    path[#path] = nil -- remove node from path
end

-- 测试
function printpath(path)
    for i = 1, #path do
        print(path[i].name)
    end
end

g = readgraph()
a = name2node(g, "a")
b = name2node(g, "b")
p = findpath(a, b)
if p then printpath(p) end
