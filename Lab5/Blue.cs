using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                answer[i] = matrix[i, 0];  
            }
            return answer;
        }

        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maxVal = int.MinValue;
            int maxRow = -1, maxCol = -1;

            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            int answerRows = rows - 1;
            int answerCols = cols - 1;
            

            int rIdx = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == maxRow) continue;
                int cIdx = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == maxCol) continue;
                    answer[rIdx, cIdx] = matrix[i, j];
                    cIdx++;
                }
                rIdx++;
            }
            return answer;
        }

        public void Task3(int[,] matrix)
        {
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
             
                    System.Console.Write($"{matrix[i, j]} ");
                }
                System.Console.WriteLine();
            }
        }

        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
          

            for (int i = 0; i < rows; i++)
            {
                int maxVal = int.MinValue;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                        maxVal = matrix[i, j];
                }

                for (int j = 0; j < cols; j++)
                {
                    answer[i, j] = matrix[i, j];
                }

                answer[i, cols] = maxVal;
            }
            return answer;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int size = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if ((i + j) % 2 == 1)
                        size++;

           
            int index = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if ((i + j) % 2 == 1)
                        answer[index++] = matrix[i, j];

            return answer;
        }

        public void Task6(int[,] matrix, int k)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > k)
                        matrix[i, j] = 0; 
                }
            }
        }

        public void Task7(int[,] matrix, int[] array)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int minLength = System.Math.Min(array.Length, rows * cols);
            int idx = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (idx < minLength)
                    {
                        matrix[i, j] = array[idx];
                        idx++;
                    }
                }
            }
        }

        public void Task8(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[rows - 1 - i, j];
                    matrix[rows - 1 - i, j] = temp;
                }
            }
        }

        public void Task9(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols / 2; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, cols - 1 - j];
                    matrix[i, cols - 1 - j] = temp;
                }
            }
        }

        public void Task10(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int sumDiagonal = 0;

            for (int i = 0; i < System.Math.Min(rows, cols); i++)
            {
                sumDiagonal += matrix[i, i];
            }

            System.Console.WriteLine($"Sum of main diagonal: {sumDiagonal}");
        }

        public void Task11(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == j)
                        matrix[i, j] = 1; 
                }
            }
        }

        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;
           
            for (int i = 0; i < array.Length; i++)
            {
                answer[i] = new int[array[i].Length];
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[i][j] = array[i][j];
                }
            }
            return answer;
        }
    }
}
