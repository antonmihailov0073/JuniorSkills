namespace JuniorSkillsFastChallenge.Entities
{
    public class School : Entity
    {
        public string Name { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
