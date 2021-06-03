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
