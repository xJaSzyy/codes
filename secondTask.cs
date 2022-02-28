/***************************
 *Author: Novoselov Stepan *
 *Date: 21.02.2022         *
 *Exercise 2               *
 ***************************/
using System;

namespace Calculator
{
    
     public class Document : Word
    {
        public string name = "";
        public string author = "";
        public string keyWords = "";
        public string themes = "";
        public string pathToFile = "";
        public void getInfo()
        {
            Console.WriteLine($"Название документа: {name} \nАвтор: {author}");
        }
    }

    public class Word : Excel
    {
        public int numberOfPages = 0;
        public void PrintWord()
        {
            Console.WriteLine($"Количество страниц: {numberOfPages}");
        }
    }
    public class Excel
    {
        public int filledColumns = 0;
        public void PrintExcel()
        {
            Console.WriteLine($"Количество страниц: {filledColumns}");
        }
    }
    
    public class Menu : Document
    {
        public static Menu Instance
        {
            get
            {
                if (instance == null) instance = new Menu();
                return instance;
            }
        }
        public void GeneralOutput() { getInfo(); }
        public void SeparateOutput()
        {
            string whichDocument = Convert.ToString(Console.ReadLine());
            switch (whichDocument)
            {
                case "word":
                    PrintWord();
                    break;
                case "excel":
                    PrintExcel();
                    break;
            }
        }
        private Menu() { }
        private static Menu instance;
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            
            //Информация присущая только Word
            Menu.Instance.numberOfPages = random.Next(1,100);
            Menu.Instance.filledColumns = random.Next(1, 100);
            Menu.Instance.SeparateOutput();

            //Общая информация
            Menu.Instance.name = "document pi-211";
            Menu.Instance.author = "Novoselov Stepan";
            Menu.Instance.GeneralOutput();
        }
    }
}
