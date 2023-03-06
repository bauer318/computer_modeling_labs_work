using ComputerModelling.Pearson;
using ComputerModelling.QuadraticCongruentMethod;

namespace ConsoleOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator random = new RandomNumberGenerator(6, 7, 3, 4001);
            double[] p = PearsonCriteriaWorker.GetProbalities(random.K);
            double[] values;
            double[] dataPlot;
            double[] dataFunc;
            random.GeneratorData(out values);
            random.MakeData(values, out dataPlot, out dataFunc, 0.0, 1.0);
            double[] dataPlotPearson = PearsonCriteriaWorker.GetDataPlot(dataPlot, 7000, 16);
            PearsonCriteriaWorker.Xi2(dataPlotPearson, p, random.K, 7000);
            Console.Read();
        }
    }
}