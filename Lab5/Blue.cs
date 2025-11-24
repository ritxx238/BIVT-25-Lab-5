using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new double[n];
            double sum = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                double sred = 0;
                if (count > 0)
                {
                    sred = sum / count;
                }
                else
                {
                    sred = 0;
                }

                answer[i] = sred;
                sum = 0; count = 0;
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int mx = int.MinValue;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int str = 0; int stolb = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j] > mx)
                    {
                        mx = matrix[i,j];
                        str = i; stolb = j;
                    }
                }
            }
            int[,] answer0 = new int[n - 1, m];
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i < str)
                    {
                        answer0[i, j] = matrix[i, j];
                    }
                    else
                    {
                        answer0[i, j] = matrix[i + 1, j];
                    }
                }
            }
            answer = new int[n - 1, m - 1];
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    if (j < stolb)
                    {
                        answer[i, j] = answer0[i, j];
                    }
                    else
                    {
                        answer[i, j] = answer0[i, j + 1];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int stolb = 0; int mx = int.MinValue;
            for (int i = 0; i < n; i++)
            {               
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        stolb = j;
                    }
                }
                for (int j = stolb; j < m - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, m - 1] = mx;
                stolb = 0;
                mx = int.MinValue;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mx = int.MinValue;
            answer = new int[n, m + 1];
            int stolb = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                    }
                }

                for (int j = 0; j < m; j++)
                {
                    if (j < m - 1)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    if (j == m - 1)
                    {
                        answer[i, j] = mx;
                    }
                    answer[i, m] = matrix[i, j];
                }
                mx = int.MinValue;
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((j + i) % 2 != 0)
                    {
                        count++;
                    }
                }
            }
            answer = new int[count];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((j + i) % 2 != 0)
                    {
                        answer[k] = matrix[i, j];
                        k++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mx = int.MinValue; int strmax = 0;
            int strotr = 0;
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    strmax = i;
                }
            }
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                if (k >= 0 && k < m)
                {
                    if (matrix[i, k] < 0)
                    {
                        strotr = i;
                        c += 1;
                        break;
                    }
                }
            }
            if ((strotr != strmax) && (c > 0))
            {
                for (int j = 0; j < m; j++)
                {
                    (matrix[strmax, j], matrix[strotr, j]) = (matrix[strotr, j], matrix[strmax, j]);
                }
            }
            else
            {
                return;
            }

            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (m < 2)
            {
                return;
            }
            if (array.Length != m)
            {
                return;
            }
            int mx = int.MinValue; int str = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, m - 2] > mx)
                {
                    mx = matrix[i, m - 2];
                    str = i;
                }
            }
            int k = 0;
            for (int j = 0; j < m; j++)
            {
                matrix[str, j] = array[k];
                k++;
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mx = int.MinValue; int str = 0;
            int sum = 0;
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        str = i;
                    }
                }

                if (str < n / 2)
                {
                    for (int i = str + 1; i < n; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }
                sum = 0;
                mx = int.MinValue;
                str = 0;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mx2 = int.MinValue; int ind22 = -1;
            int mx3 = int.MinValue; int ind33 = -1;
            for (int i = 0; i < n - 1; i += 2)
            {
                ind22 = -1; ind33 = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx2)
                    {
                        mx2 = matrix[i, j];
                        ind22 = j;
                    }
                }
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i + 1, j] > mx3)
                    {
                        mx3 = matrix[i + 1, j];
                        ind33 = j;
                    }
                }
                if (ind22 != -1 && ind33 != -1)
                {
                    int temp = matrix[i, ind22];
                    matrix[i, ind22] = matrix[i + 1,ind33];
                    matrix[i + 1, ind33] = temp;
                }
                ind22 = -1; ind33 = -1;
                mx2 = int.MinValue; mx3 = int.MinValue;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return;
            }
            int mx = int.MinValue; int indmx = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    indmx = i;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i < indmx && j > i)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = 0;
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
                array[i] = count;
                count = 0;
            }
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length - i; j++)
                {
                    if (array[j - 1] < array[j])
                    {
                        (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        for (int k = 0; k < m; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j - 1, k];
                            matrix[j - 1, k] = temp;
                        }
                    }
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double sum = 0; double sr = 0; int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                    count++;
                }
            }
            sr = sum / count;
            double sumstr = 0; int countstr = 0; double srstr = 0;
            int len = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sumstr += array[i][j];
                    countstr++;
                }
                srstr = sumstr / countstr;
                if (srstr >= sr)
                {
                    len++;
                }
                sumstr = 0; countstr = 0; srstr = 0;
            }
            if (len > 0)
            {
                answer = new int[len][];
            }
            int ind = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sumstr += array[i][j];
                    countstr++;
                }
                srstr = sumstr / countstr;
                if (srstr >= sr)
                {
                    answer[ind] = array[i];
                    ind++;
                }
                sumstr = 0; countstr = 0; srstr = 0;
            }

            // end

            return answer;
        }
    }
}
