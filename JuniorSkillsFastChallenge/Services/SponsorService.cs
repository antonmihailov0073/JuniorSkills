using JuniorSkillsFastChallenge.Entities;
using JuniorSkillsFastChallenge.Services.Db;
using System.Collections.Generic;
using System.Linq;

namespace JuniorSkillsFastChallenge.Services
{
    public class SponsorService
    {
        private readonly DbORM _orm;


        public SponsorService()
        {
            _orm = new DbORM();
        }


        public Sponsor GetByID(int id)
        {
            return _orm
                .ExecuteQuery<Sponsor>("SELECT * FROM Sponsors WHERE ID = {0}", id)
                .FirstOrDefault();
        }

        public List<Sponsor> List()
        {
            return _orm.ExecuteQuery<Sponsor>("SELECT * FROM Sponsors");
        }

        public List<Sponsor> ListByParticipantID(int participantID)
        {
            return _orm
                .ExecuteQuery<Sponsor>(
                "SELECT Sponsors.ID, Sponsors.Name FROM ParticipantSponsors " +
                "JOIN Sponsors ON ParticipantSponsors.SponsorID = Sponsors.ID " +
                "WHERE ParticipantSponsors.ParticipantID = {0}",
                participantID);
        }


        public void InsertSponsorToParticipantLink(int participantID, int sponsorID)
        {
            _orm.ExecuteQuery(
                "INSERT ParticipantSponsors (ParticipantID, SponsorID) VALUES ({0}, {1});" + SqlCommands.ReturnScopedId,
                participantID,
                sponsorID);
        }

        public void DeleteAllParticipantToSponsorsLinks(int participantID)
        {
            _orm.ExecuteQuery("DELETE FROM ParticipantSponsors WHERE ParticipantID = {0}", participantID);
        }
    }
}
