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

        private static InverseFunctionMethodGenerator _instance;

        private InverseFunctionMethodGenerator() { }
        private InverseFunctionMethodGenerator(double[] parR)
        {
            _r = parR;
        }

        public static InverseFunctionMethodGenerator GetInstance(double[] parR)
        {
            if (_instance == null)
            {
                _instance = new InverseFunctionMethodGenerator(parR);
            }
            return _instance;
        }

        public void GenerateByInverseFunctionMethod(out double[] parXValuesArray)
        {
            int n = _r.Length;
            parXValuesArray = new double[n];
            for(int i=0; i < n; i++)
            {
                parXValuesArray[i] = 1.5 * _r[i];
            }
        }
    }
}
