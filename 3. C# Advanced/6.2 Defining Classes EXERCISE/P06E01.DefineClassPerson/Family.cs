namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members = new List<Person>();
        public void AddMember(Person member) => this.members.Add(member);
        public Person GetOldestMember() => this.members.OrderByDescending(m => m.Age).First();

        public override string ToString()
        {
          return $"{this.GetOldestMember().Name} {this.GetOldestMember().Age}";
        }

    }
}
