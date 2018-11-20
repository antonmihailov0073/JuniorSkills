using JuniorSkillsFastChallenge.Entities;
using JuniorSkillsFastChallenge.Services.Db;
using System.Collections.Generic;
using System.Linq;

namespace JuniorSkillsFastChallenge.Services
{
    public class CompetenceService
    {
        private readonly DbORM _orm;


        public CompetenceService()
        {
            _orm = new DbORM();
        }


        public Competence GetByID(int id)
        {
            return _orm
                .ExecuteQuery<Competence>("SELECT * FROM Competencies WHERE ID = {0}", id)
                .FirstOrDefault();
        }

        public List<Competence> List()
        {
            return _orm.ExecuteQuery<Competence>("SELECT * FROM Competencies");
        }
    }
}
