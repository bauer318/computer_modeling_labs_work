using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.Pearson
{
    public class PearsonCriteriaWorker
    {
        /// <summary>
        /// Вычислит вероятность попадания св в j-й интервал
        /// Для равновероятного распределения при одиноковых
        /// интервалах pk = 1/k.
        /// </summary>
        /// <param name="parK">число участков разбиения</param>
        /// <returns>массив значений веротностей pk</returns>
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
        /// <summary>
        /// функция вычисления xi2 для
        /// критерия Писона
        /// </summary>
        /// <param name="parHst">Число попаданий случайной величины в интервалы</param>
        /// <param name="parPt">Теоритическая веротяность попадания случайной величины в интервалы</param>
        /// <param name="parK">Число интервалов разбиения</param>
        /// <param name="parN">Объем выборки</param>
        /// <returns>Результат вычисления xi2</returns>
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
        /// <summary>
        /// Возвращает число попаданий случайной величины X в j-й интервал
        /// </summary>
        /// <param name="parDataPlot">Массив веротностей попадания св</param>
        /// <param name="parN">Объем выборки</param>
        /// <param name="parK">Число интервалов разбиения</param>
        /// <returns>Массив числа попаданий случайной величины X в j-й интервал</returns>
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
