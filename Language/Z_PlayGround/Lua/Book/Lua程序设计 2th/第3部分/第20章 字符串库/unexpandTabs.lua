function unexpandTabs(s, tab)
    tab = tab or 8
    s = expandTabs(s)
    local pat = string.rep(".", tab)
    s = string.gsub(s, pat, "%0\1")
    s = string.gsub(s, " +\1", "\t")
    s = string.gsub(s, "\1", "")
    return s
end
