using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {

            int c;
            int[] answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                c = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j,i] < 0) c++;
                }
                answer[i] = c;
            }

            return answer;
        }
        public void Task2(int[,] matrix)
        {
            int idy=0;
            
            int cur;
            int[] id = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                        idy = j;
                    }
                    id[i] = idy;
                }
                
                
            }

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                cur = id[i];
                    
                    if ( cur != 0)
                    {
                        int temp = matrix[i, cur];
                        for (int j = cur; j > 0; j--)
                        {
                            matrix[i, j] = matrix[i, j - 1];
                        }
                         matrix[i, 0] = temp;
                    
                    }
                }
 

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] f = new int[matrix.GetLength(0), matrix.GetLength(1) + 1]; 
            int max;
            int[] id = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                max = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        id[i] = j;
                    }
                }

                for (int j = 0; j <= id[i]; j++)
                {
                    f[i, j] = matrix[i, j];
                }

                f[i, id[i] + 1] = max;

                for (int j = id[i] + 1; j < matrix.GetLength(1); j++)
                {
                    f[i, j + 1] = matrix[i, j];
                }
            }

            return f; 
        }
    
        public void Task4(int[,] matrix)
        {
            int max;
            int s=0,c=0,aver=0;

            int[] id = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                s = 0;
                c = 0;
                max = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        id[i] = j;
                    }

                }
                for (int j = id[i]; j < matrix.GetLength(1); j++)
                {

                    if (id[i] == j) continue;
                    else if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        c++;
                    }
                }
                if (c > 0)
                {
                    aver = s / c;
                    for (int j = 0; j < id[i]; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = aver;
                        }
                    }
                }
            }
        }
        public void Task5(int[,] matrix, int k)
        {
            if (k >=matrix.GetLength(1))return;
            int[] id = new int[matrix.GetLength(0)];
            int max, idx = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                max = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                    }
                }
                id[i] =max;               
            }

            for (int i = 0, j = id.Length - 1; i < j; i++, j--)
            {
                (id[i], id[j]) = (id[j], id[i]);
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, k] = id[i];
            }
            
        }
        public void Task6(int[,] matrix, int[] array)
        {         

            if (matrix.GetLength(1) != array.Length) return;
            int maxi,idx;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                idx = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[idx, i] < matrix[j, i])
                    {
                        idx = j;
                    }
                }
                matrix[idx, i] = Math.Max(array[i],matrix[idx,i]);
  
            }
            
            



        }
        public void Task7(int[,] matrix)
        {
            int min;
            int[,] mins = new int[matrix.GetLength(0), 2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                min = int.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                    }
                }
                mins[i, 0] = i;
                mins[i, 1] = min;
            }
            for (int i = 0; i < mins.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < mins.GetLength(0); j++)
                {
                    if (mins[i, 1] < mins[j, 1])
                    {
                        (mins[i, 0], mins[j, 0]) = (mins[j, 0], mins[i, 0]);
                        (mins[i, 1], mins[j, 1]) = (mins[j, 1], mins[i, 1]);
                    }
                }
            }
            int[,] res = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int r = mins[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res[i, j] = matrix[r, j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = res[i, j];
                }
            }
        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = new int[2 * matrix.GetLength(0) - 1];
            if (matrix.GetLength(0) != matrix.GetLength(1)) return null;
            int s;
            int st=0, end=1;
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                s = 0;
                for (int j = 0; j < end; j++)
                {
                    if (j == 0) s += matrix[i, j];
                    else if (j > 0)
                    {
                        if ((i + j) < matrix.GetLength(0))
                        {
                            s += matrix[i + j, j];
                        }
                    }

                }
                answer[st++] = s;
                end++;
            }
            end = matrix.GetLength(0)-1;
            for(int i = 1; i < matrix.GetLength(0); i++)
            {
                s = 0;

                for (int j = 0; j<end; j++)
                {   
                    
                    if (j == 0) s += matrix[0, i];
                    else if (i + j<matrix.GetLength(0))
                    {
                        s += matrix[j, i + j];                        
                    }
                    
                }
                
                end--;
                answer[st++] = s;
            }

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int max = 0;
            int idx = 0;
            int idy = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(max))
                    {
                        max = matrix[i, j];
                        idx = i;
                        idy = j;
                    }
                }
            }

            int sdvi = k - idx;
            int sdvj = k - idy;
            if (sdvi < 0)
            {
                for (int i = idx; i > k; i--)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = idx; i < k; i++)
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
                    for (int j = idy; j > k; j--)
                    {
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = idy; j < k; j++)
                    {
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }
            }


        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;
            if (A.GetLength(1) != B.GetLength(0)) return answer;
            answer = new int[A.GetLength(0),B.GetLength(1)];
            for(int i=0; i < A.GetLength(0); i++)
            {
                for(int j = 0; j < B.GetLength(1); j++)
                {
                    for(int k = 0; k < B.GetLength(0); k++)
                    {
                        answer[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;
            answer = new int[matrix.GetLength(0)][];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0, st = 0; ;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) c++;
                }
                int[] plus = new int[c];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        plus[st++] = matrix[i, j];
                    }
                }
                if (c > 0)
                {
                    for (int j = 0; j < plus.Length; j++)
                    {
                        answer[i] = plus;
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
            int l = (int)Math.Ceiling(Math.Sqrt(s));
            int[,] answer = new int[l, l];
            int st = 0;
            int[] x = new int[s];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    x[st++] = array[i][j]; 
                }
            }
            st = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++) 
                {
                    if (st < x.Length)
                    {
                        answer[i, j] = x[st++];
                        
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