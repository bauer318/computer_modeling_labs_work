using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.WeibullDistribution
{
    public class WeibullDistributionGenerator
    {
        public static void GenerateByWeibullDistribution(out double[] outXValues, double[] parValues, int parN, int parB, int parC)
        {
            Random random = new Random();
            outXValues = new double[parN];
            double r;
            for(int i=0; i<parN; i++)
            {
                r = random.NextDouble();
                outXValues[i] = (double)(parB * Math.Pow(-Math.Log(r), 1.0 / parC));
            }
        }
        public static void CalculateDxMx(out double outDx, out double outMx, int parB, int parC)
        {

            outMx = ((double)parB / parC) * CalculateGammaZ(1 / parC);
            outDx = (Math.Pow(parB, 2) / parC) * (2*CalculateGammaZ(2.0/parC)-(1.0/parC)*(Math.Pow(CalculateGammaZ(1.0/parC),2)));
        }

        public static void CalculateFt(out double outFt, double parXi, int parB, int parC)
        {  
            outFt = (parC*Math.Pow(parXi,(parC-1))/Math.Pow(parB,parC))*(Math.Pow(Math.E,(-Math.Pow(parXi/parB,parC))));
        }
        public static int CalculateGammaZ(double parZ)
        {
           return GetFactorial((int)parZ - 1);
        }
        private static int GetFactorial(int parA)
        {
            int fact = 1;
            if (parA == 0 || parA == 1)
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
