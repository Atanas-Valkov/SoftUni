using AccessControlSystem.Models.Contracts;
using AccessControlSystem.Utilities.Messages;

namespace AccessControlSystem.Models.SecurityZone;

public class SecurityZone : ISecurityZone
{
    private string name; 
    private int accessLevelRequired;
    private List<int> accessLog;

    public SecurityZone(string name, int accessLevelRequired)
    {
        this.Name = name;
        this.AccessLevelRequired = accessLevelRequired;
        this.accessLog = new List<int>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.InvalidSecurityZoneName);
            }
            this.name = value;
        }
    }

    public int AccessLevelRequired
    {
        get => this.accessLevelRequired;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAccessLevel);
            }
            this.accessLevelRequired = value;
        }
    }
    public IReadOnlyCollection<int> AccessLog => this.accessLog.AsReadOnly();
    public void LogAccessKey(int securityId)
    {
        this.accessLog.Add(securityId);
    }
}