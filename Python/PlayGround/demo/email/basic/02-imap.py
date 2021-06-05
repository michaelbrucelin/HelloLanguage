# 这里使用第三方的imapclient，它比内建的imaplib更好用
# imapclient下载的电子邮件格式复杂，使用pyzmail模块可以解决这个问题
# pip install imapclient pyzmail

import imapclient
import pyzmail

# 1. 基本流程
imapObj = imapclient.IMAPClient('iamp.example.com', ssl=True)
imapObj.login('bob@example.com', '123456')
imapObj.select_folder('INBOX', readonly=True)
UIDs = imapObj.search(['SINCE 05-Jul-2019'])
UIDs

rawMwssages = imapObj.fetch([40041], ['BODY[]', 'FLAGS'])
message = pyzmail.PyzMessage.factory(rawMwssages[40041][b'BODY[]'])
message.get_subject()
message.get_addresses('from')
message.get_addresses('to')
message.get_addresses('cc')
message.get_addresses('bcc')
message.text_part != None
message.text_part.get_payload().decode(message.text_part.charset)
message.html_part != None
message.html_part.get_payload().decode(message.text_part.charset)
imapObj.logout()

# 2. 删除邮件
imapObj.delete_messages(UIDs)  # 加上删除标记
imapObj.expunge()              # 删除有标记的邮件
