using ComputerModelling.QuadraticCongruentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.OneDimensionalLattice
{
    public class OneDimensionalLatticeWorker
    {
        private RandomNumberGenerator _random;
        private int _x1;
        private int _x2;
        private int _x0;
        private double _p;
        public OneDimensionalLatticeWorker(RandomNumberGenerator parRandom,int parX1, int parX2, int parX0, double parP) 
        {
            _random = parRandom;
            _x1 = parX1;
            _x2 = parX2;
            _x0 = parX0;
            _p = parP;

        }

        public int GetTime()
        {
            int t = 0;
            int n = 0;
            int nearestSide = GetNearestSide();
            double r;
            while (n < nearestSide)
            {
                r = _random.NextDouble();
                if (r < _p)
                {
                    n++;
                }
                t++;
            }
            return t;
            
        }

        private int GetNearestSide()
        {
            int rightSide = _x2 - _x0;
            int leftSide = _x0 - _x1;
            return Math.Min(leftSide, rightSide);
        }
    }
}
