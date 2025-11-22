using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int k = 0; answer= new int[m]; int l = 0;
            for (int j = 0; j < m; j++)
            { 
                k = 0;
                for (int i = 0; i < n; i++)
                    if (matrix[i, j] < 0)
                    { k++; }
                answer[l++] = k;
            }
                    // end

                    return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int row = 0; int min = 0;
            for (int i = 0; i < n; i++)
            {
                row = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] < matrix[i, row])
                        row = j;
                min = matrix[i,row];
                for (int j = row; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
                matrix[i, 0] = min;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int row = 0; int max = 0;
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                row = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > matrix[i, row])
                        row = j;
                max = matrix[i, row];
                for (int j = 0; j <=row; j++)
                { answer[i, j] = matrix[i, j]; }
                answer[i, row+1] = max;
                for (int j = row+1; j <m; j++)
                { answer[i, j+1] = matrix[i, j]; }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int row = 0; 
            for (int i = 0; i < n; i++)
            {
                row = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > matrix[i, row])
                        row = j;
                int s = 0; int k = 0; int sr = 0;
                for (int j = row + 1; j < m; j++)
                    if (matrix[i, j] > 0)
                    { s += matrix[i, j]; k++; }
                if (k != 0)
                {
                    sr = s / k;
                    for (int j = 0; j < row; j++)
                        if (matrix[i, j] < 0)
                            matrix[i, j] = sr;
                }
            }
                // end

            }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int row = 0; int[] ms = new int[n]; int l = 0;
            if (k < m)
            {
                for (int i = 0; i < n; i++)
                {
                    row = 0;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > matrix[i, row])
                            row = j;
                    }
                    ms[i] = matrix[i, row];
                }
                for (int i = 0; i < n / 2; i++)
                    (ms[i], ms[n - i - 1]) = (ms[n - i - 1], ms[i]);
                for (int i = 0; i < n; i++)
                    matrix[i, k] = ms[i];
            }
                // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int row = 0;
            for (int j = 0; j < m; j++)
            {
                row = 0;
                for (int i = 0; i < n; i++)
                    if (matrix[i, j] > matrix[row, j])
                    row = i;
                if (m==array.Length && array[j]> matrix[row, j])
                    matrix[row, j] = array[j];
            }
                // end

            }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int row = 0; int[]  min= new int[n];
            for (int i = 0; i < n; i++)
            {
                row = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < matrix[i, row])
                        row = j;
                }
                min[i] = matrix[i, row];
            }
            for (int i = 0; i < n-1; i++)
            {
                for (int k = 0; k < n - i-1; k++)
                    if (min[k] < min[k + 1])
                    {
                        (min[k], min[k + 1]) = (min[k + 1], min[k]);
                        for (int j = 0; j < m; j++)
                            (matrix[k, j], matrix[k +1, j]) = (matrix[k +1, j], matrix[k, j]);
                    }
            }
                    // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0); int m = matrix.GetLength(1);
            if (n != m) return answer;
            answer = new int[2 * n - 1]; int k = 0;
            for (int i = n-1; i>=0; i--)
            {
                int sum = 0;
                for (int j = 0; j < n - i; j++)
                { sum += matrix[i + j, j]; }
                answer[k++] = sum;
            }
            for (int j =1; j<n; j++)
            {
                int sum = 0;
                for (int i = 0; i < n - j; i++)
                { sum += matrix[i, j + i]; }
                answer[k++] = sum;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int row = 0; int col = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[row, col]))
                    { row = i; col = j; }
                }
            }
            if (k > row)
                for (int i = row; i < k; i++)
                {
                    for (int j = 0; j < m; j++)
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                }
            else 
            {
                for (int i = row; i >k; i--)
                {
                    for (int j = 0; j < m; j++)
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                }
            }
            if (k > col)
                for (int i = 0; i < n; i++)
                {
                    for (int j = col; j < k; j++)
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                }
            else
            {
                for (int i = 0; i <n; i++)
                {
                    for (int j = col; j > k; j--)
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int na = A.GetLength(0); int nb = B.GetLength(0);
            int ma = A.GetLength(1); int mb = B.GetLength(1);
            if (ma != nb) return answer;
            answer = new int[na, mb];
            for (int i = 0; i < na; i++)
            {
                for (int j = 0; j < mb; j++)
                {
                    for (int k = 0; k < nb; k++)
                        answer[i, j] += A[i, k] * B[k, j];
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int n= matrix.GetLength(0); int m = matrix.GetLength(1);
            answer = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > 0)
                        sum++;
                answer[i] = new int[sum];
                int l = 0;
                for (int k = 0; k < m; k++)
                    if (matrix[i, k] > 0)
                        answer[i][l++] = matrix[i, k];
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i].Length;
            int[] mas = new int[sum];
            int k = 0;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    mas[k++] = array[i][j];
            int n = (int)Math.Pow(sum, 0.5);
            if (n * n == sum)
                answer = new int[n, n];
            else
                answer = new int[n+1, n+1];
            int ind = 0; int m=answer.GetLength(0);
            for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (ind < sum)
                        { answer[i, j] = mas[ind++]; }
                        else
                        { answer[i, j] = 0; }
                    }
                }
                        // end

                        return answer;
        }
    }
}
