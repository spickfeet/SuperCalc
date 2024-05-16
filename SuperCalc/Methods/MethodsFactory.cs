using SuperCalc.Poliz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Methods
{
    public class MethodsFactory
    {
        private Dictionary<string, Func<decimal[], decimal>> _numberMethods;
        private Dictionary<string, Func<string[], string>> _stringMethods;
        private Dictionary<string, Func<string, string, bool>> _constStringMethods;
        private Dictionary<string, Func<decimal, decimal, bool>> _constNumberMethods;

        public MethodsFactory() => Init();

        private void Init()
        {
            _numberMethods = new Dictionary<string, Func<decimal[], decimal>>
            {
                { "МАКС", MethodsNumber.MaxMethod},
                { "МИН", MethodsNumber.MinMethod},
                { "СУММА", MethodsNumber.SumMethod},
                { "СРЕДНЕЕ", MethodsNumber.AverageMethod},
            };

            _stringMethods = new Dictionary<string, Func<string[], string>>
            {
                { "ВСТАВИТЬ", MethodsString.InsertMethod},
                 { "ЗАМЕНИТЬ", MethodsString.ReplaceMethod},
            };

            _constStringMethods = new Dictionary<string, Func<string, string, bool>>
            {
                { "БОЛЬШЕ", MethodsConst.MoreMethod},
                { "МЕНЬШЕ",  MethodsConst.LessMethod},
                { "РАВНО",  MethodsConst.EqualMethod},
            };

            _constNumberMethods = new Dictionary<string, Func<decimal, decimal, bool>>
            {
                { "БОЛЬШЕ", MethodsConst.MoreMethod},
                { "МЕНЬШЕ",  MethodsConst.LessMethod},
                { "РАВНО",  MethodsConst.EqualMethod},
            };
        }
        public string Use(string inputStroke)
        {
            inputStroke = inputStroke.Trim(' ');
            string methodName = inputStroke.Remove(inputStroke.IndexOf('('));

            if (_numberMethods.TryGetValue(methodName, out var methodNumber) == true)
            {
                string[] expressions = GetExpressions(inputStroke, methodName);

                decimal[] values = new decimal[expressions.Length];

                for (int i = 0; i < expressions.Length; i++)
                {
                    if (expressions[i][0] == '"' || expressions[i][expressions[i].Length - 1] == '"') 
                        throw new Exception("Аргумент не является числом");

                    values[i] = (decimal)RPN.Calculate(expressions[i].ToString());
                }

                return methodNumber(values).ToString().Replace(',', '.');
            }

            if (_stringMethods.TryGetValue(methodName, out var methodString) == true)
            {
                string[] expressions = GetExpressions(inputStroke, methodName);

                string[] values = new string[expressions.Length];

                for (int i = 0; i < expressions.Length; i++)
                {
                    if (i == 2 && expressions.Length == 3)
                    {
                        if (expressions[i][0] == '"' || expressions[i][expressions[i].Length - 1] == '"')
                            throw new Exception("Аргумент не является числом");

                        values[i] = RPN.Calculate(expressions[i]).ToString();

                        continue;
                    }

                    values[i] = expressions[i];
                    values[i] = values[i].Replace("\"", "");
                }
                string res = methodString(values);
                res = res.Insert(0, "\"");
                res += "\"";
                return res;
            }

            if (_constStringMethods.TryGetValue(methodName, out var methodConstString) == true)
            {
                string[] expressions = GetExpressions(inputStroke, methodName);

                string[] values = new string[expressions.Length];

                bool AreArgumentsStrings = true;
                for(int i = 0; i < values.Length; i++)
                {

                    if (expressions[i][0] != '"' || expressions[i][expressions[i].Length - 1] != '"')
                    {
                        AreArgumentsStrings = false; 
                        break;
                    }

                    values[i] = expressions[i];
                }

                if (AreArgumentsStrings == true)
                    return methodConstString(values[0], values[1]) == true ? ".TRUE." : ".FALSE.";
            }

            if (_constNumberMethods.TryGetValue(methodName, out var methodConstNumber) == true)
            {
                string[] expressions = GetExpressions(inputStroke, methodName);

                decimal[] values = new decimal[expressions.Length];
                for (int i = 0; i < expressions.Length; i++)
                {
                    if (expressions[i][0] == '"' || expressions[i][expressions[i].Length - 1] == '"') 
                        throw new Exception("Аргумент не является числом");

                    values[i] = (decimal)RPN.Calculate(expressions[i].ToString());
                }

                return methodConstNumber(values[0], values[1]) == true ? ".TRUE." : ".FALSE.";
            }

            throw new NotImplementedException("Нет метода с данным именем");
        }

        private string[] GetExpressions(string inputStroke, string methodName)
        {
            string methodStroke = inputStroke;

            methodStroke = methodStroke.Replace(methodName + '(', "");
            methodStroke = methodStroke.Remove(methodStroke.Length - 1);

            string[] expressions = methodStroke.Split(",");

            for (int i = 0; i < expressions.Length; i++)
            {
                expressions[i] = expressions[i].Trim();
            }

            return expressions;
        }
    }
}
