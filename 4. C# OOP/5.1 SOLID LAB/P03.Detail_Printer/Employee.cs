using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }
        public string Name { get; }

        public virtual string Print()
        {
            return $"{this.Name}";
        }
    }
}
