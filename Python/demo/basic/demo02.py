import random
if True:
    print("true")
elif True:
    print("elif true")
else:
    print("false")

print(random.randint(0, 99))

for i in range(4):
    print(i, end="\t")
print("="*10)

for i in range(0, 10, 3):
    print(i, end="\t")
print("="*10)

for i in range(-10, -100, -30):
    print(i, end="\t")
print("="*10)

name = "mlin"
for c in name:
    print(c, end="\t")
print("="*10)

arr = ["aa", "bb", "cc", "dd"]
for i in range(len(arr)):
    print(i, arr[i])
