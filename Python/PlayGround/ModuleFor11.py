# use for 11-usemodule.py

def printinfo():
    print("this is my first python module.")


class Dog:
    """模拟一直小狗"""

    def __init__(self, name, age):  # 构造方法
        """初始化name与age"""
        self.name = name
        self.age = age

    def sit(self):
        """模拟小狗蹲下"""
        print(f"{self.name} is now sitting.")

    def roll_over(self):
        """模拟小狗打滚"""
        print(f"{self.name} rolled over!")
