public class CommandLineArgs {
    public static void main(String[] args) {
        System.out.println("命令行参数是");

        // 遍历所有参数
        for (String str : args) {
            System.out.println(str);
        }
    }
}

/*
javac CommandLineArgs.java
java CommandLineArgs a bb  ccc    dddd
> 命令行参数是
> a
> bb
> ccc
> dddd
*/