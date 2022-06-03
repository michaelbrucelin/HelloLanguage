public class TimeComplex {
    // 场景1 T(n)=3n，执行次数是线性的
    void eat1(int n) {
        for (int i = 0; i < n; i++) {
            System.out.println("等待1min");
            System.out.println("等待1min");
            System.out.println("吃1cm面包");
        }
    }

    // 场景2 T(n)=5logn，执行次数是用对数计算的
    void eat2(int n) {
        for (int i = n; i > 1; i /= 2) {
            System.out.println("等待1min");
            System.out.println("等待1min");
            System.out.println("等待1min");
            System.out.println("等待1min");
            System.out.println("吃一半面包");
        }
    }

    // 场景3 T(n)=2，执行次数是常量
    void eat3(int n) {
        System.out.println("等待1min");
        System.out.println("吃1个鸡腿");
    }

    // 场景4 T(n)=0.5n^2+0.5n，执行次数是用多项式计算的
    void eat4(int n) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < i; j++) {
                System.out.println("等待1min");
            }
            System.out.println("吃1cm面包");
        }
    }
}
