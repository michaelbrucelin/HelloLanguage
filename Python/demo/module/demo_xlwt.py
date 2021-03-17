import xlwt

workbook = xlwt.Workbook(encoding="utf-8")

worksheet1 = workbook.add_sheet("Sheet1")
#worksheet.write(0, 0, "hello world")
for i in range(0, 10):
    for j in range(0, 10):
        worksheet1.write(i, j, "{{{0}, {1}}}".format(i, j))

worksheet2 = workbook.add_sheet("Sheet2")
for i in range(1, 10):
    for j in range(1, i+1):
        worksheet2.write(i-1, j-1, "{0} * {1} = {2}".format(i, j, i*j))

workbook.save("test.xls")