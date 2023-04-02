using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.QueuingSystem
{
    public class MultichanelQueuingSystemWithoutLimit
    {
        private double _lamba;
        private double _mu;
        private int _chanels;

        private const double REFUSAL_APPLICATION_PROBABILITY = 0.0; //System without limit

        public MultichanelQueuingSystemWithoutLimit(double parLamba, double parMu, int parChanels)
        {
            _lamba = parLamba;
            _mu = parMu;
            _chanels = parChanels;
        }
        
        public double GetLoadFactor()
        {
            return _lamba / _mu;
        }

        public double GetFreeChanelsProbability()
        {
            double p0 = 0.0;
            double loadFactor = GetLoadFactor();
            for(int i=0; i<=_chanels; i++)
            {
                p0 += Math.Pow(loadFactor, i) / GetFactorial(i);
            }
            p0 += Math.Pow(loadFactor, _chanels + 1) / (GetFactorial(_chanels)*(_chanels-loadFactor));
            return 1/p0;
        }

        public double GetQueueProbability()
        {
            double p0 = GetFreeChanelsProbability();
            double loadFactor = GetLoadFactor();

            return Math.Pow(loadFactor, _chanels + 1) * p0 / (GetFactorial(_chanels) * (_chanels - loadFactor));
        }

        public double GetAverageNumberQueueApplications()
        {
            double p0 = GetFreeChanelsProbability();
            double loadFactor = GetLoadFactor();

            return Math.Pow(loadFactor, _chanels + 1) * p0*(1/Math.Pow(1-(loadFactor/_chanels),2))/(_chanels*GetFactorial(_chanels));
        }

        public double GetRelativeThroughputQueuingSystem()
        {
            //Q
            return 1 - REFUSAL_APPLICATION_PROBABILITY;
        }

        public double GetAbsoluteThroughputQueuingSystem()
        {
            //A
            return _lamba * GetRelativeThroughputQueuingSystem();
        }

        public double GetAverageTimeQueueApplications()
        {
            return GetAverageNumberQueueApplications() / _lamba;
        }

        public double GetAverageNumberBusyChanels()
        {
            return GetAbsoluteThroughputQueuingSystem() / _mu;
        }

        public int GetFactorial(int parNumber)
        {
            if (parNumber == 0 || parNumber == 1)
            {
                return 1;
            }
            else return parNumber * GetFactorial(parNumber - 1);
        }
    }
}
