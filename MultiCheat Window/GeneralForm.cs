using MultiCheat_Window.Engine;
using MultiCheat_Window.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiCheat_Window
{
    public partial class GeneralForm : Form
    {
        private globalKeyboardHook keyHooker;
        public MacrosesForm macrosesForm;
        public MultiCheat multiCheat;

        private bool lastRun, rightsError = false;

        public GeneralForm()
        {
            InitializeComponent();

            this.Text = Constants.title + " (ver. " + Constants.versionNumber.ToString() + ")";
            lab_version.Text = string.Format("Версия {0} от\r\n{1}", Constants.versionNumber, Constants.versionDate);
            link_messages.Text = "Не работает? Вопросы?\r\n" + Constants.vkMessages.Replace("https://", "");
            link_site.Text = "Другие приложения\r\n" + Constants.site.Replace("http://", "");

            keyHooker = new globalKeyboardHook();
            //multiCheat = new MultiCheat(this);
            macrosesForm = new MacrosesForm(multiCheat);

            timer_CSGORunning.Enabled = true;
            keyHooker.HookedKeys.Add(Keys.F9);
            keyHooker.HookedKeys.Add(Keys.F10);
            keyHooker.HookedKeys.Add(Keys.F11);
            keyHooker.HookedKeys.Add(Keys.F12);
            keyHooker.HookedKeys.Add(Keys.F5);
            keyHooker.HookedKeys.Add(Keys.F6);
            keyHooker.HookedKeys.Add(Keys.F7);
            keyHooker.HookedKeys.Add(Keys.F8);
            keyHooker.KeyDown += new KeyEventHandler(keyHooker_KeyDown);
            keyHooker.KeyUp += new KeyEventHandler(keyHooker_KeyUp);
        }

        private void keyHooker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (multiCheat.IsTriggerEnabled())
                {
                    checkBox_TriggerBot.Checked = false;
                    Console.Beep(800, 100);
                }
                else
                {
                    checkBox_TriggerBot.Checked = true;
                    Console.Beep(3000, 100);
                }
            }

            if (e.KeyCode == Keys.F10)
            {
                if (multiCheat.IsWallHackEnabled())
                {
                    checkBox_Wallhack.Checked = false;
                    Console.Beep(800, 100);
                }
                else
                {
                    checkBox_Wallhack.Checked = true;
                    Console.Beep(3000, 100);
                }
            }

            if (e.KeyCode == Keys.F11)
            {
                if (multiCheat.IsNoFlashEnabled())
                {
                    checkBox_noFlash.Checked = false;
                    Console.Beep(800, 100);
                }
                else
                {
                    checkBox_noFlash.Checked = true;
                    Console.Beep(3000, 100);
                }
            }

            if (e.KeyCode == Keys.F12)
            {
                if (multiCheat.IsRadarHackEnabled())
                {
                    checkBox_RadarHack.Checked = false;
                    Console.Beep(800, 100);
                }
                else
                {
                    checkBox_RadarHack.Checked = true;
                    Console.Beep(3000, 100);
                }
            }

            if (e.KeyCode == Keys.F5)
            {
                track_delayBeforeShoot.Value = macrosesForm.getMacroses().macF5[0];
                track_daleyBetweenChucks.Value = macrosesForm.getMacroses().macF5[1];
                track_ChuckDelay.Value = macrosesForm.getMacroses().macF5[2];
                updateValueMacroses();
                Console.Beep(5000, 50);
            }

            if (e.KeyCode == Keys.F6)
            {
                track_delayBeforeShoot.Value = macrosesForm.getMacroses().macF6[0];
                track_daleyBetweenChucks.Value = macrosesForm.getMacroses().macF6[1];
                track_ChuckDelay.Value = macrosesForm.getMacroses().macF6[2];
                updateValueMacroses();
                Console.Beep(5000, 50);
            }

            if (e.KeyCode == Keys.F7)
            {
                track_delayBeforeShoot.Value = macrosesForm.getMacroses().macF7[0];
                track_daleyBetweenChucks.Value = macrosesForm.getMacroses().macF7[1];
                track_ChuckDelay.Value = macrosesForm.getMacroses().macF7[2];
                updateValueMacroses();
                Console.Beep(5000, 50);
            }

            if (e.KeyCode == Keys.F8)
            {
                track_delayBeforeShoot.Value = macrosesForm.getMacroses().macF8[0];
                track_daleyBetweenChucks.Value = macrosesForm.getMacroses().macF8[1];
                track_ChuckDelay.Value = macrosesForm.getMacroses().macF8[2];
                updateValueMacroses();
                Console.Beep(5000, 50);
            }
            e.Handled = true;
        }

        private void keyHooker_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        public void restartCheats()
        {
            bool wh = multiCheat.IsWallHackEnabled();
            bool trigger = multiCheat.IsTriggerEnabled();
            bool flash = multiCheat.IsNoFlashEnabled();
            multiCheat.EnableWallHackCheat(false);
            multiCheat.EnableTriggerCheat(false);
            multiCheat.EnableNoFlashCheat(false);
            if (wh)
                multiCheat.EnableWallHackCheat(true);
            if (trigger)
                multiCheat.EnableTriggerCheat(true);
            if (flash)
                multiCheat.EnableNoFlashCheat(true);
                
        }

        private void timer_CSGORunning_Tick(object sender, EventArgs e)
        {
            int isRunning = MachineFunctions.IsGameEnable();
            if (isRunning == 1)
            {
                rightsError = false;
                lab_csgoRunning.Text = Constants.csgoRunning;
                lab_csgoRunning.BackColor = Constants.colorDarkGreen;
                timer_CSGORunning.Interval = Constants.timerCheckOnDelay;
                if (!lastRun)
                {
                    multiCheat.CsgoStarted();
                }
                lastRun = true;
            }
            else
            {
                lab_csgoRunning.Text = Constants.csgoNotRunning;
                lab_csgoRunning.BackColor = Constants.colorDarkRed;
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

        private void updateValueMacroses()
        {
            lab_delayBetweenChucks.Text = track_daleyBetweenChucks.Value + " ms";
            lab_ChuckDelay.Text = track_ChuckDelay.Value + " ms";
            lab_delayBeforeShoot.Text = track_delayBeforeShoot.Value + " ms";
            multiCheat.delayBeforeShoot = track_delayBeforeShoot.Value;
            multiCheat.delayBetweenChucks = track_daleyBetweenChucks.Value;
            multiCheat.chuckDelay = track_ChuckDelay.Value;
        }

        private void checkBox_TriggerBot_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableTriggerCheat(checkBox_TriggerBot.Checked);
        }

        private void checkBox_Wallhack_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableWallHackCheat(checkBox_Wallhack.Checked);
        }

        private void checkBox_noFlash_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableNoFlashCheat(checkBox_noFlash.Checked);
        }

        private void checkBox_RadarHack_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableRadarCheat(checkBox_RadarHack.Checked);
        }

        private void checkBox_NoRecoil_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableNoRecoilCheat(checkBox_NoRecoil.Checked);
        }

        private void checkBox_BunnyHop_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableBunnyHopCheat(checkBox_BunnyHop.Checked);
        }

        private void checkBox_Aim_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableAimCheat(checkBox_Aim.Checked);
        }

        private void checkBox_Esp_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableWallHackEspCheat(checkBox_Esp.Checked);
        }

        private void checkBox_NoRecoilSave_CheckedChanged(object sender, EventArgs e)
        {
            multiCheat.EnableNoRecoilSaveCheat(checkBox_NoRecoilSave.Checked);
        }

        private void track_delayBetweenChucks_Scroll(object sender, EventArgs e)
        {
            lab_delayBetweenChucks.Text = track_daleyBetweenChucks.Value + " мс";
            multiCheat.delayBetweenChucks = track_daleyBetweenChucks.Value;
        }

        private void track_ChuckDelay_Scroll(object sender, EventArgs e)
        {
            lab_ChuckDelay.Text = track_ChuckDelay.Value + " мс";
            multiCheat.chuckDelay = track_ChuckDelay.Value;
        }

        private void GeneralForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            multiCheat.DisposeExit();
        }

        private void track_delayBeforeShoot_Scroll(object sender, EventArgs e)
        {
            lab_delayBeforeShoot.Text = track_delayBeforeShoot.Value + " мс";
            multiCheat.delayBeforeShoot = track_delayBeforeShoot.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            macrosesForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Constants.csgoFreeLink);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Constants.vkMessages);
        }

        private void link_site_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Constants.site);
        }

        double deltaR, deltaG, deltaB;

        private void timerColor_Tick(object sender, EventArgs e)
        {
            deltaR += 0.01f / 1.5;
            deltaG += 0.03f / 1.5;
            deltaB += 0.05f / 1.5;
            Color color = GetColorFromDouble(Math.Abs(Math.Sin(deltaR*5)), Math.Abs(Math.Cos(deltaG*5)), Math.Abs(Math.Sin(deltaB*5)));
            link_site.LinkColor = color;
        }

        private Color GetColorFromDouble(double r, double g, double b)
        {
            return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
        }

        public void offAllCheckBoxes()
        {
            checkBox_TriggerBot.Checked = false;
            checkBox_Wallhack.Checked = false;
            checkBox_noFlash.Checked = false;
            checkBox_RadarHack.Checked = false;
            checkBox_NoRecoil.Checked = false;
        }
    }
}
