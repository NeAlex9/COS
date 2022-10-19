using System;
using System.Collections.Generic;

namespace Lab1
{
    public class HarmonicalSignal
    {
        public int A { get; set; }

        public int f { get; set; }

        public double fi { get; set; }

        public int N { get; set; }

        public List<double> Points { get; set; } = new List<double>();

        public string Legend { get; set; }

        public HarmonicalSignal(int a, int f, double fi, string str, int n = 512)
        {
            A = a;
            this.f = f;
            this.fi = fi;
            N = n;
            Legend = str;
        }

        public void Calculate()
        {
            Points.Clear();
            for (int i = 0; i < N; i++)
            {
                var x = A * Math.Sin(2 * Math.PI * f * i / N + fi);
                Points.Add(x);
            }
        }
    }
}
