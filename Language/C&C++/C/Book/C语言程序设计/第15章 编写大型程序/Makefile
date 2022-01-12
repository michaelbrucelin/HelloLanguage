justify.out: justify.o word.o line.o
	gcc -o justify.out justify.o word.o line.o

justify.o: justify.c word.h line.h
	gcc -c justify.c

word.o: word.c word.h
	gcc -c word.c

line.o: line.c line.h
	gcc -c line.c

# gcc -c，选项-c 通知编译器把xxx.c编译为目标文件，但是不要试图链接它。
# 这里前2行中的justify.out通常应该为justify即可，这里添加.out是为了自动被.gitignore掉

# 下面是一些需要了解的细节。
# makefile中的每个命令前面都必须有一个制表符，不是一串空格。
# makefile通常存储在一个名为Makefile（或makefile）的文件中。
#     使用make实用程序时，它会自动在当前目录下搜索具有这些名字的文件。
# 用下面的命令调用make：
#     make 目标
#     其中目标是列在makefile中的目标文件之一。为了用我们的makefile构建justify可执行程序，可以使用命令
#     make justify
# 如果在调用make时没有指定目标文件，将构建第一条规则中的目标文件。例如，命令
#     make
#     将构建justify 可执行程序，因为justify是我们的makefile中的第一个目标文件。除了第一条规则的这一特殊性质外，makefile中规则的顺序是任意的。
