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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                double spos = 0;
                int cpos = 0;
                for (int j = 0; j < cols; j++)
                {
                    int c = matrix[i, j];
                    if (c > 0)
                    {
                        spos += c;
                        cpos++;
                    }
                }
                if (cpos > 0)
                {
                    answer[i] = spos / cpos;
                }
                else
                {
                    answer[i] = 0;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maximum = matrix[0, 0], maxr = 0, maxc = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maximum)
                    {
                        maximum = matrix[i, j];
                        maxr = i;
                        maxc = j;
                    }
                }
            }
            answer = new int[rows - 1, cols - 1];
            int indexr = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == maxr)
                {
                    continue;
                }
                int indexc = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == maxc)
                    {
                        continue;
                    }

                    answer[indexr, indexc] = matrix[i, j];
                    indexc++;
                }
                indexr++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maximum = matrix[i, 0];
                int maxindex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maximum)
                    {
                        maximum = matrix[i, j];
                        maxindex = j;
                    }
                }
                if (maxindex != cols - 1)
                {
                    int temp = matrix[i, maxindex];
                    for (int k = maxindex; k < cols - 1; k++)
                    {
                        matrix[i, k] = matrix[i, k + 1];
                    }
                    matrix[i, cols - 1] = temp;
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows, cols + 1];
            int[] maxr = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int maximum = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maximum)
                    {
                        maximum = matrix[i, j];
                    }
                }
                maxr[i] = maximum;
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j < cols - 1)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == cols - 1)
                    {
                        answer[i, j] = maxr[i];
                        answer[i, j + 1] = matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int ct = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        ct++;
                    }
                }
            }
            answer = new int[ct];
            int ansindex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[ansindex] = matrix[i, j];
                        ansindex++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int n = matrix.GetLength(0), maxr = 0, neg = -1;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[maxr, maxr])
                    maxr = i;
            }

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    neg = i;
                    break;
                }
            }
            if (neg >= 0 && neg != maxr)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[maxr, j];
                    matrix[maxr, j] = matrix[neg, j];
                    matrix[neg, j] = temp;
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(1) < 2)
            {
                return;
            }

            int maxpr = -1000000;
            int indexr = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int elem = matrix[i, matrix.GetLength(1) - 2];

                if (elem > maxpr)
                {
                    maxpr = elem;
                    indexr = i;
                }
            }
            if (indexr != -1)
            {
                if (array.Length != matrix.GetLength(1))
                {
                    return;
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[indexr, j] = array[j];
                }
            }
            // end
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int pol = rows / 2;

            for (int j = 0; j < cols; j++)
            {
                int maximum = matrix[0, j];
                int maxr = 0;
                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > maximum)
                    {
                        maximum = matrix[i, j];
                        maxr = i;
                    }
                }
                if (maxr < pol)
                {
                    int sum = 0;
                    for (int i = maxr + 1; i < rows; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return;
            }
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows - 1; i += 2)
            {
                int maxnr = matrix[i, 0];
                int maxnrindex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxnr)
                    {
                        maxnr = matrix[i, j];
                        maxnrindex = j;
                    }
                }
                int maxcr = matrix[i + 1, 0];
                int maxcrindex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i + 1, j] > maxcr)
                    {
                        maxcr = matrix[i + 1, j];
                        maxcrindex = j;
                    }
                }
                matrix[i, maxnrindex] = maxcr;
                matrix[i + 1, maxcrindex] = maxnr;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int n = matrix.GetLength(0);
            int maximum = -1000000;
            int maxr = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > maximum)
                {
                    maximum = matrix[i, i];
                    maxr = i;
                }
            }
            if (maxr == -1)
            {
                return;
            }
            for (int i = 0; i < maxr; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] pos = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int ct = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        ct++;
                    }
                }
                pos[i] = ct;
            }
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (pos[j] < pos[j + 1])
                    {
                        int temp = pos[j];
                        pos[j] = pos[j + 1];
                        pos[j + 1] = temp;
                        for (int k = 0; k < cols; k++)
                        {
                            int tempn = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = tempn;
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
            int sum = 0, ct = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                        ct++;
                    }
                }
            }
            if (ct == 0)
            {
                return new int[0][];
            }
            double sr = (double)sum / ct;
            int[][] temp = new int[array.Length][];
            int r = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null && array[i].Length > 0)
                {
                    int sumr = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sumr += array[i][j];
                    }
                    double rowsr = (double)sumr / array[i].Length;
                    if (rowsr >= sr)
                    {
                        temp[r] = array[i];
                        r++;
                    }
                }
                else if (array[i] == null || array[i].Length == 0)
                {
                    if (sr == 0)
                    {
                        temp[r] = array[i];
                        r++;
                    }
                }
            }
            answer = new int[r][];
            for (int i = 0; i < r; i++)
            {
                answer[i] = temp[i];
            }
            // end

            return answer;
        }
    }
}