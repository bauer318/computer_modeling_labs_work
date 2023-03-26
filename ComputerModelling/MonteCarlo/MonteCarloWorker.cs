using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.MonteCarlo
{
    public class MonteCarloWorker
    {
        private static double GetPA(double parP1, double parP2)
        {
            return 1 - Math.Pow(1 - (1 - parP1) * parP2, 2);
        }
        private static double GetPB(double parP1)
        {
            return parP1 * parP1;
        }
        private static double GetPC(double parP1)
        {
            return 1 - (1 - (parP1 * parP1));
        }
        private static double GetPD(double parP1, double parP2)
        {
            return 1 - Math.Pow(1 - parP1, 2) * Math.Pow(1 - parP2, 2);
        }

        private static double GetPE(double parP1, double parP2)
        {
          return 2 * parP1 * (1 - parP2);
        }

        private static double GetPF(double parP1, double parP2)
        {
            return Math.Pow(1 - parP1, 2) * (1 - Math.Pow(1 - parP2, 2)) + 2 * parP1 * (1 - parP1) * (1 - parP2); ;
        }

        public static double[] GetProbabilitiesArray(double parN, double parP1, double parP2)
        {
            double[] result = new double[6];
            double pA = GetPA(parP1, parP2);
            double pB = GetPB(parP1);
            double pC = GetPC(parP1);
            double pD = GetPD(parP1, parP2);
            double pE = GetPE(parP1, parP2);
            double pF = GetPF(parP1, parP2);
            double r;
            double nA = 0;
            double nB = 0;
            double nC = 0;
            double nD = 0;
            double nE = 0;
            double nF = 0;

            return result;
        }
    }
}
