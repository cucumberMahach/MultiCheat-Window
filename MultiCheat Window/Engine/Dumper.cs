using MultiCheat_Window.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCheat_Window.Engine
{
    static class Dumper
    {

        public static DumperData ScanVars()
        {
            string data = GetDump();
            if (data == null)
                return null;
            DumperData vars = JsonConvert.DeserializeObject<DumperData>(data);
            if (vars.NotFull())
                return null;
            return vars;
        }

        private static void RemoveAll()
        {
            try
            {
                File.Delete("csgo.cs");
                File.Delete("csgo.hpp");
                if (!Program.addresses)
                    File.Delete("csgo.json");
                File.Delete("csgo.min.json");
                File.Delete("csgo.toml");
                File.Delete("csgo.vb");
                File.Delete("csgo.yaml");
                File.Delete("hazedumper.log");
            }
            catch { }
        }

        private static string GetDump()
        {
            if (!File.Exists(Constants.tempFolder + Constants.dumperName))
            {
                MachineFunctions.UnpackTempFiles();
                return GetDump();
            }else
            {
                File.WriteAllBytes(Constants.dumperConfigName, Properties.Resources.config);

                Process pr = MachineFunctions.StartHiddenProcess(Constants.tempFolder + Constants.dumperName, "-c " + Constants.dumperConfigName);
                pr.WaitForExit(Constants.dumpWaitTime);

                File.Delete(Constants.dumperConfigName);
                if (File.Exists(Constants.varsFile))
                {
                    string data;
                    StreamReader reader = new StreamReader(Constants.varsFile);
                    data = reader.ReadToEnd();
                    reader.Close();
                    RemoveAll();
                    return data;
                }
                else
                {
                    RemoveAll();
                    return null;
                }
            }
        }
    }

    public class DumperData
    {
        public long timestamp;
        public Dictionary<String, int> signatures;
        public Dictionary<String, int> netvars;

        public bool NotFull()
        {
            return signatures == null || netvars == null;
        }
    }
}
