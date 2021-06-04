# python中一把使用PyPDF2这个第三方库来解析pdf文件
# PyPDF2没有办法提取pdf中的图像、图表以及其他媒体，它目前只能提取pdf中的文本
# python3 -m pip install PyPDF2

import PyPDF2

# 1. 提取pdf中的文本
pdfFileObj = open('data/meetingminutes.pdf', 'rb')
pdfReader = PyPDF2.PdfFileReader(pdfFileObj)
pdfReader.numPages     # 19 pdf的页数
pageObj = pdfReader.getPage(0)
pageObj.extractText()  # 提取文本
pdfFileObj.close()

# 2. 打开有密码的pdf
pdfFileObj = open('data/encrypted.pdf', 'rb')
pdfReader = PyPDF2.PdfFileReader(pdfFileObj)
pdfReader.isEncrypted  # True 这是个加密的pdf
pdfReader.getPage(0)   # 异常报错

# 不确认是bug，还是有意为之，前面没有解密读取失败一次了，必须重新加载一次pdf才可以解密成功
pdfReader = PyPDF2.PdfFileReader(pdfFileObj)
pdfReader.decrypt('rosebud')  # 通过密码解密，密码正确返回 1， 否则返回 0
pdfReader.getPage(0)

# 3. 操作pdf
# 目前PyPDF2不能将任意文本写入pdf，也不能编辑pdf，只能从其他pdf中复制页面、旋转页面、重叠页面以及加密文件
# 3.1 复制页面
pdf1File = open('data/meetingminutes.pdf', 'rb')
pdf2File = open('data/meetingminutes2.pdf', 'rb')
pdf1Reader = PyPDF2.PdfFileReader(pdf1File)
pdf2Reader = PyPDF2.PdfFileReader(pdf2File)
pdfWriter = PyPDF2.PdfFileWriter()

for pageNum in range(pdf1Reader.numPages):
    pageObj = pdf1Reader.getPage(pageNum)
    pdfWriter.addPage(pageObj)
for pageNum in range(pdf2Reader.numPages):
    pageObj = pdf2Reader.getPage(pageNum)
    pdfWriter.addPage(pageObj)

pdfOutputFile = open('data/combinedminutes.pdf', 'wb')
pdfWriter.write(pdfOutputFile)
pdfOutputFile.close()
pdf1File.close()
pdf2File.close()

# 3.2 旋转页面
minutesFile = open('data/meetingminutes.pdf', 'rb')
pdfReader = PyPDF2.PdfFileReader(minutesFile)
page0 = pdfReader.getPage(0)
page0.rotateClockwise(90)         # 顺时针旋转90度
page1 = pdfReader.getPage(1)
page1.rotateCounterClockwise(90)  # 逆时针旋转90度

pdfWriter = PyPDF2.PdfFileWriter()
pdfWriter.addPage(page0)
pdfWriter.addPage(page1)
rotatePdfFile = open('data/rotatedPage.pdf', 'wb')
pdfWriter.write(rotatePdfFile)
rotatePdfFile.close()
minutesFile.close()

# 3.3 叠加页面
# 叠加页面通常用于给pdf文件添加公司标志、时间戳或水印
minutesFile = open('data/meetingminutes.pdf', 'rb')
pdfReader = PyPDF2.PdfFileReader(minutesFile)
pdfWatermarkFile = open('data/watermark.pdf', 'rb')
pdfWatermarkReader = PyPDF2.PdfFileReader(pdfWatermarkFile)
pdfWatermarkPage = pdfWatermarkReader.getPage(0)
pdfWriter = PyPDF2.PdfFileWriter()

for pageNum in range(pdfReader.numPages):
    pageObj = pdfReader.getPage(pageNum)
    pageObj.mergePage(pdfWatermarkReader.getPage(0))
    pdfWriter.addPage(pageObj)

resultPdfFile = open('data/watermarkedCover.pdf', 'wb')
pdfWriter.write(resultPdfFile)
resultPdfFile.close()
minutesFile.close()

# 3.4 加密pdf
pdfFile = open('data/meetingminutes.pdf', 'rb')
pdfReader = PyPDF2.PdfFileReader(pdfFile)
pdfWriter = PyPDF2.PdfFileWriter()
for pageNum in range(pdfReader.numPages):
    pdfWriter.addPage(pdfReader.getPage(pageNum))

pdfWriter.encrypt('swordfish')
resultPdf = open('data/encryptedminutes.pdf', 'wb')
pdfWriter.write(resultPdf)
resultPdf.close()
pdfFile.close()
