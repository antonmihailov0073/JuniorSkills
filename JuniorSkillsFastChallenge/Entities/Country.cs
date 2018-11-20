namespace JuniorSkillsFastChallenge.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
