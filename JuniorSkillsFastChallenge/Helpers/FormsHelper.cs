using JuniorSkillsFastChallenge.Services.Exceptions;
using System;
using System.Windows.Forms;

namespace JuniorSkillsFastChallenge.Services.Helper
{
    public static class FormsHelper
    {
        public static void SafeExecute(Action action)
        {
            try
            {
                action();
            }
            catch (ServiceExecption se)
            {
                MessageBox.Show(se.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
