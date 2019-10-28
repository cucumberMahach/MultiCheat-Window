using MultiCheat_Window.Engine;
using MultiCheat_Window.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCheat_Window
{
    public partial class ActivateForm : Form
    {
        private string UUID;
        
        public ActivateForm()
        {
            InitializeComponent();
            UUID = MachineFunctions.GetUUID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = maskedTextBox_key.Text.Trim();
            CheckerWebClient wc = new CheckerWebClient();
            try
            {
                string response = wc.DownloadString(Constants.updateUrlFirst + Constants.ActivateScript + "?k=" + key + "&u=" + UUID);
                if (response == "1")
                {
                    File.WriteAllText(Constants.ActivateFile, key);
                    MessageBox.Show("MultiCheat успешно активирован", "MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    MachineFunctions.DisposeRestart();
                }
                else
                {
                    MessageBox.Show("Введён неверный ключ", "MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    maskedTextBox_key.Focus();
                    maskedTextBox_key.SelectAll();
                }
            }
            catch (Exception ex)
            {
                Messages.CheckConnectErrorMessage(ex.Message);
                Program.ExitProgram();
            }
        }

        private void ActivateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ExitProgram();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Constants.VK_group);
        }
    }
    public class CheckerWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = Constants.keyCheckTimeout;
            return w;
        }
    }
}
