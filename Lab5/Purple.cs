using System;
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int ind = 0; 

            answer = new int[m];
            for (int cols = 0; cols < m; cols++)
            {
                int c = 0;
                for (int line = 0; line < n; line++)
                {
                    if (matrix[line, cols] < 0)
                    {
                        c++;
                    }
                }
                answer[ind++] = c;

            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int line = 0; line < n; line++)
            {
                int min = 1000000, indmin = -1;
                for (int col = 0; col < m; col++)
                {
                    if (matrix[line, col] < min)
                    {
                        min = matrix[line, col];
                        indmin = col;
                    }
                }
                for (int col = indmin; col > 0; col--)
                {
                    matrix[line, col] = matrix[line, col - 1];
                }
                matrix[line, 0] = min;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            // end
        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int max = -1000000, indmax = -1;
                // 1
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indmax = j;
                    }
                }
                // 2
                for (int j = 0; j <= indmax; j++)
                    answer[i, j] = matrix[i, j];
                answer[i, indmax + 1] = max;
                for (int j = indmax + 1; j < m; j++)
                    answer[i, j + 1] = matrix[i, j];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m + 1; j++)
                {
                    Console.Write($"{answer[i, j], 5}");
                }
                Console.WriteLine();
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int c = 0, sum = 0, max = -1000000, indmax = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indmax = j;
                    }
                }

                for (int j = indmax + 1; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        c++;
                    }
                }
                
                if (sum != 0)
                {
                    int sr = sum / c;

                    for (int j = 0; j < indmax; j++)
                    {
                        if (matrix[i, j] < 0)
                            matrix[i, j] = sr;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j], 5}");
                }
                Console.WriteLine();
            }

            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] maxx = new int[n];

            if (k < m)
            {
                for (int i = 0; i < n; i++)
                {
                    int max = -100000;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > max) max = matrix[i, j];
                    }

                    maxx[i] = max;
                }

                int indK = n - 1;
                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = maxx[indK];
                    indK--;
                }
            }
             

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j], 5}");
                }
                Console.WriteLine();
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                int max = -1000000, indi = -1, indj = -1;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indi = i;
                        indj = j;
                    }
                }

                if (array.Length == m && array[indj] > max) matrix[indi, j] = array[indj]; 
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[,] sort = new int[n, 2];

            for (int i = 0; i<n; i++)
            {
                int min = 1000000;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
                sort[i, 0] = min;
                sort[i, 1] = i;
            }

            for (int i = 0; i < n; i++)
            {
                bool changed = false;
                for (int j = 0; j < n - 1; j++)
                {
                    if (sort[j, 0] < sort[j + 1, 0])
                    {
                        (sort[j, 0], sort[j + 1, 0]) = (sort[j + 1, 0], sort[j, 0]);
                        (sort[j, 1], sort[j + 1, 1]) = (sort[j + 1, 1], sort[j, 1]);
                        changed = true;
                    }
                }
                if (!changed) break;
            }

            int[,] ans = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                int k = sort[i, 1];

                for (int j = 0; j < m; j++)
                {
                    ans[i, j] = matrix[k, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = ans[i, j];
                }
            }

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        Console.Write($"{matrix[i, j], 5}");
            //    }
            //    Console.WriteLine();
            //}

            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m) return answer;

            answer = new int[2 * n - 1];
            answer[0] = matrix[n - 1, 0];
            answer[2*n - 2] = matrix[0, n - 1];

            int ind = 1;
            for (int i = n - 2; i > 0; i--)
            {

                int sum = 0, line = i, k = 0;
                while (line < n)
                {
                    sum += matrix[line++, k++];
                }
                answer[ind++] = sum;
            }

            for (int i = 0; i < n; i++) // столбцы
            {
                int sum = 0, line = 0, k = i;

                while (k < n)
                {
                    sum += matrix[line++, k++];
                }
                answer[ind++] = sum;
            }

            Console.WriteLine(string.Join(" ", answer));
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int max = 0, lnum = -1, cnum = -1;
            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(max))
                        {
                            max = matrix[i, j];
                            lnum = i; cnum = j;
                        }
                    }
                }
                // сдвиг строк
                if (lnum > k)
                {
                    int p = 0;
                    for (int j = 0; j < m; j++)  
                    {
                        p = matrix[lnum, j];
                        for (int i = lnum; i > k; i--)
                        {
                            matrix[i, j] = matrix[i - 1, j];

                        }
                        matrix[k, j] = p;
                    }
                }
                else if (lnum < k)
                {
                    int p = 0;
                    for (int j = 0; j < m; j++)
                    {
                        p = matrix[k, j];
                        for (int i = k; i > lnum; i--)
                        {
                            matrix[i, j] = matrix[i - 1, j];

                        }
                        matrix[lnum, j] = p;
                    }
                }

                // сдвиг столбцов
                if (cnum > k)
                {
                    int p = 0;
                    for (int i = 0; i < n; i++)
                    {
                        p = matrix[i, cnum];
                        for (int j = cnum; j > k; j--)
                        {
                            matrix[i, j] = matrix[i, j - 1];
                            
                        }
                        matrix[i, k] = p;
                    }
                }
                else if (cnum < k)
                {
                    int p = 0;
                    for (int i = 0; i < n; i++)
                    {
                        p = matrix[i, k];
                        for (int j = k; j > cnum; j--)
                        {
                            matrix[i, j] = matrix[i, j - 1];

                        }
                        matrix[i, cnum] = p;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j], 5}");
                }
                Console.WriteLine();
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int n1 = A.GetLength(0);
            int m1 = A.GetLength(1);
            int n2 = B.GetLength(0);
            int m2 = B.GetLength(1);

            if (m1 == n2)
            {
                answer = new int[n1, m2];
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        for (int k = 0; k < m1; k++)
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            answer = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int c = 0, ind = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }

                answer[i] = new int[c];
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][ind++] = matrix[i, j];
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", answer[i]));
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int n = array.GetLength(0);
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                c += array[i].Length;
            }
            double sq = Math.Sqrt(c);
            int k = (int)Math.Ceiling(sq);


            answer = new int[k, k];
            int[] arr = new int[k * k];
            int ind = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    arr[ind++] = array[i][j];
                }
            }

            int ind2 = 0;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    answer[i, j] = arr[ind2++];
                }
            }

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write($"{answer[i, j], 5}");
                }
                Console.WriteLine();
            }
            
            // end

            return answer;
        }
    }
}