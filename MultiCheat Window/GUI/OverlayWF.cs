using MultiCheat_Window.Engine;
using MultiCheat_Window.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCheat_Window.GUI
{
    public partial class OverlayWF : Form
    {
        private MultiCheat multiCheat;
        private globalKeyboardHook keyHooker;

        private bool lastRun, rightsError = false;
        public bool Showing;

        private Panel ActivePanel;

        public OverlayWF(MultiCheat multiCheat)
        {
            InitializeComponent();
            this.multiCheat = multiCheat;

            panel_Title.MouseDown += new MouseEventHandler(this.lab_title_MouseDown);
            panel_Title.MouseUp += new MouseEventHandler(this.lab_title_MouseUp);
            panel_Title.MouseMove += new MouseEventHandler(this.lab_title_MouseMove);

            ActivePanel = panel_Cheats;
            UpdateActivePanel();
            panel_Cheats.Visible = true;

            keyHooker = new globalKeyboardHook();
            timer_CSGORunning.Enabled = true;
            keyHooker.HookedKeys.Add(Keys.Insert);
            keyHooker.KeyDown += new KeyEventHandler(keyHooker_KeyDown);
            keyHooker.KeyUp += new KeyEventHandler(keyHooker_KeyUp);

            Showing = false;
            Opacity = 0;

            contextMenuStrip.Items[0].Click += MenuStripExit;

            ShowTrayMessage("Multicheat", "Ожидание запуска игры...", 5, ToolTipIcon.None);

            lab_title.Text += " (версия " + Constants.versionNumber + " от " + Constants.versionDate + ")"; 

            //ShowDialog();
        }

        private void MenuStripExit(object sender, EventArgs e)
        {
            multiCheat.DisposeExit();
        }

        public void ShowTrayMessage(string title, string text, int timeOut, ToolTipIcon icon)
        {
            notifyIcon_Tray.ShowBalloonTip(timeOut, title, text, icon);
        }

        private void keyHooker_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void keyHooker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (Showing)
                {
                    Showing = false;
                    Opacity = 0;
                    try
                    {
                        Process csgoProcess = Process.GetProcessesByName("csgo")[0];
                        WinAPI.SetForegroundWindow(csgoProcess.MainWindowHandle);
                    }
                    catch { }
                }
                else
                {
                    Showing = true;
                    Opacity = 100;
                    try
                    {
                        Process csgoProcess = Process.GetCurrentProcess();
                        WinAPI.SetForegroundWindow(csgoProcess.MainWindowHandle);
                    }
                    catch { }
                }
            }
        }

            private void track_delayBeforeShoot_Scroll(object sender, EventArgs e)
        {
            label_DelayBeforeShoot.Text = track_delayBeforeShoot.Value + " мс";
            multiCheat.delayBeforeShoot = track_delayBeforeShoot.Value;
        }

        private void track_delayBetweenChucks_Scroll(object sender, EventArgs e)
        {
            label_DelayBetweenChucks.Text = track_delayBetweenChucks.Value + " мс";
            multiCheat.delayBetweenChucks = track_delayBetweenChucks.Value;
        }

        private void track_ChuckDelay_Scroll(object sender, EventArgs e)
        {
            label_ChuckDelay.Text = track_ChuckDelay.Value + " мс";
            multiCheat.delayBeforeShoot = track_ChuckDelay.Value;
        }

        private void timer_CSGORunning_Tick(object sender, EventArgs e)
        {
            int isRunning = MachineFunctions.IsGameEnable();
            if (isRunning == 1)
            {
                if (lastRun)
                    return;
                else
                    multiCheat.CsgoStarted();
                rightsError = false;
                timer_CSGORunning.Interval = Constants.timerCheckOnDelay;
                lastRun = true;
                multiCheat.CheatLoaded();
            }
            else
            {
                timer_CSGORunning.Interval = Constants.timerCheckOffDelay;
                if (lastRun)
                {
                    multiCheat.OffAllCheats();
                }
                lastRun = false;
                if (isRunning == -1 && rightsError == false)
                {
                    rightsError = true;
                    MessageBox.Show("Отказано в доступе к процессу. Запустите MultiCheat от имени Администратора!", "MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void button_Info_Click(object sender, EventArgs e)
        {
            //info
        }

        private bool IsWindowDragging;
        private int startDragX, startDragY;

        private void lab_title_MouseDown(object sender, MouseEventArgs e)
        {
            IsWindowDragging = true;
            startDragX = e.X;
            startDragY = e.Y;
        }

        private void lab_title_MouseUp(object sender, MouseEventArgs e)
        {
            IsWindowDragging = false;
        }
        private void lab_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsWindowDragging)
            {
                panel_Title.Left += e.X - startDragX;
                panel_Title.Top += e.Y - startDragY;
                UpdateActivePanel();
            }
        }

        private void checkBox_enableTrigger_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableTriggerCheat(checkBox_enableTrigger.Checked);
        }

        private void checkBox_NoRecoil_CheckedChanged(object sender, EventArgs e)
        {

            multiCheat.EnableNoRecoilCheat(checkBox_NoRecoil.Checked);
        }

        private void checkBox_NoRecoilSave_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableNoRecoilSaveCheat(checkBox_NoRecoilSave.Checked);
        }

        private void checkBox_WallHack_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableWallHackCheat(checkBox_WallHack.Checked);
        }

        private void checkBox2_WallHackESP_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableWallHackEspCheat(checkBox2_WallHackESP.Checked);
        }

        private void checkBox_NoFlash_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableNoFlashCheat(checkBox_NoFlash.Checked);
        }

        private void checkBox_BunnyHop_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableBunnyHopCheat(checkBox_BunnyHop.Checked);
        }

        private void checkBox_RadarHack_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableRadarCheat(checkBox_RadarHack.Checked);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            multiCheat.DisposeExit();
        }

        private void checkBox_Aim_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableAimCheat(checkBox_Aim.Checked);
        }

        private void trackBar_AimRadius_Scroll(object sender, EventArgs e)
        {
            label_AimRadius.Text = trackBar_AimRadius.Value + " px";
            multiCheat.GetAimCheats().AIM_RADIUS = trackBar_AimRadius.Value;
        }

        private void trackBar_AimSpeed_Scroll(object sender, EventArgs e)
        {
            label_AimSpeed.Text = (trackBar_AimSpeed.Value / 100f).ToString();
            multiCheat.GetAimCheats().AIM_SPEED = trackBar_AimSpeed.Value / 100f;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Constants.VK_group);
        }

        private void ChangeActivePanel(Panel p)
        {
            ActivePanel.Visible = false;
            p.Left = ActivePanel.Left;
            p.Top = ActivePanel.Top;
            p.Visible = true;
            ActivePanel = p;
        }

        private void UpdateActivePanel()
        {
            ActivePanel.Left = panel_Title.Left;
            ActivePanel.Top = panel_Title.Bottom + 2;
        }
    }
}
