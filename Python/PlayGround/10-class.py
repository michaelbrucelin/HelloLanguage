# class

# 1. 创建类
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


# 2. 使用类
my_dog = Dog("Willie", 6)
print(
    f"my dog's name is {my_dog.name}, it is {my_dog.age} year{'s' if my_dog.age>1 else ''} old.")
my_dog.sit()

# 3. 类的继承
class Car:
    def __init__(self, make, model, year):
        self.make = make
        self.model = model
        self.year = year
        self.odometer_reading = 0

    def get_descriptive_name(self):
        long_name = f"{self.year} {self.make} {self.model}"
        return long_name.title()

    def read_odometer(self):
        print(f"This car has {self.odometer_reading} miles on it.")

    def update_odometer(self, mileage):
        if mileage >= self.odometer_reading:
            self.odometer_reading = mileage
        else:
            print("You can't roll back an odometer!")

    def increment_odometer(self, miles):
        self.odometer_reading += miles


class ElectricCar(Car):  # 继承自Car
    def __init__(self, make, model, year):
        super().__init__(make, model, year)  # 调用父类的构造方法
        self.battery_size = 75               # 子类独有的属性

    def describe_battery(self):  # 子类独有的方法
        print(f"This car has a {self.battery_size}-kWh battery.")
