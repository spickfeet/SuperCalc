﻿using SuperCalc.Methods;
using SuperCalc.Poliz;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuperCalc.Parsers
{
    public class Calculator
    {
        private MethodsFactory _methodsFactory = new MethodsFactory();

        private Dictionary<string, int> operationPriority = new() {
        {"(", 0},
        {"+", 1},
        {"-", 1},
        {"*", 2},
        {"/", 2} };

        private string operations = "+-*/";

        public string Calculate(string source)
        {

            string result;

            source = source.Trim(' ');

            source = CalculateMethods(source);

            // Работа со строками
            if (source.Contains('\"'))
            {
                result = StringParser.Concatenation(source);
                return result;
            }
            // Работа с логическими константами
            if(source.Contains(".TRUE.")|| source.Contains(".FALSE."))
            {
                return ".TRUE.";
            }
            // Работа с числами
            else
            {
                return RPN.Calculate(source).ToString();
            }
        }

        //public string TryParseMethod(string source, string word, int countArgs)
        //{

        //    string s = "";
        //    if (countArgs > 1) { s += string.Join("", Enumerable.Repeat(".+,\\s", countArgs - 1)); }
        //    s += ".+";

        //    //string pattern = "^(?<word>" + word + "\\(" + s + "\\)).*$";
        //    //Regex regex = new Regex(pattern);
        //    //Match match = regex.Match(source);

        //    //if (match.Success)
        //    //{
        //    //    string str = match.Groups["word"].Value;
        //    //    //Вызвать метод
        //    //    return str;
        //    //}

        //    if (source.StartsWith(word + "(") && source.Contains(")"))
        //    {
        //        string result = _methodsFactory.Use(source);
        //        return result;
        //    }

        //    throw new Exception();
        //}


        public string CalculateMethods(string expression)
        {
            StringBuilder sb = new StringBuilder(expression);
            //sb.Replace(" ", "");
            // Строка позволяющая пропускать лишние скобки
            string temp = sb.ToString();
            int startIndex;
            int endIndex;

            int indexOpenQuotes;
            int indexCloseQuotes = -1;

            while (true)
            {
                indexOpenQuotes = temp.IndexOf("\"", indexCloseQuotes + 1);
                indexCloseQuotes = temp.IndexOf("\"", indexOpenQuotes + 1);
                
                // Получение индекса
                startIndex = temp.LastIndexOf("(") - 1;
                // Выход из цикла
                if (startIndex < 1) { break; }
              
                endIndex = startIndex + 1;

                if (char.IsLetter(sb.ToString()[startIndex - 1]))
                {
                    // Поиск начала метода                  
                    while ("+-*/(".IndexOf(sb.ToString()[startIndex]) == -1)
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
                        int indexOpen = sb.ToString().IndexOf("(", endIndex + 1);
                        int indexClose = sb.ToString().IndexOf(")", endIndex + 1);
                        endIndex = indexClose;
                        if (indexOpen > indexClose || indexOpen == -1)
                        {
                            break;
                        }
                    }
                    if (indexCloseQuotes <= startIndex && (indexOpenQuotes != -1 || indexCloseQuotes != -1))
                    {
                        continue;
                    }

                    if((indexOpenQuotes <= startIndex || indexCloseQuotes >= endIndex) &&(indexOpenQuotes != -1 || indexCloseQuotes != -1))
                    {
                        indexCloseQuotes = -1;
                        temp = temp.Remove(startIndex);
                        continue;
                    }

                    string method = sb.ToString().Substring(startIndex, endIndex - startIndex + 1);
                    string result = _methodsFactory.Use(method);

                    sb.Replace(method, result, startIndex, endIndex - startIndex + 1);
                    indexCloseQuotes = -1;
                }
                temp = temp.Remove(startIndex);
            }
            return sb.ToString();
        }
    }
}
