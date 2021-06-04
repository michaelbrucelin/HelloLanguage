# 这里使用python-docx来操作word文档，注意是python-docx，而不是docx，docx是另一个模块，但是python-docx导入的时候使用的是import docx
# python3 -m pip install python-docx

import docx

# 1. 读取word
doc = docx.Document('data/demo.docx')
len(doc.paragraphs)             # 7
doc.paragraphs[0].text          # 'Document Title'
doc.paragraphs[1].text  # 'A plain paragraph with some bold and some italic'
len(doc.paragraphs[1].runs)     # 5
doc.paragraphs[1].runs[0].text  # 'A plain paragraph with'
doc.paragraphs[1].runs[1].text  # ' some '
doc.paragraphs[1].runs[2].text  # 'bold'
doc.paragraphs[1].runs[3].text  # ' and some '
doc.paragraphs[1].runs[4].text  # 'italic'
