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
        private static double Ft(double parXi)
        {
            if (parXi < 0.0)
            {
                return 0.0;
            }
            else if (parXi < 1.0)
            {
                return parXi;
            }
            return 1.0;
        }
        /// <summary>
        /// Функция вычисления Lambda для критерия Колмогорова
        /// </summary>
        /// <param name="parValues">Отсортирванная в порядке возврастания выборка</param>
        /// <param name="parN">Объем выборки</param>
        /// <returns>Вычисленное значение Lambda</returns>
        public static double Lambda(double[] parValues,int parN)
        {
            double[] sortedArray = (double[])parValues.Clone();
            Array.Sort(sortedArray);
            double dMax = 0.0;
            for(int i=0; i < parN; i++)
            {
                double dp = Math.Abs((double)(i + 1) / parN - Ft(sortedArray[i]));
                double dm = Math.Abs(Ft(sortedArray[i]) - (double)i / parN);
                if (dp > dMax) dMax = dp;
                if (dm > dMax) dMax = dm;
            }
            return dMax*Math.Sqrt(parN);
        }
    }
}
