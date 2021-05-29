# pip install openpyxl

import openpyxl

wb = openpyxl.load_workbook('data/example.xlsx')
type(wb)  # <class 'openpyxl.workbook.workbook.Workbook'>
