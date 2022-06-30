# 发邮件脚本
# vim send_mail.sh
#!/bin/bash

FROM=""
SUBJECT=""
ATTACHMENTS=""
TO=""
BODY=""

# 检查文件名对应的文件是否存在
function check_files() {
    output_files=""
    for file in $1
    do
        if [ -s $file ]; then
            output_files="${output_files}${file} "
        fi
    done
    echo $output_files
}

echo "*********************"
echo "E-mail sending script."
echo "*********************"
echo

# 读取用户输入的邮件地址
while [ 1 ]
do
    if [ ! $FROM ]; then
        echo -n -e "Enter the e-mail address you wish to send mail from:\n[Enter] "
    else
        echo -n -e "The address you provided is not valid:\n[Enter] "
    fi
    read FROM
    echo $FROM | grep -E '^.+@.+$' > /dev/null
    if [ $? -eq 0 ]; then
        break
    fi
done
echo

# 读取用户输入的收件人地址
while [ 1 ]
do
    if [ ! $TO ]; then
        echo -n -e "Enter the e-mail address you wish to send mail to:\n[Enter] "
    else
        echo -n -e "The address you provided is not valid:\n[Enter] "
    fi
    read TO
    echo $TO | grep -E '^.+@.+$' > /dev/null
    if [ $? -eq 0 ]; then
        break
    fi
done
echo

# 读取用户输入的邮件主题
echo -n -e "Enter e-mail subject:\n[Enter] "
read SUBJECT
echo
if [ "$SUBJECT" == "" ]; then
    echo "Proceeding without the subject..."
fi

# 读取作为附件的文件名
echo -e "Provide the list of attachments. Separate names by space.
If there are spaces in file name, quote file name with \"."
read att
echo

# 确保文件名指向真实文件
attachments=$(check_files "$att")
echo "Attachments: $attachments"
for attachment in $attachments
do
    ATTACHMENTS="$ATTACHMENTS-a $attachment "
done
echo

# 读取完整的邮件正文
echo "Enter message. To mark the end of message type ;; in new line."
read line
while [ "$line" != ";;" ]
do
    BODY="$BODY$line\n"
    read line
done
SENDMAILCMD="mutt -e \"set from=$FROM\" -s \"$SUBJECT\" \
$ATTACHMENTS -- \"$TO\" <<< \"$BODY\""
echo $SENDMAILCMD
mutt -e "set from=$FROM" -s "$SUBJECT" $ATTACHMENTS -- $TO <<< $BODY
