using ComputerModelling.QuadraticCongruentMethod;
using System;

namespace ComputerModelling.MonteCarlo
{
    public class MonteCarloWorker
    {
        private static double GetPA(double parP1, double parP2)
        {
            return 1 - Math.Pow(1 - (1 - parP1) * parP2, 2);
        }
        private static double GetPB(double parP1)
        {
            return parP1 * parP1;
        }
        public static double GetPC(double parP1)
        {
            return 1 - (1 - (parP1 * parP1));
        }
        private static double GetPD(double parP1, double parP2)
        {
            return 1 - Math.Pow(1 - parP1, 2) * Math.Pow(1 - parP2, 2);
        }

        private static double GetPE(double parP1)
        {
            return 2 * parP1 * (1 - parP1);
        }

        private static double GetPF(double parP1, double parP2)
        {
            return Math.Pow(1 - parP1, 2) * (1 - Math.Pow(1 - parP2, 2)) + 2 * parP1 * (1 - parP1) * (1 - parP2);
        }

        public static double[] GetProbabilitiesArray(double parN, double parP1, double parP2)
        {
            RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator(6, 7, 3, 4001);
            double[] result = new double[6];
            double r;
            double nA = 0;
            double nB = 0;
            double nC = 0;
            double nD = 0;
            double nE = 0;
            double nF = 0;
            int n;
            for (int i = 0; i < parN; i++)
            {
                n = 2;
                r = randomNumberGenerator.NextDouble();
                if (r < parP1)
                {
                    //Сбит истребитель
                    n--;
                    
                }
                r = randomNumberGenerator.NextDouble();
                if (r < parP1)
                {
                    //Сбит истребитель
                    n--;
                   
                }
                //сбит оба истребителя
                if (n == 0)
                {
                    nB++;
                    nD++;
                    nC++;
                }
                //сбит ровно один истребитель
                else if (n == 1)
                {
                    nE++;
                    nD++;
                    r = randomNumberGenerator.NextDouble();
                    if (r < parP2)
                    {
                        //сбит бомбардировщик
                        nA++;
                    }
                    else
                    {
                        //сбит ровно один самолет
                        nF++;
                    }
                }
                else //n=2
                {
                    r = randomNumberGenerator.NextDouble();
                    if (r < parP2)
                    {
                        //сбит бомбардировщик
                        nA++;
                        nD++;
                        nF++;
                    }
                    else
                    {
                        r = randomNumberGenerator.NextDouble();
                        if (r < parP2)
                        {
                            //сбит бомбардировщик
                            nA++;
                            nD++;
                            nF++;
                        }
                    }

                }

            }
            result[0] = (double)nA / parN;
            result[1] = (double)nB / parN;
            result[2] = (double)nC / parN;
            result[3] = (double)nD / parN;
            result[4] = (double)nE / parN;
            result[5] = (double)nF / parN;

            return result;
        }

        public static double[] GetTheoriticalsProbabilitiesArray(double parP1, double parP2)
        {
            double[] result = new double[6];
            result[0] = GetPA(parP1, parP2);
            result[1] = GetPB(parP1);
            result[2] = GetPC(parP1);
            result[3] = GetPD(parP1, parP2);
            result[4] = GetPE(parP1);
            result[5] = GetPF(parP1, parP2);
            return result;
        }


    }
}
