from selenium import webdriver
from selenium.webdriver.common.keys import Keys

# 打开一个由selenium控制的Chrome
browser = webdriver.Chrome()
type(browser)  # <class 'selenium.webdriver.chrome.webdriver.WebDriver'>
browser.get("https://www.google.com")  # 访问指定的页面

# 单击页面上的超链接
baidu_map = browser.find_element_by_link_text('地图')
baidu_map.click()

# 填写并提交表单
sear_blank = browser.find_element_by_id('kw')
sear_blank.clear()
sear_blank.send_keys('nba')
sear_blank.submit()  # 在任何表单元素上调用submit()都可以

# 发送特殊按键
htmlElem = browser.find_element_by_tag_name('html')
htmlElem.send_keys(Keys.END)
htmlElem.send_keys(Keys.HOME)

browser.back()
browser.forward()
browser.refresh()
browser.quit()
