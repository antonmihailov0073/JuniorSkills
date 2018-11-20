using JuniorSkillsFastChallenge.Entities.Enums;

namespace JuniorSkillsFastChallenge.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
