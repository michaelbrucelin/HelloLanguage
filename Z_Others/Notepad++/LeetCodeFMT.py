# -*- coding: UTF-8 -*-
# 在Notepad++的PythonScript插件中使用，格式化LeetCode的Markdown文档

# The lines up to and including sys.stderr should always come first
# Then any errors that occur later get reported to the console
# If you'd prefer to report errors to a file, you can do that instead here.
import sys
from Npp import *

# Set the stderr to the normal console as early as possible, in case of early errors
sys.stderr = console

# Define a class for writing to the console in red
class ConsoleError:
    def __init__(self):
        global console
        self._console = console

    def write(self, text):
        self._console.writeError(text)

# Set the stderr to write errors in red
sys.stderr = ConsoleError()

# This imports the "normal" functions, including "help"
import site

sys.stdout = console

# In order to set the stdout to the current active document, uncomment the following line
# sys.stdout = editor
# So print "hello world", will insert "hello world" at the current cursor position

# 上面的脚本来自官方示例的startup.py，下面是主代码

"""
# <https://npppythonscript.sourceforge.net/>
editor.replace("old", "new")                             # Simple search / replace
editor.rereplace(r"^([A-Z]{3,5})--\1", r"CODE: \1")      # Regular expressions search and replace
editor.appendText("Changed codes\r\n")                   # Call a Scintilla function 
newFilename = notepad.getCurrentFilename() + ".changed"  # Save the file
notepad.saveAs(newFilename);
console.write("Saved as %s\n" % newFilename)             # Write to the console window
notepad.new()                                            # Create a new document
console.run('compiler.exe "%s"' % newFilename, editor)   # Run a command on the file, and output results to the new file
"""

import string

editor.rereplace("^思路与算法$", "##### 思路与算法")
editor.rereplace("^代码$", "##### 代码")
editor.rereplace("^复杂度分析$", "##### 复杂度分析")

all_ascii_digits = string.digits + string.ascii_lowercase + string.ascii_uppercase
all_ascii_letter = string.ascii_lowercase + string.ascii_uppercase

for c in all_ascii_digits:
    # editor.rereplace(f'([^{c}])({c})({c})({c})([^{c}])', r'\1$\3$\5')  # python 2.7.18 不支持此用法
    editor.rereplace(r'([^%s])(%s)(%s)(%s)([^%s])' % (c, c, c, c, c), r'\1$\3$\5')
    editor.rereplace(r'(O\(%s\))(O\(%s\))(O\(%s\))' % (c, c, c), r'$\2$')

editor.replace("−", "-")
editor.replace(' ', " ")     # THSP
editor.replace('\n​\n ', '')  # ZWSP
editor.replace('​', "")       # ZWSP
editor.replace("ababab", "$ab$")
editor.replace("bcbcbc", "$bc$")
editor.replace("acacac", "$ac$")
editor.replace("abcabcabc", "$abc$")
editor.replace("a,ba,ba,b", "$a,b$")
editor.replace("b,cb,cb,c", "$b,c$")
editor.replace("a,ca,ca,c", "$a,c$")
editor.replace("a,b,ca,b,ca,b,c", "$a,b,c$")
editor.replace("a<ba < ba<b", "$a < b$")
editor.replace("b<cb < cb<c", "$b < c$")
editor.replace("a<ca < ca<c", "$a < c$")
editor.replace("a<b<ca < b < ca<b<c", "$a < b < c$")
