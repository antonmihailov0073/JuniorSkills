using JuniorSkillsFastChallenge.Entities.Enums;
using System;

namespace JuniorSkillsFastChallenge.Entities
{
    public class Participant : Entity
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public string PhotoPath { get; set; }

        public int SchoolID { get; set; }

        public int CountryID { get; set; }

        public int UserID { get; set; }

        public int CompetenceID { get; set; }
    }
}
