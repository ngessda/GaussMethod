using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Gauss_pidar
    {
        private double[,] value;
        private const double esp = 0.00001;
        private int counter = 0;

        private int rows;
        private int colls;

        public int Rows => rows;
        public int Colls => colls;

        public Gauss_pidar(int n, int m)
        {
            rows = n;
            colls = m;
            value = new double[rows, colls];
            MatrixRandom();
        }
        public Gauss_pidar(double[,] arr)
        {
            value = arr.Clone() as double[,];
            rows = arr.GetLength(0);
            colls = arr.GetLength(1);
        }
        
        //Метод для поиска определителя матрицы по методу Гаусса.
        public double GaussDet()
        {
            double result = 1;
            //Проверка на вшивость(является ли матрица квадратной, имеются ли одинаковые строки ИЛИ одинаковые строки).
            if (rows == colls)
            {
                //Вызов метода для привидения матрицы к верхнетреугольному виду
                ToStairs();
                //Определение определителя по методу Гаусса.
                for(int i = 0; i < rows; i++)
                {
                    result *= value[i, i];
                }
                //Проверка на знак определителя.
                if(counter % 2 != 0)
                {
                    result = -result;
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
        ////Метод для проверки на одинаковые строки. Вызывается в методе для определителя.
        //private bool CheckMatrixRows()
        //{
        //    bool result = true;
        //    int counter = 0;
        //    for(int i = 0; i < rows - 1 && result == true; i++)
        //    {
        //        for(int j = i + 1; j < rows; j++)
        //        {
        //            if(counter == colls)
        //            {
        //                result = false;
        //                break;
        //            }
        //            else
        //            {
        //                counter = 0;
        //                for (int k = 0; k < colls; k++)
        //                {
        //                    if (value[i, k] == value[j, k])
        //                    {
        //                        counter++;
        //                    }
        //                    else
        //                    {
        //                        continue;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}
        ////Метод для проверки на одинаковые столбцы. Вызывается в методе для определителя.
        //private bool CheckMatrixColls()
        //{
        //    bool result = true;
        //    int counter = 0;
        //    for(int i = 0; i < colls - 1 && result == true; i++)
        //    {
        //        for(int j = i + 1; j < colls; j++)
        //        {
        //            if (counter == rows)
        //            {
        //                result = false;
        //                break;
        //            }

        //            for(int k = 0; k < rows; k++)
        //            {
        //                if(value[k, i] == value[k, j])
        //                {
        //                    counter++;
        //                }
        //                else
        //                {
        //                    continue;
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}
        //Метод для привидения матрицы к верхнетреугольному виду
        private void ToStairs()
        {
            for (int i = 0; i < rows; i++)
            {
                double maxValue = value[i, i % colls];
                for (int j = i + 1; j < rows; j++)
                {
                    if (Math.Abs(value[j, i % colls]) > Math.Abs(maxValue))
                    {
                        maxValue = value[j, i];
                        for (int k = 0; k < colls; k++)
                        {
                            double t = value[i, k];
                            value[i, k] = value[j, k];
                            value[j, k] = t;
                            counter++;
                        }
                    }
                }
                if (Math.Abs(maxValue) > esp)
                {
                    for (int j = i + 1; j < rows; j++)
                    {
                        double koef = value[j, i] / maxValue;
                        for (int k = 0; k < colls; k++)
                        {
                            value[j, k] -= value[i, k] * koef;
                            if (Math.Abs(value[j, k]) < esp)
                            {
                                value[j, k] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void MatrixRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < colls; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    value[i, j] = rnd.Next(1, 30);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colls; j++)
                {
                    sb.Append($" {value[i, j]} \t");
                    if (j == colls - 1)
                    {
                        sb.Append("");
                    }
                    else
                    {
                        sb.Append("|");
                    }
                }
                sb.AppendLine();
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
