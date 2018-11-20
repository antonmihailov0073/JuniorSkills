using JuniorSkillsFastChallenge.Entities;
using ParticipantEntity = JuniorSkillsFastChallenge.Entities.Participant;
using JuniorSkillsFastChallenge.Entities.Enums;
using JuniorSkillsFastChallenge.Services;
using JuniorSkillsFastChallenge.Services.Helper;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JuniorSkillsFastChallenge.Views
{
    public partial class RegisterParticipant : Form
    {
        private readonly AuthService _authService;
        private readonly ParticipantService _participantService;
        private readonly CountryService _countryService;
        private readonly CompetenceService _competenceService;
        private readonly SchoolService _schoolService;
        private readonly SponsorService _sponsorService;


        public RegisterParticipant()
        {
            InitializeComponent();

            _authService = new AuthService();
            _participantService = new ParticipantService();
            _countryService = new CountryService();
            _competenceService = new CompetenceService();
            _schoolService = new SchoolService();
            _sponsorService = new SponsorService();

            FillForm();
        }


        public void FillForm()
        {
            BirthdatePicker.Value = DateTime.Now;

            var countries = _countryService.List();
            CountryComboBox.Items.AddRange(countries.ToArray());
            CountryComboBox.SelectedIndex = 0;
            
            var schools = _schoolService.List();
            SchoolComboBox.Items.AddRange(schools.ToArray());
            SchoolComboBox.SelectedIndex = 0;

            var sponsors = _sponsorService.List();
            SponsorsList.Items.AddRange(sponsors.ToArray());

            var allParticipants = _participantService.List();
            var competencies = _competenceService
                .List()
                .Where(c => allParticipants.Where(p => p.CompetenceID == c.ID).Count() < 6);
            CompetenceComboBox.Items.AddRange(competencies.ToArray());
            CompetenceComboBox.SelectedIndex = 0;

            GenderComboBox.Items.AddRange(Enum.GetValues(typeof(Gender)).Cast<object>().ToArray());
            GenderComboBox.SelectedIndex = 0;
        }

        private void Register(object sender, EventArgs e)
        {
            FormsHelper.SafeExecute(() =>
            {
                var user = _authService.Register(EmailBox.Text, PasswordBox.Text);

                var newParticipant = new ParticipantEntity
                {
                    Name = NameBox.Text,
                    Surname = SurnameBox.Text,
                    Gender = (Gender)GenderComboBox.SelectedItem,
                    UserID = user.ID,
                    Birthdate = BirthdatePicker.Value,
                    PhotoPath = PhotoBox.ImageLocation,
                    CountryID = (CountryComboBox.SelectedItem as Country).ID,
                    CompetenceID = (CompetenceComboBox.SelectedItem as Competence).ID,
                    SchoolID = (SchoolComboBox.SelectedItem as School).ID
                };
                var participant = _participantService.Insert(newParticipant);

                SponsorsList.SelectedItems
                    .Cast<Sponsor>()
                    .ToList()
                    .ForEach(s => _sponsorService.InsertSponsorToParticipantLink(participant.ID, s.ID));
                
                Close();
            });
        }

        private void UploadPhoto(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Pick a photo",
                Multiselect = false,
                Filter = "Image files (*.png, *.jpg)|*.png;*.jpg"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PhotoBox.ImageLocation = dialog.FileName;
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
