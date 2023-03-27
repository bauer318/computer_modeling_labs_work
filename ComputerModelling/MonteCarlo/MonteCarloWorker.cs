using ComputerModelling.QuadraticCongruentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private static double GetPE(double parP1, double parP2)
        {
          return 2 * parP1 * (1 - parP2);
        }

        private static double GetPF(double parP1, double parP2)
        {
            return Math.Pow(1 - parP1, 2) * (1 - Math.Pow(1 - parP2, 2)) + 2 * parP1 * (1 - parP1) * (1 - parP2);
        }

        public static double[] GetProbabilitiesArray(double parN, double parP1, double parP2)
        {
            RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator(6, 7, 3, 4001);
            double[] result = new double[6];
            double pA = GetPA(parP1, parP2);
            double pB = GetPB(parP1);
            double pC = GetPC(parP1);
            double pD = GetPD(parP1, parP2);
            double pE = GetPE(parP1, parP2);
            double pF = GetPF(parP1, parP2);
            double r;
            double nA = 0;
            double nB = 0;
            double nC = 0;
            double nD = 0;
            double nE = 0;
            double nF = 0;
            for (int i = 0; i < parN; i++)
            {
                r = randomNumberGenerator.NextDouble();
                //Сбит бомбардировщик
                if (r < pA)
                {
                    nA++;
                }
                else
                {
                    r = randomNumberGenerator.NextDouble();
                    //Сбиты оба истребителя
                    if (r < pB)
                    {
                        nB++;
                    }
                    else
                    {
                        r = randomNumberGenerator.NextDouble();
                        //Сбит хотя бы один истребитель
                        if (r < pC)
                        {
                            nC++;
                        }
                        else
                        {
                            r = randomNumberGenerator.NextDouble();
                            //Сбит хотя бы один самолет
                            if (r < pD)
                            {
                                nD++;
                            }
                            else
                            {
                                r = randomNumberGenerator.NextDouble();
                                //Сбит ровно один истребитель
                                if (r < pE)
                                {
                                    nE++;
                                }
                                else
                                {
                                    r = randomNumberGenerator.NextDouble();
                                    //сбит ровно один самолет
                                    if (r < pF)
                                    {
                                        nF++;
                                    }
                                }
                            }
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
            result[4] = GetPE(parP1, parP2);
            result[5] = GetPF(parP1, parP2);
            return result;
        }

         
    }
}
