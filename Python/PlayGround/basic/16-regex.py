import re

# 1. 利用括号分组
phoneNumRegex = re.compile(r'(\d{3})-(\d{3}-\d{4})')
rg = phoneNumRegex.search('My phone num is 415-555-4242.')
rg           # <re.Match object; span=(16, 28), match='415-555-4242'>
rg.group()   # '415-555-4242'
rg.group(0)  # '415-555-4242'
rg.group(1)  # '415'
rg.group(2)  # '555-4242'
rg.groups()  # ('415', '555-4242')

# 2. 出现在{}、*、+后的?表示停止贪婪模式
greedyHaRegex = re.compile(r'(Ha){3,5}')
rg = greedyHaRegex.search('Ha'*5)
rg.group()  # 'HaHaHaHaHa'
greedyHaRegex = re.compile(r'(Ha){3,5}?')
rg = greedyHaRegex.search('Ha'*5)
rg.group()  # 'HaHaHa'

greedyRegex = re.compile(r'<.*>')
rg = greedyRegex.search('<To serve man> for dinner.>')
rg.group()  # '<To serve man> for dinner.>'
greedyRegex = re.compile(r'<.*?>')
rg = greedyRegex.search('<To serve man> for dinner.>')
rg.group()  # '<To serve man>'

# 3. search()只返回第一个匹配的项，findall()返回所有匹配的项
phoneNumRegex = re.compile(r'\d{3}-\d{3}-\d{4}')
rg = phoneNumRegex.search('Cell: 415-555-9999 Work: 212-555-0000')
rg.group()  # '415-555-9999'
rg = phoneNumRegex.findall('Cell: 415-555-9999 Work: 212-555-0000')
rg          # ['415-555-9999', '212-555-0000']

phoneNumRegex = re.compile(r'(\d{3})-(\d{3}-\d{4})')
rg = phoneNumRegex.search('Cell: 415-555-9999 Work: 212-555-0000')
rg.group()  # '415-555-9999'
rg = phoneNumRegex.findall('Cell: 415-555-9999 Work: 212-555-0000')
rg          # [('415', '555-9999'), ('212', '555-0000')]

# 4. .表示换行符之外的所有字符（一直以为是所有字符了。。。）
dotRegex = re.compile(r'.*')
rg = dotRegex.search(
    'Serve the public trust.\nProtect the innocent.\nUphold the law.')
rg.group()  # 'Serve the public trust.'
# 使用 re.DOTALL 选项可以使 . 匹配换行符
dotRegex = re.compile(r'.*', re.DOTALL)
rg = dotRegex.search(
    'Serve the public trust.\nProtect the innocent.\nUphold the law.')
rg.group()  # 'Serve the public trust.\nProtect the innocent.\nUphold the law.'

# 使用 re.IGNORECASE 或 re.I 选项忽略大小写
robocop = re.compile(r'robocop')
rg = robocop.search('RoboCop is part of man, part machine, all cop.')
rg.group()  # AttributeError ... 'NoneType' object has no attribute 'group'
robocop = re.compile(r'robocop', re.I)
rg = robocop.search('RoboCop is part of man, part machine, all cop.')
rg.group()  # 'RoboCop'
