using MultiCheat_Window;
using MultiCheat_Window.Engine;
using MultiCheat_Window.Utils;
using System;
using System.Threading;

namespace MultiCheat_Window.Cheats
{
    public class TriggerCheat : Cheat
    {
        private MultiCheat Multi;

        public TriggerCheat(MultiCheat Multi)
        {
            this.Multi = Multi;
        }

        protected override void Run()
        {
            while (IsWorking())
            {
                int InCrossID = api.GetInCrossID();
                if (InCrossID > 0 && InCrossID < 65)
                {
                    int PICTeam = api.GetEntityTeam(InCrossID);
                    if ((PICTeam != api.GetMyTeam()) && (PICTeam > 1) && api.GetEntityHealth(InCrossID) > 0 && !GetKeyDown(0x1))
                    {
                        Thread.Sleep(Multi.delayBeforeShoot);
                        api.AttackEvent(1);
                        Thread.Sleep(Multi.chuckDelay);
                        api.AttackEvent(4);
                        Thread.Sleep(Multi.delayBetweenChucks);
                    }
                }
            }
        }
        private bool GetKeyDown(int key)
        {
            return Convert.ToBoolean(WinAPI.GetKeyState(key) & WinAPI.KEY_PRESSED);
        }

        public override void OnStop()
        {
            base.OnStop();
        }
    }
}
