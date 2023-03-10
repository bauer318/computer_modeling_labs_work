using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.InverseFunctionMethod
{
    public class InverseFunctionMethodGenerator
    {
        private readonly double[] _r;
        private double[] _x;

        public double[] X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        private InverseFunctionMethodGenerator() { }
        public InverseFunctionMethodGenerator(double[] parR)
        {
            _r = parR;
        }

        public void GenerateByInvereFunctionMethod(out double[] parXValuesArray)
        {
            int n = _r.Length;
            parXValuesArray = new double[n];
            for(int i=0; i < n; i++)
            {
                parXValuesArray[i] = 1.5 * _r[i];
            }
        }

        public double GetFx(double parX)
        {
            if(parX<0 || parX >= 1.5)
            {
                throw new ArgumentOutOfRangeException("x out of range [0;,0.5)");
            }
            if (parX < 0.5)
            {
                return Math.Pow(parX, 2);
            }
            else if (parX < 1)
            {
                return 1.1 * parX - 0.3;
            }
            else 
            {
                return 0.4 * parX + 0.4;
            }
        }

    }
}
