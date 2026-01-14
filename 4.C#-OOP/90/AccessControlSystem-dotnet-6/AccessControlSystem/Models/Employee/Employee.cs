using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Models.Employee
{
    public abstract class Employee : IEmployee
    {
        private string name;
        private int securityId;
      //  private IDepartment department;

        protected Employee(string name, int securityId)
        {
            this.Name = name;
            this.SecurityId = securityId;
          //  this.Department = department;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEmployeeName);
                }

                this.name = value;
            }
        }
        public IDepartment Department { get; private set; }

        public int SecurityId
        {
            get=> this.securityId;
            private set
            {
                if (value <= 100 || value >= 999)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSecurityId);
                }
                this.securityId = value;
            }
        }
        public void AssignToDepartment(IDepartment department)
        {
            this.Department = department;
        }

        public override string ToString()
        {
            return $"Employee: {this.Name}, Department: {this.Department}, Security ID: {this.SecurityId}";
        }
    }
}
