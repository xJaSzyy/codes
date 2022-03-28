/***************************
 *Author: Novoselov Stepan *
 *Date: 28.03.2022         *
 *Exercise 5               *
 ***************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringsAndCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] oldWord = { "пирвет", "првиет" };
            string newWord = "привет";
            string str = "привет пирвет првиет";

            string newStr = string.Join(" ", str.Split().Select(w => w = ReplaseWord(w, oldWord, newWord)));

            Console.WriteLine(" {0} \n {1}", str, newStr);
            Console.ReadKey();
        }

        static string ReplaseWord(string nextWord, string[] oldWord, string newWord)
        {
            string punct = string.Empty;
            string word = nextWord;

            foreach (char ch in nextWord)
            {
               
                if (char.IsPunctuation(ch) && ch != '-' && ch != '_')
                {
                    punct = ch.ToString();
                    word = word.Replace(punct, string.Empty);
                }
                if (word == oldWord[0])
                {
                    return newWord;
                }
                if (word == oldWord[1])
                {
                    return newWord;
                }

            }
            return "ошипка";

        }
    }
}
