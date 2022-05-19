#!/usr/bin/ruby

# 像if这样的控制结构，在其他语言中通常都是语句，但是在ruby中是表达式。
minimum = if x < y then x else y end

1 + 2                    # => 3: addition
1 * 2                    # => 2: multiplication
1 + 2 == 3               # => true: == tests equality
2 ** 1024                # 2 to the power 1024: Ruby has arbitrary size ints
"Ruby" + " rocks!"       # => "Ruby rocks!": string concatenation
"Ruby! " * 3             # => "Ruby! Ruby! Ruby! ": string repetition
"%d %s" % [3, "rubies"]  # => "3 rubies": Python-style, printf formatting
max = x > y ? x : y      # The conditional operator
