/***************************
 *Author: Novoselov Stepan *
 *Date: 4.04.2022         *
 *Exercise 5               *
 ***************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringsAndCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] oldWord = { "пирвет", "првиет" };
            string newWord = "привет";
            string str = System.IO.File.ReadAllText(@"D:/Users/student/Desktop/textFile.txt", Encoding.Default).Replace("\n", " ");

            string newStr = string.Join(" ", str.Split().Select(w => w = ReplaseWord(w, oldWord, newWord)));

            

            string before = @"((012)\D*345\S*67\S*89)";
            string after = @"+380 12 345 67 89";


            newStr = Regex.Replace(newStr, before, after);

            Console.WriteLine(" {0} \n {1}", "До: \n" + str, "После: \n" + newStr);
            Console.ReadKey();
            
        }

        
        static string ReplaseWord(string nextWord, string[] oldWord, string newWord)
        {
            string punct = string.Empty;
            string word = nextWord;

            foreach (char ch in nextWord)
            {
                if (word == oldWord[0])
                {
                    return newWord;
                }
                if (word == oldWord[1])
                {
                    return newWord;
                }

            }
            return word;

        }
    }
}
