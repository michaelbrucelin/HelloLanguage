package Java.Package.PlayGround;

public class HelloWorld {
    public static void main(String[] args) {
        System.out.println("Hello World!");
    }
}

// # javac Java/Package/PlayGround/HelloWorld.java  # 编译不要求完整的目录，可以直接在当前目录执行 javac
// HelloWorld2.java
// # java Java/Package/PlayGround/HelloWorld        # 需要在指定的目录下执行，必须切换到包的父目录（这里是外层的PlayGround目录）下才能执行
// Hello World!
