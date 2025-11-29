using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.TeamM
{
    public abstract class TeamMember : ITeamMember
    {
        private string name;
        private string path;
        private readonly List<string> inProgress = new List<string>();

        protected TeamMember(string name, string path)
        {
            this.Name = name;
            this.Path = path;
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
        public string Path { get; protected set; } // potentially BUG !!!

        public IReadOnlyCollection<string> InProgress
        {
            get => this.inProgress.AsReadOnly();
        }
        public void WorkOnTask(string resourceName)
        {
            if (!inProgress.Contains(resourceName))
            {
                this.inProgress.Add(resourceName);
            }
        }

        public void FinishTask(string resourceName)
        {
            this.inProgress.Remove(resourceName);
        }
    }
}
