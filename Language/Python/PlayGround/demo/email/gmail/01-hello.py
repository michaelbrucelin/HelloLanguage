# 这里使用第三方模块ezgmail来操作GMail
# pip install ezgmail
# 使用api操作gmail，需要先在gmail页面上enable the gmail api，然后下载证书json文件，放在python脚本的同目录下

import os
import ezgmail

# 1. 启用GMail API
ezgmail.init()         # 打开浏览器，并鉴权
ezgmail.EMAIL_ADDRESS

# 2. 发送邮件
ezgmail.send('recipient@example.com', 'Subject line',
             'Body of the gmail.')                                                            # 发邮件
ezgmail.send('recipient@example.com', 'Subject line',
             'Body of the gmail.', ['attachment1.jpg', 'attachment2.mps'])                    # 发送带附件的邮件
ezgmail.send('recipient@example.com', 'Subject line', 'Body of the gmail.',
             cc='friend@example.com', bcc='otherfirend@example.com,someoneelse@example.com')  # 发送带抄送和密送的邮件

# 3. 读取邮件
unreadThreads = ezgmail.unread()
ezgmail.summary(unreadThreads)
len(unreadThreads)
str(unreadThreads[0])
len(unreadThreads[0].messages)
str(unreadThreads[0].messages[0])
unreadThreads[0].messages[0].subject
unreadThreads[0].messages[0].body
unreadThreads[0].messages[0].timestamp
unreadThreads[0].messages[0].sender
unreadThreads[0].messages[0].recipient

recentThreads = ezgmail.recent()
recentThreads = ezgmail.recent(maxResults=100)

# 4. 搜索邮件
resultThreads = ezgmail.search('Robocop')
len(recentThreads)
ezgmail.summary(recentThreads)

# 5. 下载附件
threads = ezgmail.search('vacation photos')
threads[0].messages[0].attachments
threads[0].messages[0].downloadAttachment('tulips.jpg')
threads[0].messages[0].downloadAllAttachments(downloadFolder='vacat ion2019')
