using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using MultiCheat_Window.Utils;
using MultiCheat_Window.Engine;
using MultiCheat_Window.GUI;
using System.Security.Principal;

namespace MultiCheat_Window
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        public static bool noUpdate = true;
        public static bool addresses = false;

        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!MachineFunctions.IsRunAsAdmin())
            {
                Messages.NoAdminRightsMessage();
                return;
            }

            foreach (string arg in args)
                CatchStartArgument(arg);

            if (!noUpdate)
                RunWithUpdate();
            else
                ContinueFromUpdateCheck();
        }

        public static void ContinueFromUpdateCheck()
        {
            int scondsLeft = MachineFunctions.CheckActivation();
            if (scondsLeft == 0)
            {
                (new ActivateForm()).ShowDialog();
            }
            else
            {
                if (scondsLeft == -1)
                {
                    MessageBox.Show("У вас пожизненная лицензия", "MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    TimeSpan ts = TimeSpan.FromSeconds(scondsLeft);
                    string answer = string.Format("{0} дн {1:D2} час {2:D2} мин {3:D2} сек", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
                    MessageBox.Show("Лицензия закончится через " + answer, "MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                StartProgram();
            }
        }

        private static void CatchStartArgument(string arg)
        {
            if (arg == "-noupdate")
            {
                noUpdate = true;
            }
            if (arg == "-addresses")
            {
                addresses = true;
            }
            if (arg == "-newversion")
            {
                noUpdate = true;
                Messages.UpdateMessage();
            }
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string name = args.Name.Split(',')[0];
            if (name == "Newtonsoft.Json")
                return Assembly.Load(Properties.Resources.Newtonsoft_Json);

            if (name == "VAMemory")
                return Assembly.Load(Properties.Resources.VAMemory);
            return null;
        }

        public static void StartProgram()
        {
            string tempFolder = Path.GetTempPath() + "csgoMulticheat/";
            Directory.CreateDirectory(tempFolder);
            Constants.tempFolder = tempFolder;
            MachineFunctions.UnpackTempFiles();
            MultiCheat multiCheat = new MultiCheat();
            OverlayWFController overlayWFController = new OverlayWFController(multiCheat);
        }

        private static void RunWithUpdate()
        {
            Application.Run(new CheckingUpdate());
        }

        public static void StartUpdate(string updateUrl)
        {
            new UpdateForm(updateUrl).ShowDialog();
        }

        public static void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}
