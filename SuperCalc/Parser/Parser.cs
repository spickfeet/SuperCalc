using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Parser
{
    public class Parser
    {


        private Dictionary<string, int> operationPriority = new() {
        {"(", 0},
        {"+", 1},
        {"-", 1},
        {"*", 2},
        {"/", 2} };

        private string operations = "+-*/";

        public string ToPostfix(string source)
        {

            //     перед и после выражений можно поставить сколько угодно пробелов
            //     строковые, логические арифметические выражения нельзя друг с другом складывать
            //     нельзя повторять операторы несколько раз подряд
            //     между операторами пробел может отсутствовать или быть только один
            //     для строковых выражений может применяться только конкатенация(+)
            //     нельзя в строковых выражениях использовать "

            return source;
        }


        public string ParseMethods(string str)
        {//   "Равно(..., ...)" вычислить результат для всех функций + проверки
            string result;

            return "";
        }
        public string ParseExpression(string expression)
        {
            StringBuilder sb = new StringBuilder(expression);
            sb.Replace(" ", "");
            // Строка позволяющая пропускать лишние скобки
            string temp = expression;
            int startIndex;
            int endIndex;
            while (true)
            {
                // Получение индекса
                startIndex = temp.LastIndexOf("(");
                // Выход из цикла
                if (startIndex == -1)
                {
                    break;
                }
                endIndex = startIndex;
                if (char.IsLetter(expression[startIndex - 1]))
                {
                    // Поиск начала метода
                    while ("+-/*".IndexOf(expression[startIndex]) == -1)
                    {
                        startIndex--;
                        if (startIndex == -1)
                        {
                            break;
                        }
                    }
                    startIndex++;
                    // Поиск конца метода
                    while (true)
                    {
                        int indexNextOpen = expression.IndexOf("(", endIndex + 1);
                        int indexClose = expression.IndexOf(")", endIndex + 1);
                        endIndex = indexClose;
                        if (indexNextOpen > indexClose || indexNextOpen == -1)
                        {
                            break;
                        }
                    }

                    string method = expression.Substring(startIndex, endIndex - startIndex + 1);
                    string result = UseMethod(method);


                    sb.Replace(method, result, startIndex, endIndex - startIndex + 1);
                }
                temp = temp.Remove(startIndex);
            }
            return sb.ToString();
        }
    }
}
