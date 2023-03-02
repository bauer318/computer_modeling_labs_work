using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.Pearson
{
    public class PearsonCriteriaWorker
    {
        public static double[] GetProbalities(int parK)
        {
            double[] pArray = new double[parK];
            double probability = 1.0 / parK;
            for (int i = 0; i < parK; i++)
            {
                pArray[i] = probability;
            }
            return pArray;
        }

        public static double Xi2(double[] parHst, double[] parPt, int parK, long parN)
        {
            double xi = 0.0;
            for (int i = 0; i < parK; i++)
            {
                double nPi = parN * parPt[i];
                xi += Math.Pow(parHst[i] - nPi, 2) / nPi;
                Console.WriteLine(xi);
            }
            return xi;
        }
        public static double[] GetDataPlot(double[] parDataPlot, long parN, int parK)
        {
            double[] dataPlot = new double[parDataPlot.Length];
            for (int i = 0; i < parK; i++)
            {
                dataPlot[i] = parDataPlot[i] * parN;
            }
            return dataPlot;
        }
    }
}
