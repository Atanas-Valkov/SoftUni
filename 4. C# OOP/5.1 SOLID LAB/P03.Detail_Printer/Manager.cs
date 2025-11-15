using P03.Detail_Printer;
using System;
using System.Collections;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : Employee, IEmployee
    {

        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public string Name { get; }
        public virtual string GetDetails()
        {

            return string.Join(Environment.NewLine, this.Documents);
        }

        public override string Print()
        {
            return base.Print()
                   + Environment.NewLine
                   + $"{string.Join(Environment.NewLine, this.Documents)}";
        }
    }
}
