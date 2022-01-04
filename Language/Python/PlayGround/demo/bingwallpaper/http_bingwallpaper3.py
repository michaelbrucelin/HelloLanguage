#!/usr/bin/python
# -*- coding: utf-8 -*-

import os
import urllib
import urllib2
from bs4 import BeautifulSoup

# Get BingXML file which contains the URL of the Bing Photo of the day
# idx = Number days previous the present day. 0 means current day, 1 means       yesterday, etc
# n = Number of images predious the day given by idx
# mkt denotes your location. e.g. en-US means United States. Put in your  country code
BingXML_URL = "http://www.bing.com/HPImageArchive.aspx?     format=xml&idx=0&n=1&mkt=en-US"
page = urllib2.urlopen(BingXML_URL)
BingXML = BeautifulSoup(page, "lxml")

# For extracting complete URL of the image
Images = BingXML.find_all('image')
ImageURL = "https://www.bing.com" + Images[0].url.text
ImageName = Images[0].startdate.text+".jpg"

urllib.urlretrieve(ImageURL, ImageName)
