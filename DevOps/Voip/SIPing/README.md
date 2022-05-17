# SIP Ping Tools

这里记录了一些sip ping相关的工具。

## Sofia-SIP

见`../Sofia-SIP`中的说明。

## sip-ping

基于Go的，没有尝试，链接：<https://github.com/lwahlmeier/sip-ping>

## sip-ping1.py

python2下试了可以用，链接：<https://gekk.info/sipping/>

```bash
# yum install python-argparse  # CentOS6中使用pip安装argparse失败

python sipping.py 192.168.2.126
Press Ctrl+C to abort
> (17/05/22 09:32:42:831051) Sending to 192.168.2.126:5060 [id: 4629147899]
< (17/05/22 09:32:42:831431) Reply from 192.168.2.126 (0.22ms): SIP/2.0 200 OK
> (17/05/22 09:32:43:832275) Sending to 192.168.2.126:5060 [id: 2303238194]
< (17/05/22 09:32:43:832664) Reply from 192.168.2.126 (0.23ms): SIP/2.0 200 OK
> (17/05/22 09:32:44:833196) Sending to 192.168.2.126:5060 [id: 0551402828]
< (17/05/22 09:32:44:833546) Reply from 192.168.2.126 (0.19ms): SIP/2.0 200 OK
> (17/05/22 09:32:45:835056) Sending to 192.168.2.126:5060 [id: 0566406729]
< (17/05/22 09:32:45:835383) Reply from 192.168.2.126 (0.18ms): SIP/2.0 200 OK
```

## sip-ping2.py

python2与python3测试都没成功，没有继续尝试，链接：<https://github.com/pbertera/SIPPing>
