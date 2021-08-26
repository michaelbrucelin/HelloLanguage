# Python中与web相关的常用模块

- `webbrowser`

`Python`内建的模块，可以打开浏览器获取指定的页面

- `requests`

从因特网上下载文件和网页，它是第三方模块，`Python`中内建了`urllib2`模块，功能类似，但是用起来太复杂了

```bash
pip install requests
```

- `bs4`

解析`html`，即网页编写的格式，它是一个第三方模块

```bash
pip install beautifulsoup4
```

- `selenium`

启动并控制一个web浏览器。`selenium`能够填写表单，并模拟鼠标在这个浏览器中单击  
`selenium`是一个用于测试网站的自动化测试工具，支持各种浏览器包括Chrome、Firefox、Safari等主流界面浏览器，同时也支持phantomJS无界面浏览器

```bash
pip install selenium
```

除此之外，还需要安装对应浏览器的驱动：  
[Chrome](https://chromedriver.chromium.org/downloads)  
[Firefox](https://github.com/mozilla/geckodriver/releases)
