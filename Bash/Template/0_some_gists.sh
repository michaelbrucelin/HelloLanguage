# 记录localhost的公网ip，使用0时区时间做记录
echo `TZ=UTC date +'%Y%m%d-%H%M%S';curl ipinfo.io` >> /root/myselfpublicip.txt 2> /dev/null

# 项目使用语言统计
find . -name *.html | wc -l                                                                # 按文件数量汇总
find . -name *.html -exec wc -l {} \; | awk '{sum+=$1} END {print sum}'                    # 按文本行数汇总
find . -name *.html -exec stat --printf="%s {}\n" {} \; | awk '{sum+=$1} END {print sum}'  # 按文件大小汇总
