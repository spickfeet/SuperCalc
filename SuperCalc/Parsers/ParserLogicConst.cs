using SuperCalc.LogEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Parsers
{
    /// <summary>
    /// Класс парсер логических констант.
    /// </summary>
    public static class ParserLogicConst
    {
        /// <summary>
        /// Метод для расчета логического выражения.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string Parse(string str)
        {
            List<string> logicConstList = Check(str);



            for (int i = logicConstList.Count - 2; i >= 0; i--)
            {
                if (logicConstList[i] == "НЕ")
                {
                    logicConstList[i + 1] = MethodNot(logicConstList[i + 1]);
                    logicConstList.RemoveAt(i);
                }
            }

            for (int i = 1; i < logicConstList.Count; i++)
            {
                if (Enum.IsDefined(typeof(TRUEANDFALSE), logicConstList[i - 1]) && Enum.IsDefined(typeof(TRUEANDFALSE), logicConstList[i]))
                {
                    throw new ArgumentException(".TRUE. и .FALSE. не могут идти подряд");
                }

                string[] s = new string[] { "ИЛИ", "И" };
                if (s.Contains(logicConstList[i - 1]) && s.Contains(logicConstList[i])) throw new ArgumentException(".ИЛИ. и .И. не могут идти подряд");

            }
            string logicString = "." + logicConstList.Aggregate((x, y) => x + ".." + y) + ".";


            if (logicString.Contains(".И.")) logicString = MethodAnd(logicString);
            if (logicString.Contains(".ИЛИ.")) logicString = MethodOr(logicString);

            return logicString;
        }

        /// <summary>
        /// Метод проверяет корректность ввода логического выражения и разбивает его на элементы списка.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<string> Check(string str)
        {

            str = str.Trim();
            if (str[0] != '.' || str[str.Length - 1] != '.') throw new ArgumentException("Логическая константа должна заканчиваться на .");

            str = str.Replace(" ", "");
            str = str.Substring(1, str.Length - 2);

            string[] logicConstArray = str.Split("..");

            if (!logicConstArray.All(l => Enum.IsDefined(typeof(LogicConst), l))) throw new ArgumentException("Элемент не является логической константой");
            if (!Enum.IsDefined(typeof(TRUEANDFALSE), logicConstArray[logicConstArray.Length - 1]))
            {
                throw new ArgumentException("Логическая константа может заканчиваться только на .TRUE. или .FALSE.");
            }
            if (logicConstArray[0] == "И" || logicConstArray[0] == "ИЛИ")
            {
                throw new ArgumentException("Логическая константа может начинаться на .И. и .ИЛИ.");
            }

            return logicConstArray.ToList();
        }

        /// <summary>
        /// Метод рассчитывает логическую операцию НЕ.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string MethodNot(string str)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>() {
                { "FALSE", "TRUE" },
                { "TRUE", "FALSE"}
            };

            if (dict.ContainsKey(str))
            {
                return dict[str];
            }

            throw new ArgumentException("Невозможно применить метод .НЕ. к параметру " + str);
        }

        /// <summary>
        /// Метод рассчитывает логическую операцию И.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MethodAnd(string str)
        {
            string[] stringsArray = str.Split(".И.");

            for (int i = 0; i < stringsArray.Length; i++) { if (stringsArray[i].Contains(".ИЛИ.")) { stringsArray[i] = MethodOr(stringsArray[i]); } }

            if (stringsArray.Any(x => x.Contains(".FALSE."))) return ".FALSE.";
            return ".TRUE.";
        }

        /// <summary>
        /// Метод рассчитывает логическую операцию ИЛИ.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MethodOr(string str)
        {
            string[] stringsArray = str.Split(".ИЛИ.");

            if (stringsArray.Any(x => x.Contains(".TRUE."))) return ".TRUE.";
            return ".FALSE.";
        }
    }
}
