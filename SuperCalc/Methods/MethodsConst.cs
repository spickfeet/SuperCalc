using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Methods
{
    public class MethodsConst
    {
        public bool MoreMethod(string arg1, string arg2)
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

        public bool MoreMethod(decimal arg1, decimal arg2)
        {
            return arg1 > arg2;
        }


        public bool LessMethod(string arg1, string arg2)
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

        public bool LessMethod(decimal arg1, decimal arg2)
        {
            return arg1 < arg2;
        }

        public bool EqualMethod(string arg1, string arg2)
        {
            return arg1 == arg2;
        }

        public bool EqualMethod(decimal arg1, decimal arg2)
        {
            return arg1 == arg2;
        }

    }
}
