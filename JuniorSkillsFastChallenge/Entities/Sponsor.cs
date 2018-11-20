namespace JuniorSkillsFastChallenge.Entities
{
    public class Sponsor : Entity
    {
        public string Name { get; set; }
        

        public override string ToString()
        {
            return Name;
        }
    }
}
