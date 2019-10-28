using MultiCheat_Window;
using MultiCheat_Window.CSGOApi;
using MultiCheat_Window.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MultiCheat_Window.ActivateForm;

namespace MultiCheat_Window.Utils
{
    public static class MachineFunctions
    {
        public static bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        // return secondsLeft (0 - not valid, -1 ultimate, other - seconds)
        public static int CheckActivation()
        {
            //return -1;
            int secondsLeft = -1;
            if (!File.Exists(Constants.ActivateFile))
            {
                return 0;
            }
            else
            {
                string key = File.ReadAllText(Constants.ActivateFile).Trim();
                string UUID = GetUUID();
                CheckerWebClient wc = new CheckerWebClient();
                try
                {
                    string response = wc.DownloadString(Constants.updateUrlFirst + Constants.ActivCheckScript + "?k=" + key + "&u=" + UUID);
                    if (response[0] == '1')
                    {
                        secondsLeft = int.Parse(response.Split(' ')[1]);
                        return secondsLeft;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    Messages.CheckConnectErrorMessage(ex.Message);
                    Program.ExitProgram();
                    return 0;
                }
            }
        }

        public static string Base64Encode(string input)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string GetUUID()
        { 
            string UUID = "";
            ManagementObjectSearcher searcher;
            searcher = new ManagementObjectSearcher("root\\CIMV2",
                   "SELECT UUID FROM Win32_ComputerSystemProduct");
            foreach (ManagementObject queryObj in searcher.Get())
                UUID += queryObj["UUID"].ToString();
            return UUID;
        }
        public static void DisposeRestart()
        {
            string[] path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Split('\\');
            string yourFileName = path[path.Length - 1];
            string bat = @"taskkill /f /im ""yourfilename""
                start """" ""yourfilename"" params
                del ""restart.bat""
                ".Replace("yourfilename", yourFileName).Replace("params", Program.noUpdate ? "-noupdate" : "");
            StreamWriter writer = new StreamWriter("restart.bat", false);
            writer.Write(bat);
            writer.Close();
            StartHiddenProcess("restart.bat", "");
        }

        public static Process StartHiddenProcess(string fileName, string args)
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = args;
            process.Start();
            return process;
        }

        public static void UnpackTempFiles()
        {
            try
            {
                File.WriteAllBytes(Constants.tempFolder + "dumper.exe", Properties.Resources.dumper);
                File.WriteAllBytes(Constants.tempFolder + Constants.dumperConfigName, Properties.Resources.config);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при распаковке временных файлов", "MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                Program.ExitProgram();
            }
        }

        public static int IsGameEnable()
        {
            try
            {
                Process[] p = Process.GetProcessesByName(Addresses.process);
                if (p.Length > 0)
                    return 1;
                else
                    return 0;
            }
            catch
            {
                return -1;
            }
        }

        public static int GetGameModules(out int dll_client_address, out int dll_engine_address)
        {
            dll_client_address = 0;
            dll_engine_address = 0;
            try
            {
                Process[] p = Process.GetProcessesByName(Addresses.process);
                if (p.Length > 0)
                {
                    int dlls = 0;
                    foreach (ProcessModule m in p[0].Modules)
                    {
                        if (m.ModuleName == "client_panorama.dll")
                        {
                            dll_client_address = (int)m.BaseAddress;
                            dlls++;
                        }
                        if (m.ModuleName == "engine.dll")
                        {
                            dll_engine_address = (int)m.BaseAddress;
                            dlls++;
                        }
                        if (dlls == 2)
                            return 1;
                    }
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
