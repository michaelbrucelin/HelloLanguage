// A Person class with name and age accessors and equals and hashCode.
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj.GetType() != typeof(Person)) return false;
        Person p = (Person)obj;
        return p.Name == Name && p.Age == Age;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Age.GetHashCode();
    }
}

// A Calculator class with a static method to add two numbers.
class Calculator
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
}
