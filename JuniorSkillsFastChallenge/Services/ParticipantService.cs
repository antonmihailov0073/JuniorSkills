using JuniorSkillsFastChallenge.Entities;
using JuniorSkillsFastChallenge.Services.Db;
using System.Collections.Generic;
using System.Linq;

namespace JuniorSkillsFastChallenge.Services
{
    public class ParticipantService
    {
        private readonly DbORM _orm;


        public  ParticipantService()
        {
            _orm = new DbORM();
        }


        public List<Participant> List()
        {
            return _orm.ExecuteQuery<Participant>("SELECT * From Participants");
        }

        public Participant GetByID(int id)
        {
            return _orm
                .ExecuteQuery<Participant>("SELECT * FROM Participants WHERE ID = {0}", id)
                .FirstOrDefault();
        }
        
        public Participant GetByUserID(int userId)
        {
            return _orm
                .ExecuteQuery<Participant>("SELECT * FROM Participants WHERE UserID = {0}", userId)
                .FirstOrDefault();
        }

        public Participant Insert(Participant participant)
        {
            var id = (int)_orm.ExecuteScalar(
                "INSERT Participants (Name, Surname, Gender, Birthdate, PhotoPath, SchoolID, CountryID, UserID, CompetenceID)" +
                "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8});" + SqlCommands.ReturnScopedId,
                participant.Name,
                participant.Surname,
                (int)participant.Gender,
                participant.Birthdate,
                participant.PhotoPath,
                participant.SchoolID,
                participant.CountryID,
                participant.UserID,
                participant.CompetenceID);
            return GetByID(id);
        }
        
        public void Update(Participant participant)
        {
            _orm.ExecuteQuery(
                "UPDATE Participants " +
                "SET Name = {0}, Surname = {1}, Gender = {2}, Birthdate = {3}, PhotoPath = {4}, SchoolID = {5}, " +
                "CountryID = {6}, UserID = {7}, CompetenceID = {8}" +
                "WHERE Id = {9}",
                participant.Name,
                participant.Surname,
                (int)participant.Gender,
                participant.Birthdate,
                participant.PhotoPath,
                participant.SchoolID,
                participant.CountryID,
                participant.UserID,
                participant.CompetenceID,
                participant.ID);
        }
    }
}
