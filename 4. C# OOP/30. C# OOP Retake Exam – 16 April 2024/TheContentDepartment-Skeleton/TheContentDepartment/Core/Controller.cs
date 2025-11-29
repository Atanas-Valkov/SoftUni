using System.Reflection;
using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Models.Entities;
using TheContentDepartment.Models.TeamM;
using TheContentDepartment.Repositories;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core;

public class Controller : IController
{
    private readonly ResourceRepository resources;
    private readonly MemberRepository members;

    public Controller()
    {
        this.resources = new ResourceRepository();
        this.members = new MemberRepository();
    }

    private ITeamMember member;
    public string JoinTeam(string memberType, string memberName, string path)
    {
        if (memberType == nameof(TeamLead))
        {
            member = new TeamLead(memberName, path);
        }
        else if (memberType == nameof(ContentMember))
        {
            member = new ContentMember(memberName, path);
        }
        else
        {
            return string.Format(OutputMessages.MemberTypeInvalid, memberType);
        }

        if (this.members.Models.Any(m => m.Path == path))
        {
            return string.Format(OutputMessages.PositionOccupied);
        }


        if (this.members.Models.Any(m => m.Name == memberName))
        {
            return string.Format(OutputMessages.MemberExists, memberName);
        }

        this.members.Add(member);

        return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
    }

    public string CreateResource(string resourceType, string resourceName, string path)
    {
        var isFound = this.members.Models.FirstOrDefault(m => m.Path == path);


        if (isFound == null)
        {
            return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
        }

        if (isFound.InProgress.Contains(resourceName))
        {
            return string.Format(OutputMessages.ResourceExists, resourceName);
        }

        IResource resource;

        if (resourceType == nameof(Exam))
        {
            resource = new Exam(resourceName, isFound.Name);
        }
        else if (resourceType == nameof(Workshop))
        {
            resource = new Workshop(resourceName, isFound.Name);
        }
        else if (resourceType == nameof(Presentation))
        {
            resource = new Presentation(resourceName, isFound.Name);
        }
        else
        {
            return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
        }

        this.resources.Add(resource);
        isFound.WorkOnTask(resourceName);

        return string.Format(OutputMessages.ResourceCreatedSuccessfully, isFound.Name, resourceType, resourceName);
    }

    public string LogTesting(string memberName)
    {
        if (!this.members.Models.Any(m => m.Name == memberName))
        {
            return string.Format(OutputMessages.WrongMemberName);
        }

        var resource = resources.Models
            .Where(m => !m.IsTested)
            .Where(m => m.Creator == memberName)
            .MinBy(m => m.Priority);

        if (resource == null)
        {
            return string.Format(OutputMessages.NoResourcesForMember, memberName);
        }

        TeamLead teamLead = (TeamLead)this.members.Models
            .First(m => m is TeamLead);

        member.FinishTask(resource.Name);
        teamLead.WorkOnTask(resource.Name);
        resource.Test();

        return string.Format(OutputMessages.ResourceTested, resource.Name);
    }

    public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
    {
        IResource resource = this.resources.TakeOne(resourceName);

        if (!resource.IsTested)
        {
            return string.Format(OutputMessages.ResourceNotTested, resourceName);
        }

        TeamLead teamLead = (TeamLead)this.members.Models
            .First(m => m is TeamLead);


        if (isApprovedByTeamLead)
        {
            resource.Approve();
            teamLead.FinishTask(resource.Name);
            return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resource.Name);
        }
        else
        {
            resource.Test();
            return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resource.Name);
        }


    }

    public string DepartmentReport()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Finished Tasks:");

        foreach (var member in this.resources.Models.Where(m=>m.IsApproved))
        {
            sb.AppendLine();
            sb.Append("--");
            sb.Append(member);
        }

        sb.AppendLine();
        sb.AppendLine("Team Report:");

        ITeamMember teamLead = members.Models.Single(m => m is TeamLead);
        sb.Append("--");
        sb.Append(teamLead);

        foreach (var member in this.members.Models)
        {
            if (member is ContentMember)
            {
                sb.AppendLine();
                sb.Append(member);
            }
        }

        return sb.ToString().TrimEnd();
    }
}