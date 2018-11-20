using JuniorSkillsFastChallenge.Entities;
using JuniorSkillsFastChallenge.Services;
using System.Diagnostics;
using System.Windows.Forms;

namespace JuniorSkillsFastChallenge.Views
{
    public partial class Participant : Form
    {
        private readonly User _user;
        private readonly ParticipantService _participantService;
        private readonly CountryService _countryService;
        private readonly SchoolService _schoolService;
        private readonly CompetenceService _competenceService;
        private readonly SponsorService _sponsorService;


        public Participant(User user)
        {
            InitializeComponent();

            _user = user;
            _participantService = new ParticipantService();
            _countryService = new CountryService();
            _schoolService = new SchoolService();
            _competenceService = new CompetenceService();
            _sponsorService = new SponsorService();

            LoadForm();
        }


        private void LoadForm()
        {
            var participant = _participantService.GetByUserID(_user.ID);

            NameBox.Text = participant.Name;
            SurnameBox.Text = participant.Surname;
            EmailBox.Text = _user.Email;
            GenderBox.Text = participant.Gender.ToString();
            CountryBox.Text = _countryService.GetByID(participant.CountryID).Name;
            SchoolBox.Text = _schoolService.GetByID(participant.SchoolID).Name;
            PhotoBox.ImageLocation = participant.PhotoPath;

            var competence = _competenceService.GetByID(participant.CompetenceID);
            CompetenceLabel.Text = competence.Name;

            var browserStartInfo = new ProcessStartInfo("cmd", $"/c start {competence.FilesHref}")
            {
                CreateNoWindow = true
            };
            DownloadCompetenceFilesButton.Click += (o, ea) => Process.Start(browserStartInfo);
            if (string.IsNullOrEmpty(competence.FilesHref))
            {
                DownloadCompetenceFilesButton.Visible = false;
            }

            SponsorsList.Items.AddRange(_sponsorService.ListByParticipantID(participant.ID).ToArray());
        }
    }
}
