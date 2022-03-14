/***************************
 *Author: Novoselov Stepan *
 *Date: 14.03.2022         *
 *Exercise 4               *
 ***************************/
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    [Serializable]
    class TextFile
    {
        public string Author { get; set; }

        public TextFile(string Name)
        {
            Author = Name; 
        }

    }
    
    class Program
    {
        public static void CreateFile()
        {
            try
            {
                Console.Write("Enter file name: ");
                FileStream StreamFile = new FileStream(Console.ReadLine() + ".txt", FileMode.Create);
                Console.WriteLine("File text: ");
                string text = Console.ReadLine();
                StreamWriter TextWriter = new StreamWriter(StreamFile);
                TextWriter.WriteLine(text);
                TextWriter.Close();
            }
            catch (Exception exception)
            { Console.WriteLine("File creation error: { 0}", exception.Message); }
        }
        public static void OpenFile()
        {
            try
            {
                Console.WriteLine("Enter file name: ");
                using (StreamReader ReaderStream = new StreamReader(Console.ReadLine() + ".txt"))
                {
                    string Line;
                    Console.WriteLine("File text: \n");
                    while ((Line = ReaderStream.ReadLine()) != null)
                    { Console.WriteLine(Line); }
                }
            }
            catch (Exception exeption)
            { Console.WriteLine("File opening error: {0}", exeption.Message); }
        }
        static void Main(string[] args)
        {
            // object for serialize
            TextFile WordFile = new TextFile("Novoselov Stepan");
            Console.WriteLine("Object created");

            // create a BinaryFormatter object
            BinaryFormatter Formatter = new BinaryFormatter();

            // serialization to files.dat
            using (FileStream StreamFile = new FileStream("files.dat", FileMode.OpenOrCreate))
            {
                Formatter.Serialize(StreamFile, WordFile);

                Console.WriteLine("Object serialized");
            }

            // deserialization from files.dat
            using (FileStream StreamFile = new FileStream("files.dat", FileMode.OpenOrCreate))
            {
                TextFile NewWordFile = (TextFile)Formatter.Deserialize(StreamFile);

                Console.WriteLine("Object deserialized");
                Console.WriteLine($"Author: {NewWordFile.Author}");
            }

            // enter keyword
            Console.Write("Enter keyword: ");
            string Path = Console.ReadLine();
            
            // search file and enter info
            FileInfo FileInformation = new FileInfo($"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{Path}.txt");
            if (FileInformation.Exists)
            {
                Console.WriteLine($"File name: {FileInformation.Name}");
                Console.WriteLine($"Time of creation: {FileInformation.CreationTime}");
                Console.WriteLine($"Size: {FileInformation.Length}");
            }
            else
            {
                Console.WriteLine("File not found");
            }

            // menu
            bool OpenMenu = true;
            do
            {
                Console.WriteLine("***********       Menu       ***********");
                Console.WriteLine("Create file to write text -- 1\nOpen created file for reading -- 2\nExit -- 3");
                Console.WriteLine("****************************************");

                switch (Int16.Parse(Console.ReadLine()))
                {
                    case 1:
                        CreateFile();
                        break;
                    case 2:
                        OpenFile();
                        break;
                    case 3:
                        OpenMenu = false;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            } while (OpenMenu);
        }
    }
}
