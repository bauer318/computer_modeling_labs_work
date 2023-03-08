using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerModelling.PokerTest
{
    public class PokerTestValue
    {
        public string ProbabilityClassName { get; set; }
        public string ProbabilityClassValue { get; set; }

        private PokerTestValue() { }
        public PokerTestValue(string parProbabilityClassName, string parProbabilityClassValue)
        {
            ProbabilityClassName = parProbabilityClassName;
            ProbabilityClassValue = parProbabilityClassValue;
        }
    }
}
