import bs4

exampleFile = open('example.html').read()
exampleSoup = bs4.BeautifulSoup(exampleFile, 'html.parser')
type(exampleSoup)  # bs4.BeautifulSoup

elems = exampleSoup.select('#author')
type(elems)  # bs4.element.ResultSet
len(elems)   # 1

type(elems[0])  # bs4.element.Tag
str(elems[0])   # '<span id="author">Al Sweigart</span>'

elems[0].getText()  # 'Al Sweigart'
elems[0].attrs      # {'id': 'author'}


pElems = exampleSoup.select('p')
str(pElems[0])       # '<p>Download my <strong>Python ... ... site</a>.</p>'
pElems[0].getText()  # 'Download my Python book from my website.'
str(pElems[1])       # '<p class="slogan">Learn Python the easy way!</p>'
pElems[1].getText()  # 'Learn Python the easy way!'
str(pElems[2])       # '<p>By <span id="author">Al Sweigart</span></p>'
pElems[2].getText()  # 'By Al Sweigart'


spanElem = exampleSoup.select('span')[0]
str(spanElem)        # '<span id="author">Al Sweigart</span>'
spanElem.get('id')                             # 'author'
spanElem.get('some_nonexistent_addr') == None  # True
spanElem.attrs                                 # {'id': 'author'}
