public class SpaceComplex {
    // 1. 常量空间
    void fun1(int n) {
        int var = 3;
        // do something
    }

    // 2. 线性空间
    void fun2(int n) {
        int[] array = new int[n];
        // do something
    }

    // 3. 二维空间
    void fun3(int n) {
        int[][] matrix = new int[n][n];
        // do something
    }

    // 4. 递归空间
    void fun4(int n) {
        if (n <= 0) {
            return;
        }
        fun4(n - 1);
        // do something
    }
}
