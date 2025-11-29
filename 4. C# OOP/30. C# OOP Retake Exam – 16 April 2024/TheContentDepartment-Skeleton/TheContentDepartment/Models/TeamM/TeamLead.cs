using System.Diagnostics.Metrics;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models.TeamM;

public class TeamLead : TeamMember
{

    private readonly List<string> AllowedPaths = new List<string>() { "Master" };

    public TeamLead(string name, string path)
        : base(name, path)
    {
        if (!AllowedPaths.Contains(path))
        {
           throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
        }
    }

    public override string ToString()
    {
        return $"{this.Name} ({this.GetType().Name}) – Currently working on {this.InProgress.Count} tasks.";
    }
}