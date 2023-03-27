using ComputerModelling.MonteCarlo;
using ComputerModelling.QuadraticCongruentMethod;

namespace ConsoleOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double p1 = 0.3; 
            double p2 = 0.5;
            int n = 1000000;
            double[] result = MonteCarloWorker.GetProbabilitiesArray(n, p1, p2);
            double[] thericalResult = MonteCarloWorker.GetTheoriticalsProbabilitiesArray(p1, p2);
            string[] eventTexts = { "A", "B", "C", "D", "E", "F" };
            for(int i=0; i<result.Length; i++)
            {
                var info = new ConfidenceInterval(result[i], thericalResult[i], n, eventTexts[i]);
                Console.WriteLine(info.ToString()+"\n");
            }
            
            Console.ReadLine();
        }
    }
}