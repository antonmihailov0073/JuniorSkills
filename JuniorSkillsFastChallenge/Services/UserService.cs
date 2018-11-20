using JuniorSkillsFastChallenge.Entities;
using JuniorSkillsFastChallenge.Services.Db;
using System.Collections.Generic;
using System.Linq;

namespace JuniorSkillsFastChallenge.Services
{
    public class UserService
    {
        private readonly DbORM _orm;


        public UserService()
        {
            _orm = new DbORM();
        }


        public List<User> List()
        {
            return _orm.ExecuteQuery<User>("SELECT * FROM Users");
        }
        
        public User GetByEmail(string email)
        {
            return _orm
                .ExecuteQuery<User>("SELECT * FROM Users WHERE Email = {0}", email)
                .FirstOrDefault();
        }

        public User GetByID(int id)
        {
            return _orm
                .ExecuteQuery<User>("SELECT * FROM Users WHERE ID = {0}", id)
                .FirstOrDefault();
        }

        public User Insert(User user)
        {
            var id = (int)_orm.ExecuteScalar(
                "INSERT Users (Email, Password, Role) VALUES ({0}, {1}, {2});" + SqlCommands.ReturnScopedId, 
                user.Email, 
                user.Password,
                (int)user.Role);
            return GetByID(id);
        }

        public void Update(User user)
        {
            _orm.ExecuteScalar(
                "UPDATE Users " +
                "SET Email = {0}, Password = {1}, Role = {2} " +
                "WHERE Id = {3}",
                user.Email,
                user.Password,
                (int)user.Role,
                user.ID);
        }
    }
}
