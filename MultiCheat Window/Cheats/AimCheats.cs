using MultiCheat_Window;
using MultiCheat_Window.Engine;
using MultiCheat_Window.Utils;
using MultiCheat_Window.Utils.Maths;
using System;
using System.Threading;

namespace MultiCheat_Window.Cheats
{
    public class AimCheats : Cheat
    {
        private MultiCheat Multi;
        private Thread thread;

        private Matrix viewMatrix;
        private Vector3 tempVector3 = new Vector3(), tempVector3_1 = new Vector3(), tempVector3_2 = new Vector3();
        private Vector2 tempVector2 = new Vector2(), tempVector2_1 = new Vector2(), tempVector2_2 = new Vector2();
        private Vector3 AimAngles = new Vector3(), PrevAngles = new Vector3();

        private bool AimEnabled, NoRecoilEnabled, NoRecoilSaveEnabled;

        public float RecoilCrossX, RecoilCrossY;
        public float AIM_RADIUS = 70, AIM_SPEED = 5;
        private int selectedID = -1;
        

        public AimCheats(MultiCheat Multi)
        {
            this.Multi = Multi;
            viewMatrix = new Matrix(4, 4);
        }

        protected override void Run()
        {
            while (IsWorking())
            {
                #region NoRecoil
                if (NoRecoilEnabled /*&& !AimEnabled*/)
                {

                    AimAngles = api.GetPlayerRecoilAngles(AimAngles);

                    float deltaX = (AimAngles.X * Constants.noRecoilCof - PrevAngles.X) * 2f;
                    float deltaY = (AimAngles.Y * Constants.noRecoilCof - PrevAngles.Y) * 2f;

                    uint dx = (uint)MathUtils.AngletoScreenX(Constants.screenWidth, Constants.screenHeight, deltaX, 0);
                    uint dy = (uint)MathUtils.AngletoScreenY(Constants.screenWidth, Constants.screenHeight, deltaY, 0);

                    WinAPI.mouse_event((uint)1, (uint)(dx), (uint)(-dy), 0, 0);

                    PrevAngles.X = AimAngles.X * Constants.noRecoilCof;
                    PrevAngles.Y = AimAngles.Y * Constants.noRecoilCof;

                }
                #endregion

                #region NoRecoilSave
                if (NoRecoilSaveEnabled)
                {

                    AimAngles = api.GetPlayerRecoilAngles(AimAngles);

                    int dx = (int)MathUtils.AngletoScreenX(Constants.screenWidth, Constants.screenHeight, AimAngles.X, 0);
                    int dy = (int)MathUtils.AngletoScreenY(Constants.screenWidth, Constants.screenHeight, AimAngles.Y, 0);

                    RecoilCrossX = -dx + Constants.screenWidth / 2;
                    RecoilCrossY = dy + Constants.screenHeight / 2;

                }
                #endregion

                #region Aim
                
                if (AimEnabled && WinAPI.GetAsyncKeyState(WinAPI.VirtualKeyShort.LBUTTON) != 0 && !Multi.IsPaused())
                {
                    api.GetViewMatrix(viewMatrix);
                    if (selectedID == -1)
                    {
                        for (int i = 0; i < 64; i++)
                        {
                            api.GetEntityBonePos(i, 8, tempVector3);
                            if (api.IsEntityValid(i) && MathUtils.WorldToScreen(viewMatrix, Constants.screenWidth, Constants.screenHeight, tempVector3, tempVector2))
                            {
                                float dist = MathUtils.GetDistance(1920 / 2, 1080 / 2, tempVector2.X, tempVector2.Y);
                                if (dist < AIM_RADIUS)
                                {
                                    selectedID = i;
                                }
                            }
                        }
                    }
                    if (selectedID != -1)
                    {
                        api.GetEntityBonePos(selectedID, 8, tempVector3);

                        if (api.IsEntityValid(selectedID) && MathUtils.WorldToScreen(viewMatrix, Constants.screenWidth, Constants.screenHeight, tempVector3, tempVector2))
                        {
                            float dist = MathUtils.GetDistance(1920 / 2, 1080 / 2, tempVector2.X, tempVector2.Y);
                            if (dist < AIM_RADIUS)
                            {

                                if (NoRecoilEnabled)
                                {
                                    AimAngles = api.GetPlayerRecoilAngles(AimAngles);

                                    int dx = (int)MathUtils.AngletoScreenX(Constants.screenWidth, Constants.screenHeight, AimAngles.X, 0);
                                    int dy = (int)MathUtils.AngletoScreenY(Constants.screenWidth, Constants.screenHeight, AimAngles.Y, 0);

                                    RecoilCrossX = -dx + Constants.screenWidth / 2;
                                    RecoilCrossY = dy + Constants.screenHeight / 2;
                                    AimAtPos(RecoilCrossX, RecoilCrossY, tempVector2.X, tempVector2.Y);
                                }
                                else
                                {
                                    AimAtPos(Constants.screenWidth / 2, Constants.screenHeight / 2, tempVector2.X, tempVector2.Y);
                                }
                                Thread.Sleep(10);
                            }
                            else
                            {
                                selectedID = -1;
                            }
                        }
                        else
                        {
                            selectedID = -1;
                        }
                    }

                }
                else
                {
                    selectedID = -1;
                }
                #endregion
            }
        }

