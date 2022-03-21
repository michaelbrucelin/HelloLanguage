# lib_mysqludf_sys

A UDF library with functions to interact with the operating system. These functions allow you to interact with the execution environment in which MySQL runs.  
具有与操作系统交互的功能的 UDF 库。这些函数允许您与 MySQL 运行的执行环境进行交互。

项目地址：[https://github.com/mysqludf/lib_mysqludf_sys](https://github.com/mysqludf/lib_mysqludf_sys)

## Steps to be followed

- Get the files from [https://github.com/mysqludf/lib_mysqludf_sys](https://github.com/mysqludf/lib_mysqludf_sys)
    > `git clone https://github.com/mysqludf/lib_mysqludf_sys.git`
- Go to the folder path in terminal.
- Execute:
    > `yum install -y mysql-devel gcc`  
    > `gcc -DMYSQL_DYNAMIC_PLUGIN -fPIC -Wall -m64 -I/usr/include/mysql -I. -shared lib_mysqludf_sys.c -o lib_mysqludf_sys.so`  
    NOTE: If 32-bit OS replace -m64 with -m32 in the above command.
- Execute the following in mysql shell:
    > `mysql -uroot -e "SHOW VARIABLES LIKE 'plugin_dir'"`  
    This is an example of successful output:  
    +---------------+--------------------------+  
    | Variable_name | Value                    |  
    +---------------+--------------------------+  
    | plugin_dir    | /usr/lib64/mysql/plugin/ |  
    +---------------+--------------------------+
- Copy the lib_mysqludf_sys.so file to the above path.
    > `cp lib_mysqludf_sys.so /usr/lib64/mysql/plugin`
- Execute the following in mysql shell
    > `DROP FUNCTION IF EXISTS lib_mysqludf_sys_info;`  
    > `DROP FUNCTION IF EXISTS sys_get;`  
    > `DROP FUNCTION IF EXISTS sys_set;`  
    > `DROP FUNCTION IF EXISTS sys_exec;`  
    > `DROP FUNCTION IF EXISTS sys_eval;`  
    >  
    > `CREATE FUNCTION lib_mysqludf_sys_info RETURNS string SONAME 'lib_mysqludf_sys.so';`  
    > `CREATE FUNCTION sys_get RETURNS string SONAME 'lib_mysqludf_sys.so';`  
    > `CREATE FUNCTION sys_set RETURNS int SONAME 'lib_mysqludf_sys.so';`  
    > `CREATE FUNCTION sys_exec RETURNS int SONAME 'lib_mysqludf_sys.so';`  
    > `CREATE FUNCTION sys_eval RETURNS string SONAME 'lib_mysqludf_sys.so';`

## 操作

亲测在下面的环境中有效。

```bash
# 环境
cat /etc/redhat-release
> CentOS release 6.10 (Final)
mysql --version
> mysql  Ver 14.14 Distrib 5.1.73, for redhat-linux-gnu (x86_64) using readline 5.1

# 配置好postfix与mailx
vim /usr/lib64/mysql/plugin/sendemail.sh
#!/bin/bash

PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:/usr/sbin:/usr/bin:/root/bin
export PATH

LANG=C

THISTIME=$(TZ=UTC-8 date -R)
echo -e "The ${1} of ${2} have been processed. \nTime: ${THISTIME}\n" \
    | mail -r monitor@somedomain.com \
    # -a "X-Auth: EL6V8QEA2WTqSSo1ljMuiVdHSxZ16UQF" \          # mailx这样添加自定义邮件头无效
    # -s "The CDR and LOG data of ${1} have been processed" \  # 像下面这样可以添加自定义邮件头
    -s "$(echo -e "The ${1} of ${2} have been processed\nX-Auth: EL6V8QEA2WTqSSo1ljMuiVdHSxZ16UQF")" \
    somebody@somedomain.com somebody2@somedomain.com

# 使用
select sys_exec('bash /usr/lib64/mysql/plugin/sendemail.sh cdr|log 2022-03-21');
```
