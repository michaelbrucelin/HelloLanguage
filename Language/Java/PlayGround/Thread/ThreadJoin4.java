import java.util.concurrent.CompletableFuture;

public class ThreadJoin4 {
    public static void main(String[] args) throws Exception {
        Thread t1 = new Thread(() -> {
            System.out.println(Thread.currentThread().getName() + "执行");
        }, "t1");

        Thread t2 = new Thread(() -> {
            System.out.println(Thread.currentThread().getName() + "执行");
        }, "t2");

        Thread t3 = new Thread(() -> {
            System.out.println(Thread.currentThread().getName() + "执行");
        }, "t3");

        CompletableFuture.runAsync(() -> t1.start())
                .thenRun(() -> t2.start())
                .thenRun(() -> t3.start());
        System.out.println("main线程执行完成退出");
    }
}

/**
 * 原以为会实现与ThreadJoin3相同的效果，但是并不是
 * 
 * java ThreadJoin4
 * main线程执行完成退出
 * t2执行
 * t1执行
 * t3执行
 */