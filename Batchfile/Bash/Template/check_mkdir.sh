# 如果文件夹不存在，创建文件夹
# https://stackoverflow.com/questions/18622907/only-mkdir-if-it-does-not-exist

# 1. 使用if
if [ ! -d dir ]; then
    mkdir dir
fi

# 2. 使用-p，-p ensures creation if directory does not exist
mkdir -p dir

# 3. 更优雅的实现
[[ -d dir ]] || mkdir dir
