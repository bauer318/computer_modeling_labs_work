using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.NormalDistribution
{
    public class ApproximationMethodGenerator
    {
        public static void GenerateByApproximationMethod(out double[] outValues, int parN, double parM, double parD)
        {
            Random random = new Random();
            parD = Math.Sqrt(parD);
            double r;
            double x;
            double k = Math.Sqrt(8.0 / Math.PI);
            outValues = new double[parN];
            for(int i=0; i < parN; i++)
            {
                r = random.NextDouble();
                x = Math.Log((1 + r) / (1 - r)) / k;
                r = random.NextDouble();
                if (r < 0.5) x = -x;
                outValues[i] = x * parD + parM;
            }
        }
    }
}
