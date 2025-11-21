using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix == null) return null;
            int row = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            answer = new int[row];
            for (int i = 0; i < row; i++)
            {
                int min = matrix[i, 0];
                int ind = 0;
                for (int j = 1; j < rows; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        ind = j;
                    }
                }
                answer[i] = ind;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int row = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                int ind = 0;
                int max = matrix[i, 0];
                for (int j = 1; j < rows; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        ind = j;
                    }
                }
                for (int j = 0; j < ind; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)System.Math.Floor((double)matrix[i, j] /max);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1) || k < 0 || k >= n) return;
            int maxi = 0;
            int max = matrix[0, 0];
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxi = i;
                }
            }
            if (maxi != k)
            {
                for (int i = 0; i < n; i++)
                {
                    int ans = matrix[i, k];
                    matrix[i, k] = matrix[i, maxi];
                    matrix[i, maxi] = ans;
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return;
            int ind = 0;
            int max = matrix[0, 0];
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    ind = i;
                }
            }
            for (int i = 0; i < n; i++)
            {
                int ans = matrix[ind, i];
                matrix[ind, i] = matrix[i, ind];
                matrix[i, ind] = ans;
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null) return null;
            int row = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            if (row == 0) return new int[0, rows];
            int max = 0;
            int maxi = 0;
            for (int i = 0; i < row; i++)
            {
                int sum = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
                if (sum > maxi)
                {
                    maxi = sum;
                    max = i;
                }
            }
            answer = new int[row - 1, rows];
            int newRow = 0;
            for (int i = 0; i < row; i++)
            {
                if (i != max)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        answer[newRow, j] = matrix[i, j];
                    }
                    newRow++;
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int row = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            int[] negative = new int[row];
            for (int i = 0; i < row; i++)
            {
                int count = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                negative[i] = count;
            }
            int mini = 0, maxi = 0;
            int min = negative[0], max = negative[0];
            for (int i = 1; i < row; i++)
            {
                if (negative[i] < min)
                {
                    min = negative[i];
                    mini = i;
                }
                if (negative[i] > max)
                {
                    max = negative[i];
                    maxi = i;
                }
            }
            if (min != max)
            {
                for (int j = 0; j < rows; j++)
                {
                    int temp = matrix[mini, j];
                    matrix[mini, j] = matrix[maxi, j];
                    matrix[maxi, j] = temp;
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int row = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            if (array.Length != row)
            {
                return matrix;
            }
            int min = matrix[0, 0];
            int mini = 0;
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < row; i++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        mini = j;
                    }
                }
            }
            answer = new int[row, rows + 1];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <= mini; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < row; i++)
            {
                answer[i, mini+1] = array[i];
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = mini+1; j < rows; j++)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int row = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            for (int j = 0; j < rows; j++)
            {
                int positive = 0;
                int negative = 0;
                int max = matrix[0, j];
                int maxi = 0;
                for (int i = 0; i < row; i++)
                {
                    if (matrix[i, j] > 0) positive++;
                    else if (matrix[i, j] < 0) negative++;

                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxi = i;
                    }
                }
                if (positive > negative)
                {
                    matrix[maxi, j] = 0;
                }
                else if (negative > positive)
                {
                    matrix[maxi, j] = maxi;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return;
            for (int i = 0; i < n * n; i++)
            {
                int row = i / n;
                int rows = i % n;

                if (row == 0 || row == n - 1 || rows == 0 || rows == n - 1)
                {
                    matrix[row, rows] = 0;
                }
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix == null) return (null, null);
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return (null, null);
            int sA = n * (n + 1) / 2;
            int sB = n * (n - 1) / 2;
            A = new int[sA];
            B = new int[sB];
            int indA = 0, indB = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= i)
                    {
                        A[indA++] = matrix[i, j];
                    }
                    else
                    {
                        B[indB++] = matrix[i, j];
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int row = matrix.GetLength(0);
            int rows = matrix.GetLength(1);
            for (int j = 0; j < rows; j++)
            {
                int[] size = new int[row];
                for (int i = 0; i < row; i++)
                {
                    size[i] = matrix[i, j];
                }
                if (j % 2 == 0)
                {
                    for (int i = 0; i < row - 1; i++)
                    {
                        for (int k = i + 1; k < row; k++)
                        {
                            if (size[i] < size[k])
                            {
                                int ans = size[i];
                                size[i] = size[k];
                                size[k] = ans;
                            }
                        }
                    }
                }
                else
                {
                    for (int i =0; i < row-1; i++)
                    {
                        for (int k = i + 1; k < row; k++)
                        {
                            if (size[i] > size[k])
                            {
                                int ans = size[i];
                                size[i] = size[k];
                                size[k] = ans;
                            }
                        }
                    }
                }
                for (int i=0; i < row; i++)
                {
                    matrix[i, j] = size[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null) return;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int countI = 0;
                    int countJ = 0;
                    int sumI = 0;
                    int sumJ = 0;
                    if (array[i] != null)
                    {
                        countI = array[i].Length;
                        for (int k = 0; k < array[i].Length; k++)
                        {
                            sumI += array[i][k];
                        }
                    }
                    if (array[j] != null)
                    {
                        countJ = array[j].Length;
                        for (int k = 0; k < array[j].Length; k++)
                        {
                            sumJ += array[j][k];
                        }
                    }
                    bool answer = false;
                    if (countI < countJ)
                    {
                        answer = true;
                    }
                    else if (countI == countJ && sumI < sumJ)
                    {
                        answer = true;
                    }
                    if (answer)
                    {
                        int[] ans = array[i];
                        array[i] = array[j];
                        array[j] = ans;
                    }
                }
            }
            // end

        }
    }
}
