using System;
using System.Linq;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan your heist!");
            TeamList teamList = new TeamList();
            Bank Target = new Bank();
        BankSetup:
            Console.Write("What is the bank difficulty? ");
            string diff = Console.ReadLine();
            int bankDiff;
            if (!int.TryParse(diff, out bankDiff))
            {
                goto BankSetup;
            }
            while (true)
            {
                Console.Write("What do you call this team member? ");
                string name = Console.ReadLine();
                Console.WriteLine("");
                if (name == "") { break; }
                teamList.Team.Add(BuildTeam(name));
            }
            Console.WriteLine($"Total number of members: {teamList.Team.Count} ");
            int totalSkill = teamList.Team.Sum(member => member.SkillLevel);
            Console.WriteLine($"The team's combined skill level: {totalSkill} ");
        Trials:
            Console.Write("How many trial runs would you like to attempt? ");
            string attempts = Console.ReadLine();
            int attemptNum;
            if (!int.TryParse(attempts, out attemptNum))
            {
                goto Trials;
            }
            int trys = 0;
            while (trys < attemptNum)
            {
                Target.GetDifficulty();
                Console.WriteLine($"The bank's difficulty level: {Target.GetDifficulty() + Target.Luck} ");
                if (totalSkill >= Target.GetDifficulty() + Target.Luck)
                {
                    Console.WriteLine("Your team was successful!");
                }
                else
                {
                    Console.WriteLine("Your team was unsuccessful! Try a new team LOSER.");
                }
                trys++;
            }
        }
        static TeamMember BuildTeam(string name)
        {
        First:
            Console.Write($"I see. What would you say {name}'s skill level is? ");
            string skill = Console.ReadLine();
            Console.WriteLine("");
            int SkillLevel;
            if (!int.TryParse(skill, out SkillLevel))
            {
                Console.WriteLine("That's not a valid number!");
                goto First;
            }
        Second:
            Console.WriteLine($"What would you say {name}'s courage factor is? ");
            Console.Write($"Enter a number between 0.0 and 2.0: ");
            string courage = Console.ReadLine();
            Console.WriteLine("");
            double x;
            if (!double.TryParse(courage, out x))
            {
                Console.WriteLine("That's not a valid number!");
                goto Second;
            }
            if (x < 0.0 || x > 2.0)
            {
                goto Second;
            }
            return new TeamMember(name, SkillLevel, x);
        }

    }
}
