using ComputerModelling.InverseFunctionMethod;
using ComputerModelling.Kolmogorov;
using ComputerModelling.Pearson;
using ComputerModelling.PokerTest;
using ComputerModelling.QuadraticCongruentMethod;

namespace ConsoleOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator random = new RandomNumberGenerator(6, 7, 3, 4001);
            double[] values;
            double[] dataPlot;
            double[] dataFunc;
            random.GeneratorData(out values);
            InverseFunctionMethodGenerator inverseFunction = new InverseFunctionMethodGenerator(values);
            double[] xValues;
            inverseFunction.GenerateByInvereFunctionMethod(out xValues);
            
            //random.MakeData(values, out dataPlot, out dataFunc, 0.0, 1.0);
            
            
            Console.Read();
        }
    }
}