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
        /// Теорическая функция распределения
        /// </summary>
        /// <param name="parXi">Случайное величиние</param>
        /// <returns>Значение теорической функции распределения</returns>
        private static double Ft(double parXi,double parM, double parSquareD)
        {
            double d = Math.Sqrt(parSquareD);
            return (1 / (d * Math.Sqrt(2 * Math.PI))) * Math.Pow(Math.E, -(Math.Pow(parXi - parM, 2) / (2 * parSquareD)));
        }
        /// <summary>
        /// Функция вычисления Lambda для критерия Колмогорова
        /// </summary>
        /// <param name="parValues">Отсортирванная в порядке возврастания выборка</param>
        /// <param name="parN">Объем выборки</param>
        /// <returns>Вычисленное значение Lambda</returns>
        public static double Lambda(double[] parValues,int parN, double parM, double parSquareD)
        {
            double[] sortedArray = (double[])parValues.Clone();
            
            Array.Sort(sortedArray);
            double[] dp = new double[parN];
            double[] dm = new double[parN];
            for(int i=0; i < parN; i++)
            {
                dp[i] = i / parN - Ft(sortedArray[i], parM, parSquareD);
                dm[i] = Ft(sortedArray[i], parM, parSquareD) - (i - 1) / parN;
            }
            return Math.Max(dp.Max(), dm.Max());
        }
    }
}
