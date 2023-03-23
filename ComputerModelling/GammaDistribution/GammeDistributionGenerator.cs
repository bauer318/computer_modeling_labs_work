using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.GammaDistribution
{
    public class GammeDistributionGenerator
    {
        public static void GenerateByGammaDistribution(out double[] outXValues, int parN, double parLambda, double parBeta)
        {
            Random random = new Random();
            outXValues = new double[parN];
            double p;
            double r;
            for(int i=0; i<parN; i++)
            {
                p = 1;
                for(int k=0; k<parLambda; k++)
                {
                    r = random.NextDouble();
                    p *= r;
                }
                outXValues[i] = -Math.Log(p) * parBeta;
            }

        }
        public static void CalculateDxMx(out double outDx, out double outMx, double parLambda, double parBeta)
        {
            outDx = parLambda * parBeta * parBeta;
            outMx = parLambda * parBeta;
        }

        public static void CalculateFt(out double outFt, double parXi, double parLambda, double parBeta)
        {
            if (parXi > 0)
            {
                int gammaZ;
                CalculateGammaZ(out gammaZ, parLambda);
                outFt = (Math.Pow(parXi, (parLambda - 1)) * Math.Pow(Math.E, (-parXi / parBeta))) / (Math.Pow(parBeta, parLambda) * gammaZ);

            }
            else
            {
                outFt = 1;
            }
            
        }

        public static void CalculateGammaZ(out int outGammaZ, double parZ)
        {
            outGammaZ = GetFactorial((int)parZ - 1);
        }
        private static int GetFactorial(int parA)
        {
            int fact = 1;
            if(parA==0 || parA == 1)
            {
                return 1;
            }
            for (int x = 1; x <= parA; x++)
            {
                fact *= x;
            }
            return fact;

        }
    }
}
