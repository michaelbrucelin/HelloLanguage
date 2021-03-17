function Add(num1) {
    return num1 + 1;
}
console.log(Add(1, 2, 3, 4))

function Add2(num1) {
    for (let i = 0; i < arguments.length; i++) {
        console.log(arguments[i] + 100);
    }
}
Add2(1, 2, 3, 4)

function Add3() {
    for (let i = 0; i < arguments.length; i++) {
        console.log(arguments[i] + 100);
    }
}
Add3(1, 2, 3, 4)