using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] answer = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int minValue = matrix[i, 0];
                int minIndex = 0;            

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minIndex = j;
                    }
                }

                answer[i] = minIndex;
            }

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                
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

                
                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / maxValue);
                    }
                }
            }

        }
        public void Task3(int[,] matrix, int k)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols) { return; }
            
            if (k < 0 || k >= cols)
            {
                return; 
            }
            int minSize = Math.Min(rows, cols);

            if (minSize == 0) return; 

            int maxDiagonalValue = matrix[0, 0];
            int maxDiagonalColumn = 0;

            for (int i = 1; i < minSize; i++)
            {
                if (matrix[i, i] > maxDiagonalValue)
                {
                    maxDiagonalValue = matrix[i, i];
                    maxDiagonalColumn = i;
                }
            }

            
            if (maxDiagonalColumn != k)
            {
                for (int i = 0; i < rows; i++)
                {
                    
                    int temp = matrix[i, k];
                    matrix[i, k] = matrix[i, maxDiagonalColumn];
                    matrix[i, maxDiagonalColumn] = temp;
                }
            }

        }
        public void Task4(int[,] matrix)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if(cols!=rows) { return; }

            
            int minSize = Math.Min(rows, cols);
            if (minSize == 0) return;

            int maxDiagonalValue = matrix[0, 0];
            int maxIndex = 0;

            for (int i = 1; i < minSize; i++)
            {
                if (matrix[i, i] > maxDiagonalValue)
                {
                    maxDiagonalValue = matrix[i, i];
                    maxIndex = i;
                }
            }

            
            for (int i = 0; i < Math.Max(rows, cols); i++)
            {
                
                if (i < rows && i < cols)
                {
                    
                    if (i != maxIndex)
                    {
                        int temp = matrix[maxIndex, i];
                        matrix[maxIndex, i] = matrix[i, maxIndex];
                        matrix[i, maxIndex] = temp;
                    }
                }
            }

        }
        public int[,] Task5(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] answer = new int[rows-1, cols];
            int maxsum = 0;
            int maxrow = 0;
            for(int i = 0; i < rows; i++)
            {
                int sum = 0;
                for(int j = 0; j < cols; j++)
                {
                    if (matrix[i,j] >= 0) sum+= matrix[i,j];
                }
                if (sum > maxsum) { maxsum = sum; maxrow = i; }
            }
            int newrow = 0;
            for(int i = 0; i < rows; i++)
            {
                if (i == maxrow) continue;
                for (int j = 0; j < cols; j++)
                {
                    answer[newrow, j] = matrix[i,j];
                }
                newrow++;
            }


            return answer;
        }
        public void Task6(int[,] matrix)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows <= 1) return;

            int minNegativeCount = cols + 1;
            int maxNegativeCount = -1;
            int minRowIndex = -1;
            int maxRowIndex = -1;

            for (int i = 0; i < rows; i++)
            {
                int negativeCount = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negativeCount++;
                    }
                }

                if (negativeCount < minNegativeCount)
                {
                    minNegativeCount = negativeCount;
                    minRowIndex = i;
                }

                if (negativeCount > maxNegativeCount)
                {
                    maxNegativeCount = negativeCount;
                    maxRowIndex = i;
                }
            }

            if (minNegativeCount == maxNegativeCount) return;

            for (int j = 0; j < cols; j++)
            {
                int temp = matrix[minRowIndex, j];
                matrix[minRowIndex, j] = matrix[maxRowIndex, j];
                matrix[maxRowIndex, j] = temp;
            }

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (array == null || array.Length != rows)
            {
                return matrix;
            }

            int minValue = matrix[0, 0];
            int minCol = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minCol = j;
                    }
                }
            }

            int[,] answer = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols + 1; j++)
                {
                    if (j <= minCol)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == minCol + 1)
                    {
                        answer[i, j] = array[i];
                    }
                    else
                    {
                        answer[i, j] = matrix[i, j - 1];
                    }
                }
            }

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int positiveCount = 0;
                int negativeCount = 0;
                int maxValue = matrix[0, j];
                int maxindex = 0;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0)
                        positiveCount++;
                    else if (matrix[i, j] < 0)
                        negativeCount++;

                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxindex = i;
                    }
                }

                if (positiveCount > negativeCount)
                {
                    matrix[maxindex, j] = 0;
                }
                else if (negativeCount > positiveCount)
                {
                    matrix[maxindex, j] = maxindex;
                }

            }

        }
        public void Task9(int[,] matrix)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols) return;

            int n = rows;

            for (int k = 0; k < 4 * (n - 1); k++)
            {
                int i, j;

                if (k < n)
                {
                    i = 0;
                    j = k;
                }
                else if (k < 2 * n - 1)
                {
                    i = k - n + 1;
                    j = n - 1;
                }
                else if (k < 3 * n - 2)
                {
                    i = n - 1;
                    j = n - 1 - (k - (2 * n - 2));
                }
                else
                {
                    i = n - 1 - (k - (3 * n - 3));
                    j = 0;
                }

                matrix[i, j] = 0;
            }

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols) return (A, B);

            int n = rows;

            int sizeA = n * (n + 1) / 2;
            int sizeB = n * (n - 1) / 2;

            A = new int[sizeA];
            B = new int[sizeB];

            int indexA = 0;
            int indexB = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= i) 
                    {
                        A[indexA] = matrix[i, j];
                        indexA++;
                    }

                    if (j < i)
                    {
                        B[indexB] = matrix[i, j];
                        indexB++;
                    }
                }
            }

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int[] column = new int[rows];
                for (int i = 0; i < rows; i++)
                {
                    column[i] = matrix[i, j];
                }

                if (j % 2 == 0)
                {
                    Array.Sort(column);
                    Array.Reverse(column);
                }
                else
                {
                    Array.Sort(column);
                }

                for (int i = 0; i < rows; i++)
                {
                    matrix[i, j] = column[i];
                }
            }

        }
        public void Task12(int[][] array)
        {

            if (array == null || array.Length <= 1) return;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    bool shouldSwap = false;

                    if (array[j].Length < array[j + 1].Length)
                    {
                        shouldSwap = true;
                    }
                    else if (array[j].Length == array[j + 1].Length)
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

                        if (sum1 < sum2)
                        {
                            shouldSwap = true;
                        }
                    }

                    if (shouldSwap)
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

        }
    }
}
