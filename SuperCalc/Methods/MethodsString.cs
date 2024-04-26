using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Methods
{
    public class MethodsString
    {
        public string InsertMethod(string arg1, string arg2, decimal arg3)
        {
            return arg1.Insert((int)arg3, arg2);
        }

        public string ReplaceMethod(string arg1, string arg2, string arg3, string arg4)
        {//используется TRUE
            StringBuilder stringBuilder = new StringBuilder(arg1);
            if (arg4 == "TRUE") return stringBuilder.Replace(arg2, arg3).ToString();
            return stringBuilder.Replace(arg2, arg3, 0, 1).ToString();
        }
    }
}
