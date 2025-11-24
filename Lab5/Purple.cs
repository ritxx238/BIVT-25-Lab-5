using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(1)];

            // code here
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int count = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0) count++;
                }
                answer[j] = count;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minIndex = 0;
                int minValue = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minIndex = j;
                        minValue = matrix[i, j];
                    }
                }
                if (minIndex == 0) continue;
                int temp = matrix[i, minIndex];
                
                for (int j = minIndex; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j-1];
                }
                matrix[i, 0] = temp;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] answer = new int[rows, cols+1];

            // code here
            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxIndex = j;
                        maxValue = matrix[i, j];
                    }
                }

                for (int j = 0, newCol = 0; j < cols; j++, newCol++)
                {
                    answer[i, newCol] = matrix[i, j];
                    if (j == maxIndex)
                    {
                        newCol++;
                        answer[i, newCol] = maxValue;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i ,0];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxIndex = j;
                        maxValue = matrix[i, j];
                    }
                }

                int countPos = 0, sum = 0;
                for (int j = maxIndex+1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        countPos++;
                    }
                }

                if (sum != 0)
                {
                    int avg = sum / countPos;

                    for (int j = 0; j < maxIndex; j++)
                    {
                        if (matrix[i, j] < 0) matrix[i, j] = avg;
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

            int[] arr = new int[rows];

            if (k < cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    int maxValue = matrix[i, 0];
                    for (int j = 1; j < cols; j++)
                    {
                        if (matrix[i, j] > maxValue) maxValue = matrix[i, j];
                    }

                    arr[i] = maxValue;
                }

                int indexK = rows-1;
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, k] = arr[indexK];
                    indexK--;
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int maxValue = int.MinValue, indexI = -1, indexJ = -1;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        indexI = i;
                        indexJ = j;
                    }
                }

                if (array.Length == cols && array[indexJ] > maxValue) matrix[indexI, j] = array[indexJ];
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            
            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    int minCurr = matrix[j, 0];
                    for (int k = 1; k < cols; k++)
                    {
                        if (matrix[j, k] < minCurr)
                        {
                            minCurr = matrix[j, k];
                        }
                    }

                    int minNext = matrix[j+1, 0];
                    for (int k = 1; k < cols; k++)
                    {
                        if (matrix[j+1, k] < minNext)
                        {
                            minNext = matrix[j+1, k];
                        }
                    }
                    if (minCurr < minNext)
                    {
                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j+1, k];
                            matrix[j+1, k] = temp;
                        }
                    }
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int n = matrix.GetLength(0);
                answer = new int[2*n-1];
                int answerIndex = 0;

                for (int row = n - 1; row >= 0; row--)
                {
                    int sum = 0, i = row, j = 0;
                    while (i < n && j < n)
                    {
                        sum += matrix[i, j];
                        i++;
                        j++;
                    }
                    answer[answerIndex++] = sum;
                }

                for (int col = 1; col < n; col++)
                {
                    int sum = 0, i = 0, j = col;
                    while (i < n && j < n)
                    {
                        sum += matrix[i, j];
                        i++;
                        j++;
                    }
                    answer[answerIndex++] = sum;
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int n = matrix.GetLength(0), maxValue = Math.Abs(matrix[0, 0]), maxRow = 0, maxCol = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > maxValue)
                        {
                            maxValue = Math.Abs(matrix[i, j]);
                            maxRow = i;
                            maxCol = j;
                        }
                    }
                }
                int[] rowChange = new int[n];
                rowChange[k] = maxRow;
                
                int currPos = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i == maxRow) continue;
                    if (currPos == k) currPos++;
                    rowChange[currPos++] = i;
                }

                int[] colChange = new int[n];
                colChange[k] = maxCol;

                currPos = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i == maxCol) continue;
                    if (currPos == k) currPos++;
                    colChange[currPos++] = i; 
                }

                int[,] tempMatrix = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        tempMatrix[i, j] = matrix[rowChange[i], colChange[j]];
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = tempMatrix[i, j];
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int rowsA = A.GetLength(0), colsA = A.GetLength(1), rowsB = B.GetLength(0), colsB = B.GetLength(1);
            if (colsA == rowsB)
            {
                answer = new int[rowsA, colsB];

                for (int i = 0;  i < rowsA; i++)
                {
                    for (int j = 0; j < colsB; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < colsA; k++)
                        {
                            sum += A[i, k] * B[k, j];
                        }
                        answer[i, j] = sum;
                    }
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            answer = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int countPos = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0) countPos++;
                }

                answer[i] = new int[countPos];
                int currIndex = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0) answer[i][currIndex++] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count += array[i].Length;
            }

            int n = (int)Math.Ceiling(Math.Sqrt(count));
            answer = new int[n, n];
            count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    int row = count / n, col = count % n;
                    answer[row, col] = array[i][j];
                    count++;
                }
            }
            // end

            return answer;
        }
    }
}