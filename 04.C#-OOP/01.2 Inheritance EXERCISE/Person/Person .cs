using System;
using System.Dynamic;

namespace Person;

public class Person
{
    private int age;
    private string name;
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public virtual int Age
    {
        get => this.age;
        set
        {
            if (value > 0)
            {
                this.age = value;
            }
        }
    }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{this.GetType().Name} -> Name: {this.Name}, Age: {this.Age}";
    }
}