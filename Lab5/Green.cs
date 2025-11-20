using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int m = int.MaxValue;
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < m)
                    {
                        m = matrix[i, j];
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int m = int.MinValue;
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > m)
                    {
                        m = matrix[i, j];
                        ind = j;
                    }
                }
                for (int j = 0; j < ind; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / m);
                    }
                }
            }

            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1) && k < matrix.GetLength(1))
            {
                int inds = 0;
                int m = matrix[0, 0];

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, i] > m)
                    {
                        m = matrix[i, i];
                        inds = i;
                    }
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {

                    int t = matrix[i, k];
                    matrix[i, k] = matrix[i, inds];
                    matrix[i, inds] = t;


                }
            }

            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            

            int m = matrix[0, 0];
            int mstr = 0;
            int mstl = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > m)
                {
                    m = matrix[i, i];
                    mstr= i;
                    mstl = i;
                }
            }

            int[] tstr = new int[matrix.GetLength(0)];
            int[] tstl = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                tstr[i] = matrix[mstr, i];
                tstl[i] = matrix[i, mstl];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[mstr, i] = tstl[i];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, mstl] = tstr[i];
            }


            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int mostsum = 0;
            int ind = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int s = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                    }
                }

                if (s > mostsum)
                {
                    mostsum = s;
                    ind = i;
                }
            }
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (i < ind)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else
                    {
                        answer[i, j] = matrix[i + 1, j];
                    }
                }
            }

            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int maxc = -1;
            int minc = int.MaxValue;
            int indmax = -1;
            int indmin = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        c++;
                    }
                }
                if (maxc == -1 || c > maxc)
                {
                    maxc = c;
                    indmax = i;
                }
                if (minc == int.MaxValue || c < minc)
                {
                    minc = c;
                    indmin = i;
                }
            }
            if (maxc == minc || indmax == -1 || indmin == -1)
            {
                return;
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    int t = matrix[indmax, i];
                    matrix[indmax, i] = matrix[indmin, i];
                    matrix[indmin, i] = t;
                }
            }

            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (rows != array.Length)
            {
                return matrix;
            }

            int min_item_row = 0;
            int min_item_col = 0;

            for (int r = 0; r < rows; r += 1)
            {
                for (int c = 0; c < cols; c += 1)
                {
                    if (matrix[r, c] < matrix[min_item_row, min_item_col])
                    {
                        min_item_col = c;
                        min_item_row = r;
                    }
                }
            }

            answer = new int[rows, cols + 1];

            for (int r = 0; r < rows; r += 1)
            {
                for (int c = 0; c < min_item_col + 1; c += 1)
                {
                    answer[r, c] = matrix[r, c];
                }

                answer[r, min_item_col + 1] = array[r];

                for (int c = min_item_col + 1; c < cols; c += 1)
                {
                    answer[r, c + 1] = matrix[r, c];
                }
            }

            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 0 || cols == 0) matrix = null;
            for (int j = 0; j < cols; j++)
            {
                int pos = 0;
                int neg = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0) pos++;
                    else if (matrix[i, j] < 0) neg++;
                }

                if (pos == neg)
                    continue;

                int maxVal = int.MinValue;
                int maxRow = 0;

                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRow = i;
                    }
                }

                if (pos > neg)
                    matrix[maxRow, j] = 0;
                else
                    matrix[maxRow, j] = maxRow;
            }

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (i == 0 || i == matrix.GetLength(0) - 1 || j == 0 || j == matrix.GetLength(1) - 1)
                        {
                            matrix[i, j] = 0;
                        }
                    }
                }
            }

            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix.GetLength(0)!= matrix.GetLength(1))
            {
                return (A, B);
            }
            else
            {
                int ca = 0;
                int cb = 0;
                for (int i = 0; i<matrix.GetLength(0); i++)
                {
                    for (int j = 0; j<matrix.GetLength(1); j++)
                    {
                        if (j>=i)
                        {
                            ca++;
                        }
                        if (j<i)
                        {
                            cb++;
                        }
                    }
                }
                A = new int[ca];
                B = new int[cb];
                int inda = 0;
                int indb = 0;
                for (int i = 0; i<matrix.GetLength(0); i++)
                {
                    for (int j =0; j<matrix.GetLength(1); j++)
                    {
                        if (j>=i)
                        {
                            A[inda] = matrix[i, j];
                            inda++;
                        }
                        if (j<i)
                        {
                            B[indb] = matrix[i, j];
                            indb++;
                        }
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            
                for (int st = 0; st<matrix.GetLength(1); st++)
                {
                    int[] stl = new int[matrix.GetLength(0)];
                    for(int i = 0; i< matrix.GetLength(0); i++)
                    {
                        stl[i] = matrix[i, st];
                    }
                    Array.Sort(stl);

                    if (st%2==0)
                    {
                        Array.Reverse(stl);
                    }
                    for (int i = 0; i< matrix.GetLength(0); i++)
                    {
                        matrix[i, st] = stl[i];
                    }
                }
            
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            for (int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j<array.Length-1-i; j++)
                {
                    if (array[j].Length < array[j+1].Length)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                    if (array[j].Length == array[j+1].Length)
                    {
                        int s = 0;
                        int s1 = 0;
                        for(int k = 0; k < array[j].Length; k++)
                        {
                            s += array[j][k];
                            s1 += array[j + 1][k];
                        }
                        if (s1>s)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }
            // end

        }
    }
}