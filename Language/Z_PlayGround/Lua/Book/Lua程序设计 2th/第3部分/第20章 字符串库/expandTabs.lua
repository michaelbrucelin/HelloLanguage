function expandTabs(s, tab)
    tab = tab or 8 -- tab "size" (default is 8)
    local corr = 0
    s = string.gsub(s, "()\t", function(p)
        local sp = tab - (p - 1 + corr) % tab
        corr = corr - 1 + sp
        return string.rep(" ", sp)
    end)
    return s
end
