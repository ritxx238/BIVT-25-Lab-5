using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Microsoft.VisualBasic;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];
            int cnt = 0, ind = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        cnt++;
                    }
                }
                answer[ind++] = cnt;
                cnt = 0;                
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int min_ind = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < matrix[i, min_ind])
                    {
                        min_ind = j;
                    }
                }
                for (int j = min_ind; j > 0; j--)
                {
                    (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                }
                min_ind = 0;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            int mx_ind = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, mx_ind])
                    {
                        mx_ind = j;
                    }
                }
                for (int j = 0; j < m; j++)
                {
                    if (j < mx_ind)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == mx_ind)
                    {
                        answer[i, j] = matrix[i, j];
                        answer[i, j + 1] = matrix[i, j];
                    }
                    else
                    {
                        answer[i, j + 1] = matrix[i, j];
                    }
                }
                mx_ind = 0;
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int mxf_ind = 0, row_avg = 0, cnt_pos = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, mxf_ind])
                    {
                        mxf_ind = j;
                    }
                }
                for (int j = mxf_ind + 1; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        row_avg += matrix[i, j];
                        cnt_pos++;
                    }
                }
                if (cnt_pos > 0)
                {
                    row_avg /= cnt_pos;
                    for (int j = 0; j < mxf_ind; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = row_avg;
                        }
                    }
                }
                row_avg = 0;
                cnt_pos = 0;
                mxf_ind = 0;
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] each_max = new int[n];
            int ind_mx = 0, ind = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, ind_mx])
                    {
                        ind_mx = j;
                    }
                }
                each_max[ind++] = matrix[i, ind_mx];
            }
            ind = 0;
            if (k < m)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = each_max[i];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int max_ind = 0, ind = 0;
            int f = 0;
            if (m == array.Length )
            {
                for (int j = 0; j < m; j++)
                {
                    for (int i = 1; i < n; i++)
                    {
                        if (matrix[i, j] > matrix[max_ind, j])
                        {
                            max_ind = i;
                        }
                    }
                    if (j < array.Length)
                
                    {
                        if (matrix[max_ind, j] < array[j])
                        {
                            matrix[max_ind, j] = array[j];
                        }
                    }
                    max_ind = 0;
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] arr = new int[n];
            int ind = 0;
            for (int i = 0; i < n; i++)
            {
                ind = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < matrix[i, ind])
                    {
                        ind = j;
                    }
                }
                arr[i] = matrix[i, ind];
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        for (int k = 0; k < m; k++)
                        {
                            (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                        }
                    }
                }
            }
        }        
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0), k = matrix.GetLength(1);
            int m = 2 * n - 1;
            answer = new int[m];
            if ((n == 1) & (k == 1))
            {
                answer[0] = matrix[0, 0];
            }
            else if (n != k)
            {
                return null;
            }
            else
            {
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        answer[j + m / 2 - i] += matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n == m)
            {
                int mx = Math.Abs(matrix[0, 0]);
                int i_mx = 0, j_mx = 0;
                // find_max_value
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > mx)
                        {
                            mx = Math.Abs(matrix[i, j]);
                            i_mx = i;
                            j_mx = j;
                        }
                    }
                }
                // move_row
                if (i_mx > k)
                {
                    for (int i = i_mx; i > k; i--)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                        }
                    }
                }
                else if (i_mx < k)
                {
                    for (int i = k; i > i_mx; i--)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                        }
                    }
                }
                // move_column
                if (j_mx > k)
                {
                    for (int j = j_mx; j > k; j--)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                        }
                    }
                }
                else if (j_mx < k)
                {
                    for (int j = k; j > j_mx; j--)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                        }
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int na = A.GetLength(0), nb = B.GetLength(0), ma = A.GetLength(1), mb = B.GetLength(1);

            if (ma == nb)
            {
                answer = new int[na, mb];

                for (int i = 0; i < na; i++)
                {
                    for (int j = 0; j < mb; j++)
                    {
                        int answer_el = 0;
                        for (int k = 0; k < ma; k++)
                        {
                            answer_el += A[i, k] * B[k, j];
                        }
                        answer[i, j] = answer_el;
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
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] arr_ln = new int[n];
            // finding_numb_of_non-neg_els_for_row
            for (int i = 0; i < n; i++)
            {
                int cnt = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt++;
                    }
                }
                arr_ln[i] = cnt;
            }
            //_the_result
            answer = new int[n][];
            int ind = 0;
            for (int i = 0; i < n; i++)
            {
                answer[i] = new int[arr_ln[i]];
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][ind++] = matrix[i, j];
                    }
                }
                ind = 0;
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int total_els = 0;
            int n = array.Length;
            int[] length_of_each_row = new int[n];
            for (int i = 0; i < n; i++)
            {
                total_els += array[i].Length;
                length_of_each_row[i] = array[i].Length;
            }
            int min_n = (int)Math.Ceiling(Math.Pow(total_els, 0.5));
            answer = new int[min_n, min_n];
            int currentIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    int row = currentIndex / min_n;
                    int col = currentIndex % min_n;
                    answer[row, col] = array[i][j];
                    currentIndex++;
                }
            }
            // end

            return answer;
        }
    }
}