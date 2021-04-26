# 将豆瓣上电影top250的信息下载下来

# -*- codeing = utf-8 -*-
import os.path
from bs4 import BeautifulSoup  # 网页解析，获取数据
import re  # 正则表达式
import urllib.request
import urllib.error  # 制定url，获取网页数据
import xlwt  # excel
import sqlite3  # sqlite


def main():
    baseurl = "https://movie.douban.com/top250?start="
    # 1.爬取网页
    datalist = getData(baseurl)
    excelpath = r"DouBanMovieTop250.xls"
    dbpath = r"DouBanMovieTop250.db"

    # 3.保存数据
    # saveData2Excel(datalist, excelpath)
    saveData2DB(datalist, dbpath)


# 创建正则表达式对象
findLink = re.compile(r'<a href="(.*?)">')  # 影片详情链接
findImgSrc = re.compile(r'<img.*src="(.*?)".*>', re.S)  # 影片图片
findTitle = re.compile(r'<span class="title">(.*)</span>')  # 影片片名
findRating = re.compile(r'<span class="rating_num" property="v:average">(.*)</span>')  # 影片评分
findJudge = re.compile(r'<span>(\d*)人评价</span>')  # 影片评价人数
findInq = re.compile(r'<span class="inq">(.*)</span>')  # 影片概况
findBd = re.compile(r'<p class="">(.*?)</p>', re.S)  # 影片相关内容

# 爬取网页
def getData(baseurl):
    datalist = []
    for i in range(0, 10):
        url = baseurl + str(i*25)
        html = askURL(url)
        # 2.逐一解析数据
        soup = BeautifulSoup(html, "html.parser")
        for item in soup.findAll("div", class_="item"):
            # print(item)
            data = []
            item = str(item)
            
            link = re.findall(findLink, item)[0]  #影片链接
            data.append(link)
            imgSrc = re.findall(findImgSrc, item)[0]  #影片图片
            data.append(imgSrc)
            titles = re.findall(findTitle, item)
            if(len(titles) == 2):
                ctitle = titles[0]  #影片中文名
                data.append(ctitle)
                otitle = titles[1].replace("/", "").strip()  #影片外文名
                data.append(otitle)
            else:
                data.append(titles[0])
                data.append(" ")
            rating = re.findall(findRating, item)[0]  #影片评分
            data.append(rating)
            judgeNum = re.findall(findJudge,item)[0]  #影片评价人数
            data.append(judgeNum)
            inq = re.findall(findInq, item)  #影片概况
            if(len(inq) != 0):
                inq = inq[0].replace("。", "")
                data.append(inq)
            else:
                data.append(" ")
            bd = re.findall(findBd, item)[0]  #影片相关内容
            bd = re.sub('<br(\s+)?/>(\s+)?', "", bd)
            bd = re.sub('/', "", bd)
            data.append(bd.strip())

            datalist.append(data)

    #print(datalist)
    return datalist

# 获取一个指定url的网页内容
def askURL(url):
    header = {
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.92 Safari/537.36"
    }
    request = urllib.request.Request(url, headers=header)
    html = ""
    try:
        response = urllib.request.urlopen(request)
        html = response.read().decode("utf-8")
        # print(html)
    except urllib.error.URLError as ex:
        if hasattr(ex, "code"):
            print(ex.code)
        if hasattr(ex, "reason"):
            print(ex.reason)

    return html

# 保存数据到Excel
def saveData2Excel(datalist, excelpath):
    print("saving ... ...")
    workbook = xlwt.Workbook(encoding="utf-8", style_compression=0)
    worksheet = workbook.add_sheet("豆瓣电影Top250", cell_overwrite_ok=True)
    cols = ("详情链接", "图片链接", "影片中文名", "影片外文名", "评分", "评价数", "概况", "相关信息")
    for i in range(0, len(cols)):
        worksheet.write(0, i, cols[i])
    for i in range(0, len(datalist)):
        print("正在保存第%d条"%(i+1))
        data = datalist[i]
        for j in range(0, len(data)):
            worksheet.write(i+1, j, data[j])
    
    workbook.save(excelpath)

# 保存数据到Sqlite
def saveData2DB(datalist, dbpath):
    init_db(dbpath)
    conn = sqlite3.connect(dbpath)
    cursor = conn.cursor()
    for data in datalist:
        for index in range(0, len(data)):
            if(index == 4 or index == 5):
                continue
            data[index] = '"'+data[index]+'"'
        sql = '''
            insert into movie250(info_link, pic_link, cname, ename, score, rated, instroduction, info)
            values(%s)
        '''%",".join(data)
        #print(sql)
        cursor.execute(sql)
        conn.commit()
    cursor.close()
    conn.close()

# 创建数据库
def init_db(dbpath):
    if(not os.path.exists(dbpath)):
        conn = sqlite3.connect(dbpath)
        sql = '''
            create table movie250(
                id integer primary key autoincrement,
                info_link text,
                pic_link text,
                cname varchar,
                ename varchar,
                score numeric,
                rated numeric,
                instroduction text,
                info text
            )
        '''
        cursor = conn.cursor()
        cursor.execute(sql)
        conn.commit()
        conn.close()

# main函数，程序入口
if __name__ == "__main__":
    main()
    print("爬取完成")
