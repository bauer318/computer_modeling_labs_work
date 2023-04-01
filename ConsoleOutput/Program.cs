using ComputerModelling.OneDimensionalLattice;
using ComputerModelling.QuadraticCongruentMethod;
using System;

namespace ConsoleOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator random = new RandomNumberGenerator(6, 7, 3, 4001);
            OneDimensionalLatticeWorker one;// = new OneDimensionalLatticeWorker(random, 0, 10, 3, 0.6);
            double[] a = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };
            double[] plot;
            double[] funn;
            double[] v = { 1, 1, 2, 3, 4, 5, 6, 7, 6, 5, 4, 3, 3, 2, 1 };
            for (int i = 1; i < 30; i++)
            {
                for(int j=0; j<a.Length; j++)
                {
                    one = new OneDimensionalLatticeWorker(random, 0,30, i, a[j]);
                    double[] values = one.GetValues(7000);
                    random.MakeData(values, out plot, out funn, values.Min(), values.Max());
                    /*if (Check(v))
                    {
                        Console.WriteLine(i);
                        Console.WriteLine(a[j]);
                    }
                    else
                    {
                        Console.WriteLine("No");
                    }*/
                }
            }
            Console.Write("End");
            
            /*Console.WriteLine(Check(v));*/
            Console.ReadLine();
        }

        private static bool Check(double[] parIn)
        {
            bool result = parIn[0] <= parIn[1] && parIn[1] <= parIn[2] && parIn[2] <= parIn[3] && parIn[3] <= parIn[4] && parIn[4] <= parIn[5]
                && parIn[14] <= parIn[13] && parIn[13] <= parIn[12] && parIn[12] <= parIn[11] && parIn[11] <= parIn[10]  && parIn[10] <= parIn[9];

            return result;
        }
    }
}