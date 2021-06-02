# PyInputPlus是一个第三方模块，与内建的input()类似，但是有很多验证数据的功能
# python3 -m pip install pyinputplus
# 模块中有inputStr(), inputNum()， inputInt(), inputFloat(), inputChoice, inputMenu(), inputDatetime(),
#         inputYesNo(), inputBool(), inputEmail(), inputFilepath(), inputPassword(), inputCustom()等函数

import pyinputplus as pyip

# 1. 验证数字输入
# 验证数字的有inputNum(), inputInt() 与 inputFloat()
response = pyip.inputNum(prompt='Enter a number: ')
Enter a number: five
'five' is not a number.
Enter a number: 18

# 关键字min, max, greaterThan， lessThan，可以限制输入的范围
response = pyip.inputNum(prompt='Enter a number: ', min=4)
Enter a number: 3
Number must be at minimum 4.
Enter a number: 8

response = pyip.inputNum(prompt='Enter a number: ', min=4, lessThan=8)
Enter a number: 8
Number must be less than 8.
Enter a number: 6

# 关键字blank，默认情况下，不允许输入空格，除非使用blank关键字
response = pyip.inputNum('Enter a number: ')
Enter a number:
Blank values are not allowed.
Enter a number: 23

response = pyip.inputNum('Enter a number: ', blank=True)
Enter a number:
''

# 关键字limit, timeout, default可以限制输入的次数，时间等
response = pyip.inputNum('Enter a number: ', limit=2)                 # 异常
response = pyip.inputNum('Enter a number: ', timeout=10)              # 异常
response = pyip.inputNum('Enter a number: ', limit=2, default='N/A')  # 不会引发异常

# 关键字allowRegexes, blockRegexes
# 同时指定allowRegexes, blockRegexes的话，允许列表优先于阻止列表
response = pyip.inputNum('Enter a number: ', allowRegexes=[
                         r'(I|V|X|L|C|D|M)+', r'zero'])
Enter a number: xlii
'xlii' is not a number.
Enter a number: XLII

response = pyip.inputNum('Enter a number: ', blockRegexes=[r'[02468]$'])
Enter a number: 20
This response is invalid.
Enter a number: 23

# 使用自己的验证函数
def addsUpToTen(numbers):
    numbersList = list(numbers)
    for i, digit in enumerate(numbersList):
        numbersList[i] = int(digit)
    if sum(numbersList) != 10:
        raise Exception('The digits must add up to 10, not %s.' %
                        (sum(numbersList)))
    return int(numbers)

response = pyip.inputCustom(addsUpToTen)
1024
The digits must add up to 10, not 7.
1234
