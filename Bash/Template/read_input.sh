# 从终端用户读取输入并存入变量
# https://stackoverflow.com/questions/18544359/how-to-read-user-input-into-a-variable-in-bash

# 1. Use read -p:
# fullname="USER INPUT"
read -p "Enter fullname: " fullname
# user="USER INPUT"
read -p "Enter user: " user

printf "\nfullname: %s; user: %s\n" "${fullname}" "${user}"

# 注意：下面的用法是错误的，如果用户的输入含有空格，将会出现错误
printf "\nfullname: %s; user: %s\n" ${fullname} ${user}

# 2. If you like to confirm:
read -p "Continue? (Y/N): " confirm && [[ $confirm == [yY] || $confirm == [yY][eE][sS] ]] || exit 1
# if you use bash 4.0+, you can write like this
read -p "Continue? (Y/N): " confirm && ${confirm^^} == 'YES' || exit 1
