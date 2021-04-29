# 邮件发送
# https://docs.python.org/zh-cn/3/library/email.examples.html

# 1. 创建和发送简单的文本消息（文本内容和地址都可能包含unicode字符）
# Import smtplib for the actual sending function
import smtplib
# Import the email modules we'll need
from email.message import EmailMessage

# Open the plain text file whose name is in textfile for reading.
# with open(textfile) as fp:
#     # Create a text/plain message
#     msg = EmailMessage()
#     msg.set_content(fp.read())
msg = EmailMessage()
msg.set_content('Hello World.')

# me == the sender's email address
# you == the recipient's email address
msg['Subject'] = f'The contents of {msg.get_content()}'
msg['From'] = 'root@localhost.localdomain'
msg['To'] = ['user1@localhost.localdomain', 'user2@localhost.localdomain']

# Send the message via our own SMTP server.
s = smtplib.SMTP('localhost')
s.send_message(msg)
s.quit()
