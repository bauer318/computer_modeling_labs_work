using ComputerModelling.QuadraticCongruentMethod;
using System;

namespace ComputerModelling.OneDimensionalLattice
{
    public class OneDimensionalLatticeWorker
    {
        private RandomNumberGenerator _random;
        private Random random = new Random();
        private int _x1;
        private int _x2;
        private int _x0;
        private double _p;
        public OneDimensionalLatticeWorker(RandomNumberGenerator parRandom, int parX1, int parX2, int parX0, double parP)
        {
            _random = parRandom;
            _x1 = parX1;
            _x2 = parX2;
            _x0 = parX0;
            _p = parP;

        }

        private double GetTime()
        {
            double x = _x0;
            double T = 0;
            int time = 0;
            while((x!=_x1) && (x != _x2))
            {
                double r = random.NextDouble();
                if (r < _p)
                {
                    x++;
                }
                else
                {
                    x--;
                }
                time++;
            }
            T += time;
            return T / 1.0;
        }

        public double[] GetValues(int parN)
        {
            double[] values = new double[parN];
            for (int i = 0; i < parN; i++)
            {
                values[i] = GetTime();
            }
            return values;
        }

        private int GetNearestSide()
        {
            int rightSide = _x2 - _x0;
            int leftSide = _x0 - _x1;
            return Math.Min(leftSide, rightSide);
        }
    }
}
