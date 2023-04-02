using ComputerModelling.QuadraticCongruentMethod;
using System;

namespace ComputerModelling.QueuingSystem
{
    public class QueuingSystemModeling
    {
        private ExponentialDistribution _arrivalTimeGeneraor;
        private ExponentialDistribution _serviceTimeGeneration;
        private RandomNumberGenerator _random;
        private double _lambda;
        private double _mu;


        public QueuingSystemModeling(double parLamdba, double parMu, RandomNumberGenerator parRandom)
        {
            _lambda = parLamdba;
            _mu = parMu;
            _arrivalTimeGeneraor = new ExponentialDistribution(_lambda, parRandom);
            _serviceTimeGeneration = new ExponentialDistribution(_mu, parRandom);
        }
        private double[] InitArray(int parN)
        {
            double[] result = new double[parN];
            for (int i = 0; i < parN; i++)
            {
                result[i] = 0.0;
            }
            return result;
        }
        public void Execute(int parZMax, double parModelTime)
        {
            double[] z_arrive = InitArray(parZMax);
            double[] z_serve = InitArray(parZMax);
            double timeServe = 0;
            double timeEnd = 0;
            //Обнуляем модельное время
            double time = 0;
            //Обнуляем счетчик поступивших заявок
            int Nin = 0;

            //Формируем входяшие заяки
            for (int i = 0; i < parZMax; i++)
            {
                //формируем время поступления очередной заявки
                time += _arrivalTimeGeneraor.NextDouble();
                //Если время моделирования не закончено
                if (time < parModelTime)
                {
                    //То увеличить количество поступивших заявок
                    Nin++;
                    //Запомнить время приходя заявки
                    z_arrive[i] = time;
                    //сформировать продолжительность обслуживания заявки
                    z_serve[i] = _serviceTimeGeneration.NextDouble();
                }
                else //выход при окончании времени моделирования
                {
                    break;
                }

            }
            //кол-во каналов
            int serveCount = 3;
            int ind;
            //сначала все обслуживающие приборы свободны
            double[] endTime = InitArray(serveCount);
            //Обнуляем счетик обслуженных заявок
            int Nserve = 0;
            //время ожидания заявок в очереди
            double timeWait = 0;
            //
            double timeSys = 0;
            //
            double timeWork = 0;
            double[] z_begin = InitArray(Nin);
            double[] z_end = InitArray(Nin);
            //перебираем все поступившие заявки
            for (int i = 0; i < Nin; i++)
            {
                //определяем номер канала ind, который освободится раньше
                ind = 0;
                for (int j = 1; j < serveCount; j++)
                {
                    if (endTime[j] < endTime[ind])
                    {
                        ind = j;
                    }
                }
                //определяем время начала обслуживания
                //если все приборы обслуживания заняты
                if (z_arrive[i] < endTime[ind])
                {
                    timeServe = endTime[ind];
                }
                else
                {
                    timeServe = z_arrive[i];
                }
                //если время не закончилось
                if (timeServe < parModelTime)
                {
                    //то запоминаем время начала обслуживания заявки
                    z_begin[i] = timeServe;
                    //запоминаем время окночания обслуживания
                    z_end[i] = timeServe + z_serve[i];
                    //накладиваем время работы системы
                    timeWork += z_serve[i];
                    endTime[ind] = z_end[i];
                    //увеличиваем кол-во обслуженных заявок
                    Nserve++;
                    //накладиваем время ожидания в очереди
                    timeWait += (z_begin[i] - z_arrive[i]);
                    //накладиваем время пребывания в системе
                    timeSys += (z_end[i] - z_arrive[i]);
                    if (timeEnd < endTime[ind])
                    {
                        timeEnd = endTime[ind];
                    }
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Число поступивших заявок " + Nin);
            Console.WriteLine("Число обслуженных заявок " + Nserve);
            Console.WriteLine("Среднее время ожидания в очереди {0:f4} ", (double)timeWait / Nserve);
            Console.WriteLine("Среднее время пребывания в системе {0:f4} ", (double)timeSys / Nserve);
            Console.WriteLine("Коэффициент использования СМО {0:f4} ", (double)timeWork / timeEnd);
        }

    }
}
