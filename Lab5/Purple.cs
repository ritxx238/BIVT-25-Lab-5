using System.Globalization;
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
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[j] += Convert.ToInt32(matrix[i, j] < 0);
                }
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int mn = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                mn = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i, mn])
                    {
                        mn = j;
                    }
                }
                for (int j = mn - 1; j >= 0; j--)
                {
                    (matrix[i, j], matrix[i, mn]) = (matrix[i, mn], matrix[i, j]);
                    mn = j;
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            int mx = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                mx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, mx])
                    {
                        mx = j;
                    }
                }
                for (int j = 0; j <= mx; j++)
                    answer[i, j] = matrix[i, j];
                answer[i, mx + 1] = matrix[i, mx];
                for (int j = mx + 1; j < answer.GetLength(1); j++)
                    answer[i, j] = matrix[i, j - 1];
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return;
            }
            int mx,
                sr,
                cnt;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sr = 0;
                cnt = 0;
                mx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, mx])
                    {
                        mx = j;
                    }
                }
                for (int j = mx + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt++;
                        sr += matrix[i, j];
                    }
                }
                if (cnt == 0)
                {
                    continue;
                }
                sr /= cnt;
                for (int j = 0; j < mx; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = sr;
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
           if (k >= matrix.GetLength(1))
            {
                return;
            }
            int[] arr = new int[matrix.GetLength(0)];
            int mx = 0, n = matrix.GetLength(0);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                mx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, mx])
                    {
                        mx = j;
                    }
                }
                arr[n - i - 1] = matrix[i, mx];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                matrix[i, k] = arr[i];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length != matrix.GetLength(1))
            {
                return;
            }
            int mx = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                mx = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > matrix[mx, j])
                    {
                        mx = i;
                    }
                }
                System.Console.WriteLine(1);
                if (array[j] > matrix[mx, j])
                {
                    matrix[mx, j] = array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int i, j;
            int[,] arr = new int[matrix.GetLength(0), 2],
                answer = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int mn;
            for (i = 0; i < matrix.GetLength(0); i++)
                for (j = 0; j < matrix.GetLength(1); j++)
                    answer[i, j] = matrix[i, j];

            for (i = 0; i < matrix.GetLength(0); i++)
            {
                mn = 0;
                for (j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i, mn])
                    {
                        mn = j;
                    }
                }
                arr[i, 0] = matrix[i, mn];
                arr[i, 1] = i;
            }
            i = 0;
            j = i + 1;
            while (i < arr.GetLength(0))
            {
                if (i == 0 || arr[i - 1, 0] >= arr[i, 0])
                {
                    i = j;
                    j++;
                }
                else
                {
                    (arr[i, 0], arr[i - 1, 0]) = (arr[i - 1, 0], arr[i, 0]);
                    (arr[i, 1], arr[i - 1, 1]) = (arr[i - 1, 1], arr[i, 1]);
                    i--;
                }
            }
            for (i = 0; i < answer.GetLength(0); i++)
            {
                for (j = 0; j < answer.GetLength(1); j++)
                {
                    matrix[i, j] = answer[arr[i, 1], j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;
            int n = matrix.GetLength(0),
                m = matrix.GetLength(1);
            if (n != m)
            {
                return null;
            }

            answer = new int[2 * n - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    answer[n - i - 1 + j] += matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0),
                m = matrix.GetLength(1),
                mxi = 0,
                mxj = 0;
            if (n != m || k >= n || k < 0)
            {
                return;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[mxi, mxj]))
                    {
                        mxi = i;
                        mxj = j;
                    }
                }
            }

            while (mxi < k)
            {
                for (int j = 0; j < n; j++)
                {
                    (matrix[mxi, j], matrix[mxi + 1, j]) = (matrix[mxi + 1, j], matrix[mxi, j]);
                }
                mxi++;
            }
            while (mxi > k)
            {
                for (int j = 0; j < n; j++)
                {
                    (matrix[mxi, j], matrix[mxi - 1, j]) = (matrix[mxi - 1, j], matrix[mxi, j]);
                }
                mxi--;
            }

            while (mxj < k)
            {
                for (int i = 0; i < n; i++)
                {
                    (matrix[i, mxj], matrix[i, mxj + 1]) = (matrix[i, mxj + 1], matrix[i, mxj]);
                }
                mxj++;
            }
            while (mxj > k)
            {
                for (int i = 0; i < n; i++)
                {
                    (matrix[i, mxj], matrix[i, mxj - 1]) = (matrix[i, mxj - 1], matrix[i, mxj]);
                }
                mxj--;
            }
            
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int n = A.GetLength(0),
                m1 = A.GetLength(1),
                m2 = B.GetLength(0),
                k = B.GetLength(1),
                ind, i, j;
            if (m1 != m2)
            {
                return answer;
            }
            answer = new int[n, k];
            ind = 0;
            while (ind < n * k)
            {
                i = ind / k;
                j = ind % k;
                for (int z = 0; z < m1; z++)
                {
                    answer[i, j] += A[i, z] * B[z, j];
                }
                ind++;
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int[] cnt = new int[matrix.GetLength(0)];
            int ind = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    cnt[i] += Convert.ToInt32(matrix[i, j] <= 0);
                }
            }
            answer = new int[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                ind = 0;
                answer[i] = new int[matrix.GetLength(1) - cnt[i]];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][j - ind] = matrix[i, j];
                    }
                    else
                    {
                        ind++;
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
            int cnt = 0, ind = 0;
            for (int i = 0; i < array.Length; i++)
            {
                cnt += array[i].Length;
            }
            int[] arr = new int[cnt];
            for (int i = 0; i < Math.Pow(cnt, 0.5) + 1; i++)
            {
                if (Math.Pow(i, 2) >= cnt){
                    cnt = i;
                    break;
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    arr[ind] = array[i][j];
                    ind++;
                }
            }
            answer = new int[cnt, cnt];
            for (int i = 0; i < cnt; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    if (j + i * cnt < arr.Length)
                    {
                        answer[i, j] = arr[j + i * cnt];
                    }
                    else
                    {
                        answer[i, j] = 0;
                    }
                }
            }
            // end

            return answer;
        }
    }
}
