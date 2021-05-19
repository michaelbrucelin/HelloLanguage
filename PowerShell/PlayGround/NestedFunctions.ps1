# 函数外面可以调用outer函数，但是不能调用inner1/2函数
function outer() {
    function inner1() {
        Write-Host "inner fucntion1"
    }

    function inner2() {
        Write-Host "inner fucntion2"
    }

    Write-Host "outer fucntion"
    inner1
    inner2
}