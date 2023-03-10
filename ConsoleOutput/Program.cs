using ComputerModelling.InverseFunctionMethod;
using ComputerModelling.Kolmogorov;
using ComputerModelling.QuadraticCongruentMethod;

namespace ConsoleOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator random = new RandomNumberGenerator(6, 7, 3, 4001);
            double[] values;
            random.GeneratorData(out values);
           
            
            //random.MakeData(values, out dataPlot, out dataFunc, 0.0, 1.0);
            
            
            Console.Read();
        }
    }
}