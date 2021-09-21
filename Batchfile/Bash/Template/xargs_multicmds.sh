# xargs执行多条命令
# https://stackoverflow.com/questions/6958689/running-multiple-commands-with-xargs

# 借助 ... | xargs -i -n1 sh 'cmd1 {}; cmd2 {};...' 即可实现xargs执行多条命令
# 但是这样可能会有类似于sql注入的风险，所以推荐使用下面的方式

cat a.txt | xargs -d $'\n' sh -c 'for arg do command1 "$arg"; command2 "$arg"; ...; done' _
# ...or, without a Useless Use Of cat:
<a.txt xargs -d $'\n' sh -c 'for arg do command1 "$arg"; command2 "$arg"; ...; done' _

# To explain some of the finer points:
# 1. The use of "$arg" instead of % (and the absence of -I in the xargs command line) is for security reasons:
#    Passing data on sh's command-line argument list instead of substituting it into code prevents content that data might contain (such as $(rm -rf ~),
#    to take a particularly malicious example) from being executed as code.

# 2. Similarly, the use of -d $'\n' is a GNU extension which causes xargs to treat each line of the input file as a separate data item.
#    Either this or -0 (which expects NULs instead of newlines) is necessary to prevent xargs from trying to apply shell-like (but not quite shell-compatible)
#    parsing to the stream it reads. (If you don't have GNU xargs, you can use tr '\n' '\0' <a.txt | xargs -0 ... to get line-oriented reading without -d).

# 3. The _ is a placeholder for $0, such that other data values added by xargs become $1 and onward, which happens to be the default set of values a for loop iterates over.