        private void AimAtPos(float fromX, float fromY, float x, float y)
        {
            float TargetX = 0;
            float TargetY = 0;
            float scrCenterX = fromX;
            float scrCenterY = fromY;

            //X Axis
            if (x != 0)
            {
                if (x > scrCenterX)
                {
                    TargetX = -(scrCenterX - x);
                    TargetX /= AIM_SPEED;
                    if (TargetX + scrCenterX > scrCenterX * 2) TargetX = 0;
                }

                if (x < scrCenterX)
                {
                    TargetX = x - scrCenterX;
                    TargetX /= AIM_SPEED;
                    if (TargetX + scrCenterX < 0) TargetX = 0;
                }
            }

            //Y Axis

            if (y != 0)
            {
                if (y > scrCenterY)
                {
                    TargetY = -(scrCenterY - y);
                    TargetY /= AIM_SPEED;
                    if (TargetY + scrCenterY > scrCenterY * 2) TargetY = 0;
                }

                if (y < scrCenterY)
                {
                    TargetY = y - scrCenterY;
                    TargetY /= AIM_SPEED;
                    if (TargetY + scrCenterY < 0) TargetY = 0;
                }
            }

            WinAPI.mouse_event((uint)1, (uint)(TargetX), (uint)(TargetY), 0, 0);
        }

        public void SetAimRadius(float value)
        {
            AIM_RADIUS = value;
        }

        public float GetAimRadous()
        {
            return AIM_RADIUS;
        }

        public void SetAimEnabled(bool value)
        {
            AimEnabled = value;
            CheckAutomaticTurnOff();
        }

        public void SetNoRecoilSaveEnabled(bool value)
        {
            NoRecoilSaveEnabled = value;
            CheckAutomaticTurnOff();
        }

        public void SetNoRecoilEnabled(bool value)
        {
            NoRecoilEnabled = value;
            CheckAutomaticTurnOff();
        }

        public bool IsAimEnabled()
        {
            return AimEnabled;
        }

        public bool IsNoRecoilEnabled()
        {
            return NoRecoilEnabled;
        }

        public bool IsNoRecoilSaveEnabled()
        {
            return NoRecoilSaveEnabled;
        }

        private void CheckAutomaticTurnOff()
        {
            if (!NoRecoilEnabled && !NoRecoilSaveEnabled && !AimEnabled)
            {
                OnStop();
                thread.Abort();
            }
        }

        public void SetThread(Thread thread)
        {
            this.thread = thread;
        }

        public override void OnStop()
        {
            base.OnStop();
        }
    }
}
