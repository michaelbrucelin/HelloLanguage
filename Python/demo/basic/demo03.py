i = 0
while i < 4:
    print("i=%d"%i)
    i += 1

count = 0
while count < 4:
    print(count, "<4")
    count += 1
else:
    print("="*16)
    print(count, ">=4")

for m in range(1, 10, 1):
    for n in range(1, m+1, 1):
        print("%d * %d = %d"%(m, n, m*n), end="\t")
    print()

p = 1
q = 1
while p < 10:
    q = 1
    while q <= p:
        print("%d * %d = %d"%(p, q, p*q), end="\t")
        q += 1
    print()
    p += 1