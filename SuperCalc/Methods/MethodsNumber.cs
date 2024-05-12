using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Methods
{
    public static class MethodsNumber
    {
        public static decimal MaxMethod(decimal[] args) { return args.Max(); }

        public static decimal MinMethod(decimal[] args) { return args.Min(); }

        public static decimal SumMethod(decimal[] args) { return args.Sum(); }

        public static decimal AverageMethod(decimal[] args) { return args.Average(); }
    }
}
