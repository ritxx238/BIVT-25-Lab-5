using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int cnt = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0) cnt++;
                }
                answer[j] = cnt;
            }
            
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int ind_mn = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i, ind_mn]) ind_mn = j;
                }
                for (int j = ind_mn; j > 0; j--)
                {
                    (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                }
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
                int ind_mx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, ind_mx]) ind_mx = j;
                }
                for (int j = 0; j <= ind_mx; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, ind_mx + 1] = matrix[i, ind_mx];
                for (int j = ind_mx + 1; j < matrix.GetLength(1); j++)
                {
                    answer[i, j + 1] = matrix[i, j];
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
                int ind_mx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, ind_mx]) ind_mx = j;
                }
                int cnt = 0;
                int sum = 0;
                for (int j = ind_mx + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt++;
                        sum += matrix[i, j];
                    }
                }
                if (cnt == 0) continue;
                int sr = sum / cnt;
                for (int j = 0; j < ind_mx; j++)
                {
                    if (matrix[i, j] < 0) matrix[i, j] = sr;
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {
            int[] stolb = new int[matrix.GetLength(0)];
            // code here
            int t = stolb.Length - 1;
            if (k >= matrix.GetLength(1)) return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int ind_mx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, ind_mx]) ind_mx = j;
                }
                stolb[t--] = matrix[i, ind_mx];
            }
            
            t = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, k] = stolb[t++];
            }
            Console.WriteLine("test\n");
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {
            

            if (array.Length != matrix.GetLength(1)) return;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int inmx = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[inmx, j] < matrix[i, j]) inmx = i;
                }

                if (array[j] > matrix[inmx, j])
                {
                    matrix[inmx, j] = array[j];
                }
            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int raw = 0; raw < matrix.GetLength(0) - 1; raw++)
                {
                    int[] temp1 = new int[matrix.GetLength(1)];
                    int[] temp2 = new int[matrix.GetLength(1)];

                    for (int jj = 0; jj < matrix.GetLength(1); jj++)
                    {
                        temp1[jj] = matrix[raw, jj];
                        temp2[jj] = matrix[raw + 1, jj];
                    }

                    if (temp1.Min() < temp2.Min())
                    {
                        for (int jj = 0; jj < matrix.GetLength(1); jj++)
                        {
                            int t = matrix[raw, jj];
                            matrix[raw, jj] = matrix[raw + 1, jj];
                            matrix[raw + 1, jj] = t; 
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
            if (matrix.GetLength(0) != matrix.GetLength(1)) return answer;
            

            answer = new int[matrix.GetLength(1) * 2 - 1];
            int n = matrix.GetLength(0);
            int k = 0;
            
            for (int raw = n - 1; raw >= 0; raw--)
            {
                int sum = 0;
                for (int col = 0; col < n - raw; col++)
                {
                    sum += matrix[raw + col, col];
                } 
                answer[k++] = sum;
            }
            
            for (int col = 1; col < n; col++)
            {
                int sum = 0;
                for (int raw = 0; raw < n - col; raw++)
                {
                    sum += matrix[raw, col + raw];
                }
                answer[k++] = sum;
            }
        
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int max = 0;
            int indexi = 0;
            int indexj = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(max))
                    {
                        max = matrix[i, j];
                        indexi = i;
                        indexj = j;
                    }
                }
            }
            int sdvi = k - indexi;
            int sdvj = k - indexj;

            if (sdvi < 0)
            {
                for (int i = indexi; i > k; i--)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = indexi; i < k; i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                    }
                }
            }

            if (sdvj < 0)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = indexj; j > k; j--)
                    {
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = indexj; j < k; j++)
                    {
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }
            }

            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1) != B.GetLength(0)) return answer;
            answer = new int[A.GetLength(0), B.GetLength(1)];
            
            for (int raw = 0; raw < A.GetLength(0); raw++)
            {
                for (int col = 0; col < B.GetLength(1); col++)
                {
                    for (int j = 0; j < B.GetLength(0); j++)
                    {
                        answer[raw, col] += A[raw, j] * B[j, col];
                    }
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            answer = new int[matrix.GetLength(0)][];
            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) count++;
                }

                answer[i] = new int[count];
                int index = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][index++] = matrix[i, j];
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                Console.WriteLine(string.Join(" ", answer[i]));
            }
            Console.WriteLine("--------------------------------");
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                cnt += array[i].Length;
            }

            int[] arr = new int[cnt];
            int k = 0;
            foreach (int[] i in array)
            {
                foreach (int el in i)
                {
                    arr[k++] = el;
                }
            }
            k = 0;
            int r = Convert.ToInt32(Math.Ceiling(Math.Sqrt(1.0f * arr.Length)));
            answer = new int[r, r];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    if (k >= arr.Length) break;
                    answer[i, j] = arr[k++];
                }
            }
            // end

            return answer;
        }
    }
}
