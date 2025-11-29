using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.Entities
{
    public abstract class Resource : IResource
    {
        private string name;
        private string creator;
        private int priority;

        protected Resource(string name, string creator, int priority)
        {
            this.Name = name;
            this.Creator = creator;
            this.Priority = priority;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }

                this.name = value;
            }
        }

        public string Creator
        {
            get => this.creator;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                this.creator = value;
            }
        }

        public int Priority
        {
            get => this.priority;
            private set
            {
                this.priority = value;
            }
        }

        public bool IsTested { get; private set; } 

        public bool IsApproved { get; private set; } 

        public void Test()
        {
            this.IsTested = !this.IsTested;
        }

        public void Approve()
        {
            this.IsApproved = true;
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.GetType().Name}), Created By: {this.Creator}";
        }
    }
}
