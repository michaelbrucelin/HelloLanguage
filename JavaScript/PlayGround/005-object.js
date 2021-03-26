//对象，Object

//创建对象方式1
var lennon = Object();
lennon.name = "John";
lennon.year = 1940;
lennon.living = false;

//创建对象方式2
var lennon = {};
lennon.name = "John";
lennon.year = 1940;
lennon.living = false;

//创建对象方式3
var lennon = { name: "John", year: 1940, living: false };

/*
javascript中的对象有3种
1. 用户定义对象（user-defined object），由程序员自行创建的对象；
2. 内建对象（native object），内建在javascript语言里的对象，如Array、Math和Date等；
3. 宿主对象（host objetc），由浏览器提供的对象，如Document、From和Element等；
*/