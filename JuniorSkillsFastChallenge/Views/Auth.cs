using JuniorSkillsFastChallenge.Entities.Enums;
using JuniorSkillsFastChallenge.Services;
using JuniorSkillsFastChallenge.Services.Helper;
using System;
using System.Windows.Forms;

namespace JuniorSkillsFastChallenge.Views
{
    public partial class Auth : Form
    {
        private readonly AuthService _authService;


        public Auth()
        {
            InitializeComponent();

            _authService = new AuthService();
        }

        private void Login(object sender, EventArgs e)
        {
            FormsHelper.SafeExecute(() =>
            {
                var user = _authService.Login(EmailBox.Text, PassordBox.Text);
                Hide();
                switch (user.Role)
                {
                    case Role.Participant:
                        new Participant(user).ShowDialog();
                        break;
                    case Role.Expert:
                        // TODO
                        break;
                    case Role.Staff:
                        new Staff().ShowDialog();
                        break;
                }
                Show();
            });
        }
    }
}
