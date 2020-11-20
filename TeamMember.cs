using System;
using System.Collections.Generic;

namespace Heist
{
    public class TeamMember
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public double CourageFactor { get; set; }

        public TeamMember(string name, int skill, double courage)
        {
            Name = name;
            SkillLevel = skill;
            CourageFactor = courage;
        }
    }
    public class TeamList
    {
        public List<TeamMember> Team = new List<TeamMember>();
        public int Successes { get; set; }
        public int Fails { get; set; }
    }
}