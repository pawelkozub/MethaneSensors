using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQ4_PC
{
    public static class Config
    {
        //Sample
        public static int Sample_count;
        public static int Sample_time;
        public static int Sample_delay;
        
        //MQ4
        public static double Rl = 10000.0;
        public static double Vc = 1023.0;
        public static double Ro_calibration = 0.0;
        public static double RsRo_air = 4.429893;
        public static double[] ppm_Methane = { 200.705095, 1002.564557, 4982.434542, 10000 };
        public static double[] RsRo_Methane = { 1.756693, 0.990277, 0.569251, 0.438682 };
        public static double[] L_Methane = { 2.806123, 2.89591, 2.67386 };
    }
}
