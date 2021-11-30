# 在bash中读取csv中的内容，这里以读取一个两列的csv为例。

# 第一种方式，整行读取
while read line; do
    echo $line
done < <(cat files/kvinfo.csv)

# 第二种方式，分列读取
while IFS=$',' read key value; do
    echo key:$key value:$value
done < <(cat files/kvinfo.csv)
