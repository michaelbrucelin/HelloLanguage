public class Employee {
    private String name;
    private double salary;

    public native void raiseSalary(double byPercent);

    public Employee(String n, double s) {
        name = n;
        salary = s;
    }

    public void print() {
        System.out.println(name + " " + salary);
    }

    static {
        System.loadLibrary("Employee");
    }
}
