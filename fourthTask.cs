/***************************
 *Author: Novoselov Stepan *
 *Date: 14.03.2022         *
 *Exercise 4               *
 ***************************/
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            string path = Console.ReadLine();
            
            // search file and enter info
            FileInfo fileInfo = new FileInfo($"D:/Users/student/desktop/{path}.txt");
            if (fileInfo.Exists)
            {
                Console.WriteLine($"File name: {fileInfo.Name}");
                Console.WriteLine($"Time of creation: {fileInfo.CreationTime}");
                Console.WriteLine($"Size: {fileInfo.Length}");
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}
