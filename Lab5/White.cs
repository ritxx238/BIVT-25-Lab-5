using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        average += matrix[i, j];
                        count++;
                    }
                }
            }
            
            average /= count;

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;
            
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            if (k < 0 || k >= cols)
                return;
            
            int max = int.MinValue;
            int maxRow = -1;
            
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, k] > max)
                {
                    max = matrix[i, k];
                    maxRow = i;
                }
            }
            
            for (int j = 0; j < cols; j++)
            {
                (matrix[0, j], matrix[maxRow, j]) = (matrix[maxRow, j], matrix[0, j]);
            }
        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            if (rows == 0 || cols == 0)
            {
                answer = new int[0, cols];
                return answer;
            }
            
            if (rows == 1)
            {
                answer = new int[0, cols];
                return answer;
            }
            
            int minValue = int.MaxValue;
            int minRow = 0;

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, 0] < minValue)
                {
                    minValue = matrix[i, 0];
                    minRow = i;
                }
            }
            
            answer = new int[rows - 1, cols];

            int newRow = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i == minRow)
                {
                    continue;
                }

                for (int j = 0; j < cols; j++)
                {
                    answer[newRow, j] = matrix[i, j];
                }

                newRow++;
            }

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
            {
                return 0;
            }
            
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int firstNegIndex = -1;
                int lastNegIndex = -1;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (firstNegIndex == -1)
                        {
                            firstNegIndex = j;
                        }
                        
                        lastNegIndex = j;
                    }
                }

                if (firstNegIndex == -1)
                {
                    continue;
                }
                
                int maxEl = matrix[i, 0];
                int maxIndex = 0;

                for (int j = 1; j < firstNegIndex; j++)
                {
                    if (matrix[i, j] > maxEl)
                    {
                        maxEl = matrix[i, j];
                        maxIndex = j;
                    }
                }

                if (firstNegIndex == 0)
                {
                    continue;
                }
                
                (matrix[i, maxIndex], matrix[i, lastNegIndex]) = (matrix[i, lastNegIndex], matrix[i, maxIndex]);
            }
        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;
            int count = 0;
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                return negatives;
            }
            
            negatives = new int[count];
            int index = 0;
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[index] = matrix[i, j];
                        index++;
                    }
                }
            }
            
            return negatives;
        }
        public void Task8(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                if (cols == 1)
                {
                    continue;
                }
                
                int maxIndex = 0;
                int maxValue = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
                
                if (maxIndex == 0)
                {
                    matrix[i, 1] *= 2;
                }
                else if (maxIndex == cols - 1)
                {
                    matrix[i, cols - 2] *= 2;
                }
                else
                {
                    int left = matrix[i, maxIndex - 1];
                    int right = matrix[i, maxIndex + 1];

                    if (left <= right)
                    {
                        matrix[i, maxIndex - 1] *= 2;
                    }
                    else
                    {
                        matrix[i, maxIndex + 1] *= 2;
                    }
                }
            }
        }
        public void Task9(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            for (int i = 0; i < rows; i++)
            {
                int[] array = new int[cols];
                int count = 0;
                
                for (int j = cols - 1; j >= 0; j--)
                {
                    array[count] = matrix[i, j];
                    count++;
                }

                for (int j = 0; j < cols; j++)
                { 
                    matrix[i, j] = array[j];
                }
            }
        }
        public void Task10(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
            {
                return;
            }
            
            for (int i = rows / 2; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }
        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int goodRows = 0;

            for (int i = 0; i < rows; i++)
            {
                bool zero = false;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                        break;
                    }
                }

                if (zero == false)
                {
                    goodRows++;
                }
            }
            
            if (goodRows == 0)
            {
                answer = new int[0, cols];
                return answer;
            }

            if (goodRows == rows)
            {
                answer = new int[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                }
                
                return answer;
            }
            
            answer = new int[goodRows, cols];
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }

                if (hasZero == false)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        answer[count, j] = matrix[i, j];
                    }

                    count++;
                }
            }
            
            return answer;
        }
        public void Task12(int[][] array)
        {
            int rows = array.Length;
            if (rows == 0)
            {
                return;
            }
            
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    int sum1 = 0;
                    int sum2 = 0;

                    for (int k = 0; k < array[j].Length; k++)
                    {
                        sum1 += array[j][k];
                    }

                    for (int k = 0; k < array[j + 1].Length; k++)
                    {
                        sum2 += array[j + 1][k];
                    }
                    
                    if (sum1 > sum2)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }
    }
}
