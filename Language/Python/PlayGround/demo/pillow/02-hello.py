import os
from PIL import Image, ImageColor, ImageDraw, ImageFont

# 1. 创建图像
img = Image.new("RGBA", (100, 200), "purple")
img.save("imgs/purpleImage.png")
img2 = Image.new("RGBA", (20, 20))  # 没有指定颜色，透明背景
img2.save("imgs/transparentImage.png")

# 2. 更改单个像素
img = Image.new("RGBA", (100, 100))
img.getpixel((0, 0))  # (0, 0, 0, 0)  获取颜色
for x in range(100):
    for y in range(100):
        img.putpixel((x, y), (210, 210, 210))  # 设置颜色

for x in range(100):
    for y in range(50, 100):
        img.putpixel((x, y), ImageColor.getcolor("darkgray", "RGBA"))

img.getpixel((0, 0))  # (210, 210, 210, 255)
img.getpixel((0, 50))  # (169, 169, 169, 255)
img.save("imgs/putPixel.png")

# 3. 在图像上绘画
img = Image.new("RGBA", (200, 200), "white")
draw = ImageDraw.Draw(img)
draw.line([(0, 0), (199, 0), (199, 199), (0, 199), (0, 0)], fill="black")
draw.rectangle((20, 30, 60, 60), fill="blue")
draw.ellipse((120, 30, 160, 60), fill="red")
draw.polygon(((57, 87), (79, 62), (94, 85), (120, 90), (103, 113)), fill="brown")

for i in range(100, 200, 10):
    draw.line([(i, 0), (200, i - 100)], fill="green")

img.save("imgs/drawing.png")

# 4. 绘制文本
img = Image.new("RGBA", (200, 200), "white")
draw = ImageDraw.Draw(img)
draw.text((20, 150), "Hello", fill="purple")
fontsFolder = r"C:\Windows\Fonts"
arialFont = ImageFont.truetype(os.path.join(fontsFolder, "arial.ttf"), 32)
draw.text((100, 150), "Howdy", fill="gray", font=arialFont)
img.save("imgs/text.png")
