// 开发中如果需要跳出多层循环或switch语句，可以使用goto语句，下面两种代码等价

// 代码1，使用goto语句
/*
for (i = 0; i < n; i++)
    for (j = 0; j < m; j++)
        if (a[i] == b[j])
            goto found;
didn't find any common element
...
found:
got one: a[i] == b[j]
...
*/

// 代码2，不使用goto语句
/*
found = 0;
for (i = 0; i < n && !found; i++)
    for (j = 0; j < m && !found; j++)
        if (a[i] == b[j])
            found = 1;
if (found)
    got one: a[i-1] == b[j-1]
    ...
else
    didn't find any common element
    ...
*/