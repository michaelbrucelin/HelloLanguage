function myjava-run() {
    javac "$1"
    java "$(basename "$1" .java)"
    rm -f "$(basename "$1" .java).class"
}
