using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MultiCheat_Window.Engine
{
    public class CheatSettings
    {
        private MultiCheat multicheat;
        private Settings settings;
        private readonly string configFile;

        public CheatSettings(string configFile, MultiCheat multicheat)
        {
            this.configFile = configFile;
            this.multicheat = multicheat;
            Load();
        }

        public void Save(Settings settings)
        {
            string data = JsonConvert.SerializeObject(settings);
            StreamWriter writer = new StreamWriter(configFile, false);
            writer.Write(data);
            writer.Close();
        }

        public Settings Load()
        {
            if (!File.Exists(configFile))
            {
                settings = RestoreSettings();
                Save(settings);
                return settings;
            }
            string data;
            StreamReader reader = new StreamReader(configFile);
            data = reader.ReadToEnd();
            reader.Close();
            settings = JsonConvert.DeserializeObject<Settings>(data);
            return settings;
        }

        private Settings RestoreSettings()
        {
            settings = new Settings();
            settings.Macroses = new Macroses();
            settings.Macroses.macF5 = new int[3];
            settings.Macroses.macF6 = new int[3];
            settings.Macroses.macF7 = new int[3];
            settings.Macroses.macF8 = new int[3];
            settings.Macroses.macF5[0] = multicheat.delayBeforeShoot;
            settings.Macroses.macF5[1] = multicheat.delayBetweenChucks;
            settings.Macroses.macF5[2] = multicheat.chuckDelay;
            settings.Macroses.macF6[0] = multicheat.delayBeforeShoot;
            settings.Macroses.macF6[1] = multicheat.delayBetweenChucks;
            settings.Macroses.macF6[2] = multicheat.chuckDelay;
            settings.Macroses.macF7[0] = multicheat.delayBeforeShoot;
            settings.Macroses.macF7[1] = multicheat.delayBetweenChucks;
            settings.Macroses.macF7[2] = multicheat.chuckDelay;
            settings.Macroses.macF8[0] = multicheat.delayBeforeShoot;
            settings.Macroses.macF8[1] = multicheat.delayBetweenChucks;
            settings.Macroses.macF8[2] = multicheat.chuckDelay;
            settings.csgoVerison = 0;
            return settings;
        }
    }

    public struct Settings
    {
        public Macroses Macroses;
        public int csgoVerison;
    }
}


