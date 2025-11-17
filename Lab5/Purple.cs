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
            int h = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            int s;
            answer = new int[l];

            for (int i=0; i<l; i++)
            {
                s = 0;
                for (int j=0; j<h; j++)
                {
                    if (matrix[j,i] < 0) s++;
                }
                answer[i] = s;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int h = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            int m=1000000;
            int mi=0;
            int k = -1;

            for (int i = 0; i < h; i++)
            {
                m = 1000000;
                k = -1;
                for (int j = 0; j < l; j++)
                {
                    k++;
                    if (matrix[i,j] < m)
                    {
                        m = matrix[i, j];
                        mi = k;
                    }
                }
                int f = -1;
                for (int o=0; o<mi; o++)
                {
                    f++;
                    (matrix[i, mi-1-f], matrix[i, mi-f]) = (matrix[i, mi-f], matrix[i, mi-1-f]);
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int h = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            int m = -1000000;
            int mi = 0;
            int k = -1;
            int[,] matrix2 = new int[h, l + 1];

            for (int i = 0; i < h; i++)
            {
                m = -1000000;
                k = -1;
                for (int j = 0; j < l; j++)
                {
                    k++;
                    if (matrix[i, j] > m)
                    {
                        m = matrix[i, j];
                        mi = k;
                    }
                }
                int f = -1;
                for (int o = 0; o < l; o++)
                {
                    f++;
                    if (f==mi)
                    {
                        matrix2[i, f] = matrix[i, o];
                        f++;
                    }
                    matrix2[i, f] = matrix[i,o];
                }
            }
            answer = matrix2;
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int h = matrix.GetLength(0);
            int l = matrix.GetLength(1);

            for (int i = 0; i < h; i++)
            {
                int mi = 0;
                int mv = matrix[i, 0];

                for (int j = 1; j < l; j++)
                {
                    if (matrix[i, j] > mv)
                    {
                        mv = matrix[i, j];
                        mi = j;
                    }
                }
                if (mi == l - 1)
                    continue;
                int sum = 0;
                int c = 0;
                for (int j = mi + 1; j < l; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        c++;
                    }
                }
                if (c == 0)
                    continue;
                int av = sum / c; 
                for (int j = 0; j < mi; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = av;
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int h = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            if (k < 0 || k >= l)
                return;
            int[] mxel = new int[h];
            for (int i = 0; i < h; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < l; j++)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                }
                mxel[i] = max;
            }
            for (int i = 0; i < h; i++)
            {
                matrix[i, k] = mxel[h - 1 - i];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (matrix == null || array == null)
                return;
            int h = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            if (h == 0 || l == 0 || array.Length < l)
                return;
            for (int j = 0; j < l; j++)
            {
                int mri = 0;
                int mv = matrix[0, j];

                for (int i = 1; i < h; i++)
                {

                    if (matrix[i, j] > mv)
                    {
                        mv = matrix[i, j];
                        mri = i;
                    }
                }
                if (array[j] > mv && array.Length == l) 
                {
                    matrix[mri, j] = array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int h = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            for (int i = 0; i < h - 1; i++)
            {
                for (int j = 0; j < h - i - 1; j++)
                {
                    int minc = matrix[j, 0];
                    for (int k = 1; k < l; k++)
                    {
                        if (matrix[j, k] < minc)
                            minc = matrix[j, k];
                    }

                    int minex = matrix[j + 1, 0];
                    for (int k = 1; k < l; k++)
                    {
                        if (matrix[j + 1, k] < minex)
                            minex = matrix[j + 1, k];
                    }
                    if (minc < minex)
                    {
                        for (int k = 0; k < l; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            {
                int n = matrix.GetLength(0);
                int m = matrix.GetLength(1);
                if (n != m)
                    return null;
                answer = new int[2 * n - 1];
                int index = 0;

                for (int i = n - 1; i >= 0; i--)
                {
                    int sum = 0;
                    int h = i;
                    int l = 0;
                    while (h < n && l < n)
                    {
                        sum += matrix[h, l];
                        h++;
                        l++;
                    }
                    answer[index++] = sum;
                }

                for (int j = 1; j < n; j++)
                {
                    int sum = 0;
                    int h = 0;
                    int l = j;
                    while (h < n && l < n)
                    {
                        sum += matrix[h, l];
                        h++;
                        l++;
                    }
                    answer[index++] = sum;
                }
            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                int maxh = 0, maxl = 0;
                int mxabs = Math.Abs(matrix[0, 0]);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int curabs = Math.Abs(matrix[i, j]);
                        if (curabs > mxabs)
                        {
                            mxabs = curabs;
                            maxh = i;
                            maxl = j;
                        }
                    }
                }

                int[] tmp = new int[n];
                for (int j = 0; j < n; j++)
                {
                    tmp[j] = matrix[maxh, j];
                }
                for (int i = maxh; i > k; i--)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
                for (int i = maxh; i < k; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = matrix[i + 1, j];
                    }
                }
                for (int j = 0; j < n; j++)
                {
                    matrix[k, j] = tmp[j];
                }
                int[] tmpl = new int[n];
                for (int i = 0; i < n; i++)
                {
                    tmpl[i] = matrix[i, maxl];
                }
                for (int j = maxl; j > k; j--)
                {
                    for (int i = 0; i < n; i++)
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }
                }
                for (int j = maxl; j < k; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        matrix[i, j] = matrix[i, j + 1];
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = tmpl[i];
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int hA = A.GetLength(0);
            int lA = A.GetLength(1);
            int hB = B.GetLength(0);
            int lB = B.GetLength(1);

            if (lA == hB)
            {
                answer = new int[hA, lB];
                for (int i = 0; i < hA; i++)
                {
                    for (int j = 0; j < lB; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < lA; k++)
                        {
                            sum += A[i, k] * B[k, j];
                        }
                        answer[i, j] = sum;
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
            int h = matrix.GetLength(0);
            int l = matrix.GetLength(1);
            answer = new int[h][];
            for (int i = 0; i < h; i++)
            {
                int c = 0;
                for (int j = 0; j < l; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }
                answer[i] = new int[c];
                int index = 0;
                for (int j = 0; j < l; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][index] = matrix[i, j];
                        index++;
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
            int totl = 0;
            foreach (int[] h in array)
            {
                totl += h.Length;
            }
            int sz = (int)Math.Ceiling(Math.Sqrt(totl));
            answer = new int[sz, sz];
            int curh = 0;
            int curl = 0;

            foreach (int[] h in array)
            {
                foreach (int elem in h)
                {
                    answer[curh, curl] = elem;
                    curl++;

                    if (curl >= sz)
                    {
                        curl = 0;
                        curh++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}