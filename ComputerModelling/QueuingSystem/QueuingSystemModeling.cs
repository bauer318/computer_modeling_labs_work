using ComputerModelling.QuadraticCongruentMethod;
using System;

namespace ComputerModelling.QueuingSystem
{
    public class QueuingSystemModeling
    {
        private PoissonDistribution _poisson;
        private ExponentialDistribution _serviceTimeGeneration;
        private RandomNumberGenerator _random;
        private double _lambda;
        private double _mu;
        private int _zMax;
        private double _modelTime;

        public QueuingSystemModeling(double parLamdba, double parMu, RandomNumberGenerator parRandom, int zMax, double modelTime)
        {
            _lambda = parLamdba;
            _mu = parMu;
            _serviceTimeGeneration = new ExponentialDistribution(_mu, parRandom);
            _zMax = zMax;
            _modelTime = modelTime;
            _poisson = new PoissonDistribution(_lambda, _zMax, parRandom);
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
        public void Execute()
        {
            double[] z_arrive = InitArray(_zMax);
            double[] z_serve = InitArray(_zMax);
            double timeServe = 0;
            double timeEnd = 0;
            double[] arrivalTime = _poisson.GetValues();
            //_poisson.SortValues(out arrivalTime, _poisson.GetValues());
            //Обнуляем модельное время
            double time = 0;
            //Обнуляем счетчик поступивших заявок
            int Nin = 0;

            //Формируем входяшие заяки
            for (int i = 0; i < _zMax; i++)
            {
                //формируем время поступления очередной заявки
                time += arrivalTime[i];
                //Если время моделирования не закончено
                if (time < _modelTime)
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
            //время работы системы
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
                if (timeServe < _modelTime)
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
            double tOch = (double)timeWait / Nserve;
            double coeffQS = (double)timeWork / timeEnd;
            double lost = tOch * 30 + coeffQS * 15;
            Console.WriteLine("Число поступивших заявок " + Nin);
            Console.WriteLine("Число обслуженных заявок " + Nserve);
            Console.WriteLine("Среднее время ожидания в очереди {0:f4} ", tOch);
            Console.WriteLine("Среднее время пребывания в системе {0:f4} ", (double)timeSys / Nserve);
            Console.WriteLine("Коэффициент использования СМО {0:f4} ",coeffQS);
            Console.WriteLine("Средние потери цеха {0:f4} д.е.", lost);
        }

    }
}
