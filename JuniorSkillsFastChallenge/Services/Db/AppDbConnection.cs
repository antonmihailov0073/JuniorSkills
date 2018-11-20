using System.Data.SqlClient;

namespace JuniorSkillsFastChallenge.Services.Db
{
    public class AppDbConnection   
    {
        private readonly SqlConnection _connection;


        public AppDbConnection()
        {
            _connection = new SqlConnection("Server=(local);Database=JuniorSkills;Trusted_Connection=True;MultipleActiveResultSets=True");
        }


        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }

        public SqlCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }
    }
}
