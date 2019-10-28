using MultiCheat_Window.Engine;
using MultiCheat_Window.Update;
using MultiCheat_Window.Utils;
using System;
using System.Text;
using System.Windows.Forms;

namespace MultiCheat_Window
{
    public partial class CheckingUpdate : Form
    {

        public CheckingUpdate()
        {
            InitializeComponent();
        }


        private void CheckingUpdate_Shown(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 1;
            t.Tick += new System.EventHandler(timerTick);
            t.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            if (checkUpdate() == false)
                Program.ContinueFromUpdateCheck();
        }

        private bool checkUpdate()
        {
            UpdateChecker checker = new UpdateChecker(Constants.updateUrlFirst, Constants.updateUrlSecond, Constants.updateVersionFile);

            CheckerGlobalErrorType error = checker.CheckUpdate();

            Hide();
            switch (error)
            {
                case CheckerGlobalErrorType.LOAD_ERROR_BOTH:
                    Messages.UpdateConnectError();
                    return false;
                case CheckerGlobalErrorType.CONTENT_ERROR_BOTH:
                    Messages.UpdateDataError();
                    return false;
                case CheckerGlobalErrorType.DIFFERENT_ERRORS:
                    Messages.UpdateConnectError();
                    return false;
                case CheckerGlobalErrorType.LOAD_ERROR_ONCE:
                    break;
                case CheckerGlobalErrorType.CONTENT_ERROR_ONCE:
                    break;
                case CheckerGlobalErrorType.NONE:
                    break;
            }

            if (checker.GetNewestVersion() > Constants.versionNumber)
            {
                Program.StartUpdate(checker.GetNewestUpdateUrl());
                return true;
            }
            return false;
        }
    }
}
