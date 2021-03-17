function Person(){};
var p1 = new Person();
p1.name = 'mlin';
p1.age = 18;
p1.SayHello = function(){
    console.log('Hello World')
};

console.log(p1.name);
console.log(p1.age);
p1.SayHello();


function Person(name, age){
    this.name = name;
    this.age = age;
    this.SayHello = function(){
        console.log('Hello World');
    };
}

var p2 = new Person("mlin", 18);
console.log(p2.name);
console.log(p2.age);
p2.SayHello();