using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab4
{
    public partial class MainForm : Form
    {
        Chart[] targetCharts;
        Bitmap originImage;

        public MainForm()
        {
            InitializeComponent();

            targetCharts = new Chart[3];
            targetCharts[0] = chart1;
            targetCharts[1] = chart2;
            targetCharts[2] = chart3;

            groupBox1.Enabled = true;

            Calculate(1,NoisySignal.FilteringType.Parabolic);
        }

        private void ClearCharts()
        {
            for(int i = 0; i <= 2; i++)
            {
                foreach(var j in targetCharts[i].Series)
                {
                    j.Points.Clear();
                }
            }
        }

        private void Calculate(int freq, NoisySignal.FilteringType ft)
        {
            NoisySignal hs = new NoisySignal(10, freq, 0, 512);
            double[] fs=null;
            switch (ft)
            {
                case NoisySignal.FilteringType.Parabolic:
                    fs = hs.ps;
                    break;
                case NoisySignal.FilteringType.Median:
                    fs = hs.ms;
                    break;
                case NoisySignal.FilteringType.Sliding:
                    fs = hs.ss;
                    break;
                default:
                    break;
            }

            ClearCharts();

            for (int i = 0; i <= 359; i++)
            {
                targetCharts[0].Series[0].Points.AddXY(2 * Math.PI * i / 360, hs.signVal[i]);
                targetCharts[0].Series[1].Points.AddXY(2 * Math.PI * i / 360, fs[i]);
            }

            hs.Operate(ft);

            for (int i = 0; i <= 49; i++)
            {
                targetCharts[1].Series[0].Points.AddXY(i, hs.phaseSp[i]);
                targetCharts[1].Series[1].Points.AddXY(i, hs.psp[i]);
                targetCharts[2].Series[0].Points.AddXY(i, hs.amplSp[i]);
                targetCharts[2].Series[1].Points.AddXY(i, hs.asp[i]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Calculate(1, NoisySignal.FilteringType.Parabolic);
                    break;
                case 1:
                    Calculate(1, NoisySignal.FilteringType.Sliding);
                    break;
                case 2:
                    Calculate(1, NoisySignal.FilteringType.Median);
                    break;
                default: return;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
                groupBox1.Enabled = false;
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
            }
        }
    }
}
