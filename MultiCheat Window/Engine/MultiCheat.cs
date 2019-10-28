using MultiCheat_Window.Cheats;
using MultiCheat_Window.CSGOApi;
using MultiCheat_Window.Engine;
using MultiCheat_Window.GUI;
using MultiCheat_Window.Utils;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MultiCheat_Window.Engine
{
    static class Constants
    {
        public static string versionDate = "7 Декабря 2018";
        public static int versionNumber = 8;

        public static string title = "MultiCheat CSGO";
        public static string updateUrlFirst = "http://alex6406.ru/multicheat/"; //127.0.0.1
        public static string updateUrlSecond = "http://aleksandr6406.ucoz.ru/MultiCheat/";
        public static string updateVersionFile = "version.dat";
        public static int updateTimeout = 2000;
        public static int afterUpdateWait = 1000;
        public static int timerStatusInterval = 1000;
        public static float timeDownloadTimeout = 5;

        public static string ActivateFile = "activation.cheat";
        public static string ActivateScript = "activate.php";
        public static string ActivCheckScript = "active_check.php";

        public static int keyCheckTimeout = 4000;

        public static string tempUpdateFileName = "multicheat.dat";
        public static string csgoFreeLink = "https://csgo-download.ru/";
        public static string vkMessages = "https://vk.com/mrkotyathread";
        public static string site = "http://alex6406.ru";
        public static string VK_group = "https://vk.com/csgo_priv_cheats";

        public static string csgoNotRunning = "CSGO не запущена";
        public static string csgoRunning = "CSGO работает";

        public static string configFile = "config.cheat";
        public static string varsFile = "csgo.min.json";
        public static string tempFolder;
        public static string dumperName = "dumper.exe";
        public static int dumpWaitTime = 5000;
        public static string dumperConfigName = "dumperConfig.json";

        public static Color colorDarkRed = Color.Firebrick;
        public static Color colorDarkGreen = Color.DarkGreen;
        public static int cheatRefreshDelay = 200;
        public static int timerCheckOffDelay = 500;
        public static int timerCheckOnDelay = 1500;
        public static int dumpDelay = 1000;
        public static int screenWidth = SystemInformation.VirtualScreen.Width;
        public static int screenHeight = SystemInformation.VirtualScreen.Height;
        public static float noRecoilCof = 1.2f;

        public static int[] Llegbones = { 28, 27, 26, 0 };
        public static int[] Rlegbones = { 25, 24, 23, 0 };
        public static int[] Spinebones = { 0, 1, 2, 3, 4, 5, 10 };
        public static int[] Larmbones = { 9, 8, 7, 6 };
        public static int[] Rarmbones = { 15, 14, 13, 12 };

        public static int[] pointsIndexesT = { 8, 7, 7, 39, 39, 40, 40, 41, 41, 60, 7, 11, 11, 12, 12, 13, 13, 25, 7, 4, 4, 0, 0, 78, 78, 79, 79, 74, 74, 75, 75, 76, 0, 66, 66, 71, 71, 67, 67, 68, 68, 69 };
        public static int[] pointsIndexesCT = { 8, 39, 39, 40, 40, 41, 41, 64, 64, 96, 96, 61, 39, 38, 38, 12, 12, 35, 35, 23, 39, 81, 81, 77, 77, 73, 73, 74, 74, 75, 81, 86, 86, 82, 82, 83, 83, 84 };
    }

    public class MultiCheat
    {
        private TriggerCheat triggerCheat;
        private readonly OtherCheatsRealisation otherCheatsRealisation;
        private AimCheats aimCheats;

        private Thread triggerThread, otherCheatsThread, AimThread;
        private CheatSettings cheatSettings;

        private readonly globalKeyboardHook keyHooker;
        private readonly Overlay Overlay;
        private OverlayWFController overlayWFController;

        public int delayBeforeShoot = 0;
        public int delayBetweenChucks = 0;
        public int chuckDelay = 1;

        public Settings settings;

        public MultiCheat()
        {

            keyHooker = new globalKeyboardHook();
            triggerCheat = new TriggerCheat(this);
            otherCheatsRealisation = new OtherCheatsRealisation(this);
            aimCheats = new AimCheats(this);
            cheatSettings = new CheatSettings(Constants.configFile, this);
            settings = cheatSettings.Load();

            //stop
            Overlay = new Overlay(otherCheatsRealisation, aimCheats);
        }

        public void CheatLoaded()
        {
            overlayWFController.GetOverlayWF().ShowTrayMessage("MultiCheat", "Чит загружен и готов к работе.\nИспользуйте Insert для настройки", 5, ToolTipIcon.None);
        }

        public void SetOverlayWFController(OverlayWFController overlayWFController)
        {
            this.overlayWFController = overlayWFController;
        }

        public bool IsPaused()
        {
            return overlayWFController.GetOverlayWF().Showing;
        }

        public void RestartCheats()
        {
            bool trigger = IsTriggerEnabled();
            bool norecoil = IsNoRecoilEnabled();
            bool norecoil_save = IsNoRecoilSaveEnabled();
            bool wh = IsWallHackEnabled();
            bool wh_esp = IsWallHackEspEnabled();
            bool aim = IsAimEnabled();
            bool flash = IsNoFlashEnabled();
            bool bunnyHop = IsBunnyHopEnabled();
            bool radar = IsRadarHackEnabled();
            OffAllCheats();
            if (trigger)
                EnableTriggerCheat(true);
            if (norecoil)
                EnableNoRecoilCheat(true);
            if (norecoil_save)
                EnableNoRecoilSaveCheat(true);
            if (wh)
                EnableWallHackCheat(true);
            if (wh_esp)
                EnableWallHackEspCheat(true);
            if (aim)
                EnableAimCheat(true);
            if (flash)
                EnableNoFlashCheat(true);
            if (bunnyHop)
                EnableBunnyHopCheat(true);
            if (radar)
                EnableRadarCheat(true);
        }

        public ConcurrentDictionary<float, OtherCheatsParams> GetOtherCheatsParams()
        {
            return otherCheatsRealisation.GetCheatsParams();
        }

        public void DisposeExit()
        {
            OffAllCheats();
            Program.ExitProgram();
        }

        public void OffAllCheats()
        {
            EnableTriggerCheat(false);
            EnableNoRecoilCheat(false);
            EnableNoRecoilSaveCheat(false);
            EnableWallHackCheat(false);
            EnableWallHackEspCheat(false);
            EnableAimCheat(false);
            EnableNoFlashCheat(false);
            EnableBunnyHopCheat(false);
            EnableRadarCheat(false);
        }

        public bool IsNoFlashEnabled()
        {
            return otherCheatsRealisation.IsNoFlashEnabled();
        }

        public bool IsTriggerEnabled()
        {
            return triggerCheat.IsWorking();
        }

        public bool IsWallHackEnabled()
        {
            return otherCheatsRealisation.IsWallHackEnabled();
        }
        public bool IsWallHackEspEnabled()
        {
            return otherCheatsRealisation.IsWallHackEspEnabled();
        }
        public bool IsRadarHackEnabled()
        {
            return otherCheatsRealisation.IsRadarHackEnabled();
        }

        public bool IsNoRecoilSaveEnabled()
        {
            return aimCheats.IsNoRecoilSaveEnabled();
        }

        public bool IsNoRecoilEnabled()
        {
            return aimCheats.IsNoRecoilEnabled();
        }

        public bool IsBunnyHopEnabled()
        {
            return otherCheatsRealisation.IsBunnyHopEnabled();
        }

        public bool IsAimEnabled()
        {
            return aimCheats.IsAimEnabled();
        }

        public void EnableNoFlashCheat(bool enable)
        {
            if (otherCheatsRealisation.IsNoFlashEnabled() == enable)
                return;
            otherCheatsRealisation.SetNoFlashEnabled(enable);
            if (enable && !otherCheatsRealisation.IsWorking())
            {
                otherCheatsThread = new Thread(otherCheatsRealisation.OnStart);
                otherCheatsRealisation.SetThread(otherCheatsThread);
                otherCheatsThread.Start();
            }
        }

        public void EnableTriggerCheat(bool enable)
        {
            if (triggerCheat.IsWorking() == enable)
                return;
            if (enable)
            {
                triggerThread = new Thread(triggerCheat.OnStart);
                triggerThread.Start();
            }
            else
            {
                triggerCheat.OnStop();
                if (triggerThread != null)
                    triggerThread.Abort();
            }

        }

        public void EnableWallHackEspCheat(bool enable)
        {
            if (otherCheatsRealisation.IsWallHackEspEnabled() == enable)
                return;
            otherCheatsRealisation.SetWallHackEspEnabled(enable);
            if (enable && !otherCheatsRealisation.IsWorking())
            {
                otherCheatsThread = new Thread(otherCheatsRealisation.OnStart);
                otherCheatsRealisation.SetThread(otherCheatsThread);
                otherCheatsThread.Start();
            }
        }

        public void EnableWallHackCheat(bool enable)
        {
            if (otherCheatsRealisation.IsWallHackEnabled() == enable)
                return;
            otherCheatsRealisation.SetWallHackEnabled(enable);
            if (enable && !otherCheatsRealisation.IsWorking())
            {
                otherCheatsThread = new Thread(otherCheatsRealisation.OnStart);
                otherCheatsRealisation.SetThread(otherCheatsThread);
                otherCheatsThread.Start();
            }
        }


        public void EnableRadarCheat(bool enable)
        {
            if (otherCheatsRealisation.IsRadarHackEnabled() == enable)
                return;
            otherCheatsRealisation.SetRadarHackEnabled(enable);
            if (enable && !otherCheatsRealisation.IsWorking())
            {
                otherCheatsThread = new Thread(otherCheatsRealisation.OnStart);
                otherCheatsRealisation.SetThread(otherCheatsThread);
                otherCheatsThread.Start();
            }
        }

        public void EnableNoRecoilSaveCheat(bool enable)
        {
            if (aimCheats.IsNoRecoilSaveEnabled() == enable)
                return;
            aimCheats.SetNoRecoilSaveEnabled(enable);
            if (enable && !aimCheats.IsWorking())
            {
                AimThread = new Thread(aimCheats.OnStart);
                aimCheats.SetThread(AimThread);
                AimThread.Start();
            }
        }

        public void EnableNoRecoilCheat(bool enable)
        {
            if (aimCheats.IsNoRecoilEnabled() == enable)
                return;
            aimCheats.SetNoRecoilEnabled(enable);
            if (enable && !aimCheats.IsWorking())
            {
                AimThread = new Thread(aimCheats.OnStart);
                aimCheats.SetThread(AimThread);
                AimThread.Start();
            }
        }

        public void EnableBunnyHopCheat(bool enable)
        {
            if (otherCheatsRealisation.IsBunnyHopEnabled() == enable)
                return;
            otherCheatsRealisation.SetBunnyHopEnabled(enable);
            if (enable && !otherCheatsRealisation.IsWorking())
            {
                otherCheatsThread = new Thread(otherCheatsRealisation.OnStart);
                otherCheatsRealisation.SetThread(otherCheatsThread);
                otherCheatsThread.Start();
            }
        }

        public void EnableAimCheat(bool enable)
        {
            if (aimCheats.IsAimEnabled() == enable)
                return;
            aimCheats.SetAimEnabled(enable);
            if (enable && !aimCheats.IsWorking())
            {
                AimThread = new Thread(aimCheats.OnStart);
                aimCheats.SetThread(AimThread);
                AimThread.Start();
            }
        }

        public void CsgoStarted()
        {
            DumperData vars = Dumper.ScanVars();
            if (vars == null)
            {
                Thread.Sleep(Constants.dumpDelay);
                CsgoStarted();
                return;
            }
            CSGOFunctions.InitVars(vars);
            RestartCheats();
        }

        public AimCheats GetAimCheats()
        {
            return aimCheats;
        }

        public OtherCheatsRealisation GetOtherCheatsRealisation()
        {
            return otherCheatsRealisation;
        }
    }

    
}
