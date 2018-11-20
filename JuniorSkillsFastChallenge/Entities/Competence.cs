namespace JuniorSkillsFastChallenge.Entities
{
    public class Competence : Entity
    {
        public string Name { get; set; }

        public string FilesHref { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
