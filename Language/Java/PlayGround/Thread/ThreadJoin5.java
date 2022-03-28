public class ThreadJoin5 {
    public static void main(String[] args) throws Exception {
        Thread t1 = new Thread(() -> {
            for (int i = 1; i < 16; i++) {
                System.out.println(Thread.currentThread().getName() + "执行:\t" + i);
                try {
                    Thread.sleep(100);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
            System.out.println(Thread.currentThread().getName() + "执行完成");
        }, "t1");

        Thread t2 = new Thread(() -> {
            try {
                t1.join(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }

            for (int i = 1; i < 16; i++) {
                System.out.println(Thread.currentThread().getName() + "执行:\t" + i);
                try {
                    Thread.sleep(100);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
            System.out.println(Thread.currentThread().getName() + "执行完成");
        }, "t2");

        t1.start();
        t2.start();
    }
}

/**
 * join()可以接收参数，表示串行等待的时间，如果超过这个时间，就恢复为join之前的并行状态
 */