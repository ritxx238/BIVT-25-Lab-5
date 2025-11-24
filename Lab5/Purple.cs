using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{

    public class Purple
    {
        public static void print(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
        }
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            print(matrix);
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int[] answer1 = new int[n];
            for (int i = 0; i < n; i++)
            {
                int k = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[j, i] < 0) { k++; }
                }
                answer1[i] = k;
            }
            answer = answer1;

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int[] ind = new int[m];
            int[,] answer2 = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                int mn = int.MaxValue;
                int mni = 0;
                for (int j = 0; j < n; j++)
                {
                    if (mn > matrix[i, j])
                    {
                        mn = matrix[i, j];
                        mni = j;
                    }
                }
                ind[i] = mni;
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0) { answer2[i, j] = matrix[i, ind[i]]; }
                    else if (j <= ind[i]) { answer2[i, j] = matrix[i, j - 1]; }
                    else if (j > ind[i]) { answer2[i, j] = matrix[i, j]; }
                }

            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = answer2[i, j];
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int[,] answer1 = new int[m,n+1];
            int[] ind = new int[m];
            for (int i = 0; i < m; i++)
            {
                int mx = int.MinValue;
                int mxi = 0;
                for (int j = 0; j < n; j++)
                {
                    if (mx < matrix[i, j])
                    {
                        mx = matrix[i, j];
                        mxi = j;
                    }
                }
                ind[i] = mxi;
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < ind[i]) { answer1[i, j] = matrix[i, j]; }
                    else if (j == ind[i]) { answer1[i, j] = matrix[i, j]; answer1[i, j+1] = matrix[i, j]; }
                    else if (j > ind[i]) { answer1[i, j+1] = matrix[i, j]; }
                }

            }
            answer = answer1;
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int[] ind = new int[m];
            int[] avr = new int[m];
            for (int i = 0; i < m; i++)
            {
                int mxi = -1;
                int mx = int.MinValue;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        ind[i] = j;
                        mx = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                int s = 0;
                int k = 0;
                for (int j = ind[i] + 1; j < n; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        k++;
                        s += matrix[i, j];
                    }
                }
                if (k == 0)
                {
                    avr[i] = -1;
                }
                else { avr[i] = s / k; }

            }
            for (int i = 0; i < m; i++)
            {
                int s = 0;
                int k = 0;
                for (int j = 0; j < ind[i]; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (avr[i] == -1) { break; }
                        else { matrix[i, j] = avr[i]; }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (k < m)
            {
                int[] mxx = new int[n];
                for (int i = 0; i < n; i++)
                {
                    int mx = int.MinValue;
                    for (int j = 0; j < m; j++)
                    {
                        if (mx < matrix[i, j])
                        {
                            mxx[i] = matrix[i, j];
                            mx = matrix[i, j];
                        }
                    }
                }
                int l = n - 1;
                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = mxx[l];
                    l--;
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (m == array.Length)
            {
                int[] mxi = new int[m];
                for (int i = 0; i < m; i++)
                {
                    int mx = int.MinValue;
                    for (int j = 0; j < n; j++)
                    {
                        if (mx < matrix[j, i])
                        {
                            mxi[i] = j;
                            mx = matrix[j, i];
                        }
                    }
                    if (matrix[mxi[i], i] < array[i])
                    {
                        matrix[mxi[i], i] = array[i];
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] mni = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                int mn = int.MaxValue;
                for (int j = 0; j < m; j++)
                {
                    if (mn > matrix[i, j])
                    {
                        mn = matrix[i, j];
                        mni[i, 0] = matrix[i, j];
                        mni[i, 1] = i;
                    }
                }
            }
            print(mni);
            for (int i = 0; i < n - 1; i++)
            {

                for (int j = 0; j < n - i - 1; j++)
                    if (mni[j, 0] < mni[j + 1, 0])
                    {
                        (mni[j, 0], mni[j + 1, 0]) = (mni[j + 1, 0], mni[j, 0]);
                        (mni[j, 1], mni[j + 1, 1]) = (mni[j + 1, 1], mni[j, 1]);
                    }

            }
            int[,] answer = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = answer[mni[i, 1], j];

                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if (m != n)
            {
                return null;
            }
            int[] ar = new int[2 * n - 1];
            int l = 0;
            int ll = n - 1;
            int col = 0;
            int row = 0;
            for (int i = 0; i < 2 * n - 1; i++)
            {

                int s = 0;
                if (l < n)
                {
                    row = n - 1;
                    row -= l;
                    col = 0;
                    l++;
                    for (int j = 0; j < l; j++)
                    {
                        s += matrix[row, col];
                        col++;
                        row += 1;

                    }
                    ar[i] = s;
                }
                else
                {
                    col = n - 1;
                    col -= (ll - 1);
                    row = 0;
                    for (int j = 0; j < ll; j++)
                    {
                        s += matrix[row, col];
                        col++;
                        row += 1;

                    }
                    ll--;
                    ar[i] = s;
                }
            }
            answer = ar;
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if (m == n)
            {

                int ii = -1;
                int jj = -1;
                int mx = int.MinValue;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > mx)
                        {
                            mx = Math.Abs(matrix[i, j]);
                            ii = i;
                            jj = j;
                        }
                    }
                }
                while (ii > k)
                {
                    int p;
                    for (int j = 0; j < m; j++)
                    {
                        p = matrix[ii - 1, j];
                        matrix[ii - 1, j] = matrix[ii, j];
                        matrix[ii, j] = p;
                    }
                    ii -= 1;
                }
                while (ii < k)
                {
                    int p;
                    for (int j = 0; j < m; j++)
                    {
                        p = matrix[ii + 1, j];
                        matrix[ii + 1, j] = matrix[ii, j];
                        matrix[ii, j] = p;
                    }
                    ii += 1;
                }
                while (jj > k)
                {
                    int p;
                    for (int i = 0; i < m; i++)
                    {
                        p = matrix[i, jj - 1];
                        matrix[i, jj - 1] = matrix[i, jj];
                        matrix[i, jj] = p;
                    }
                    jj -= 1;
                }
                while (jj < k)
                {
                    int p;
                    for (int i = 0; i < m; i++)
                    {
                        p = matrix[i, jj + 1];
                        matrix[i, jj + 1] = matrix[i, jj];
                        matrix[i, jj] = p;
                    }
                    jj += 1;
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
            if (ma != nb) { return answer; }
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

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int s = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s++;

                    }
                }
                Console.WriteLine(s);
                answer[i] = new int[s];
                int k = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][k] = matrix[i, j];
                        k++;
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int n = array.GetLength(0);
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                s += array[i].Length;
            }
            int[] ar = new int[s];
            s = 0;
            for (int i = 0; i < n; i++)
            {
                int m = array[i].Length;
                for (int j = 0; j < m; j++)
                {
                    ar[s] = array[i][j];
                    s++;
                }
            }
            int m1 = (int)Math.Sqrt(s);

            if (m1 * m1 != s) { m1++; }
            answer = new int[m1, m1];
            int k = 0;

            for (int i = 0; i < m1; i++)
            {
                for (int j = 0; j < m1; j++)
                {
                    answer[i, j] = ar[k];
                    k++;
                    if (k == s)
                    {
                        break;
                    }
                }
                if (k == s)
                {
                    break;
                }

            }
            // end

            return answer;
        }
    }
    }
