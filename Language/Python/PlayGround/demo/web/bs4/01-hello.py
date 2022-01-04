import requests
import bs4

res = requests.get('https://www.baidu.com/')
res.raise_for_status()
# html.parser解析器是python自带的，也可以使用更快的第三方模块lxml
# pip install lxml
noStarchSoup = bs4.BeautifulSoup(res.text, 'html.parser')
type(noStarchSoup)  # bs4.BeautifulSoup
