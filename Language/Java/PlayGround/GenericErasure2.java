import java.lang.reflect.Method;
import java.util.ArrayList;

public class GenericErasure2 {
    public static void main(String[] args) throws Exception {
        ArrayList<Integer> list_int = new ArrayList<>();
        ArrayList<String>  list_str = new ArrayList<>();

        // System.out.println(list_int.getClass());                         // class java.util.ArrayList
        // System.out.println(list_str.getClass());                         // class java.util.ArrayList
        // System.out.println(list_int.getClass() == list_str.getClass());  // true

        // Class c = Class.forName("java.util.ArrayList");      // 通过全限名（包名 + 类名）来获取类型
        // Class c = ArrayList.class;                           // 通过类的名称来获取类型
        Class c = list_int.getClass();                          // 通过类的实例来获取类型
        Method add = c.getDeclaredMethod("add", Object.class);  // 获取类型的方法

        // 向整型列表中添加其它类型的元素
        list_int.add(1);
        list_int.add(2);
        add.invoke(list_int, "hello world");
        add.invoke(list_int, true);
        System.out.println(list_int);  // [1, 2, hello world, true]

        // 向字符串列表中添加其它类型的元素，反射获取的是类型，与具体使用哪个实例获取无关
        list_str.add("hello");
        list_str.add("world");
        add.invoke(list_str, 1024);
        add.invoke(list_str, false);
        System.out.println(list_str);  // [hello, world, 1024, false]
    }
}

/*
[1, 2, hello world, true]
[hello, world, 1024, false]
*/
