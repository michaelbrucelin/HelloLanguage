public class Break2Label {
    public static void main(String[] args) {
        int i = 0, j = 0;
        OUTER: for (i = 0; i < 10; i++) {
            System.out.println("进入外层循环，i = " + i);
            INNER: for (j = 0; j < 10; j++) {
                System.out.println("进入内层循环，i = " + i + ", j = " + j);
                if (i == 3 && j == 3) {
                    break INNER;
                } else if (i == 5 && j == 5) {
                    break OUTER;
                }
            }
        }
        System.out.println("循环结束，i = " + i + ", j = " + j);
    }
}

/**
 * Java中没有goto，但是为跳出（多层）循环，可以使用标签来实现
 * break的标签必须写在循环的开头
 */