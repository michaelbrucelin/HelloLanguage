from bs4 import BeautifulSoup

file = open("./baidu.html", "rb")
html = file.read().decode("utf-8")
bs = BeautifulSoup(html, "html.parser")

'''
print(bs.title)
print(bs.head)
print(bs.a)  #获取文档中的第一个a标签
'''
'''
print(bs.title)
print(bs.title.string)

print(bs.a)
print(bs.a.string)
print(bs.a.attrs)

print(bs)
print(bs.name)
print(bs.text)
'''
'''
print(bs.head.contents)
'''

#文档搜索
# 1. find_all()
# 1.1 字符串查找
t_list = bs.findAll("a")
# 1.2 正则表达式查找
import re
t_list = bs.findAll(re.compile("^a$"))
# 1.3 传入一个方法，根据方法的要求进行搜索
def onmousedown_is_exists(tag):
    return tag.has_attr("onmousedown")
t_list = bs.findAll(onmousedown_is_exists)

# 2. kwargs 参数查找
t_list = bs.findAll(id="head")
t_list = bs.findAll(class_=True)

# 3. text参数
t_list = bs.findAll(text="新闻")
t_list = bs.findAll(text=["新闻", "贴吧", "地图"])
t_list = bs.findAll(text=re.compile("\d"))

# 4. limit参数
t_list = bs.findAll("a", limit=3)

#选择器
t_list = bs.select("title")
t_list = bs.select(".none")
t_list = bs.select("#s_tab")
t_list = bs.select("a[class='c2']")
t_list = bs.select("head > title")

for item in t_list:
    print(item)