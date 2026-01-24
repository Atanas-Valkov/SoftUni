namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
         : this(age: 1)
        {
        }
        public Person(int age)
        : this(name: "No name", age)
        {
        }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
