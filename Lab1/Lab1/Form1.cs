using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private int graphCount = 5;
        private readonly Chart _chart;
        private readonly List<Series> _seriesList = new List<Series>();
        private readonly List<HarmonicalSignal> _signals = new List<HarmonicalSignal>()
        {
            new HarmonicalSignal(0, 0, 0, ""),
            new HarmonicalSignal(0, 0, 0, ""),
            new HarmonicalSignal(0, 0, 0, ""),
            new HarmonicalSignal(0, 0, 0, ""),
            new HarmonicalSignal(0, 0, 0, "")
        };
        private readonly List<double> _polyharmonicalSignal = new List<double>();

        public Form1()
        {
            InitializeComponent();
            _chart = new Chart
            {
                Parent = this,
                Width = 1000,
                Height = 400,
            };
            _chart.ChartAreas.Add(new ChartArea("chart1"));
            constValues.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void Draw(IEnumerable<double> points, string legend)
        {
            var series = new Series
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "chart1",
                Legend = legend
            };

            var k = 0;
            foreach (var t in points)
            {
                series.Points.AddXY(k, t);
                k++;
            }
            _seriesList.Add(series);
            _chart.Series.Add(series);

            _chart.Legends.Add(new Legend(legend));

            _chart.Legends[legend].DockedToChartArea = "chart1";

            _chart.Series.Last().Legend = legend;
            _chart.Series.Last().LegendText = legend;
            _chart.Series.Last().IsVisibleInLegend = true;
        }

        private void DrawPolyharmonicalWithLinearDiff(int N)
        {
            var polyAndLinear = new List<double>();
            double A = 5;
            double[] fis = { 100.0, 150.0 };
            double f = 1;
            var legend = $"Init val: A={A} fi=[{fis[0]}, {fis[1]}] f={f}\n";
            for (var i = 0; i < N; i++)
            {
                double sum = 0;
                var ntmp = i % N;
                A += 0.2 * i / N;
                f -= 0.1 * i / N;
                fis[0] += 0.05 * i / N;
                fis[1] -= 0.05 * i / N;
                for (var j = 0; j < 2; j++)
                {
                    sum += A * Math.Sin(2 * Math.PI * f * ntmp / N + fis[j]);
                }
                polyAndLinear.Add(sum);
            }

            Draw(polyAndLinear, legend + $"End val: A={A} fi=[{fis[0]}, {fis[1]}] f={f}");
        }

        private void DrawPolyharmonicalSignal(int n)
        {
            var fiValues = new[] { Math.PI / 9, Math.PI / 4, Math.PI / 3, Math.PI / 6, 0 };
            for (var i = 0; i < graphCount; i++)
            {
                _signals[i].A = 5;
                _signals[i].f = i + 1;
                _signals[i].fi = fiValues[i];
                _signals[i].N = n;
                _signals[i].Calculate();
            }

            for (var i = 0; i < n; i++)
            {
                var x = _signals.Sum(s => s.Points[i]);
                _polyharmonicalSignal.Add(x);
            }

            Draw(_polyharmonicalSignal, "polyharm");
        }

        private void DrawHarmonicalSignals(int n)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ConstAandF(n);
                    break;
                case 1:
                    ConstAnadFi(n);
                    break;
                case 2:
                    ConstFandFi(n);
                    break;
                default:
                    ConstAandF(n);
                    return;
            }

            foreach (var signal in _signals)
            {
                signal.N = n;
                signal.Calculate();
                Draw(signal.Points, signal.Legend);
            }
        }

        private void ConstAandF(int n) 
        {
            var fiValues = new [] { Math.PI / 4, Math.PI / 2, Math.PI * 3 / 4, 0, Math.PI };
            var legends = new [] { "pi/4", "pi/2", "pi3/4", "0", "pi" };
            for (var i = 0; i < graphCount; i++)
            {
                _signals[i].A = 5;
                _signals[i].f = 1;
                _signals[i].fi = fiValues[i];
                _signals[i].Legend = $"fi = {legends[i]}";
                _signals[i].N = n;
            }

        }   

        private void ConstAnadFi(int n)
        {
            var fValues = new[] { 1, 3, 2, 4, 10 };
            for (var i = 0; i < graphCount; i++)
            {
                _signals[i].A = 1;
                _signals[i].f = fValues[i];
                _signals[i].fi = Math.PI;
                _signals[i].Legend = $"f = {fValues[i]}";
                _signals[i].N = n;
            }
        }   

        private void ConstFandFi(int n)
        {
            var aValues = new [] { 3, 5, 10, 4, 8 };
            for (var i = 0; i < graphCount; i++)
            {
                _signals[i].A = aValues[i];
                _signals[i].f = 4;
                _signals[i].fi = Math.PI;
                _signals[i].Legend = $"A = {aValues[i]}";
                _signals[i].N = n;
            }
        }   

        private void ResetValues()
        {
            _chart.ResetAutoValues();
            _chart.Legends.Clear();
            if (_chart.Series.Count > 1)
                for (var i = 0; i < graphCount; i++)
                    _chart.Series[i].Points.Clear();
            _chart.Series.Clear();
            _seriesList.Clear();
            _polyharmonicalSignal.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetValues();
            var n = Convert.ToInt32(constValues.SelectedItem);
            DrawHarmonicalSignals(n);
        }

        private void Polynomical_btn_Click(object sender, EventArgs e)
        {
            ResetValues();
            var n = Convert.ToInt32(constValues.SelectedItem);
            DrawPolyharmonicalSignal(n);
        }

        private void numberInput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PolynomicalWithLinear_Click(object sender, EventArgs e)
        {
            ResetValues();
            var n = Convert.ToInt32(constValues.SelectedItem);
            DrawPolyharmonicalWithLinearDiff(n);
        }
    }
}
