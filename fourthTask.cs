/***************************
 *Author: Novoselov Stepan *
 *Date: 21.03.2022         *
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
        static string FileName;
        public static void CreateFile()
        {
            try
            { 
                Console.Write("Enter file name: ");
                FileName = Console.ReadLine();
                
                File.Move($"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}.txt", $"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}Copy.txt");
                FileStream StreamFile = new FileStream(FileName + ".txt", FileMode.Create);
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
                    Console.WriteLine("File text: ");
                    while ((Line = ReaderStream.ReadLine()) != null)
                    { Console.WriteLine(Line + "\n"); }
                }
            }
            catch (Exception exeption)
            { Console.WriteLine("File opening error: {0}", exeption.Message); }
        }

        public static void RollbackChanges()
        {
            File.Delete($"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}.txt");
            File.Move($"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}Copy.txt", $"C:/Users/student/source/repos/Serialization/Serialization/bin/Debug/netcoreapp3.1/{FileName}.txt");
            Console.WriteLine("Rollback was successful");
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
                Console.WriteLine("Create file to write text -- 1\nOpen created file for reading -- 2\nRollback changes -- 3\nExit -- 4");
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
                        RollbackChanges();
                        break;
                    case 4:
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

