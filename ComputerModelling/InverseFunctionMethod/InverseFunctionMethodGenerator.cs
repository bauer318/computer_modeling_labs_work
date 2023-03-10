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
    }
}
