# 第三方模块pillow允许python像Microsoft Paint或Adobe Photoshop一样处理图片
# -m pip install --upgrade pip

from PIL import ImageColor, Image

# 1. 通过颜色获取RGBA值
ImageColor.getcolor("red", "RGBA")  # (255, 0, 0, 255)
ImageColor.getcolor("RED", "RGBA")  # (255, 0, 0, 255)
ImageColor.getcolor("Red", "RGBA")  # (255, 0, 0, 255)
ImageColor.getcolor("Black", "RGBA")  # (0, 0, 0, 255)
ImageColor.getcolor("chocolate", "RGBA")  # (210, 105, 30, 255)
ImageColor.getcolor("CornflowerBlue", "RGBA")  # (100, 149, 237, 255)

# 2. 用pillow操作图像
catImg = Image.open("imgs/zophie.png")
catImg.size(816, 1088)
width, height = catImg.size
width  # 816
height  # 1088
catImg.filename  # 'imgs/zophie.png'
catImg.format  # 'PNG'
catImg.format_description  # 'Portable network graphics'
catImg.save("imgs/zophie.jpg")

# 3. 裁剪图像
# crop()方法不会更改原图，而是返回一个新的图像
catImg = Image.open("imgs/zophie.png")
croppedImg = catImg.crop((335, 345, 565, 560))
croppedImg.save("imgs/cropped.png")

# 4. 复制和粘贴图像到其他图像
# copy()与paste()并不使用操作系统的剪切板
catImg = Image.open("imgs/zophie.png")
catCopyImg = catImg.copy()  # paste()方法在原图上更改图片，所以复制出来一份，这样可以保留原图
faceImg = catImg.crop((335, 345, 565, 560))
catCopyImg.paste(faceImg, (0, 0))
catCopyImg.paste(faceImg, (400, 500))
catCopyImg.save("imgs/pasted.png")

catImg = Image.open("imgs/zophie.png")
catImgWidth, catImgHeight = catImg.size
faceImg = catImg.crop((335, 345, 565, 560))
faceImgWidth, faceImgHeight = faceImg.size
catCopy2 = catImg.copy()
for left in range(0, catImgWidth, faceImgWidth):
    for top in range(0, catImgHeight, faceImgHeight):
        # print(left, top)
        catCopy2.paste(faceImg, (left, top))
catCopy2.save("imgs/tiled.png")

# 5. 调整图像大小
# resize()方法不会更改原图，而是返回一个新的图像
catImg = Image.open("imgs/zophie.png")
catImgWidth, catImgHeight = catImg.size
quartersizedImg = catImg.resize((int(catImgWidth / 2), int(catImgHeight / 2)))
quartersizedImg.save("imgs/quartersized.png")
svelteImg = catImg.resize((catImgWidth, catImgHeight + 300))
svelteImg.save("imgs/svelte.png")

# 6. 旋转和翻转图像
# rotate()与transpose()方法不会更改原图，而是返回一个新的图像
catImg = Image.open("imgs/zophie.png")
catImg.rotate(90).save("imgs/rotated90.png")
catImg.rotate(180).save("imgs/rotated180.png")
catImg.rotate(270).save("imgs/rotated270.png")

catImg.rotate(6).save("imgs/rotated6.png")
catImg.rotate(6, expand=True).save("imgs/rotated6_expanded.png")

catImg.transpose(Image.FLIP_LEFT_RIGHT).save("imgs/horizontal_flip.png")
catImg.transpose(Image.FLIP_TOP_BOTTOM).save("imgs/vertical_flip.png")
