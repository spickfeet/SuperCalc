using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Methods
{
    public static class MethodsConst
    {
        /// <summary>
        /// Метод больше для сравнения строк.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static bool MoreMethod(string arg1, string arg2)
        {

            if (arg1.Length > arg2.Length)
            {
                arg2 = arg2.Insert(arg2.Length, new string(' ', arg1.Length - arg2.Length));
            }
            else
            {
                arg1 = arg1.Insert(arg1.Length, new string(' ', arg2.Length - arg1.Length));
            }
            return arg1.CompareTo(arg2) > 0;
        }

        /// <summary>
        /// Метод больше для сравнения числе.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static bool MoreMethod(decimal arg1, decimal arg2)
        {
            return arg1 > arg2;
        }


        public static bool LessMethod(string arg1, string arg2)
        {
            if (arg1.Length > arg2.Length)
            {
                arg2 = arg2.Insert(arg2.Length, new string(' ', arg1.Length - arg2.Length));
            }
            else
            {
                arg1 = arg1.Insert(arg1.Length, new string(' ', arg2.Length - arg1.Length));
            }
            return arg1.CompareTo(arg2) < 0;
        }

        public static bool LessMethod(decimal arg1, decimal arg2)
        {
            return arg1 < arg2;
        }

        public static bool EqualMethod(string arg1, string arg2)
        {
            return arg1 == arg2;
        }

        public static bool EqualMethod(decimal arg1, decimal arg2)
        {
            return arg1 == arg2;
        }

    }
}
