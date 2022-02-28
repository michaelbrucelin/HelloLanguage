function myjava-run() {
    touch DeleteAnchor.class  # 这个文件用来记录删除文件的时间锚点
    javac "$1"
    java "$(basename "$1" .java)"
    # rm -f "$(basename "$1" .java).class"  # 可能会生成多个class文件，这样删除删不干净
    find . -name '*.class' -newer DeleteAnchor.class -exec rm -f {} \;
    rm -f DeleteAnchor.class
}
