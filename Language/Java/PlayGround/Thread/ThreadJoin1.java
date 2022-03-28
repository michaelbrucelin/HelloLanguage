public class ThreadJoin1 {
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

        t1.start();
        t2.start();
        t3.start();
        System.out.println("main线程执行完成退出");
    }
}

/**
 * 此时，t1、t2、t3、main线程作为4个独立的线程执行，没有执行顺序
 * 
 * java ThreadJoin1
 * > main线程执行完成退出
 * > t3执行
 * > t1执行
 * > t2执行
 */