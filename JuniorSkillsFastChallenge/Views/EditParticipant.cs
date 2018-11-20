using JuniorSkillsFastChallenge.Entities.Enums;
using ParticipantEntity = JuniorSkillsFastChallenge.Entities.Participant;
using JuniorSkillsFastChallenge.Services;
using JuniorSkillsFastChallenge.Services.Helper;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using JuniorSkillsFastChallenge.Entities;

namespace JuniorSkillsFastChallenge.Views
{
    public partial class EditParticipant : Form
    {
        private readonly ParticipantEntity _participant;
        private readonly User _user;
        private readonly ParticipantService _participantService;
        private readonly UserService _userService;
        private readonly CountryService _countryService;
        private readonly CompetenceService _competenceService;
        private readonly SchoolService _schoolService;
        private readonly SponsorService _sponsorService;


        public EditParticipant(ParticipantEntity participant, Entities.User user)
        {
            InitializeComponent();

            _participant = participant;
            _user = user;
            _participantService = new ParticipantService();
            _userService = new UserService();
            _countryService = new CountryService();
            _competenceService = new CompetenceService();
            _schoolService = new SchoolService();
            _sponsorService = new SponsorService();
            
            LoadForm();
        }


        public void LoadForm()
        {
            LoadTextInfo();
            LoadCountries();
            LoadSchools();
            LoadSponsors();
            LoadCompetencies();
            LoadGender();
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

        private void Save(object sender, EventArgs e)
        {
            FormsHelper.SafeExecute(() =>
            {
                SaveParticipant();
                SaveUser();
                UpdateSponsorToParticipantLinks();
                Close();
            });
        }


        private void SaveParticipant()
        {
            _participant.Gender = (Gender)GenderComboBox.SelectedItem;
            _participant.PhotoPath = PhotoBox.ImageLocation;
            _participant.Name = NameBox.Text;
            _participant.Surname = SurnameBox.Text;

            if (CompetenceComboBox.SelectedItem is Entities.Competence competence)
            {
                _participant.CompetenceID = competence.ID;
            }
            if (CountryComboBox.SelectedItem is Entities.Country country)
            {
                _participant.CountryID = country.ID;
            }
            if (SchoolComboBox.SelectedItem is Entities.School school)
            {
                _participant.SchoolID = school.ID;
            }

            _participantService.Update(_participant);
        }

        private void SaveUser()
        {
            _user.Email = EmailBox.Text;
            _user.Password = PasswordBox.Text;

            Validations.ValidateEmail(_user.Email);
            Validations.ValidatePassword(_user.Password);

            _userService.Update(_user);
        }

        private void UpdateSponsorToParticipantLinks()
        {
            _sponsorService.DeleteAllParticipantToSponsorsLinks(_participant.ID);
            SponsorsList.SelectedItems
                .Cast<Sponsor>()
                .ToList()
                .ForEach(s => _sponsorService.InsertSponsorToParticipantLink(_participant.ID, s.ID));
        }

        private void LoadTextInfo()
        {
            PhotoBox.ImageLocation = _participant.PhotoPath;
            BirthdatePicker.Value = _participant.Birthdate;
            NameBox.Text = _participant.Name;
            SurnameBox.Text = _participant.Surname;
            EmailBox.Text = _user.Email;
            PasswordBox.Text = _user.Password;
        }

        private void LoadCountries()
        {
            var countries = _countryService.List();
            CountryComboBox.Items.AddRange(countries.ToArray());
            CountryComboBox.SelectedItem = countries.FirstOrDefault(c => _participant.CountryID == c.ID);
        }

        private void LoadSchools()
        {
            var schools = _schoolService.List();
            SchoolComboBox.Items.AddRange(schools.ToArray());
            SchoolComboBox.SelectedItem = schools.FirstOrDefault(s => _participant.SchoolID == s.ID);
        }

        private void LoadSponsors()
        {
            var sponsors = _sponsorService.List();
            SponsorsList.Items.AddRange(sponsors.ToArray());
            var participantSponsors = _sponsorService
                .ListByParticipantID(_participant.ID)
                .Select(ps => ps.ID);
            sponsors.Where(s => participantSponsors.Contains(s.ID))
                .ToList()
                .ForEach(s => SponsorsList.SelectedItems.Add(s));
        }

        private void LoadCompetencies()
        {
            var allParticipants = _participantService.List();
            var competencies = _competenceService
                .List()
                .Where(c => c.ID == _participant.CompetenceID || allParticipants.Where(p => p.CompetenceID == c.ID).Count() < 6);
            CompetenceComboBox.Items.AddRange(competencies.ToArray());
            CompetenceComboBox.SelectedItem = competencies.FirstOrDefault(c => _participant.CompetenceID == c.ID);
        }

        private void LoadGender()
        {
            GenderComboBox.Items.AddRange(Enum.GetValues(typeof(Gender)).Cast<object>().ToArray());
            GenderComboBox.SelectedItem = _participant.Gender;
        }
    }
}
