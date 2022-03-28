public class ThreadJoin2 {
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

        t1.start(); // t1与t2都是先start，后join
        t1.join();
        t2.start();
        t2.join();
        t3.join(); // t3先join，后start
        t3.start();
        System.out.println("main线程执行完成退出");
    }
}

/**
 * 执行了100次，都是一样的结果，怎样解释t3在main之后执行？
 * 
 * javac ThreadJoin2.java
 * for i in `seq 100`; do java ThreadJoin2; echo ; done
 * > t1执行
 * > t2执行
 * > main线程执行完成退出
 * > t3执行
 */