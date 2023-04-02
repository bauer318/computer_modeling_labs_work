using ComputerModelling.QuadraticCongruentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.QueuingSystem
{
    public class PoissonDistribution
    {
        private double _lambda;
        private int _n;
        private RandomNumberGenerator _random;

        public PoissonDistribution(double parLambda, int parN, RandomNumberGenerator parRandom)
        {
            _lambda = parLambda;
            _n = parN;
            _random = parRandom;
        }

        public double[] GetValues()
        {
            double[] result = new double[_n];
            double r;
            double pr; 
            int x;
            var l = Math.Exp(-_lambda);
            for(int i=0; i<_n; i++)
            {
                r = _random.NextDouble();
                pr = r;
                int k;

                for(k=0; pr > l; k++)
                {
                    r = _random.NextDouble();
                    pr *= r;
                }
                x = k;
                result[i] = x;
            }
            return result;
        }

        public void SortValues(out double[] outSortedArray, double[] parValues)
        {
            
            outSortedArray = (double[])parValues.Clone();
            Array.Sort(outSortedArray);
        }
    }
}
