using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Geared;

namespace MQ4_PC
{
    class Chartslive
    {
        const int keepRecords = 500;
        private double _trend;

        public Chartslive()
        {
            Values1 = new GearedValues<double>().WithQuality(Quality.High);
        }

        public GearedValues<double> Values1 { get; set; }
        public double Count { get; set; }
        public double CurrentLecture { get; set; }
        public bool IsHot { get; set; }

        public void Clear()
        {
            Values1.Clear();
        }

        public void Read(double data)
        {
            Action readFromTread = () =>
            { 
                _trend = data;                    
                var first = Values1.DefaultIfEmpty(0).FirstOrDefault();
                if (Values1.Count > keepRecords - 1) Values1.Remove(first);
                if (Values1.Count < keepRecords) Values1.Add(_trend);
                IsHot = _trend > 0;
                Count = Values1.Count;
                CurrentLecture = _trend;
            };

            Task.Factory.StartNew(readFromTread);
            Task.Factory.StartNew(readFromTread);
            Task.Factory.StartNew(readFromTread);
        }
    }
}
