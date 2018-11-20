namespace JuniorSkillsFastChallenge.Services.Db
{
    public static class SqlCommands
    {
        public const string ReturnScopedId = "SELECT CAST(scope_identity() AS int)";
    }
}
