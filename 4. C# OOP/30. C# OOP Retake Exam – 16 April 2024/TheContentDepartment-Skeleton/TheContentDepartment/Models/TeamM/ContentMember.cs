using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.TeamM
{
    public class ContentMember : TeamMember
    {

        private readonly List<string> AllowedPaths = new List<string>()
        {
            "CSharp", "JavaScript", "Python","Java"
        };
        public ContentMember(string name, string path) 
            : base(name, path)
        {
            if (!AllowedPaths.Contains(path))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Path} path. Currently working on {this.InProgress.Count} tasks.";
        }

    }
}
