using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SuperCalc.Parsers
{
    public class StringParser
    {
        private const string operations = "+-*/";
        /// <summary>
        /// Конкатенация строк формата "Строка1" + "Строка2"
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string Concatenation(string expression)
        {
            if (expression[0] != '\"' || expression[expression.Length - 1] != '\"') 
                throw new ArgumentException("В конце или в начале строки отсутствуют кавычки");

            string result = "";

            bool isString = false;
            bool OneOperator = false;

            if (expression.Count(c => c == '\"') % 2 != 0)
                throw new ArgumentException("Число кавычек в строке не чётное");


            int expressionLength = expression.Length;
            isString = true;


            for (int i = 0; i < expressionLength; i++)
            {
                if (expression[i] == '"')
                {
                    if (OneOperator == false && i != 0) 
                        throw new ArgumentException("Пропущен оператор");

                    string s = expression.Substring(i + 1);
                    int index = s.IndexOf('\"');

                    result = result + expression.Substring(i, index + 1);

                    i += index + 1;
                    OneOperator = false;
                    continue;
                }
                else
                {
                    if (OneOperator == true && operations.Contains(expression[i]))
                        throw new ArgumentException("Не может быть 2 и более операторов в одном месте");

                    if (operations.Contains(expression[i]) && (expression.Length - 1 == i || i == 0))
                        throw new ArgumentException("Оператор не может стоять в конце или в начале строки");
       
                    if (expression[i] == ' ') { continue; }

                    // Если в строке есть арифметическая или логическая опреция выбрасываем исключение
                    if ((OneOperator == true || i == 0) && expression[i] != '\"')
                        throw new ArgumentException("Конкатенация доступна только для строковых значений");

                    if (expression[i] == '+' && isString == true)
                    {
                        OneOperator = true;
                        continue;
                    }
                    throw new ArgumentException("Неизвестный оператор");
                }
            }
            result = result.Replace("\"", "");
            result = result.Insert(0, "\"");
            result = result.Insert(result.Length, "\"");

            return result;
        }

    }
}

