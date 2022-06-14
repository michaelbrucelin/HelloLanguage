import java.util.ArrayList;

public class GenericErasure {
    public static void main(String[] args) throws Exception {
        ArrayList<Integer> list_int = new ArrayList<>();
        list_int.add(1);
        list_int.add(2);
        // list_int.add("hello world");  // 这里是报错的，看起来是有泛型的

        // 可以这样绕过去
        ArrayList list_obj = list_int;
        list_obj.add("hello world");
        list_obj.add(true);

        System.out.println(list_int);    // [1, 2, hello world, true]
    }
}

/*
[1, 2, hello world, true]
 */
