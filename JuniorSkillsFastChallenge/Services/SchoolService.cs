using JuniorSkillsFastChallenge.Entities;
using JuniorSkillsFastChallenge.Services.Db;
using System.Collections.Generic;
using System.Linq;

namespace JuniorSkillsFastChallenge.Services
{
    public class SchoolService
    {
        private readonly DbORM _orm;


        public SchoolService()
        {
            _orm = new DbORM();
        }


        public School GetByID(int id)
        {
            return _orm
                .ExecuteQuery<School>("SELECT * FROM Schools WHERE ID = {0}", id)
                .FirstOrDefault();
        }

        public List<School> List()
        {
            return _orm.ExecuteQuery<School>("SELECT * FROM Schools");
        }
    }
}
