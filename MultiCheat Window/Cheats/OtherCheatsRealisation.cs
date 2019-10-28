using GameOverlay.Graphics.Primitives;
using MultiCheat_Window.CSGOApi;
using MultiCheat_Window.Engine;
using MultiCheat_Window.GUI;
using MultiCheat_Window.Utils;
using MultiCheat_Window.Utils.Maths;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MultiCheat_Window.Cheats
{
    public class OtherCheatsRealisation : Cheat
    {
        private readonly MultiCheat Multi;
        private readonly Stopwatch stopwatch = new Stopwatch();
        private Thread thread;
        private bool NoFlashEnabled, WallHackEnabled, WallHackEspEnabled, RadarHackEnabled, BunnyHopEnabled;
        private long DeltaMillis, PrevCircleTime, NoFlashElapsed;
        private GlowColor glowColor = new GlowColor();
        private Vector3 PrevAngles = new Vector3(), AimAngles = new Vector3();
        private Matrix viewMatrix;
        private Vector3 tempVector3 = new Vector3(), tempVector3_1 = new Vector3(), tempVector3_2 = new Vector3();
        private Vector2 tempVector2 = new Vector2(), tempVector2_1 = new Vector2(), tempVector2_2 = new Vector2();

        public readonly ESPRectangle[] Rects = new ESPRectangle[64];

        private ConcurrentDictionary<float, OtherCheatsParams> Params = new ConcurrentDictionary<float, OtherCheatsParams>();


        public OtherCheatsRealisation(MultiCheat multi)
        {
            Multi = multi;
            viewMatrix = new Matrix(4, 4);
            tempVector3 = new Vector3();
            for (int i = 0; i < Rects.Length; i++)
                Rects[i] = new ESPRectangle();
            /*for (int i = 0; i < pointsT.Length; i++)
                pointsT[i] = new Vector2();*/
            csApi = api;
        }

        public CSGOFunctions csApi;
        protected override void Run()
        {
            stopwatch.Start();
            while (IsWorking())
            {
                DeltaMillis = stopwatch.ElapsedMilliseconds - PrevCircleTime;
                PrevCircleTime = stopwatch.ElapsedMilliseconds;

                #region NoFlash
                if (NoFlashEnabled)
                {
                    NoFlashElapsed += DeltaMillis;
                    if (NoFlashElapsed >= 1000)
                    {
                        NoFlashElapsed = 0;
                        if (api.GetFlashAlpha() > 0.0f)
                        {
                            api.SetFlashAlpha(0.0f);
                        }
                    }
                }
                #endregion

                #region Wallhack esp
                if (WallHackEspEnabled)
                {
                    api.GetViewMatrix(viewMatrix);
                    for (int i = 0; i < Rects.Length; i++)
                    {
                        api.GetEntityBonePos(i, 8, tempVector3);

                        if (api.IsEntityValid(i) && MathUtils.WorldToScreen(viewMatrix, Constants.screenWidth, Constants.screenHeight, tempVector3, tempVector2))
                        {

                            Rects[i].topPosX = tempVector2.X;
                            Rects[i].topPosY = tempVector2.Y;

                            Rects[i].IsEnemy = api.GetMyTeam() != api.GetEntityTeam(i);

                            api.GetPlayerPosition(tempVector3);
                            api.GetEntityEyePos(i, tempVector3_2);
                            Rects[i].lenToPlayer = tempVector3.DistanceTo(tempVector3_2);

                            api.GetEntityBonePos(i, 0, tempVector3_1);

                            if (MathUtils.WorldToScreen(viewMatrix, Constants.screenWidth, Constants.screenHeight, tempVector3_1, tempVector2_1))
                            {
                                Rects[i].downPosX = tempVector2_1.X;
                                Rects[i].downPosY = tempVector2_1.Y;
                                Rects[i].hp = api.GetEntityHealth(i) / 100f;
                            }
                            else
                            {
                                Rects[i].downPosX = 0;
                                Rects[i].downPosY = 0;
                            }
                        }
                        else
                        {
                            Rects[i].topPosX = 0;
                            Rects[i].topPosY = 0;
                            Rects[i].downPosX = 0;
                            Rects[i].downPosY = 0;
                        }
                    }
                }
                #endregion

                #region WallHack glow and RadarHack
                if (WallHackEnabled || RadarHackEnabled)
                {
                    for (int i = 0; i < 64; i++)
                    {
                        if (!api.IsEntityDormant(i))
                        {
                            if (api.GetMyTeam() == api.GetEntityTeam(i) && WallHackEnabled)
                            {
                                glowColor.RestoreTeam();
                                api.DrawEntityGlow(i, glowColor);

                            }
                            else
                            {
                                if (WallHackEnabled)
                                {
                                    glowColor.RestoreEnemyAndCalc(api.GetEntityHealth(i));
                                    api.DrawEntityGlow(i, glowColor);
                                }
                                if (RadarHackEnabled)
                                    api.SetSpotted(i, true);
                            }
                        }
                    }
                }
                #endregion
                
                #region BunnyHop
                if (BunnyHopEnabled)
                {
                    if (WinAPI.GetAsyncKeyState(WinAPI.VirtualKeyShort.SPACE) != 0 && api.GetMyFlags() == (int)CSGOFunctions.LocalFlags.FL_ON_GROUND)
                        api.PlayerForceJump(35);
                }
                #endregion

                
            }
        }

        public void SetWallHackEspEnabled(bool value)
        {
            WallHackEspEnabled = value;
            CheckAutomaticTurnOff();
        }

        public void SetBunnyHopEnabled(bool value)
        {
            BunnyHopEnabled = value;
            CheckAutomaticTurnOff();
        }

        public void SetRadarHackEnabled(bool value)
        {
            RadarHackEnabled = value;
            CheckAutomaticTurnOff();
        }

        public void SetWallHackEnabled(bool value)
        {
            WallHackEnabled = value;
            CheckAutomaticTurnOff();
        }

        public void SetNoFlashEnabled(bool value)
        {
            NoFlashEnabled = value;
            CheckAutomaticTurnOff();
        }

        public bool IsBunnyHopEnabled()
        {
            return BunnyHopEnabled;
        }

        public bool IsRadarHackEnabled()
        {
            return RadarHackEnabled;
        }

        public bool IsWallHackEnabled()
        {
            return WallHackEnabled;
        }

        public bool IsWallHackEspEnabled()
        {
            return WallHackEspEnabled;
        }

        public bool IsNoFlashEnabled()
        {
            return NoFlashEnabled;
        }
        public void SetThread(Thread thread)
        {
            this.thread = thread;
        }

        private void CheckAutomaticTurnOff()
        {
            if (!NoFlashEnabled && !WallHackEnabled && !WallHackEspEnabled && !RadarHackEnabled && !BunnyHopEnabled)
            {
                OnStop();
                thread.Abort();
            }
        }

        public override void OnStop()
        {
            base.OnStop();
            stopwatch.Reset();
            if (api != null) //OnStopHandle
                api.SetFlashAlpha(255.0f);
        }

        public ConcurrentDictionary<float, OtherCheatsParams> GetCheatsParams()
        {
            return Params;
        }
    }

    public enum OtherCheatsParams
    {
        AimWithNoRecoil
    }
}
