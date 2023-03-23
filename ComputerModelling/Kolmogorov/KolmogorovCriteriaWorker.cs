using ComputerModelling.GammaDistribution;
using ComputerModelling.WeibullDistribution;
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
        ///  Функция вычисления Lambda для критерия Колмогорова (Гамма-распределения)
        /// </summary>
        /// <param name="parValues">Отсортирванная в порядке возврастания выборка</param>
        /// <param name="parN">Объем выборки</param>
        /// <param name="parLambda">Параматр ламбда</param>
        /// <param name="parBeta">Параметр бета</param>
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
        /// <summary>
        ///  Функция вычисления Lambda для критерия Колмогорова (Распределение Вейбулла)
        /// </summary>
        /// <param name="parValues">Отсортирванная в порядке возврастания выборка</param>
        /// <param name="parN">Объем выборки</param>
        /// <param name="parB">Параметр B</param>
        /// <param name="parC">Параметр C</param>
        /// <returns>Вычисленное значение Lambda</returns>
        public static double LambdaWeibull(double[] parValues, int parN, int parB, int parC)
        {
            double[] sortedArray = (double[])parValues.Clone();

            Array.Sort(sortedArray);
            double[] dp = new double[parN];
            double[] dm = new double[parN];
            for (int i = 0; i < parN; i++)
            {
                double ft;
                WeibullDistributionGenerator.CalculateFt(out ft, sortedArray[i], parB, parC);
                dp[i] = i / parN - ft;
                dm[i] = ft - (i - 1) / parN;
            }
            return Math.Max(dp.Max(), dm.Max());
        }
    }
}
