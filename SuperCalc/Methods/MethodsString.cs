using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Methods
{
    public static class MethodsString
    {
        public static string InsertMethod(string[] args)
        {
            if (args.Length != 3) throw new ArgumentException("Неверное количество входных данных! Ожидалось: 3.");

            decimal arg3 = decimal.Parse(args[2]);

            return args[0].Insert((int)arg3, args[1]);
        }

        public static string ReplaceMethod(string[] args)
        {//используется TRUE
            if (args.Length != 4) throw new ArgumentException("Неверное количество входных данных! Ожидалось: 4.");

            StringBuilder stringBuilder = new StringBuilder(args[0]);
            if (args[3] == "TRUE") return stringBuilder.Replace(args[1], args[2]).ToString();
            return stringBuilder.Replace(args[1], args[2], 0, 1).ToString();
        }
    }
}
