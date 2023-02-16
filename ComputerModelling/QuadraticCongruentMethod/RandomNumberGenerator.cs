﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.QuadraticCongruentMethod
{
    public class RandomNumberGenerator
    {
        //Объем выборки
        private const int N = 7000;
        private const int I = 12;
        //Число участков разбиения
        private const int K = 16;
        private int _a;
        private int _b;
        private int _c;
        //Модуль
        private int _m;
        //Случайно число
        private double _y;
        public RandomNumberGenerator(int parA, int parB, int parC, int parM, int parY)
        {
            _a = parA;
            _b = parB;
            _c = parC;
            _m = parM;
            _y = parY;
        }
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        /// <returns>случайно число</returns>
        private double Rnd()
        {
            _y = (_a * _y * _y + _b * _y + _c) % _m;
            return (double)_y / _m;
        }
        /// <summary>
        /// Формировать набор данных
        /// </summary>
        /// <param name="outValues">Массив случайных чисел</param>
        public void GeneratorData(out double[] outValues)
        {
            outValues = new double[N];
            for(int i=0; i<N; i++)
            {
                outValues[i] = Rnd();
            }
        }
        /// <summary>
        /// Получить массивы плотности и фукции распределения
        /// </summary>
        /// <param name="parValues">Массив случайных чисел</param>
        /// <param name="outDataPlot">Массив частот</param>
        /// <param name="outDataFunc">Массив функции распределения</param>
        /// <param name="parMin">Левая граница интервала</param>
        /// <param name="parMax">Правая граница интервала</param>
        public void MakeData(
            double[] parValues,
            out double[] outDataPlot, 
            out double[] outDataFunc, 
            double parMin, 
            double parMax)
        {
            double delta = (parMax - parMin) / K;
            outDataPlot = new double[K];
            outDataFunc = new double[K];
            for(int i=0; i<N; i++)
            {
                int j = (int)((parValues[i] - parMin) / delta);
                if (j >= K)
                {
                    j = K - 1;
                }
                else if(j<0)
                {
                    j = 0;
                }
                outDataPlot[j]++;
            }
            for(int i=0; i < K; i++)
            {
                outDataPlot[i] /= N;
            }
            outDataFunc[0] = outDataPlot[0];
            for(int i=1; i < K; i++)
            {
                outDataFunc[i] = outDataFunc[i - 1] + outDataPlot[i];
            }
        }
        /// <summary>
        /// Получить статистические оценки
        /// </summary>
        /// <param name="parValues">Случайнные числа</param>
        /// <param name="parMx">Математическое ожидание</param>
        /// <param name="parDx">Исправленная выборочная дисперсия</param>
        private void Estimate(double[] parValues,out double parMx, out double parDx)
        {
            double m2 = 0;
            parMx = 0;
            for(int i=0; i<N; i++)
            {
                parMx += parValues[i];
                m2 += parValues[i] * parValues[i];
            }
            parMx /= N;
            m2 /= N;
            parDx = (m2 - parMx * parMx) * N / (N - 1);
        }
    }
}
