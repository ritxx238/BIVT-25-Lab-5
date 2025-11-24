using System;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int index = 0;
            answer = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int n = 0;
                double s = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        n++;
                    }
                }
                if (n > 0)
                {
                    answer[index] = s / n;
                    index++;
                }
                else
                {
                    answer[index] = 0;
                    index++;
                }
            }
            foreach (double i in answer)
            {
                Console.Write(i + " ");
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int maxel = matrix[0, 0];
            int k = 0;
            int m = 0;
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                        k = i;
                        m = j;
                    }
                }
            }
            int index1 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == k) continue; // скип строки с макс эл

                int index2 = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == m) continue; // скип столбца с макс эл

                    answer[index1, index2] = matrix[i, j];
                    index2++;
                }
                index1++;
            }
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    Console.Write($"{answer[i, j],5}");
                }
                Console.WriteLine();
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int m = 0;
                int maxel = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                        m = j;
                    }
                }
                for (int j = m; j < matrix.GetLength(1) - 1; j++)
                {
                    (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                }
                Console.WriteLine(m);
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return null;
            }
            int[] array = new int[matrix.GetLength(0)];
            int index = 0;
            int index1 = 0;
            int index2 = 0;
            int index3 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxel = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel = matrix[i, j];
                    }
                }
                array[index] = maxel;
                index++;
            }
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((j < answer.GetLength(1) - 1 - 1))
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else
                    {
                        answer[index1, j] = array[index2];
                        index1++;
                        index2++;
                    }
                }
            }
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j == answer.GetLength(1) - 1)
                    {
                        answer[i, j] = matrix[index3, matrix.GetLength(1) - 1];
                        index3++;
                    }
                }
            }

            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int index = 0;
            int n = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        n++;
                    }
                }
            }
            answer = new int[n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[index] = matrix[i, j];
                        index++;
                    }
                }
            }
            Console.WriteLine(n);
            foreach (int i in answer)
            {
                Console.Write(i + " ");
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            if (k < 0 || k >= matrix.GetLength(1))
            {
                return;
            }
            int maxelofmain = matrix[0, 0];
            int indexofmaxel = 0;
            int firstotr = 0;
            int n = 0;
            int indexofotr = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                ;
                {
                    if (matrix[i, i] > maxelofmain)
                    {
                        maxelofmain = matrix[i, i];
                        indexofmaxel = i;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] < 0 && n < 1)
                {
                    firstotr = matrix[i, k];
                    indexofotr = i;
                    n++;
                }
            }
            if (n != 0 && indexofmaxel != indexofotr)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    (matrix[indexofmaxel, j], matrix[indexofotr, j]) = (matrix[indexofotr, j], matrix[indexofmaxel, j]);
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(1) < 2)
            {
                return;
            }
            if (array.Length != matrix.GetLength(0))
            {
                return;
            }
            int maxel = matrix[0, 0];
            int indexofi = 0;
            int indexofarray = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, matrix.GetLength(1) - 1 - 1] > maxel)
                {
                    maxel = matrix[i, matrix.GetLength(1) - 1 - 1];
                    indexofi = i;
                }
            }
            Console.WriteLine(indexofi);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[indexofi, j] = array[indexofarray];
                indexofarray++;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            if (matrix == null) return;


            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                // Находим позицию максимального элемента относитьльно столбца(индекс сверху вниз)
                int indexofmaxincol = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > matrix[indexofmaxincol, j])
                    {
                        indexofmaxincol = i;
                    }
                }
                Console.WriteLine(indexofmaxincol);

                if (indexofmaxincol < matrix.GetLength(0) / 2)
                {
                    int sum = 0;
                    for (int i = indexofmaxincol + 1; i < matrix.GetLength(0); i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }
            }
            // end
        }
        public void Task9(int[,] matrix)
        {

            //code here
            if(matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0) - 1; i += 2)
            {
                int jmaxf = 0, jmaxs = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, jmaxf]) jmaxf = j;                }
                for (int j = 0; j < matrix.GetLength(1); j++) 
                {
                    if (matrix[i + 1, j] > matrix[i + 1, jmaxs]) jmaxs = j;
                }
                (matrix[i, jmaxf], matrix[i + 1, jmaxs]) = (matrix[i + 1, jmaxs], matrix[i, jmaxf]);
            }
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        Console.Write($"{matrix[i, j],5}");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            //int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 16, 12 }, { 13, 14, 15, 16 } };
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            if (matrix == null) return;

            int maxofi = matrix[0, 0];
            int indexofmaxiij = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxofi)
                {
                    maxofi = matrix[i, i];
                    indexofmaxiij = i;
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i < indexofmaxiij && j > i)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here

            if (matrix == null ) return;

            int[] countofplus = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) count++;
                }
                countofplus[i] = count;
            }

            foreach (int i in countofplus)
            {
                Console.Write(i + " ");
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                int maxIndex = i;  
                    
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    if (countofplus[j] > countofplus[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                {
                    (countofplus[i], countofplus[maxIndex]) = (countofplus[maxIndex], countofplus[i]);

                    for (int m = 0; m < matrix.GetLength(1); m++)
                    {
                        (matrix[i, m], matrix[maxIndex, m]) = (matrix[maxIndex, m], matrix[i, m]);
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; (j < matrix.GetLength(1)); j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            if (array == null || array.Length == 0)
            {
                return null;
            }

            double s = 0;
            int cnt = 0;
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        s += array[i][j];
                        cnt++;
                    }
                }
            }

            double avg = s /cnt;


            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null && array[i].Length > 0)
                {
                    double rowSum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        rowSum += array[i][j];
                    }
                    double rowAverage = rowSum / array[i].Length;
                    if (rowAverage >= avg)
                    {
                        count++;
                    }
                }
            } 

            answer = new int[count][];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null && array[i].Length > 0)
                {
                    double sofrow = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sofrow += array[i][j];
                    }
                    double rowAverage = sofrow / array[i].Length;

                    if (rowAverage >=avg)
                    {
                        answer[index] = new int[array[i].Length];
                        for (int j = 0; j < array[i].Length; j++)
                        {
                            answer[index][j] = array[i][j];
                        }
                        index++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}