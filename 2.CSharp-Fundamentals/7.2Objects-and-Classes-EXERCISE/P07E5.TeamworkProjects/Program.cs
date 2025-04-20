/*
2 
John-PowerPuffsCoders
Tony-Tony is the best
Peter->PowerPuffsCoders
Tony->Tony is the best
end of assignment

3
Tanya-CloneClub
Helena-CloneClub
Tedy-SoftUni
George->softUni
George->SoftUni
Tatyana->Leda
John->SoftUni
Cossima->CloneClub
end of assignment
 */

using System.Security.Cryptography.X509Certificates;
using static P07E5.TeamworkProjects.Program;

namespace P07E5.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int numberOfTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] input = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                string creatorName = input[0];
                string teamName = input[1];
                Team team = new Team(creatorName, teamName);

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {team.TeamName} was already created!");
                }
                else if (teams.Any(x => x.CreatorName == creatorName))
                {
                    Console.WriteLine($"{team.CreatorName} cannot create another team!");
                }
                else
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {team.TeamName} has been created by {team.CreatorName}!");
                }
            }

            string command ;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] arguments = command.Split("->");
                string memberName = arguments[0];
                string teamName = arguments[1];

                Team targetTeam = teams.FirstOrDefault(x => x.TeamName == teamName);

                if (targetTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(x => x.CreatorName == memberName || x.MembersName.Contains(memberName)))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                }
                else
                {
                    targetTeam.MembersName.Add(memberName);
                }
            }

            foreach (Team team in teams
                         .Where(x => x.MembersName.Count > 0)
                         .OrderByDescending(x => x.MembersName.Count)
                         .ThenBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.CreatorName}");
                foreach (var teamM in team.MembersName.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {teamM}");
                }
            }

            Console.WriteLine($"Teams to disband:");
            foreach (Team team in teams.Where(x => x.MembersName.Count == 0).OrderBy(x => x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
            }
        }
        public class Team
        {
            public Team(string creatorName, string teamName)
            {
                this.CreatorName = creatorName;
                this.TeamName = teamName;
                this.MembersName = new List<string>();
            }
            public string CreatorName { get; set; }
            public List<string> MembersName { get; set; }
            public string TeamName { get; set; }
        }
    }
}