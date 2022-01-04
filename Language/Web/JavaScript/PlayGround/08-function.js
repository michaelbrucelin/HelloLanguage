//虽然函数定义只有一个形参，调用时却可以传入实参，但是只有第一个实参有效
function Add(num1) {
    return num1 + 1;
}
console.log(Add(1, 2, 3, 4))

//虽然函数定义只有一个形参，调用时却可以通过“参数列表”使用所有传进来的参数
function Add2(num1) {
    for (let i = 0; i < arguments.length; i++) {
        console.log(arguments[i] + 100);
    }
}
Add2(1, 2, 3, 4)

//虽然函数定义没有形参，调用时却可以通过“参数列表”使用所有传进来的参数
function Add3() {
    for (let i = 0; i < arguments.length; i++) {
        console.log(arguments[i] + 100);
    }
}
Add3(1, 2, 3, 4)
