using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCalc.Poliz
{
    /// <summary>
    /// Класс для польской записи и её расчет.
    /// </summary>
    public class RPN
    {

        /// <summary>
        /// Метод, преобразующий входную строку с выражением в постфиксную запись.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static private string GetExpression(string input)
        {
            // Строка для хранения выражения.
            string output = string.Empty;
            // Стек для хранения операторов.
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                // Разделители пропускаем.
                if (IsDelimeter(input[i]))
                    continue;

                // Если символ - цифра, то считываем все число.
                if (Char.IsDigit(input[i]))
                {
                    // Читаем до разделителя или оператора, что бы получить число.
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++; 

                        if (i == input.Length) break;
                    }

                    output += " ";
                    i--;
                }

                // Если символ - оператор.
                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                        operStack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        // Выписываем все операторы до открывающей скобки в строку.
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    // Если любой другой оператор.
                    else
                    {
                        if (operStack.Count > 0) 
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";
                        // Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека.
                        operStack.Push(char.Parse(input[i].ToString()));

                    }
                }
            }

            // Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку.
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;
        }

        /// <summary>
        /// Метод, вычисляющий значение выражения, уже преобразованного в постфиксную запись.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static private double Counting(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < input.Length; i++)
            {
                // Если символ - цифра, то читаем все число и записываем на вершину стека.
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a, CultureInfo.InvariantCulture));
                    i--;
                }
                // Если символ - оператор.
                else if (IsOperator(input[i]))
                {
                    //Берем два последних значения из стека
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }

        /// <summary>
        /// Проверка является ли символ разделителем.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static private bool IsDelimeter(char c)
        {
            if ((" ".IndexOf(c) != -1))
                return true;
            return false;
        }

        /// <summary>
        /// Проверка является ли символ оператором.
        /// </summary>
        /// <param name="с"></param>
        /// <returns></returns>
        static private bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;
            return false;
        }

        /// <summary>
        /// Получить приоритет символа.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }

        /// <summary>
        /// Метод преобразует выражение в польскую запись и решает его.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public double Calculate(string input)
        {
            string output = GetExpression(input);
            double result = Counting(output);
            return result;
        }
    }
}
