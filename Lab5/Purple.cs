using System.Linq;
using System.Numerics;
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
            int k = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int amount = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        amount++;
                    }
                }

                answer[k] = amount;
                k++;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int imin = 0;

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i, imin])
                    {
                        imin = j;
                    }
                }

                int[] array = new int[matrix.GetLength(1)];
                array[0] = matrix[i, imin];
                int cur = 1;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != imin)
                    {
                        array[cur] = matrix[i, j];
                        cur++;
                    }
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[j];
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
                int imax = 0;
                
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, imax])
                    {
                        imax = j;
                    }
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < imax)
                    {
                        answer[i, j] = matrix[i, j];
                    } else if (j == imax)
                    {
                        answer[i, j] = matrix[i, j];
                        answer[i, j + 1] = matrix[i, j];
                    } else
                    {
                        answer[i, j + 1] = matrix[i, j];
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
                int imax = 0;
                
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, imax])
                    {
                        imax = j;
                    }
                }

                if (imax != matrix.GetLength(1) - 1)
                {
                    int sum = 0, count = 0;

                    for (int j = imax + 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            sum += matrix[i, j];
                            count++;
                        }
                    }

                    if (count != 0)
                    {
                        for (int j = 0; j < imax; j++)
                        {
                            if (matrix[i, j] < 0)
                            {
                                matrix[i, j] = sum / count;
                            }
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

            if (k >= 0 && k < matrix.GetLength(1))
            {
                int[] array = new int[matrix.GetLength(0)];
                int cc = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int imax = 0;

                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > matrix[i, imax])
                        {
                            imax = j;
                        }
                    }

                    array[cc] = matrix[i, imax];
                    cc++;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = array[matrix.GetLength(0) - 1 - i];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            if (matrix.GetLength(1) == array.Length)
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

                    if (array[j] > matrix[imax, j])
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
            int[] mins = new int[matrix.GetLength(0)];

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

                mins[i] = matrix[i, jmin];
            }

            for (int i = 0; i < mins.Length - 1; i++)
            {
                for (int j = 0; j < mins.Length - 1 - i; j++)
                {
                    if (mins[j] < mins[j + 1])
                    {
                        (mins[j], mins[j + 1]) = (mins[j + 1], mins[j]);

                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
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

            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                answer = new int[2 * matrix.GetLength(0) - 1];

                for (int i = 1; i < 2 * matrix.GetLength(0); i++)
                {
                    int sum = 0;
                    int first, second;

                    if (matrix.GetLength(0) - i >= 0)
                    {
                        first = matrix.GetLength(0) - i;
                        second = 0;
                    } else
                    {
                        first = 0;
                        second = i - matrix.GetLength(0);
                    }

                    for (int j = 0; j < matrix.GetLength(0) - Math.Abs(matrix.GetLength(0) - i); j++)
                    {
                        sum += matrix[first, second];
                        first++;
                        second++;
                    }

                    answer[i - 1] = sum;
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
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[imax, jmax]))
                        {
                            imax = i;
                            jmax = j;
                        }
                    }
                }

                int n = matrix.GetLength(0);
                int[] row_order = new int[n];
                for (int i = 0; i < n; i++)
                {
                    row_order[i] = i;
                }

                int[] col_order = new int[n];
                for (int j = 0; j < n; j++)
                {
                    col_order[j] = j;
                }

                if (imax != k)
                {
                    int saved_row = row_order[imax];

                    if (imax < k)
                    {
                        for (int i = imax; i < k; i++)
                        {
                            row_order[i] = row_order[i + 1];
                        }
                    }
                    else
                    {
                        for (int i = imax; i > k; i--)
                        {
                            row_order[i] = row_order[i - 1];
                        }
                    }

                    row_order[k] = saved_row;
                }

                if (jmax != k)
                {
                    int saved_col = col_order[jmax];

                    if (jmax < k)
                    {
                        for (int j = jmax; j < k; j++)
                        {
                            col_order[j] = col_order[j + 1];
                        }
                    }
                    else
                    {
                        for (int j = jmax; j > k; j--)
                        {
                            col_order[j] = col_order[j - 1];
                        }
                    }

                    col_order[k] = saved_col;
                }

                int[,] temp = new int[n, n];

                for (int new_i = 0; new_i < n; new_i++)
                {
                    int old_i = row_order[new_i];
                    for (int new_j = 0; new_j < n; new_j++)
                    {
                        int old_j = col_order[new_j];
                        temp[new_i, new_j] = matrix[old_i, old_j];
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = temp[i, j];
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
                answer = new int[A.GetLength(0), B.GetLength(1)];

                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        int sum = 0;

                        for (int k = 0; k < A.GetLength(1); k++)
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
            answer = new int[matrix.GetLength(0)][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int how_many = matrix.GetLength(1);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] <= 0)
                    {
                        how_many--;
                    }
                }

                answer[i] = new int[how_many];
                int k = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
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
            int total = 0;
            for (int i = 0; i < array.Length; i++)
                    total += array[i].Length;

            answer = new int[(int)Math.Ceiling(Math.Sqrt(total)), (int)Math.Ceiling(Math.Sqrt(total))];
            int[] total_array = new int[total];
            int k = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    total_array[k] = array[i][j];
                    k++;
                }
            }

            k = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                if (k == total)
                {
                    break;
                }
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    answer[i, j] = total_array[k];
                    k++;
                    
                    if (k == total)
                    {
                        break;
                    }
                }
            }
            // end

            return answer;
        }
    }
}
