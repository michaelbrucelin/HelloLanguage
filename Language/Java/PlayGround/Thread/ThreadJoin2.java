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
        t3.join(); // t3先join，后start，没start就join，相当于啥都没干
        t3.start();
        System.out.println("main线程执行完成退出");
    }
}

/**
 * join()的意思是使得放弃当前线程的执行，并返回对应的线程，例如t1.join();的意思就是：
 * 程序在main线程中调用t1线程的join方法，则main线程放弃cpu控制权，并返回t1线程继续执行直到线程t1执行完毕，
 * 所以结果是t1线程执行完后，才到主线程执行，相当于在main线程中同步t1线程，t1执行完了，main线程才有执行的机会。
 * 
 * 执行了100次，都是一样的结果，解释为什么t3在main之后执行？
 * 
 * javac ThreadJoin2.java
 * for i in `seq 100`; do java ThreadJoin2; echo ; done
 * > t1执行
 * > t2执行
 * > main线程执行完成退出
 * > t3执行
 */