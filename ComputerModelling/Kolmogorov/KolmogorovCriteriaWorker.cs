using ComputerModelling.GammaDistribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.Kolmogorov
{
    public class KolmogorovCriteriaWorker
    {
        /// <summary>
        /// Функция вычисления Lambda для критерия Колмогорова
        /// </summary>
        /// <param name="parValues">Отсортирванная в порядке возврастания выборка</param>
        /// <param name="parN">Объем выборки</param>
        /// <returns>Вычисленное значение Lambda</returns>
        public static double Lambda(double[] parValues,int parN, double parLambda, double parBeta)
        {
            double[] sortedArray = (double[])parValues.Clone();
            
            Array.Sort(sortedArray);
            double[] dp = new double[parN];
            double[] dm = new double[parN];
            for(int i=0; i < parN; i++)
            {
                double ft;
                GammeDistributionGenerator.CalculateFt(out ft, sortedArray[i], parLambda, parBeta);
                dp[i] = i / parN - ft;
                dm[i] = ft - (i - 1) / parN;
            }
            return Math.Max(dp.Max(), dm.Max());
        }
    }
}
