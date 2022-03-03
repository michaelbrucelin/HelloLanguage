public class StringHash {
    public static void main(String[] args) {
        String str = "abcdefghijklmnopqrstuvwxyz";
        int hash = 0;
        for (int i = 0; i < str.length(); i++) {
            hash = hash * 31 + str.charAt(i);
        }
        System.out.println("calculate myself:\t" + hash);
        System.out.println("calculate java:\t" + str.hashCode());
    }
}

/**
 * Java类库中计算String的hashCode的方法就是这么简单，如果String很长，岂不是很容易溢出？
 */