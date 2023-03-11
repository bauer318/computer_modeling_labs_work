using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.InverseFunctionMethod
{
    public class InverseFunctionMethodGenerator
    {
        /// <summary>
        /// Массив случайных величин равномерно распределение на [0;1)
        /// </summary>
        private readonly double[] _r;

        private static InverseFunctionMethodGenerator _instance;

        private InverseFunctionMethodGenerator() { }
        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="parR">Массив случайных величин равномерно распределение на [0;1)</param>
        private InverseFunctionMethodGenerator(double[] parR)
        {
            _r = parR;
        }

        public static InverseFunctionMethodGenerator GetInstance(double[] parR)
        {
            if (_instance == null)
            {
                _instance = new InverseFunctionMethodGenerator(parR);
            }
            return _instance;
        }
        /// <summary>
        /// Генератор случайных величин
        /// </summary>
        /// <param name="parXValuesArray">Массив случайных величин</param>
        public void GenerateByInverseFunctionMethod(out double[] parXValuesArray)
        {
            int n = _r.Length;
            parXValuesArray = new double[n];
            for(int i=0; i < n; i++)
            {
                double r = _r[i];
                if (r < 0.25)
                {
                    parXValuesArray[i] = GetFx1(r);
                }
                else if (r < 0.8)
                {
                    parXValuesArray[i] = GetFx2(r);
                }
                else
                {
                    parXValuesArray[i] = GetFx3(r);
                }
            }
        }
        /// <summary>
        /// Вычисляет значение x при r на иетревале [0;0.25)
        /// </summary>
        /// <param name="parR">значение случайной величины равномеро распределение на [0;1)</param>
        /// <returns></returns>
        private double GetFx1(double parR)
        {
            return Math.Sqrt(parR);
        }
        /// <summary>
        /// Вычисляет значение x при r на иетревале [0.25;0.8)
        /// </summary>
        /// <param name="parR">значение случайной величины равномеро распределение на [0;1)</param>
        /// <returns></returns>
        private double GetFx2(double parR)
        {
            return (parR + 0.3) / 1.1;
        }
        /// <summary>
        /// Вычисляет значение x при r на иетревале [0.8;1)
        /// </summary>
        /// <param name="parR">значение случайной величины равномеро распределение на [0;1)</param>
        /// <returns></returns>
        private double GetFx3(double parR)
        {
            return (parR / 0.4) - 1;
        }
    }
}
