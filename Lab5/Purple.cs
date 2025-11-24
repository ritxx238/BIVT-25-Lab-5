using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text.Json.Serialization.Metadata;

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
                int cnt = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        cnt++;
                    }
                }
                answer[k++] = cnt;
            }
            k = 0;

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mn = int.MaxValue, ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                        ind = j;
                    }
                }
                if (ind > 0)
                {
                    for (int j = ind; j >= 1; j--)
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }
                    matrix[i, 0] = mn;
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
                int mx = int.MinValue, ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        ind = j;
                    }
                }
                for (int elem = 0; elem < answer.GetLength(1); elem++)
                {
                    if (elem == ind + 1)
                    {
                        answer[i, elem] = mx;
                    }
                    else if (elem > ind)
                    {
                        answer[i, elem] = matrix[i, elem - 1];
                    }
                    else
                    {
                        answer[i, elem] = matrix[i, elem];
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
                int mx = int.MinValue, ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        ind = j;
                    }
                }
                double avg = 0;
                double sum = 0; int cnt = 0;
                for (int j = ind + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        cnt++;
                    }
                }
                if (cnt > 0)
                {
                    avg = sum / cnt;
                    for (int j = 0; j < ind; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = (int)avg;
                        }
                    }
                }
            }


            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

            int[] max = new int[matrix.GetLength(0)];

            if (k < matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int mx = int.MinValue;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                        }
                    }
                    max[i] = mx;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = max[max.Length - i - 1];
                }
            }

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            if (matrix.GetLength(1) == array.Length)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int mx = int.MinValue, ind = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                            ind = i;
                        }
                    }
                    if (array[k] > mx)
                    {
                        matrix[ind, j] = array[k];
                    }
                    k++;
                }
            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int[,] new_matrix = new int[matrix.GetLength(0), 2];

            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mn = int.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                    }
                }

                new_matrix[k, 0] = mn;
                new_matrix[k, 1] = i;
                k++;
            }

            for (int i = 0; i < new_matrix.GetLength(0); i++)
            {
                bool swap = false;
                for (int j = 0; j < new_matrix.GetLength(0) - i - 1; j++)
                {
                    if (new_matrix[j, 0] < new_matrix[j + 1, 0])
                    {
                        (new_matrix[j, 0], new_matrix[j + 1, 0]) = (new_matrix[j + 1, 0], new_matrix[j, 0]);
                        (new_matrix[j, 1], new_matrix[j + 1, 1]) = (new_matrix[j + 1, 1], new_matrix[j, 1]);
                        swap = true;
                    }
                }
                if (!swap)
                {
                    break;
                }
            }

            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matrix[new_matrix[i, 1], j];
                }
            }

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    matrix[i, j] = result[i, j];
                }
            }

            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here

            if ((matrix != null) && (matrix.GetLength(0) == matrix.GetLength(1)))
            {
                answer = new int[matrix.GetLength(0) * 2 - 1];
                int c = 0;

                for (int cnt = 0; cnt < matrix.GetLength(0); cnt++)
                {
                    int local_sum = 0;
                    int i = matrix.GetLength(0) - 1 - cnt;
                    int j = 0;
                    while (i < matrix.GetLength(0) && j < matrix.GetLength(1))
                    {
                        local_sum += matrix[i, j];
                        i++;
                        j++;
                    }
                    answer[c++] = local_sum;
                }

                for (int cnt = matrix.GetLength(0) - 2; cnt >= 0; cnt--)
                {
                    int local_sum = 0;
                    int i = 0;
                    int j = matrix.GetLength(0) - 1 - cnt;
                    while (i < matrix.GetLength(0) && j < matrix.GetLength(1))
                    {
                        local_sum += matrix[i, j];
                        i++;
                        j++;
                    }
                    answer[c++] = local_sum;
                }
            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            if (k >= matrix.GetLength(0) || matrix.GetLength(0) != matrix.GetLength(1) || k < 0)
                return;

            int mx = 0, mx_row = 0, mx_col = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (Math.Abs(matrix[i, j]) > mx)
                    {
                        mx = Math.Abs(matrix[i, j]);
                        mx_row = i;
                        mx_col = j;
                    }
                }
            }

            int[] temp_row = new int[matrix.GetLength(0)];
            int[] temp_col = new int[matrix.GetLength(0)];

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                temp_row[j] = matrix[mx_row, j];
            }

            for (int i = mx_row; i > k; i--)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = matrix[i - 1, j];
                }
            }

            for (int i = mx_row; i < k; i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = matrix[i + 1, j];
                }
            }

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrix[k, j] = temp_row[j];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                temp_col[i] = matrix[i, mx_col];
            }

            for (int j = mx_col; j > k; j--)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
            }

            for (int j = mx_col; j < k; j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, k] = temp_col[i];
            }

            // end
        }


        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here

            if (A.GetLength(1) == B.GetLength(0) && A != null && B != null)
            {
                int rows = A.GetLength(0);
                int cols = B.GetLength(1);
                answer = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
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
                int cnt_neg = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt_neg++;
                    }
                }
                answer[i] = new int[cnt_neg];
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][k++] = matrix[i, j];
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

            int len = 0;
            for (int i = 0; i < array.Length; i++)
            {
                len += array[i].Length;
            }

            int new_len = (int)Math.Ceiling(Math.Sqrt(len));

            answer = new int[new_len, new_len];
            int k1 = 0, k2 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (k2 == new_len)
                    {
                        k1++;
                        k2 = 0;
                    }
                    answer[k1, k2++] = array[i][j];
                }
            }

            // end

            return answer;
        }
    }
}
