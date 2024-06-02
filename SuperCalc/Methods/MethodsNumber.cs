using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Methods
{
    /// <summary>
    /// Класс с методами возвращающими числа.
    /// </summary>
    public static class MethodsNumber
    {
        /// <summary>
        /// Метод для нахождения максимального числа. 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static decimal MaxMethod(decimal[] args) { return args.Max(); }

        /// <summary>
        /// Метод для нахождения минимального числа.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static decimal MinMethod(decimal[] args) { return args.Min(); }

        /// <summary>
        /// Метод для нахождения суммы чисел. 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static decimal SumMethod(decimal[] args) { return args.Sum(); }

        /// <summary>
        /// Метод для нахождения среднего значения.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static decimal AverageMethod(decimal[] args) { return args.Average(); }
    }
}
