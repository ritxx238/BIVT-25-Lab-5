using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int s = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        s++;
                    }
                }
                answer[i] = s;
            }


            return answer;
        }
        public void Task2(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int idx = 0;
           
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i, idx])
                    {
                        idx = j;
                    }   
                }
                if (idx != 0)
                {
                    int r = matrix[i, 0];
                    matrix[i, 0] = matrix[i, idx];
                    for (int j = 1; j <= idx; j++)
                    {
                        (matrix[i, j], r) = (r, matrix[i, j]);
                    }
                }
            }

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int idx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, idx])
                    {
                        idx = j;
                    }
                }

                for (int j = 0; j <= idx; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, idx + 1] = matrix[i, idx];
                for (int j = idx + 2; j < answer.GetLength(1); j++)
                {
                    answer[i, j] = matrix[i, j - 1];
                }
                
            }

            return answer;

        }
        public void Task4(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int idx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, idx])
                    {
                        idx = j;
                    }
                }
                if (idx == 0 || idx == matrix.GetLength(1) - 1) { continue; }
                int sum = 0, c = 0;
                for (int j = idx + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        c++;
                    }
                }
                if (c == 0) { continue; }
                int avg = sum / c;
                for (int j = 0; j < idx; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = avg;
                    }
                }

            }
            
        }
        public void Task5(int[,] matrix, int k)
        {
            if (k >= 0 && k < matrix.GetLength(1))
            {
                int[] r = new int[matrix.GetLength(0)];
                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                {
                    int el = matrix[i, 0];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > el)
                        {
                            el = matrix[i, j];
                        }
                    }
                    r[matrix.GetLength(0) - 1 - i] = el;
                }
             
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = r[i];
                }
            }

        }
        public void Task6(int[,] matrix, int[] array)
        {
            if (array.Length == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    int idx = 0;
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (matrix[j, i] > matrix[idx, i])
                        {
                            idx = j;
                        }
                    }
                    if (matrix[idx, i] < array[i])
                    {
                        matrix[idx, i] = array[i];
                    }
                    
                }
            }

        }
        public void Task7(int[,] matrix)
        {
            //тут много чегг
            // Я бы хотел чтобы меня называли все талант
            // Но уже есть один талант по псевдонимом Травоман
            int[,] r = new int[matrix.GetLength(0), 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int idx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i, idx])
                    {
                        idx = j;
                    }     
                }
                (r[i, 0], r[i, 1]) = (i, matrix[i, idx]);
            }

            //сортировка
            for (int idx = 1; idx < r.GetLength(0); idx++)
            {
                int i = idx;
                for (int j = i - 1 ; j >= 0; j--)
                {
                    if (r[i, 1] > r[j, 1])
                    {
                        (r[i, 0], r[j, 0], r[i, 1], r[j, 1]) = (r[j, 0], r[i, 0], r[j, 1], r[i, 1]);
                        i = j;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //меняет местами строки
            int[,] k = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    k[i, j] = matrix[r[i, 0], j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = k[i, j];
                }
            }



        }
        public int[] Task8(int[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int[] answer = new int[2*matrix.GetLength(0) - 1];
                int k = 0;
                for (int i = matrix.GetLength(0) - 1; i >= 0; i--, k++)
                {
                    int sum = 0, idx = i, j = 0;
                    while (idx < matrix.GetLength(0))
                    {
                        sum += matrix[idx, j];
                        j++;
                        idx++;
                    }
                    answer[k] = sum;
                }
                for (int i = 1; i < matrix.GetLength(0); i++, k++)
                {
                    int sum = 0, idx = i, j = 0;
                    while (idx < matrix.GetLength(0))
                    {
                        sum += matrix[j, idx];
                        j++;
                        idx++;
                    }
                    answer[k] = sum;
                }

                return answer;
            }
            else
            {
                return null;
            }
            
        }
        public void Task9(int[,] matrix, int k)
        {

            if (matrix.GetLength(0) == matrix.GetLength(1) && k >= 0 && k <= matrix.GetLength(0))
            {
                //максимальная
                int idx1 = 0, idx2 = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[idx1, idx2]))
                        {
                            idx1 = i; idx2 = j;
                        }
                    }
                }

                //строки 
                int[] r = new int[matrix.GetLength(0)];
                
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    r[i] = matrix[idx1, i];
                }

                if (idx1 < k)
                {
                    for (int i = idx1; i < k; i++)
                    {
                        for (int j = 0; j < matrix.GetLength(0); j++)
                        {
                            matrix[i, j] = matrix[i + 1, j];
                        }
                    }

                }
                else
                {
                    for (int i = idx1; i > k; i--)
                    {
                        for (int j = 0; j < matrix.GetLength(0); j++)
                        {
                            matrix[i, j] = matrix[i - 1, j];
                        }
                    }
                }
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[k, j] = r[j];
                }
                //столбцы
                int[] c = new int[matrix.GetLength(0)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    c[i] = matrix[i, idx2];
                }
                if (idx2 < k)
                {
                    for (int i = idx2; i < k; i++)
                    {
                        for (int j = 0; j < matrix.GetLength(0); j++)
                        {
                            matrix[j, i] = matrix[j, i + 1];
                        }
                            
                    }      
                }
                else
                {
                    for (int i = idx2; i > k; i--)
                    {
                        for (int j = 0; j < matrix.GetLength(0); j++)
                        {
                            matrix[j, i] = matrix[j, i - 1];
                        }   
                    }
                        
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = c[i];
                }
            }

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            if (A.GetLength(1) == B.GetLength(0))
            {
                int[,] answer = new int[A.GetLength(0), B.GetLength(1)];
                for (int i = 0; i < answer.GetLength(0); i++)
                {
                    for (int j = 0; j < answer.GetLength(1); j++)
                    {
                        int sum = 0;
                        for (int x = 0; x < A.GetLength(1); x++)
                        {
                            sum += A[i, x] * B[x, j];
                        }
                        answer[i, j] = sum;
                    }
                }
                return answer;
            }
            return null;
            
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = new int[matrix.GetLength(0)][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int s = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s++;
                    }
                }
                answer[i] = new int[s];
                int x = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][x] = matrix[i, j];
                        x++;
                    }
                }
            }

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            

            int s = 0;
            for (int i = 0; i < array.Length; i++)
            {
                s += array[i].Length;
            }
            //
            int m = (int)Math.Ceiling(Math.Sqrt(s));
            int[,] answer = new int[m, m];
            //
            int r = 0;
            int[] x = new int[s];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    x[r] += array[i][j];
                    r++;
                }
            }
            //
            int t = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(0); j++)
                {
                    if (t < x.Length)
                    {
                        answer[i, j] = x[t];
                        t++;
                    }
                    else
                    {
                        answer[i, j] = 0;
                    }
                }
            }

            return answer;
        }
    }
}