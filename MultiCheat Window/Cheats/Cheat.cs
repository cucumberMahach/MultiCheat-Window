using MultiCheat_Window;
using MultiCheat_Window.CSGOApi;
using MultiCheat_Window.Engine;
using MultiCheat_Window.Utils;
using System.Diagnostics;
using System.Threading;

namespace MultiCheat_Window.Cheats
{
    public abstract class Cheat
    {
        private int dll_client_address, dll_engine_address;
        public CSGOFunctions api;

        private bool working;

        public Cheat()
        {
            
        }
        public void OnStart()
        {
            working = true;
            if (Init())
            {
                api = new CSGOFunctions(dll_client_address, dll_engine_address);
                Run();
            }
        }

        private bool Init()
        {
            while (working)
            {
                if (MachineFunctions.IsGameEnable() == 1 && MachineFunctions.GetGameModules(out dll_client_address, out dll_engine_address) == 1)
                    break;
                Thread.Sleep(Constants.cheatRefreshDelay);
            }
            return working;
        }

        protected abstract void Run();

        public virtual void OnStop()
        {
            working = false;
        }

        public bool IsWorking()
        {
            return working;
        }

        protected void SetWorking(bool value)
        {
            working = value;
        }
    }
}
