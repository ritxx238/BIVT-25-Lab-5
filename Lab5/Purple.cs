using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int count = matrix.GetLength(1);
            int[] result = new int[count];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int count1 = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        count1++;
                    }
                }
                result[i] = count1;
            }
            answer = result;
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0], position = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        position = j;
                    }
                }
                if (position != 0)
                {
                    int k = 1;
                    while (position > 0)
                    {
                        if (matrix[i, k] == min)
                        {
                            (matrix[i, k], matrix[i, k - 1]) = (matrix[i, k - 1], matrix[i, k]);
                            position--;
                            k = 0;
                        }
                        k++;
                    }
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                int f = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (f == 0)
                        result[i, j] = matrix[i, j];
                    if (matrix[i, j] == max && f == 0)
                    {
                        result[i, j + 1] = max;
                        f = 1;
                    }
                    else if (f == 1)
                    {
                        result[i, j + 1] = matrix[i, j];
                    }
                }
            }
            answer = result;
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0], maxPosition = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == max)
                    {
                        maxPosition = j;
                        break;
                    }
                }
                int s = 0, sr = 0, n = 0;
                for (int j = maxPosition+1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        s += matrix[i, j];
                        n++;
                    }
                }
                if (n != 0)
                {  
                    sr = s / n;
                    for (int j = 0; j < maxPosition; j++)
                    {
                        if (matrix[i, j] < 0)
                            matrix[i, j] = sr;
                    }
                }
                // end
            }
        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int[] Max = new int[matrix.GetLength(0)];
            int t = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                Max[t] = max;
                Max[t] = max;
                t++;
            }
            int n = 0;
            if (k < matrix.GetLength(1))
            {
                for (int l = matrix.GetLength(0) - 1; l >= 0; l--)
                {
                    matrix[l, k] = Max[n];
                    n++;
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int t = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = matrix[0, j];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i,j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                if (array.Length == matrix.GetLength(1))
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (t < array.Length)
                        {
                            if (matrix[i, j] == max && array[t] > max)
                            {
                                matrix[i, j] = array[t];
                            }
                        }
                    }
                    t++;
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int[] Min = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                Min[i] = min;
            }
            int n = matrix.GetLength(0), k = 1;
            while (n > k)
            {
                if (k == 0 || Min[k] <= Min[k - 1])
                {
                    k++;
                }
                else
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[k, j], matrix[k - 1, j]) = (matrix[k - 1, j], matrix[k, j]);
                    }
                    (Min[k], Min[k - 1]) = (Min[k - 1], Min[k]);
                    k--;
                }
            }
        }
            // end

        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int[] a = new int[n * 2 - 1];
            int t = n - 1;
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                for (int k = 0; k < (n * 2 - 1); k++)
                {
                    int s = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (j - i == -t)
                            {
                                s += matrix[i, j];
                            }
                        }
                    }
                    a[k] = s;
                    t--;
                }
                answer = a;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int iMax = 0, jMax = 0, max = matrix[0, 0];
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(max))
                        {
                            max = matrix[i, j];
                            iMax = i;
                            jMax = j;
                        }
                    }
                }
                if (k < jMax && k <= matrix.GetLength(1) - 1)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = jMax; j > k; j--)
                        {
                            (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                        }
                    }
                }
                else if (k > jMax && k <= matrix.GetLength(1) - 1)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = jMax; j < k; j++)
                        {
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                        }
                    }
                }
                if (k < iMax && k <= matrix.GetLength(0) - 1)
                {
                    for (int i = iMax; i > k; i--)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            (matrix[i - 1, j], matrix[i, j]) = (matrix[i, j], matrix[i - 1, j]);
                        }
                    }
                }
                else if (k > iMax && k <= matrix.GetLength(0) - 1)
                {
                    for (int i = iMax; i < k; i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            (matrix[i + 1, j], matrix[i, j]) = (matrix[i, j], matrix[i + 1, j]);
                        }
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int[,] a = new int[A.GetLength(0), B.GetLength(1)];
            int[] result = new int[A.GetLength(0) * B.GetLength(1)];
            if (A.GetLength(1) == B.GetLength(0))
            {
                int m = 0;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int l = 0; l < B.GetLength(1); l++)
                    {
                        int s = 0;
                        for (int j = 0; j < A.GetLength(1); j++)
                        {
                            s += A[i, j] * B[j, l];
                        }
                        result[m] = s;
                        m++;
                    }
                }
                int k = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        a[i, j] = result[k];
                        k++;
                    }
                }
                answer = a;
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int[][] jagged = new int[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int t = 0, k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        jagged[i] = new int[t + 1];
                        t++;
                        k = 1;
                    }
                }
                if (k == 0)
                {
                    jagged[i] = new int[0];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int t = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        jagged[i][t] = matrix[i, j];
                        t++;
                    }
                }
            }
            answer = jagged;
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
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }
            }
            int[] a = new int[count];
            int t = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    a[t] = array[i][j];
                    t++;
                }
            }
            int max = (int)Math.Ceiling(Math.Sqrt(a.Length));
            int[,] matrix = new int[max, max];
            int k = 0;
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    if (k >= a.Length)
                    {
                        break;
                    }
                    matrix[i, j] = a[k];
                    k++;
                }
            }
            answer = matrix;
            // end

            return answer;
        }
    }
}
