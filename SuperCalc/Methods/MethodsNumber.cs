using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Methods
{
    public class MethodsNumber
    {
        public decimal MaxMethod(decimal[] args) { return args.Max(); }

        public decimal MinMethod(decimal[] args) { return args.Min(); }

        public decimal SumMethod(decimal[] args) { return args.Sum(); }

        public decimal AverageMethod(decimal[] args) { return args.Average(); }
    }
}
