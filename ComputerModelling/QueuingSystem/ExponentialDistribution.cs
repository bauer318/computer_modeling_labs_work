using ComputerModelling.QuadraticCongruentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.QueuingSystem
{
    public class ExponentialDistribution
    {
        private double _lambda;
        private RandomNumberGenerator _randomNumberGenerator;
        
        public ExponentialDistribution(double parLamdba, RandomNumberGenerator parRandomNumberGenerator)
        {
            _lambda = parLamdba;
            _randomNumberGenerator = parRandomNumberGenerator;
        }

        public double NextDouble()
        {
            double r = _randomNumberGenerator.NextDouble();
            return -Math.Log(r) / _lambda;
        }
    }
}
