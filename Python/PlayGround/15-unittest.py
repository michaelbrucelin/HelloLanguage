# unittest
# unittest模块可以自动测试代码，测试自己编写的函数与类

import unittest
from ModuleFor15 import get_formatted_name


class NameTestCase(unittest.TestCase):
    """测试ModuleFor15.py"""

    def test_first_last_name(self):
        """能够正确地处理像Janis Joplin这样的姓名吗？"""
        formatted_name = get_formatted_name('janis', 'joplin')
        self.assertEqual(formatted_name, 'Janis Joplin')


if __name__ == '__main__':
    unittest.main()
