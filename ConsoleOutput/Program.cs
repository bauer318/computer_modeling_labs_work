using ComputerModelling.QuadraticCongruentMethod;
using ComputerModelling.QueuingSystem;
using System;

namespace ConsoleOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator random = new RandomNumberGenerator(6, 7, 3, 4001);
            MultichanelQueuingSystemWithoutLimit qs = new MultichanelQueuingSystemWithoutLimit(0.8, 1.0, 3);
            QueuingSystemModeling queuingSystem = new QueuingSystemModeling(0.8, 1.0, random,10,50);
            Console.WriteLine("Аналитические характеристики СМО\n");
            qs.PrintValues();
            Console.WriteLine("\nМоделирование СМО\n");
            queuingSystem.Execute();

            Console.ReadLine();
        }

    }
}