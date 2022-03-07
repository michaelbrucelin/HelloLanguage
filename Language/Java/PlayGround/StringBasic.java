public class StringBasic {
    public static void main(String[] args) {
        // 整型存储在栈中，每个变量占4个字节
        int i1 = 1024;
        int i2 = 1024;
        System.out.println("i1 address:\t" + Integer.toHexString(System.identityHashCode(i1)));
        System.out.println("i2 address:\t" + Integer.toHexString(System.identityHashCode(i2)));

        // 字面字符串存储在字符串常量池中，不可变，是相同的对象
        // Java中==比较的是对象的地址，s1.equals(s2)比较的是字符串的内容
        System.out.println();
        String s1 = "abc";
        String s2 = "abc";
        // System.out.println("s1 hashcode:\t" + s1.hashCode());
        // System.out.println("s2 hashcode:\t" + s2.hashCode());
        System.out.println("s1 address:\t" + Integer.toHexString(System.identityHashCode(s1)));
        System.out.println("s2 address:\t" + Integer.toHexString(System.identityHashCode(s2)));
        System.out.println("s1 == s2:\t" + (s1 == s2));

        // 计算或new出来的字符串存储在堆中，是不同的对象
        System.out.println();
        String s3 = "abc";
        String s4 = new String("abc");
        System.out.println("s3 address:\t" + Integer.toHexString(System.identityHashCode(s3)));
        System.out.println("s4 address:\t" + Integer.toHexString(System.identityHashCode(s4)));
        System.out.println("s3 == s4:\t" + (s3 == s4));

        // String s6 = "a" + "b" + "c";在编译的时候被优化成s6 = "abc"，可以检查编译后的class文件的内容来验证
        System.out.println();
        String s5 = "abc";
        String s6 = "a" + "b" + "c";
        System.out.println("s5 address:\t" + Integer.toHexString(System.identityHashCode(s5)));
        System.out.println("s6 address:\t" + Integer.toHexString(System.identityHashCode(s6)));
        System.out.println("s5 == s6:\t" + (s5 == s6));

        System.out.println();
        String s7 = new String("ab");
        System.out.println("s7 address:\t" + Integer.toHexString(System.identityHashCode(s7)));
        s7 += "c";
        System.out.println("s7 address:\t" + Integer.toHexString(System.identityHashCode(s7)));
        String s8 = s7 + "d";
        System.out.println("s8 address:\t" + Integer.toHexString(System.identityHashCode(s8)));
    }
}

/**
 * Output:
 * i1 address: d716361
 * i2 address: 4517d9a3
 * 
 * s1 address: 372f7a8d
 * s2 address: 372f7a8d
 * s1 == s2: true
 * 
 * s3 address: 372f7a8d
 * s4 address: a09ee92
 * s3 == s4: false
 * 
 * s5 address: 372f7a8d
 * s6 address: 372f7a8d
 * s5 == s6: true
 * 
 * s7 address: 30f39991
 * s7 address: 63961c42
 * s8 address: 65b54208
 */