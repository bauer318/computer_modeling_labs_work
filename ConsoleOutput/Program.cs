using ComputerModelling.InverseFunctionMethod;
using ComputerModelling.Kolmogorov;
using ComputerModelling.QuadraticCongruentMethod;

namespace ConsoleOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator(6, 7, 3, 4001);
            double p1 = 0.8; 
            double p2 = 0.5;
            double pA = 1 - Math.Pow(1 - (1 - p1) * p2, 2);
            double pB = p1 * p1;
            double pC = 1 - (1 - (p1 * p1));
            double pD = 1 - Math.Pow(1 - p1, 2) * Math.Pow(1 - p2, 2);
            double pE = 2 * p1 * (1 - p1);
            double pF = Math.Pow(1 - p1, 2) * (1 - Math.Pow(1 - p2, 2)) + 2 * p1 * (1 - p1) * (1 - p2);
            Random random = new Random();
            int n = 100;
            int nA = 0, nB = 0, nC = 0, nD = 0, nE = 0, nF = 0;
            double r;
            for(int i=0; i < n; i++)
            {
                r = random.NextDouble();
                if (r < pA)
                {
                    nA++;
                }
                else if(r<(pA+pB))
                {
                    nB++;
                }
                else if (r < (pA+pB+pC))
                {
                    nC++;
                }
                else if (r < (pA + pB + pC+pD))
                {
                    nD++;
                }
                else if (r < (pA + pB + pC + pD+pE))
                {
                    nE++;
                }
                else if (r < (pA + pB + pC + pD + pE + pF))
                {
                    nF++;
                }
                
                
            }
            Console.WriteLine("Search probabilty");
            Console.WriteLine("pA = {0:f4}", (double)nA / n);
            Console.WriteLine("pB = {0:f4}", (double)nB / n);
            Console.WriteLine("pC = {0:f4}", (double)nC/ n);
            Console.WriteLine("pD = {0:f4}", (double)nD / n);
            Console.WriteLine("pE = {0:f4}", (double)nE / n);
            Console.WriteLine("pF = {0:f4}", (double)nF / n);
            
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}