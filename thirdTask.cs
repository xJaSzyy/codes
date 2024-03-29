/***************************
 *Author: Novoselov Stepan *
 *Date: 28.02.2022         *
 *Exercise 3               *
 ***************************/
using System;

namespace Program
{
    class Matrix
    {
        private int Size;
        public Matrix()
        {
            Size = 3;
        }
        public int[,] MainArray = new int[100, 100];
        public int[,] AuxiliaryArray = new int[100, 100];
        public int DeterminantValue = 0;

        //Рандомное заполнение матрицы(ввод)
        public void Input()
        {
            Random random = new Random();
            for (int Row = 0; Row < Size; ++Row)
            {
                for (int Column = 0; Column < Size; ++Column)
                {
                    MainArray[Row, Column] = random.Next(1, 10);
                }
            }
        }

        //Вывод матрицы
        public void Output(int[,] Array)
        {
            for (int Row = 0; Row < Size; ++Row)
            {
                for (int Column = 0; Column < Size; ++Column)
                {
                    Console.Write(Array[Row, Column] + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        public void ReverseMatrixOutput(int[,] Array)
        {
            string StringDeterminant = DeterminantValue.ToString();
            if (DeterminantValue != 0)
            {
                for (int Row = 0; Row < Size; ++Row)
                {
                    for (int Column = 0; Column < Size; ++Column)
                    {
                        string StringArray = Array[Row, Column].ToString();
                        string ReverseMatrixElement = StringArray + "/" + StringDeterminant;
                        Console.Write(ReverseMatrixElement + "  ");
                    }
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("Определитель равен нулю => обратная матрица не может быть найдена");
            }
        }

        public void Addition(int[,] FirstArray, int[,] SecondArray)
        {
            for (int Row = 0; Row < Size; ++Row)
            {
                for (int Column = 0; Column < Size; ++Column)
                {
                    MainArray[Row, Column] = FirstArray[Row, Column] + SecondArray[Row, Column];
                }
            }
        }

        public void Multiplication(int[,] FirstArray, int[,] SecondArray)
        {
            for (int Row = 0; Row < Size; ++Row)
            {
                for (int Column = 0; Column < Size; ++Column)
                {
                    MainArray[Row, Column] = FirstArray[Row, Column] * SecondArray[Row, Column];
                }
            }
        }
        public void OverLoad()
        {
            for (int Row = 0; Row < Size; ++Row)
            {
                for (int Column = 0; Column < Size; ++Column)
                {
                    MainArray[Row, Column] = 0;
                }
            }
        }
        public void Determinant(int[,] Array)
        {
            int Determinant = 0;
            Determinant = Array[0, 0] * Array[1, 1] * Array[2, 2] + Array[2, 0] * Array[0, 1] * Array[1, 2] +
                          Array[1, 0] * Array[2, 1] * Array[0, 2] - Array[2, 0] * Array[1, 1] * Array[0, 2] -
                          Array[1, 0] * Array[0, 1] * Array[2, 2] - Array[0, 0] * Array[1, 2] * Array[2, 1];
            DeterminantValue = Determinant;
        }

        public void Comparison(int FirstDeterminant, int SecondDeterminant)
        {
            if (FirstDeterminant > SecondDeterminant)
            {
                Console.WriteLine($"Определитель первой матрицы больше и равен {FirstDeterminant}");
            }
            else if (FirstDeterminant < SecondDeterminant)
            {
                Console.WriteLine($"Определитель второй матрицы больше и равен {SecondDeterminant}");
            }
            else if (Equals(FirstDeterminant, SecondDeterminant))
            {
                Console.WriteLine($"Оба определителя матриц равны {FirstDeterminant}");
            }
        }

        public void ReverseMatrix(int[,] MainArray)
        {
            AuxiliaryArray[0, 0] = MainArray[1, 1] * MainArray[2, 2] - MainArray[1, 2] * MainArray[2, 1];
            AuxiliaryArray[0, 1] = -(MainArray[1, 0] * MainArray[2, 2] - MainArray[1, 2] * MainArray[2, 0]);
            AuxiliaryArray[0, 2] = MainArray[1, 0] * MainArray[2, 1] - MainArray[1, 1] * MainArray[2, 0];
            AuxiliaryArray[1, 0] = -(MainArray[0, 1] * MainArray[2, 2] - MainArray[0, 2] * MainArray[2, 1]);
            AuxiliaryArray[1, 1] = MainArray[0, 0] * MainArray[2, 2] - MainArray[0, 2] * MainArray[2, 0];
            AuxiliaryArray[1, 2] = -(MainArray[0, 0] * MainArray[2, 1] - MainArray[0, 1] * MainArray[2, 0]);
            AuxiliaryArray[2, 0] = MainArray[0, 1] * MainArray[1, 2] - MainArray[0, 2] * MainArray[1, 1];
            AuxiliaryArray[2, 1] = -(MainArray[0, 0] * MainArray[1, 2] - MainArray[0, 2] * MainArray[1, 0]);
            AuxiliaryArray[2, 2] = MainArray[0, 0] * MainArray[1, 1] - MainArray[0, 1] * MainArray[1, 0];
        }

        public bool DeterminantZero(int DeterminantValue)
        {
            if (DeterminantValue == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class MainProgram
    {

        static void Main(string[] args)
        {
            Matrix FirstMatrix = new Matrix();
            Matrix SecondMatrix = new Matrix();
            Matrix Result = new Matrix();

            //Создание первой матрицы
            FirstMatrix.Input();
            Console.WriteLine("Первая матрица\n" + "--------------------");
            FirstMatrix.Output(FirstMatrix.MainArray);
            Console.WriteLine("--------------------");

            //Создание второй матрицы
            SecondMatrix.Input();
            Console.WriteLine("Вторая матрица\n" + "--------------------");
            SecondMatrix.Output(SecondMatrix.MainArray);
            Console.WriteLine("--------------------");

            //Сложение
            Console.WriteLine("Сложение\n" + "--------------------");
            Result.Addition(FirstMatrix.MainArray, SecondMatrix.MainArray);
            Result.Output(Result.MainArray);
            Console.WriteLine("--------------------");

            Result.OverLoad();

            //Умножение
            Console.WriteLine("Умножение\n" + "--------------------");
            Result.Multiplication(FirstMatrix.MainArray, SecondMatrix.MainArray);
            Result.Output(Result.MainArray);
            Console.WriteLine("--------------------");

            //Определитель
            Console.WriteLine("------------------------------------------------");
            FirstMatrix.Determinant(FirstMatrix.MainArray);
            SecondMatrix.Determinant(SecondMatrix.MainArray);
            Console.WriteLine("Определитель первой матрицы:" + FirstMatrix.DeterminantValue.GetHashCode());
            Console.WriteLine("Определитель второй матрицы:" + SecondMatrix.DeterminantValue.GetHashCode());
            Result.Comparison(FirstMatrix.DeterminantValue, SecondMatrix.DeterminantValue);
            Console.WriteLine("------------------------------------------------");

            //Обратные матрицы
            Console.WriteLine("Первая обратная матрица\n" + "------------------------------------------------");
            FirstMatrix.ReverseMatrix(FirstMatrix.MainArray);
            FirstMatrix.ReverseMatrixOutput(FirstMatrix.AuxiliaryArray);
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine("Вторая обратная матрица\n" + "------------------------------------------------");
            SecondMatrix.ReverseMatrix(SecondMatrix.MainArray);
            SecondMatrix.ReverseMatrixOutput(SecondMatrix.AuxiliaryArray);
            Console.WriteLine("------------------------------------------------");

            //True or false
            Console.WriteLine("Первая матрица\n" + "----------------");
            Console.WriteLine(FirstMatrix.DeterminantZero(FirstMatrix.DeterminantValue));
            Console.WriteLine("----------------");
            Console.WriteLine("Вторая матрица\n" + "----------------");
            Console.WriteLine(SecondMatrix.DeterminantZero(SecondMatrix.DeterminantValue));
            Console.WriteLine("----------------");



            Console.ReadLine();
        }
    }
}
