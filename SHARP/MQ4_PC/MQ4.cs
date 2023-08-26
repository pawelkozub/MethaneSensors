using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQ4_PC
{
    public class MQ4
    {
        Export _export = new Export();
        double LL = 0;
        double ppm = 0;
        double RsRo = 0;

        public double ResistanceCalculation(int Vrl)
        {
            return (Vrl == 0) ? -1 : ((Config.Vc - Vrl) / Vrl) * Config.Rl;
        }

        public double PPM(int bit)
        {
            double Rs_methane = ResistanceCalculation(bit);
            if (Rs_methane == -1) return -1;
            double RsRo_methane = Rs_methane / Config.Ro_calibration;

            if (Config.RsRo_Methane[0] >= RsRo_methane && RsRo_methane >= Config.RsRo_Methane[3])
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Config.RsRo_Methane[i] <= RsRo_methane)
                    {
                        LL = Config.L_Methane[i - 1];
                        ppm = Config.ppm_Methane[i];
                        RsRo = Config.RsRo_Methane[i];
                        break;
                    }
                }
                return ppm / Math.Pow((RsRo_methane / RsRo), LL);
            }
            else if (Config.RsRo_Methane[0] < RsRo_methane)
            {
                return 199;
            }
            else if (Config.RsRo_Methane[3] > RsRo_methane)
            {
                return 10001;
            }

            return 0;
        }

        public void Set_Calibration(int bit)
        {
            double Rs_air = ResistanceCalculation(bit);
            double Ro_air = Rs_air / Config.RsRo_air;
            Config.Ro_calibration = Ro_air;

            _export.Save_Calibration(Ro_air);
        }      

        public bool Read_Calibration()
        {
           return _export.Read_Calibration();
        }
    }
}
