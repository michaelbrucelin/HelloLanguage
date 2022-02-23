public class StringEquals {
    public static void main(String[] args) {
        String s1 = "abc";
        String s2 = "a" + s1.substring(1, 2) + "c";

        System.out.println("s1:\t" + s1);
        System.out.println("s2:\t" + s2);

        System.out.println("s1 == s2:\t" + (s1 == s2));
        System.out.println("s1.equals(s2):\t" + s1.equals(s2));
    }
}

/**
 * s1: abc
 * s2: abc
 * s1 == s2: false
 * s1.equals(s2): true
 */
