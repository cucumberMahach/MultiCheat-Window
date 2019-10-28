using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using MultiCheat_Window.Engine;

namespace MultiCheat_Window
{
    public partial class MacrosesForm : Form
    {
        private MultiCheat multi;
        private Macroses macroses;

        public MacrosesForm(MultiCheat multi)
        {
            InitializeComponent();
            this.multi = multi;

            this.macroses = multi.settings.Macroses;
            printMacroses();
        }

        private void macrosesChanged()
        {
            printMacroses();
            //multi.ChangeMacroses(macroses);
        }

        private void printMacroses()
        {
            lab_Mac1.Text = macroses.macF5[0] + " мс | " + macroses.macF5[1] + " мс | " + macroses.macF5[2] + " мс";
            lab_Mac2.Text = macroses.macF6[0] + " мс | " + macroses.macF6[1] + " мс | " + macroses.macF6[2] + " мс";
            lab_Mac3.Text = macroses.macF7[0] + " мс | " + macroses.macF7[1] + " мс | " + macroses.macF7[2] + " мс";
            lab_Mac4.Text = macroses.macF8[0] + " мс | " + macroses.macF8[1] + " мс | " + macroses.macF8[2] + " мс";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            macroses.macF5[0] = multi.delayBeforeShoot;
            macroses.macF5[1] = multi.delayBetweenChucks;
            macroses.macF5[2] = multi.chuckDelay;
            macrosesChanged();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            macroses.macF6[0] = multi.delayBeforeShoot;
            macroses.macF6[1] = multi.delayBetweenChucks;
            macroses.macF6[2] = multi.chuckDelay;
            macrosesChanged();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            macroses.macF7[0] = multi.delayBeforeShoot;
            macroses.macF7[1] = multi.delayBetweenChucks;
            macroses.macF7[2] = multi.chuckDelay;
            macrosesChanged();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            macroses.macF8[0] = multi.delayBeforeShoot;
            macroses.macF8[1] = multi.delayBetweenChucks;
            macroses.macF8[2] = multi.chuckDelay;
            macrosesChanged();
        }

        public Macroses getMacroses()
        {
            return macroses;
        }

        private void MacrosesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }

    public struct Macroses
    {
        public int[] macF5;
        public int[] macF6;
        public int[] macF7;
        public int[] macF8;
    }
}
