using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            double sum = 0;
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        k++;
                        average = sum / k;
                    }
                }
            }
            
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (min >  matrix[i, j])
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int max = int.MinValue;
            int row = 0;
            if (k < 0 || k >= m)
                return;
            for (int i = 0; i < n; i++)
            {
                if (max < matrix[i, k])
                {
                     max = matrix[i, k];
                     row = i;
                }
                
            }
            if (row != 0)
            {
                for (int j = 0; j < m; j++)
                {
                    (matrix[row, j], matrix[0, j]) = (matrix[0, j], matrix[row, j]);
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int min = int.MaxValue;
            if (n == 1)
                return new int[0,m];
            int row = 0;
            for (int i = 0; i < n; i++)
            {
                if (min > matrix[i, 0])
                { 
                    min = matrix[i, 0];
                    row = i;
                }
            }
            answer = new int[n-1,m];
            int new_row = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == row)
                    continue;

                for (int j = 0; j < m; j++)
                {
                    answer[new_row, j] = matrix[i, j];
                }
                new_row++;
            }
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if(n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    sum += matrix[i, i];
                }
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int ind = -1;
                int neg = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        neg = j;
                    }
                    else if (neg == -1 && (ind == -1 || matrix[i, j] > matrix[i, ind]))
                    {
                        ind = j;
                    }
                }
                if (ind != -1 && neg != -1 && ind != neg)
                {
                    int temp = matrix[i, ind];
                    matrix[i, ind] = matrix[i, neg];
                    matrix[i, neg] = temp;
                }
            }

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        k++;
                    }
                }
            }
            if (k == 0)
                return null;
            negatives = new int[k];
            int ind = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0;j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[ind] = matrix[i, j];
                        ind++;
                    }
                }
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                if (m == 1) 
                    continue;

                int ind = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, ind])
                        ind = j;
                }
                if (ind == 0)
                    matrix[i, 1] *= 2;
                else if (ind == m - 1)
                    matrix[i, m - 2] *= 2;
                else
                {
                    int left = matrix[i, ind - 1];
                    int right = matrix[i, ind + 1];

                    if (left <= right)
                        matrix[i, ind - 1] *= 2;
                    else
                        matrix[i, ind + 1] *= 2;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m/2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, m - 1 - j];
                    matrix[i, m - 1 - j] = temp;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
                return;
            for (int i = n / 2; i < n; i++)
            {
                for (int j = 0; j <= i; j++) 
                {
                    matrix[i, j] = 1;
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int q = 0;
            for (int i = 0; i < n; i++)
            {
                int z = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        z = 1;
                        break;
                    }
                }
                if (z == 0) 
                    q++;
            }
            answer = new int[q, m];
            int ind = 0;
            for (int i = 0; i < n; i++)
            {
                int z = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        z = 1;
                        break;
                    }
                }
                if (z == 0)
                {
                    for (int j = 0; j < m; j++)
                        answer[ind, j] = matrix[i, j];
                    ind++;
                }
            }
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
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
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            // end

        }
    }
}