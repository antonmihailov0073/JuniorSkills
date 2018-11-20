using JuniorSkillsFastChallenge.Entities;
using JuniorSkillsFastChallenge.Services.Db;
using System.Collections.Generic;
using System.Linq;

namespace JuniorSkillsFastChallenge.Services
{
    public class CountryService
    {
        private readonly DbORM _orm;


        public CountryService()
        {
            _orm = new DbORM();
        }

        
        public Country GetByID(int id)
        {
            return _orm
                .ExecuteQuery<Country>("SELECT * FROM Countries WHERE ID = {0}", id)
                .FirstOrDefault();
        }

        public List<Country> List()
        {
            return _orm.ExecuteQuery<Country>("SELECT * FROM Countries");
        }
    }
}
