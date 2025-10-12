namespace _00.Demo.Person;

public class Student : Person
{
    public Student(string address, string name, string school) 
        : base(address, name)
    {
        School = school;
    }

    public string School { get; set; }


}