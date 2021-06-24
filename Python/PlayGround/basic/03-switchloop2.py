# 在C#中，可以这样跳过循环中的项目
for(int i=0; i < 10; i++)
{
    if(i == 3)
    	i += 5
    Console.WriteLine(i)
}

# 在python中目前只找到这种跳循环的方法
forange = iter(range(10))
for i in forange:
    if i == 3:
        for _ in range(5):
            next(forange)
    print(i)
