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
            string[] OldWord = { "пирвет", "првиет" };
            string NewWord = "привет";
            string FileText = System.IO.File.ReadAllText(@"D:/Users/student/Desktop/textFile.txt", Encoding.Default).Replace("\n", " ");

            string NewFileText = string.Join(" ", FileText.Split().Select(w => w = ReplaseWord(w, OldWord, NewWord)));

            string Before = @"(.012.\D*345\S*67\S*89)";
            string After = @"+380 12 345 67 89";


            NewFileText = Regex.Replace(NewFileText, Before, After);

            Console.WriteLine(" {0} \n {1}", "До: \n" + FileText, "После: \n" + NewFileText);
            Console.ReadKey();

        }


        static string ReplaseWord(string NextWord, string[] OldWord, string NewWord)
        {
            string Punct = string.Empty;
            string Word = NextWord;

            foreach (char ch in NextWord)
            {
                if (Word == OldWord[0])
                {
                    return NewWord;
                }
                if (Word == OldWord[1])
                {
                    return NewWord;
                }

            }
            return Word;

        }
    }
}
