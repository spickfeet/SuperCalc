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
    }
}
