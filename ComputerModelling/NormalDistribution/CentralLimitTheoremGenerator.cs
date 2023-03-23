using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.NormalDistribution
{
    public class CentralLimitTheoremGenerator
    {
        public static void GenerateByCentralLimitTheorem(out double[] outXValues, int parN, double parM, double parSquareD)
        {
            outXValues = new double[parN];
            double s;
            double r;
            Random random = new Random();
            for(int i=0; i<parN; i++)
            {
                s = 0;
                for(int j=0; j<12; j++)
                {
                    r = random.NextDouble();
                    s += r;
                }
                double x = s - 6;
                outXValues[i] = parM + x * Math.Sqrt(parSquareD);
            }
        }
    }
}
