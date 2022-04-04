public class ValueReference {
    public static void main(String[] args) {
        Employee a = new Employee("Alice", 70000);
        Employee b = new Employee("Bob", 60000);
        System.out.println("Before: a=" + a.getName());
        System.out.println("Before: b=" + b.getName());

        swap(a, b);

        System.out.println("After: a=" + a.getName());
        System.out.println("After: b=" + b.getName());
    }

    public static void swap(Employee x, Employee y) {
        System.out.println("Begin of method: x=" + x.getName());
        System.out.println("Begin of method: y=" + y.getName());
        Employee temp = x;
        x = y;
        y = temp;
        System.out.println("End of method: x=" + x.getName());
        System.out.println("End of method: y=" + y.getName());
    }
}

class Employee {
    private String name;
    private double salary;

    public Employee(String n, double s) {
        name = n;
        salary = s;
    }

    public String getName() {
        return name;
    }

    public double getSalary() {
        return salary;
    }
}

/**
 * Java中引用类型的参数，也是值引用，即复制了对象的一个新的引用，也就是说，方法无法更改变量的引用。
 * 下面示例可以看出，在方法内部，确实交换了变量的引用，但是在方法外部，并没有真的交换了变量的引用。
 * 运行结果：
 * Before: a=Alice
 * Before: b=Bob
 * Begin of method: x=Alice
 * Begin of method: y=Bob
 * End of method: x=Bob
 * End of method: y=Alice
 * After: a=Alice
 * After: b=Bob
 */