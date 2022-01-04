import smtplib

# 1. 基本流程
smtpObj = smtplib.SMTP('smtp.example.com', 587)  # 通常为587端口，表示标准的tls加密
smtpObj.ehlo()
smtpObj.starttls()
smtpObj.login('bob@example.com', '123456')
smtpObj.sendmail('bob@ex.com', 'alice@ex.com',
                 'Subject:So long.\nDear alice, so long ... ...')
smtpObj.quit()
