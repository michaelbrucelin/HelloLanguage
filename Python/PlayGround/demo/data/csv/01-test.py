import csv

# 1. 读取
exampleFile = open('data/example.csv')
exampleReader = csv.reader(exampleFile)
exampleData = list(exampleReader)
exampleData
exampleData[0][0]
exampleData[0][1]

# 2. 遍历
exampleFile = open('data/example.csv')
exampleReader = csv.reader(exampleFile)
for row in exampleReader:
    print('Row #'+str(exampleReader.line_num)+' '+str(row))

# 3. 写入
outputFile = open('data/output.csv', 'w', newline='')
outputWriter = csv.writer(outputFile)
outputWriter.writerow(['spam', 'eggs', 'bacon', 'ham'])
outputWriter.writerow(['Hello, world!', 'eggs', 'bacon', 'ham'])
outputWriter.writerow([1, 2, 3.141592, 4])
outputFile.close()

# 4. delimiter与lineterminator参数
# 更改分隔符与行终止符为\t与\n\n
csvFile = open('data/example.tsv', 'w', newline='')  # 使用\t分隔的csv，通常使用tsv作为文件后缀
csvWriter = csv.writer(csvFile, delimiter='\t', lineterminator='\n\n')
csvWriter.writerow(['apples', 'oranges', 'grapes'])
csvWriter.writerow(['eggs', 'bacon', 'ham'])
csvWriter.writerow(['spam', 'spam', 'spam', 'spam', 'spam', 'spam'])
csvFile.close()

# 5. 使用DictReader与DictWriter对象处理含有标题的csv文件
exampleFile = open('data/exampleWithHeader.csv')
exampleDictReader = csv.DictReader(exampleFile)
for row in exampleDictReader:
    print(row['Timestamp'], row['Fruit'], row['Quantity'])
exampleFile.close()
# 如果csv文件没有标题，也可以这样使用，但是需要手动设置标题
exampleFile = open('data/example.csv')
exampleDictReader = csv.DictReader(exampleFile, ['time', 'name', 'amount'])
for row in exampleDictReader:
    print(row['time'], row['name'], row['amount'])
exampleFile.close()
# 利用DictWriter对象使用字段创建csv
outputFile = open('data/dictto.csv', 'w', newline='')
outputDictWriter = csv.DictWriter(outputFile, ['Name', 'Pet', 'Phone'])
outputDictWriter.writeheader()
outputDictWriter.writerow({'Name': 'Alice', 'Pet': 'cat', 'Phone': '555-1234'})
outputDictWriter.writerow({'Name': 'Bob', 'Phone': '555-9999'})
outputDictWriter.writerow({'Phone': '555-5555', 'Name': 'Carol', 'Pet': 'dog'})
outputFile.close()
