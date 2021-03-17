import jieba  # 分词
from matplotlib import pyplot as plt  # 绘图，数据可视化
from wordcloud import WordCloud  # 词云
from PIL import Image  # 图片处理
import numpy as np  # 矩阵运算
import sqlite3

# 准备词云所需要的文字（词）
conn = sqlite3.connect("DouBanMovieTop250.db")
cursor = conn.cursor()
sql = "select instroduction from movie250"
data = cursor.execute(sql)
text = ""
for item in data:
    text = text + item[0]
    # print(item[0])
# print(text)
cursor.close()
conn.close()

# 分词
cut = jieba.cut(text)
string = ' '.join(cut)
# print(string)
# print(len(string))

# 生成遮罩
img = Image.open(r"./static/img/tree.jpg")  # 打开遮罩图片
img_array = np.array(img)  # 将图片转为数组
wc = WordCloud(
    background_color="white",
    mask=img_array,
    font_path=r"./static/font/stxinwei.ttf"
)
wc.generate_from_text(string)

# 绘制图片
fig = plt.figure(1)  # 找第一个位置
plt.imshow(wc)
plt.axis("off")  # 是否显示坐标轴
# plt.show()  #显示生成的词云图片
plt.savefig(r"./static/img/word.jpg", dpi=441)
