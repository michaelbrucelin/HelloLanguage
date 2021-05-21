# 使用密码加密解密字符串，可用于文本文件保存明文密码的场景
# https://stackoverflow.com/questions/2490334/simple-way-to-encode-a-string-according-to-a-password

import base64


def encode(key, clear):
    enc = []
    for i in range(len(clear)):
        key_c = key[i % len(key)]
        enc_c = chr((ord(clear[i]) + ord(key_c)) % 256)
        enc.append(enc_c)
    return base64.urlsafe_b64encode("".join(enc).encode()).decode()


def decode(key, enc):
    dec = []
    enc = base64.urlsafe_b64decode(enc).decode()
    for i in range(len(enc)):
        key_c = key[i % len(key)]
        dec_c = chr((256 + ord(enc[i]) - ord(key_c)) % 256)
        dec.append(dec_c)
    return "".join(dec)


# 测试
mykey = "y@4><h2+qfLNKrEhAo@dArgfY#MvXj62zen1"

str_secure = encode(mykey, "hello world.")
str_plain = decode(mykey, str_secure)
str_plain2 = decode("123456", str_secure)

print(str_secure)
print(str_plain)
print(str_plain2)
