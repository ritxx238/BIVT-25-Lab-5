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
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            int k = 0;
            int ind = 0;
            answer = new int[y];
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        k++;
                    }
                }
                answer[ind++] = k;
                k = 0;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int x = matrix.GetLength (0);
            int y = matrix.GetLength (1);
            int[] ans = new int[x];
            int ind = 0;
            for (int i = 0; i < x; i++)
            {
                int mn = matrix[i, 0];
                for (int j = 1; j < y; j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                        ans[ind] = j;
                    }
                }
                ind++;
            }
            for (int i = 0; i < x; i++)
            {
                if (ans[i] > 0)
                {
                    int elem = matrix[i, ans[i]];
                    for (int k = ans[i]; k > 0; k--)
                    {
                        matrix[i, k] = matrix[i, k - 1];
                    }
                    matrix[i, 0] = elem;
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            answer = new int[x, y + 1];
            int[] h = new int[x];
            int term = 0;
            int mx = int.MinValue;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        term = j;
                    }
                }
                h[i] = term;
                mx = int.MinValue;
            }
            for (int i = 0; i < x; i++)
            {
                for (int k = 0; k <= h[i]; k++)
                {
                    answer[i, k] = matrix[i, k];
                }
                for (int k = h[i] + 2; k < y + 1; k++)
                {
                    answer[i, k] = matrix[i, k - 1];
                }
                answer[i, h[i] + 1] = answer[i, h[i]];

            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            
            int mx = int.MinValue;
            for (int i = 0; i < x; i++)
            {
                mx = int.MinValue;
                int s = 0;
                int term = 0;
                int k = 0;
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        term = j;
                    }
                }
                for (int j = term + 1; j < y; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        k++;
                    }
                }
                if (k > 0)
                {
                    int sred = (int)(s / k);

                    for (int j = 0; j < term; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = sred;
                        }
                    }
                }
            }
            
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            int[] m = new int[x];
            int ind = 0;
            int term = 0;
            for (int i = 0; i < x; i++)
            {
                int mx = int.MinValue;
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        term = matrix[i, j];
                    }
                }
                m[i] = term;
            }
            if (k < y)
            {
                ind = 0;
                for (int i = x - 1; i >= 0; i--)
                {
                    matrix[i, k] = m[ind++];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            for (int j = 0; j < y; j++)
            {
                int mx = matrix[0, j];
                int term = 0;
                for (int i = 1; i < x; i++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        term = i;
                    }
                }
                if (array.Length == y && mx < array[j])
                {
                    matrix[term, j] = array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);

            int[,] m = new int[x, 2];
            for (int i = 0; i < x; i++)
            {
                int term = 0;
                int mn = int.MaxValue;
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                        term = matrix[i, j];
                    }
                }
                m[i, 0] = term;
                m[i, 1] = i;
            }
            
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x - 1; j++)
                {
                    if (m[j, 0] < m[j + 1, 0])
                    {
                        (m[j, 0], m[j + 1, 0]) = (m[j + 1, 0], m[j, 0]);
                        (m[j, 1], m[j + 1, 1]) = (m[j + 1, 1], m[j, 1]);
                    }
                }
            }

            int[,] s = new int[x, y];
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int k = 0; k < x; k++)
                    {
                        if (m[k, 1] == i)
                        {
                            s[k, j] = matrix[i, j];
                        }
                    }
                }
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = s[i, j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            
            if (x != y)
            {
                answer = null;
            }
            else
            {
                answer = new int[2 * x - 1];
                int st = matrix[x - 1, 0];
                int end = matrix[0, y - 1];
                answer[0] = st;
                answer[2 * x - 2] = end;
                int ind = 1;
                for (int i = x - 2; i > 0; i--)
                {
                    int ind1 = i;
                    int ind2 = 0;
                    int t = 0;
                    while (ind1 < x && ind2 < y)
                    {
                        t += matrix[ind1, ind2];
                        ind1++;
                        ind2++;
                    }
                    answer[ind++] = t;
                }
                for (int j = 0; j < y; j++)
                {
                    int ind1 = 0;
                    int ind2 = j;
                    int t = 0;
                    while (ind2 < y && ind1 < x)
                    {
                        t += matrix[ind1, ind2];
                        ind1++;
                        ind2++;
                    }
                    answer[ind++] = t;
                }
                
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            int str = 0;
            int st = 0;
            int mx = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(mx))
                    {
                        mx = matrix[i, j];
                        str = i;
                        st = j;
                    }
                }
            }
            //Console.WriteLine(str + " " + st);
            if (x == y)
            {
                int ism1 = 0;
                int ism2 = 0;
                int st1, st2, e1, e2;
                if (k > str)
                {
                    ism1 = k - str;
                    st1 = str;
                    e1 = k;
                }
                else
                {
                    ism1 = (x - k + str) % x;
                    st1 = k;
                    e1 = str;
                }
                if (k > st)
                {
                    ism2 = k - st;
                    st2 = st;
                    e2 = k;
                }
                else
                {
                    ism2 = (y - k + st) % y;
                    st2 = k;
                    e2 = st;
                }
                int tem = 0;
                for (int i = 0; i < x; i++)
                {
                    tem = matrix[i, e2];
                    for (int j = e2; j > st2; j--)
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }
                    matrix[i, st2] = tem;
                }

                for (int j = 0; j < y; j++)
                {
                    tem = matrix[e1, j];
                    for (int i = e1; i > st1; i--)
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                    matrix[st1, j] = tem;
                }
            }
            
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int x1 = A.GetLength(0);
            int y1 = A.GetLength(1);
            int x2 = B.GetLength(0);
            int y2 = B.GetLength(1);
            if (y1 == x2)
            {
                answer = new int[x1, y2];
                int ind1 = 0;
                int ind2 = 0;
                for (int i = 0; i < x1; i++)
                {
                    for (int j = 0; j < y2; j++)
                    {
                        for (int k = 0; k < x2; k++)
                        {
                            answer[i, j] += A[i, k] * B[k, j];
                        }
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
            int x = matrix.GetLength(0);
            int y = matrix.GetLength(1);
            int[] term = new int[matrix.GetLength(0)];
            for (int i = 0; i < x; i++)
            {
                int k = 0;
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        k++;
                    }
                }
                term[i] = k;
            }
            answer = new int[x][];
            for (int i = 0; i < x; i++)
            {
                answer[i] = new int[term[i]];
            }
            for (int i = 0; i < x; i++)
            {
                int ind2 = 0;
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][ind2++] = matrix[i, j];
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
            int x = array.GetLength(0);
            int k = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    k++;
                }
            }
            int n = 0;
            for (int i = 1; i <= k; i++)
            {
                if (i * i >= k)
                {
                    n = i; break;
                }
            }
            answer = new int[n, n];
            int ind1 = 0;
            int ind2 = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (ind2 < n)
                    {
                        answer[ind1, ind2++] = array[i][j];
                    }
                    else
                    {
                        ind1++;
                        ind2 = 0;
                        answer[ind1, ind2++] = array[i][j];
                    }
                }
            }
            // end

            return answer;
        }
    }
}