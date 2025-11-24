using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            answer = new int[columns];
            int id = 0;
            int count;

            for (int i = 0; i < columns; i++)
            {
                count = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[j, i] < 0)
                        count++;
                }
                answer[id++] = count;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int mn = int.MaxValue;
                int idColumn = -1;

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                        idColumn = j;
                    }
                }
                while (idColumn > 0)
                {
                    (matrix[i, idColumn], matrix[i, idColumn - 1]) = (matrix[i, idColumn - 1], matrix[i, idColumn]);
                    idColumn--;
                }
            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            answer = new int[rows, columns + 1];

            for (int i = 0; i < rows; i++)
            {
                int mx = int.MinValue;
                int idColumn = -1;

                for (int j = 0; j < columns; j++)
                {
                    answer[i, j] = matrix[i, j];

                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        idColumn = j;
                    }
                }

                int curId = idColumn + 1;
                while (curId < columns)
                {
                    answer[i, curId + 1] = matrix[i, curId++];
                }
                answer[i, idColumn + 1] = mx;
            }

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int mx = matrix[i, 0];
                int idColumn = 0;

                int sm = 0;
                int count = 0;
                int average = 0;

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        idColumn = j;
                    }
                }

                for (int k = idColumn + 1; k < columns; k++)
                {
                    if (matrix[i, k] > 0)
                    {
                        sm += matrix[i, k];
                        count++;
                    }
                }
                if (count != 0)
                {
                    average = sm / count;
                    for (int q = 0; q < idColumn; q++)
                    {
                        if (matrix[i, q] < 0)
                        {
                            matrix[i, q] = average;
                        }
                    }
                }


            }
            // end

        }

        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int[] mxs = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int mx = int.MinValue;

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                    }
                }
                mxs[i] = mx;
            }

            if (k >= 0 && k < columns)
            {
                for (int q = 0; q < rows; q++)
                {
                    matrix[q, k] = mxs[mxs.Length - q - 1];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int count = 0;

            if (array.Length == columns)
            {

                for (int j = 0; j < columns; j++)
                {
                    int mx = int.MinValue;
                    int id = -1;

                    for (int i = 0; i < rows; i++)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                            id = i;
                        }
                    }

                    if (j < array.Length && array[j] > mx)
                    {
                        matrix[id, j] = array[j];
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int[] min = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                min[i] = int.MaxValue;
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < min[i])
                        min[i] = matrix[i, j];
                }
            }

            // Пузырёк на матрице
            for (int k = 0; k < rows - 1; k++)
            {
                for (int i = 0; i < rows - 1 - k; i++)
                {
                    if (min[i] < min[i + 1])
                    {
                        // свапнем строки тремя стаканами
                        for (int j = 0; j < columns; j++)
                        {
                            int tmp = matrix[i, j];
                            matrix[i, j] = matrix[i + 1, j];
                            matrix[i + 1, j] = tmp;
                        }
                        // и при этом свапнем сами min
                        int t = min[i];
                        min[i] = min[i + 1];
                        min[i + 1] = t;
                    }
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            if (rowCount == colCount)
            {
                int size = rowCount;

                int[] result = new int[2 * size - 1];

                int k = 0;
                int additional = 0;

                for (int i = rowCount - 1; i >= 0; i--)
                {
                    int downSum = matrix[i, 0];
                    int idx = i + 1;

                    for (int j = 0; j < additional; j++)
                    {
                        downSum += matrix[idx, j + 1];
                        idx++;
                    }

                    additional++;
                    result[k++] = downSum;
                }

                int upNumbers = rowCount - 2;

                for (int j = 1; j < colCount; j++)
                {
                    int upSum = matrix[0, j];
                    int c = j + 1;

                    for (int i = 0; i < upNumbers; i++)
                    {
                        upSum += matrix[i + 1, c];
                        c++;
                    }

                    upNumbers--;
                    result[k++] = upSum;
                }
                answer = result;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int row = matrix.GetLength(0);
            int column = matrix.GetLength(1);

            if (row != column)
                return;

            int rowId = 0;
            int columnId = 0;
            int mx = 0; // minvalue не нужен

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(mx))
                    {
                        mx = matrix[i, j];
                        rowId = i;
                        columnId = j;
                    }
                }
            }

            int sdvgRow = k - rowId;
            int sdvgColumn = k - columnId;


            if (sdvgRow < 0)
            {
                for (int i = rowId; i > k; i--)
                {
                    for (int j = 0; j < column; j++)
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                }
            }

            else
            {
                for (int i = rowId; i < k; i++)
                {
                    for (int j = 0; j < column; j++)
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                }
            }

            if (sdvgColumn < 0)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = columnId; j > k; j--)
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                }
            }

            else
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = columnId; j < k; j++)
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                }
            }

            // end

        }



        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1) != B.GetLength(0))
                return answer;

            int row = A.GetLength(0);
            int column = B.GetLength(1);

            answer = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < row; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    answer[i, j] = sum;
                }
            }

            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            answer = new int[matrix.GetLength(0)][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int countPositives = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        countPositives++;
                }
                answer[i] = new int[countPositives];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        answer[i][answer[i].Length - countPositives--] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int total = 0;
            for (int i = 0; i < array.Length; i++)
            {
                total += array[i].Length;
            }

            int n;

            int[] nouns = new int[total];
            int id = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                    nouns[id++] = array[i][j];
            }

            int sqrt = (int)Math.Pow(total, 0.5);

            if (sqrt * sqrt == total)
                n = sqrt;
            else
                n = sqrt + 1;

            answer = new int[n, n];
            int indexer = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (indexer < total)
                    {
                        answer[i, j] = nouns[indexer++];
                    }
                    else
                    {
                        answer[i, j] = 0;
                    }
                }
            }

            // end

            return answer;
        }
    }
}
