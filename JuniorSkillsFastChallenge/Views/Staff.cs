using JuniorSkillsFastChallenge.Entities.Enums;
using JuniorSkillsFastChallenge.Services;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JuniorSkillsFastChallenge.Views
{
    public partial class Staff : Form
    {
        private static readonly string[] _needToShield = { ".", "+", "\\", "(", ")", "[", "]" };

        private readonly UserService _userService;
        private readonly ParticipantService _participantService;
        private readonly CompetenceService _competenceService;
        private readonly CountryService _countryService;
        private readonly SponsorService _sponsorService;
        private readonly SchoolService _schoolService;

        public Staff()
        {
            InitializeComponent();

            _userService = new UserService();
            _participantService = new ParticipantService();
            _competenceService = new CompetenceService();
            _countryService = new CountryService();
            _sponsorService = new SponsorService();
            _schoolService = new SchoolService();

            LoadParticipants();
        }

        private void RegisterParticipant(object sender, EventArgs e)
        {
            new RegisterParticipant().ShowDialog();
            LoadParticipants();
        }

        private void LoadParticipants(string emailPattern = ".*")
        {
            ParticipantsGrid.Rows.Clear();

            var infos = (from user in _userService.List()
                         join participant in _participantService.List()
                             on user.ID equals participant.UserID
                         where user.Role == Role.Participant && Regex.IsMatch(user.Email, emailPattern)
                         select new
                         {
                             participant.ID,
                             user.Email,
                             participant.Surname,
                             participant.Name,
                             Competence = _competenceService
                                .GetByID(participant.CompetenceID)
                                .Name,
                             Country = _countryService
                                .GetByID(participant.CountryID)
                                .Name,
                             School = _schoolService
                                .GetByID(participant.SchoolID)
                                .Name,
                             Sponsors = _sponsorService
                                .ListByParticipantID(participant.ID)
                                .Select(s => s.Name)
                                .ToArray()
                        }).ToArray();
            if (infos.Length == 0) return;

            ParticipantsGrid.Rows.Add(infos.Length);
            for (var row = 0; row < infos.Length; ++row)
            {
                var value = infos[row];
                ParticipantsGrid[nameof(IDColumn), row].Value = value.ID;
                ParticipantsGrid[nameof(EmailColumn), row].Value = value.Email;
                ParticipantsGrid[nameof(SurnameNameColumn), row].Value = $"{value.Surname} {value.Name}";
                ParticipantsGrid[nameof(CompetenceColumn), row].Value = value.Competence;
                ParticipantsGrid[nameof(CountryColumn), row].Value = value.Country;
                ParticipantsGrid[nameof(SchoolColumn), row].Value = value.School;
                ParticipantsGrid[nameof(SponsorsColumn), row].Value = string.Join(", ", value.Sponsors);
            }
        }

        private void EditParticipant(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)ParticipantsGrid[nameof(IDColumn), e.RowIndex].Value;
            var participantToEdit = _participantService.GetByID(id);
            var userToEdit = _userService.GetByID(participantToEdit.UserID);
            new EditParticipant(participantToEdit, userToEdit).ShowDialog();
            LoadParticipants();
        }

        private void Search(object sender, EventArgs e)
        {
            var searchQuery = SearchBox.Text;
            Array.ForEach(_needToShield, nts => searchQuery.Replace(nts, "\\" + nts));
            LoadParticipants($".*({searchQuery})+.*");
        }
    }
}
