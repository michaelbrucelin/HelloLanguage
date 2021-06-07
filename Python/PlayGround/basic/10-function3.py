# 生成器
# 类似于C#中的延时执行，同样使用yield关键字

# 1. basic
def squares(n=10):
    for i in range(1, n+1):
        yield i**2


gen = squares()  # 这时，虽然写的是调用，但是代码并没有真的执行
for x in gen:
    print(x, end=' ')  # 这个时候（请求元素的时候）才会执行代码

# 2. 生成器表达式
# 生成器表达式与列表表达式类似，只需要把中括号改为小括号即可

