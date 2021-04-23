import urllib.request as urllib
import json
from datetime import date
from dateutil import parser
import sys
import os

months = "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"


def downloadBingImages(start):
    try:
        data = urllib.urlopen(
            "https://www.bing.com/hpimagearchive.aspx?format=js&idx=%i&n=8&mkt=en-NZ" % start).read()
    except:
        sys.exit()
    e = json.loads(data.decode())
    images = e["images"]

    for image in images:
        d = parser.parse(image["startdate"])  # parse("20181206")

        filename = str(d.date())+".jpg"  # 2018-12-06.jpg
        # 2018/12 December/
        folder = "%i/%i %s/" % (d.year, d.month, months[d.month-1])
        # 2018/12 December/2018-12-06.jpg
        file = folder+filename

        if not os.path.exists(folder):
            os.makedirs(folder)
        exists = os.path.isfile(file)

        url = "https://www.bing.com"+image["urlbase"]+"_1920x1200.jpg"
        print(("downloading", "exists")[exists], filename, url)
        if not exists:
            try:
                urllib.urlretrieve(url, file)
            except:
                sys.exit()

    print()


# downloads the 16 latest bing images
downloadBingImages(-1)
downloadBingImages(7)
