using JuniorSkillsFastChallenge.Entities;
using JuniorSkillsFastChallenge.Entities.Enums;
using JuniorSkillsFastChallenge.Services.Db;
using JuniorSkillsFastChallenge.Services.Exceptions;

namespace JuniorSkillsFastChallenge.Services
{
    public class AuthService
    {
        private readonly DbORM _orm;
        private readonly UserService _userService;


        public AuthService()
        {
            _orm = new DbORM();
            _userService = new UserService();
        }


        public User Login(string email, string password)
        {
            var existUser = _userService.GetByEmail(email);

            if (existUser == null) throw new ServiceExecption("User not found!");
            if (existUser.Password != password) throw new ServiceExecption("Wrong password!");

            return existUser;
        }

        public User Register(string email, string password, Role role = Role.Participant)
        {
            if (_userService.GetByEmail(email) != null) throw new ServiceExecption("User with specified email already exist!");

            Validations.ValidateEmail(email);
            Validations.ValidatePassword(password);

            var newUser = new User
            {
                Email = email,
                Password = password,
                Role = role
            };

            return _userService.Insert(newUser);
        }
    }
}
