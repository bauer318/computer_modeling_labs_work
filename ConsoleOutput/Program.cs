﻿using ComputerModelling.InverseFunctionMethod;
using ComputerModelling.Kolmogorov;
using ComputerModelling.OneDimensionalLattice;
using ComputerModelling.QuadraticCongruentMethod;

namespace ConsoleOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator random = new RandomNumberGenerator(6, 7, 3, 4001);
            OneDimensionalLatticeWorker one = new OneDimensionalLatticeWorker(random, 0, 7, 3, 0.4);
            for(int i=0; i < 10; i++)
            {
                Console.WriteLine(one.GetTime());
            }
           
            Console.ReadLine();
        }
    }
}