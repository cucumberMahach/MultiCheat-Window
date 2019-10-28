using MultiCheat_Window.Cheats;
using MultiCheat_Window.Engine;
using MultiCheat_Window.Utils;
using MultiCheat_Window.Utils.Maths;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCheat_Window.GUI
{
    public class OverlayWFController
    {
        private readonly OverlayWF overlay;
        private MultiCheat multiCheat;

        public OverlayWFController(MultiCheat multiCheat)
        {
            this.multiCheat = multiCheat;
            multiCheat.SetOverlayWFController(this);
            overlay = new OverlayWF(multiCheat);
            overlay.ShowDialog();
        }

        public void Render(Graphics g)
        {

        }

        public OverlayWF GetOverlayWF()
        {
            return overlay;
        }
    }
}
