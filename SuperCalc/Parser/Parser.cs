using SuperCalc.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuperCalc.Parser
{
    public class Parser
    {
        private MethodsFactory _methodsFactory = new MethodsFactory();

        private Dictionary<string, int> operationPriority = new() {
        {"(", 0},
        {"+", 1},
        {"-", 1},
        {"*", 2},
        {"/", 2} };

        private string operations = "+-*/";

        public string ParseField(string source)
        {

            string result = "";


            //     перед и после выражений можно поставить сколько угодно пробелов
            //     строковые, логические арифметические выражения нельзя друг с другом складывать
            //     нельзя повторять операторы несколько раз подряд
            //     между операторами количество пробелов может быть разное
            //     для строковых выражений может применяться только конкатенация(+)
            //     нельзя в строковых выражениях использовать "
            //     можно использовать только один метод в строках


            bool isString = false;
            bool OneOperator = false;

            source = source.Trim(' ');

            if (source.Contains('\"'))
            {
                if (source.Count(c => c == '\"') % 2 != 0) { throw new Exception(); }

                isString = true;
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == '"')
                {
                    if (OneOperator == false && i != 0) { throw new Exception(); }

                    string s = source.Substring(i + 1);
                    int index = s.IndexOf('\"');

                    result = result + source.Substring(i, index + 1);

                    i += index + 1;
                    OneOperator = false;
                }
                else
                {
                    if (OneOperator == true && operations.Contains(source[i])) { throw new Exception(); }
                    if (operations.Contains(source[i]) && (source.Length - 1 == i || i == 0))
                    {
                        throw new Exception();
                    }
                    if (source[i] == ' ') { continue; }

                    if (source[i] == '+' && isString == true)
                    {
                        OneOperator = true;
                        continue;
                    }

                    if (isString && source[i] == 'З' && source.Length - i + 1 >= 16 + 8)
                    {
                        if (OneOperator == false && i != 0) { throw new Exception(); }

                        string s = source.Substring(i);
                        string str = TryParseMethod(s, "ЗАМЕНИТЬ", 4);

                        int len = str.Length;
                        i += len - 1;
                        result += str;
                        
                        OneOperator = false;
                        isString = true;
                        continue;
                    }

                    if (isString && source[i] == 'В' && source.Length - i + 1 >= 16 + 8)
                    {
                        if (OneOperator == false && i != 0) { throw new Exception(); }

                        string s = source.Substring(i);
                        string str = TryParseMethod(s, "ВСТАВИТЬ", 4);

                        int len = str.Length;
                        i += len - 1;
                        result += str;

                        OneOperator = false;
                        isString = true;
                        continue;
                    }

                    throw new Exception();
                }
            }

            if (isString == true)
            {
                result = result.Replace('\"', '\0');
                result = result.Insert(0, "\"");
                result = result.Insert(result.Length, "\"");

                return result;
            }

            return result;
        }

        public string TryParseMethod(string source, string word, int countArgs)
        {

            string s = "";
            if (countArgs > 1) { s += string.Join("", Enumerable.Repeat(".+,\\s", countArgs - 1)); }
            s += ".+";

            //string pattern = "^(?<word>" + word + "\\(" + s + "\\)).*$";
            //Regex regex = new Regex(pattern);
            //Match match = regex.Match(source);

            //if (match.Success)
            //{
            //    string str = match.Groups["word"].Value;
            //    //Вызвать метод
            //    return str;
            //}

            if (source.StartsWith(word + "(") && source.Contains(")"))
            {
                int index = source.IndexOf(")");
                return source.Substring(0, index + 1);
            }

            throw new Exception();
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
                if (char.IsLetter(sb.ToString()[startIndex - 1]))
                {
                    // Поиск начала метода
                    while (operations.IndexOf(sb.ToString()[startIndex]) == -1)
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
                        int indexNextOpen = sb.ToString().IndexOf("(", endIndex + 1);
                        int indexClose = sb.ToString().IndexOf(")", endIndex + 1);
                        endIndex = indexClose;
                        if (indexNextOpen > indexClose || indexNextOpen == -1)
                        {
                            break;
                        }
                    }

                    string method = sb.ToString().Substring(startIndex, endIndex - startIndex + 1);
                    string result = _methodsFactory.Use(method);

                    sb.Replace(method, result, startIndex, endIndex - startIndex + 1);
                }
                temp = temp.Remove(startIndex);
            }
            return sb.ToString();
        }
    }
}
