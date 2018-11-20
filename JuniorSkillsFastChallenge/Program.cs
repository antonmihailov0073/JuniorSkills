using JuniorSkillsFastChallenge.Views;
using System;
using System.Windows.Forms;

namespace JuniorSkillsFastChallenge
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Auth());
        }
    }
}
