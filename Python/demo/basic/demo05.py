import random
testlist = [1, "test", [100, "test100"]]
for item in testlist:
    print(item, end="\t")
    print(type(item))
    if(type(item) == list):
        for iitem in item:
            print(iitem, end="\t")
            print(type(iitem))

list1 = [1, 2, 3]
print(list1)
list1.append(10)
print(list1)

list21 = [100, 200]
list22 = [100, 200]
list2 = [300, 400]
list21.append(list2)
list22.extend(list2)
print(list21)
print(list22)

list1.insert(1, 1000)
print(list1)

list31 = [1, 2, 3, 4, 5, 6, 4, 7, 8]
list32 = [1, 2, 3, 4, 5, 6, 4, 7, 8]
list33 = [1, 2, 3, 4, 5, 6, 4, 7, 8]
del list31[3]
list32.pop()
list33.remove(4)
print(list31)
print(list32)
print(list33)

list4 = ["A", "B", "C", "D"]
if "A" in list4:
    print("in")
if "E" not in list4:
    print("not in")

list5 = ["A", "B", "C", "A", "B"]
print(list5.index("A", 1, 4))  # [1, 4) 左闭右开
print(list5.count("A"))

list6 = [1, 4, 3, 2]
list6.reverse()
list6.sort()
list6.sort(reverse=True)

offices = [[], [], []]
names = ["A", "B", "C", "D", "E", "F", "G", "H"]
for name in names:
    index = random.randint(0, 2)
    offices[index].append(name)

i = 1
for office in offices:
    print("办公室%d的人数为: %d" % (i, len(office)))
    i += 1
    for name in office:
        print("%s" % name, end="\t")
    print("\n")
    print("="*30)

list7 = ["a", "b", "c", "d"]
for x in list7:
    print(x)
for i,x in enumerate(list7):
    print(i,x)