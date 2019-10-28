using System;
using System.Windows.Forms;
using System.Net;
using System.ComponentModel;
using System.IO;
using MultiCheat_Window.Engine;
using System.Diagnostics;
using MultiCheat_Window.Utils;

namespace MultiCheat_Window
{
    public partial class UpdateForm : Form
    {
        private string updateUrl;
        private Timer timerWait = new Timer();
        private long bytesAll, bytesReceived, bytesLast = 0;
        private WebClient client;

        public UpdateForm(string updateUrl)
        {
            InitializeComponent();
            this.updateUrl = updateUrl;
            timerWait.Interval = Constants.afterUpdateWait;
            timerWait.Tick += new EventHandler(timerWaitTick);
        }

        private void update()
        {
            client = new WebClient();
            Uri uri = new Uri(updateUrl);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadCompleted);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(progressChanged);
            try
            {
                client.DownloadFileAsync(uri, Constants.tempUpdateFileName);
            }
            catch (WebException ex)
            {
                downloadError(DownloadErrorType.WEB_ERROR, ex.Status.ToString());
            }
            timerStatus.Interval = Constants.timerStatusInterval;
            timerStatus.Start();
        }

        private void timerWaitTick(object sender, EventArgs args)
        {
            ((Timer)sender).Stop();
            string[] path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Split('\\');
            string yourFileName = path[path.Length - 1];
            createBatFile(yourFileName);

            MachineFunctions.StartHiddenProcess("update.bat", "");
            Program.ExitProgram();
        }

        private void downloadCompleted(object sender, AsyncCompletedEventArgs args)
        {
            timerStatus.Stop();
            if (args.Error != null)
            {
                downloadError(DownloadErrorType.DOWNLOAD_COMPLETED_ERROR, null);
            }
            else
            {
                timerWait.Start();
                lab_status.Text = "Копирование...";
            }
        }

        private void progressChanged(object sender, DownloadProgressChangedEventArgs args)
        {
            progressBar.Value = args.ProgressPercentage;
            bytesAll = args.TotalBytesToReceive;
            bytesReceived = args.BytesReceived;
        }

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
            update();
        }

        private void createBatFile(string yourFileName)
        {
            string bat = @"taskkill /f /im ""yourfilename""
                del ""yourfilename""
                rename ""tempupdatefilename"" ""yourfilename""
                start """" ""yourfilename"" -newversion
                del ""update.bat""
                ".Replace("yourfilename", yourFileName).Replace("tempupdatefilename", Constants.tempUpdateFileName);
            StreamWriter writer = new StreamWriter("update.bat", false);
            writer.Write(bat);
            writer.Close();
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ExitProgram();
        }

        private float averangeSpeed = -1;
        private float timeDisconected = 0;

        private void timerStatus_Tick(object sender, EventArgs e)
        {

            float timeChanged = Constants.timerStatusInterval / 1000f;
            long bytesChanged = bytesReceived - bytesLast;

            float bps = bytesChanged / timeChanged;

            if (averangeSpeed == -1)
                averangeSpeed = bps;
            else
                averangeSpeed = (bps + averangeSpeed) / 2;

            if (bytesChanged == 0)
            {
                timeDisconected += timeChanged;
                if (timeDisconected >= Constants.timeDownloadTimeout)
                {
                    timerStatus.Stop();
                    client.Dispose();
                    downloadError(DownloadErrorType.TIMEOUT, null);
                }
            }else
            {
                timeDisconected = 0;
            }

            lab_status.Text = String.Format("Скорость: {0} КБ/сек. Осталось: {1}", Math.Round(bytesChanged / 1024 / timeChanged, 2), bytesChanged == 0 ? "∞" : (Math.Round((bytesAll - bytesReceived) / averangeSpeed).ToString() + " сек"));
            bytesLast = bytesReceived;
        }

        private void downloadError(DownloadErrorType error, string otherMessage)
        {
            tryDeleteTempFile();
            switch (error)
            {
                case DownloadErrorType.DOWNLOAD_COMPLETED_ERROR:
                    MessageBox.Show("Произошла ошибка во время загрузки файла", "Обновление MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
                case DownloadErrorType.TIMEOUT:
                    MessageBox.Show("Превышение времени ожидания. Проверьте подключение к интернету", "Обновление MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
                case DownloadErrorType.WEB_ERROR:
                    MessageBox.Show("Ошибка во время подключения: " + otherMessage, "Обновление MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
            }
            Hide();
            Program.StartProgram();
        }

        private void tryDeleteTempFile()
        {
            try
            {
                File.Delete(Constants.tempUpdateFileName);
            }
            catch { }
        }
    }
}

enum DownloadErrorType
{
    DOWNLOAD_COMPLETED_ERROR, TIMEOUT, WEB_ERROR
}
