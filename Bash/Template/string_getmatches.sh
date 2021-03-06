# 字符串提取
# shell中字符串提取主要是利用grep和sed两个文本工具实现

# 测试数据
echo '-rw-r--r--. 1 root root 1001 May  1 08:15 mtr.195.154.47.131_20190501-081320.txt' >  test.txt
echo '-rw-r--r--. 1 root root 1001 May  1 08:16 mtr.195.154.47.131_20190501-081501.txt' >> test.txt
echo '-rw-r--r--. 1 root root 1001 May  1 08:18 mtr.195.154.47.131_20190501-081641.txt' >> test.txt
echo '-rw-r--r--. 1 root root 1001 May  1 08:20 mtr.195.154.47.131_20190501-081821.txt' >> test.txt
echo '-rw-r--r--. 1 root root 1001 May  1 08:21 mtr.195.154.47.131_20190501-082002.txt' >> test.txt
echo '-rw-r--r--. 1 root root 1001 May  1 08:23 mtr.195.154.47.131_20190501-082142.txt' >> test.txt
echo '-rw-r--r--. 1 root root 1001 May  1 08:25 mtr.195.154.47.131_20190501-082322.txt' >> test.txt
echo '-rw-r--r--. 1 root root 1078 May  1 08:26 mtr.195.154.47.131_20190501-082503.txt' >> test.txt
echo '-rw-r--r--. 1 root root 1078 May  1 08:28 mtr.195.154.47.131_20190501-082643.txt' >> test.txt

# 方法1、利用grep实现
cat test.txt | grep -E -o "[0-9]{8}-[0-9]{6}"
20190501-081320
20190501-081501
20190501-081641
20190501-081821
20190501-082002
20190501-082142
20190501-082322
20190501-082503
20190501-082643

# 方法2、利用sed实现
cat test.txt | sed 's/.*\([0-9]\{8\}-[0-9]\{6\}\).*/\1/g'
20190501-081320
20190501-081501
20190501-081641
20190501-081821
20190501-082002
20190501-082142
20190501-082322
20190501-082503
20190501-082643
