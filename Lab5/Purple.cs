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
            int i1 = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int count = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                answer[i1] = count;
                i1++;
            }

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int jmin = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i, jmin])
                    {
                        jmin = j;
                    }
                }

                int tmp = matrix[i, jmin];
                for (int j = jmin; j >= 1; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = tmp;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int jmax = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, jmax])
                    {
                        jmax = j;
                    }
                }

                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j <= jmax)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == jmax + 1)
                    {
                        answer[i, j] = matrix[i, jmax];
                    }
                    else
                    {
                        answer[i, j] = matrix[i, j - 1];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int jmax = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, jmax])
                    {
                        jmax = j;
                    }
                }

                int count = 0,tb=0;
                for (int j = jmax + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        tb += matrix[i, j];
                        count++;
                    }
                }

                if (count != 0)
                {
                    tb = tb / count;
                    for (int j = 0; j < jmax; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = tb;
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            if (k < matrix.GetLength(1))
            {
                int[] max = new int[matrix.GetLength(0)];
                int i1 = 0;
                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                {
                    int jmax = 0, max_elem = matrix[i, 0];
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > matrix[i, jmax])
                        {
                            jmax = j;
                            max_elem = matrix[i, j];
                        }
                    }

                    max[i1] = max_elem;
                    i1++;
                }

                i1 = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = max[i1];
                    i1++;
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length == matrix.GetLength(1))
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int imax = 0;
                    for (int i = 1; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] > matrix[imax, j])
                        {
                            imax = i;
                        }
                    }

                    if (matrix[imax, j] < array[j])
                    {
                        matrix[imax, j] = array[j];
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int[] min = new int[matrix.GetLength(0)];
            int i1 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int jmin = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i, jmin])
                    {
                        jmin = j;
                    }
                }

                min[i1] = matrix[i, jmin];
                i1++;
            }

            i1 = 0;
            while (i1 < min.Length)
            {
                if (i1 == 0 || min[i1] <= min[i1 - 1])
                {
                    i1++;
                }
                else
                {
                    int tmp = min[i1];
                    min[i1] = min[i1 - 1];
                    min[i1 - 1] = tmp;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int tmp1 = matrix[i1, j];
                        matrix[i1, j] = matrix[i1 - 1, j];
                        matrix[i1 - 1, j] = tmp1;
                    }

                    i1--;
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                answer = new int[2 * matrix.GetLength(0) - 1];
                int i1 = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int i = 0; i < j + 1; i++)
                    {
                        sum += matrix[matrix.GetLength(0) - 1 - i, j - i];
                    }

                    answer[i1] = sum;
                    i1++;
                }

                i1 = answer.Length - 1;
                int d = 0;
                for (int j = matrix.GetLength(1) - 1; j > 0; j--)
                {
                    int sum = 0;
                    for (int i = 0; i < d + 1; i++)
                    {
                        sum += matrix[0 + i, j + i];
                    }

                    answer[i1] = sum;
                    i1--;
                    d++;
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int imax = 0, jmax = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[imax, jmax]))
                        {
                            imax = i;
                            jmax = j;
                        }
                    }
                }

                int[] arr1 = new int[matrix.GetLength(0)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    arr1[i] = matrix[i, jmax];
                }
                
                if (jmax > k)
                {
                    for (int j = jmax; j > k; j--)
                    {
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            matrix[i, j] = matrix[i, j - 1];
                        }
                    }

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[i, k] = arr1[i];
                    }
                }
                else
                {
                    for (int j = jmax; j < k; j++)
                    {
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            matrix[i, j] = matrix[i, j + 1];
                        }
                    }

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[i, k] = arr1[i];
                    }
                }

                int[] arr2 = new int[matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    arr2[j] = matrix[imax, j];
                }
                if (k > imax)
                {
                    for (int i = imax; i < k; i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[i, j] = matrix[i + 1, j];
                        }
                    }

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[k, j] = arr2[j];
                    }
                }
                else
                {
                    for (int i = imax; i > k; i--)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[i, j] = matrix[i - 1, j];
                        }
                    }

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[k, j] = arr2[j];
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1) == B.GetLength(0))
            {
                int n = 0,i1=0,j1=0;
                answer = new int[A.GetLength(0), B.GetLength(1)];
                while (n+1 <= answer.Length)
                {
                    n++;
                    int tich = 0;
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        tich += A[i1, j] * B[j, j1];
                    }

                    answer[i1, j1] = tich;
                    if (j1+1 < answer.GetLength(1))
                    {
                        j1++;
                    }
                    else
                    {
                        j1 = 0;
                        i1++;
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
            answer = new int[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int dem = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        dem++;
                    }
                }

                answer[i] = new int[dem];
                int i1 = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][i1] = matrix[i, j];
                        i1++;
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
            int n = 0;
            for (int i = 0; i < array.Length; i++)
            {
                n+=array[i].Length;
            }

            n = (int)Math.Ceiling(Math.Sqrt(n));
            answer = new int[n, n];
            int[] arr = new int[answer.Length];
            int i1 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    arr[i1] = array[i][j];
                    i1++;
                }
            }

            i1 = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    answer[i, j] = arr[i1];
                    i1++;
                }
            }
            // end

            return answer;
        }
    }
}
