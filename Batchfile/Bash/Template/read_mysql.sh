# 在bash中查询mysql，并分析（遍历）查询结果（二维表格）
# https://stackoverflow.com/questions/35274597/store-mysql-result-in-a-bash-array-variable

# 方法1可以处理2列结果（稍加改动，也可以处理一列结果），正常情况下够用
# 如果需要处理多列或者更复杂的场景，可以使用sql将多列合并成一列，或者干脆使用python等其他语言吧
# 方法3没看明白，先记录在这里

# 方法1
# You could try this:
mapfile result < <(mysql -uroot -ppwd -se "select Host, User from mysql.user;")
# Than
echo ${result[0]%$'\t'*}
echo ${result[0]#*$'\t'}
# or
for row in "${result[@]}"; do
    echo Host: ${row%$'\t'*} User: ${row#*$'\t'}
done
# Nota This will work fine while there is only 2 fields by row. More is possible but become tricky.

# 方法2
# Read for reading table row by row
while IFS=$'\t' read name pass; do
    echo name:$name pass:$pass
done < <(mysql -uroot -ppwd -se "SELECT * from mysql.user;")

# 方法3
# Read and loop to hold whole table into many variables
i=0
while IFS=$'\t' read name[i] pass[i++]; do
    :;done < <(mysql -uroot –ppwd –se "SELECT * from mysql.user;")

echo ${name[0]} ${pass[0]}
echo ${name[1]} ${pass[1]}