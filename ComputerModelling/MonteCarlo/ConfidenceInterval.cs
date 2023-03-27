using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.MonteCarlo
{
    public class ConfidenceInterval
    {
        private const double T = 1.96;
        private double _p;
        private double _theoreticalP;
        private int _n;
        private string _currentEvent;


        public ConfidenceInterval(double parP, double parThereticalP, int parN, string parCurrentEvent)
        {
            _p = parP;
            _theoreticalP = parThereticalP;
            _n = parN;
            _currentEvent = parCurrentEvent;
        }

        override
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            double dx = T * Math.Sqrt(_p * (1 - _p) / (double)_n);
            double min = _p - dx;
            double max = _p + dx;
            bool succes = _theoreticalP >= min && _theoreticalP <= max;
            sb.AppendLine("Оценка верояность события " + _currentEvent + " : " + _p);
            sb.AppendFormat("Доворительный интервал [{0:f4}; {1:f4}]", min, max);
            sb.AppendLine();
            sb.AppendFormat("Теоретическая вероятность {0:f4} " + GetSuccesText(succes) + " попала в доверительный интервал", _theoreticalP);
            return sb.ToString();


        }
        private string GetSuccesText(bool parSucces)
        {
            return parSucces ? "" : " не ";
        }
    }
}
