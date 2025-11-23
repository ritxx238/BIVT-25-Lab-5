using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0); 
            int m = matrix.GetLength(1); 

            answer = new int[n];
            for (int i = 0; i < n; i++)
            {
                int min = matrix[i, 0];
                int minind = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minind = j;
                    }
                }
                answer[i] = minind;
            }
                // end

                return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int max = matrix[i, 0];
                int maxind = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxind = j;
                    }
                }
                for (int k = 0; k < maxind; k++)
                {
                    if (matrix[i, k] < 0)
                    {
                        matrix[i, k] = (int)Math.Floor((double)matrix[i, k] / max);
                    }
                }

            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m || k < 0 || k >= m) return;

            int max = matrix[0, 0];
            int maxind = 0;
                       
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxind = i;
                }
            }

            if (maxind == k) return;
            
            for (int row = 0; row < n; row++)
            {
                (matrix[row, k], matrix[row, maxind]) = (matrix[row, maxind], matrix[row, k]);
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int max = int.MinValue;
            int maxind = -1;

            if (n != m) return;

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxind = i;
                }
                                
            }

            for (int i = 0; i < n; i++)
            {
                (matrix[i, maxind], matrix[maxind, i]) = (matrix[maxind, i], matrix[i, maxind]);
            }
                        
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int maxSum = 0;
            int maxind = -1;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > 0) sum += matrix[i, j];
                if (sum > maxSum || maxind == -1)
                {
                    maxSum = sum;
                    maxind = i;
                }
            }

            if (maxind != -1)
            {
                answer = new int[n - 1, m];
                int rowid = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i == maxind) continue;
                    for (int j = 0; j < m; j++)
                    {
                        answer[rowid, j] = matrix[i, j];
                        
                    }
                    rowid++;
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] negCount = new int[n];
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0) count++;
                }
                negCount[i] = count;
            }

            int min = negCount[0], max = negCount[0];
            int minind = 0, maxind = 0;
            bool x = true;

            for (int i = 1; i < n; i++)
            {

                if (negCount[i] > max)
                {
                    max = negCount[i];
                    maxind = i;
                }
                if (negCount[i] < min)
                {
                    min = negCount[i];
                    minind = i;
                }
                if (negCount[i] != negCount[0]) x = false;
            }

            if (!x && minind != maxind)
            {
                for (int j = 0; j < m; j++)
                {
                    (matrix[minind, j], matrix[maxind, j]) = (matrix[maxind, j], matrix[minind, j]);
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (array.Length != n) return matrix;

            int min = int.MaxValue;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            int st = m;

            for (int j = 0; j < m; j++)
            {
                bool y = false;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] == min) 
                    { 
                        st = j;
                        break; 
                    }
                }
                if (st != m) break;
            }

            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int x = 0;
                for (int j = 0; j < m + 1; j++)
                {                    
                    if (j == st + 1)
                        answer[i, j] = array[i];
                    else
                        answer[i, j] = matrix[i, x++];
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                int pol = 0;
                int neg = 0;

                int max = matrix[0, j];
                int maxst = 0;

                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0) pol++;
                    if (matrix[i, j] < 0) neg++;

                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxst = i;
                    }
                }

                if (pol > neg)
                {
                    matrix[maxst, j] = 0;
                }
                else if (neg > pol)
                {
                    matrix[maxst, j] = maxst;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            for (int k = 0; k < n; k++)
            {
                matrix[0, k] = 0;
                matrix[n - 1, k] = 0;
                matrix[k, 0] = 0;
                matrix[k, n - 1] = 0;
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || n != m)
                return (null, null);

            int colelA = n * (n - 1) / 2;
            int colelB = n * (n + 1) / 2;

            A = new int[colelB];
            B = new int[colelA];

            int Ai = 0, Bi = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= i) A[Ai++] = matrix[i, j];
                    if (j < i) B[Bi++] = matrix[i, j];
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                for (int x = 0; x < n - 1; x++)
                {
                    for (int i = 0; i < n - 1 - x; i++)
                    {
                        if (j % 2 == 0 && matrix[i, j] < matrix[i + 1, j])
                        {
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                        }

                        if (j % 2 != 0 && matrix[i, j] > matrix[i + 1, j])
                        {
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                        }
                    }
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            int n = array.Length;

            for (int x = 0; x < n - 1; x++)
            {
                for (int i = 0; i < n - 1 - x; i++)
                {
                    bool proverka = false;

                    if (array[i].Length < array[i + 1].Length) proverka = true;
                    else if (array[i].Length == array[i + 1].Length)
                    {
                        int sum1 = 0, sum2 = 0;
                        for (int k = 0; k < array[i].Length; k++) sum1 += array[i][k];
                        for (int k = 0; k < array[i + 1].Length; k++) sum2 += array[i + 1][k];

                        if (sum1 < sum2) proverka = true;
                    }

                    if (proverka) (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }
            }
            // end

        }
    }
}