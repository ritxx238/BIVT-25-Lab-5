using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
           

            // code here
            int[] answer = new int[matrix.GetLength(1)];

            int k = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        c++;
                    }

                }
                answer[k++] = c;

            }

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int[,] matrix1 = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix1[i, j] = matrix[i, j];
                }

            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mn = int.MaxValue;
                int imn = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                        imn = j;

                    }
                }
                for (int k = 0; k < imn; k++)
                {
                    matrix1[i, k + 1] = matrix[i, k];
                }
                matrix1[i, 0] = mn;



            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix1[i, j];
                }
            }

                // end

            }
        public int[,] Task3(int[,] matrix)
        {
            

            // code here
            int[,] matrix1 = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx = int.MinValue;
                int imx = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        imx = j;
                    }

                }

                int c = 0;
                for (int k = 0; k <= imx; k++)
                {
                    matrix1[i, k] = matrix[i, c++];

                }
                int count = c;
                for (int l = imx + 2; l < matrix1.GetLength(1); l++)
                {
                    matrix1[i, l] = matrix[i, count++];
                }
                matrix1[i, imx + 1] = mx;

            }
            // end

            return matrix1;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx = -1000;
                int imx = -1;
                int sr = 0;
                int sum = 0;
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        imx = j;

                    }
                }
                if (imx < matrix.GetLength(1))
                {
                    for (int j = imx + 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            sum += matrix[i, j];
                            c++;
                        }
                    }
                }
                if (c > 0)
                {
                    sr = sum / c;
                    for (int j = 0; j < imx; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = sr;
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
                int[,] matrix2 = new int[matrix.GetLength(0), matrix.GetLength(1)];
                int count = 0;
                int[] answer = new int[matrix.GetLength(0)];
                int[] answer1 = new int[matrix.GetLength(0)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {

                    int count1 = 0;
                    int mx = int.MinValue;
                    int imx = -1;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                            imx = j;


                        }
                    }

                    answer[count++] = mx;
                    for (int a = answer1.Length - 1; a >= 0; a--)
                    {
                        answer1[count1++] = answer[a];

                    }
                    for (int b = 0; b < matrix.GetLength(0); b++)
                    {
                        for (int h = k; h <= k; h++)
                        {

                            matrix2[b, h] = answer1[b];


                        }
                    }
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = k; j <= k; j++)
                    {
                        matrix[i, j] = matrix2[i, j];
                    }
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
                    int mx = int.MinValue;
                    int imx = -1;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                            imx = i;

                        }
                    }
                    if (j < array.Length)
                    {
                        if (array[j] > matrix[imx, j])
                        {
                            matrix[imx, j] = array[j];
                        }
                    }


                }
            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here

            int[] array = new int[matrix.GetLength(0)];

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
                array[i] = mn;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(0) - i; j++)
                {
                    if (array[j] > array[j - 1])
                    {
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
                        for (int jj = 0; jj < matrix.GetLength(1); jj++)
                        {
                            (matrix[j, jj], matrix[j - 1, jj]) = (matrix[j - 1, jj], matrix[j, jj]);
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
                answer = new int[(2 * matrix.GetLength(0)) - 1];
                int k = 0;
                for (int i = matrix.GetLength(0) - 1; i >= 1; i--)
                {
                    int s = 0;
                    for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
                    {
                        if (i + j < matrix.GetLength(0))
                        {
                            s += matrix[j + i, j];
                        }
                    }
                    answer[k++] = s;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int sum = 0;
                    for (int j = 0; j + i < matrix.GetLength(0); j++)
                    {
                        sum += matrix[j, j + i];
                    }
                    answer[k++] = sum;
                }


            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength (0) == matrix.GetLength (1))
            {
                int mx = -10000;
                int imx = -1;
                int jmx = -1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (Math.Abs(matrix[i, j]) > mx)
                        {
                            mx = Math.Abs(matrix[i, j]);
                            imx = i;
                            jmx = j;

                        }
                    }
                }

                if (k < matrix.GetLength(0))
                {
                    if (k > imx)
                    {
                        for (int i = imx; i < k; i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);

                            }
                        }
                    }
                    else if (k < imx)
                    {
                        for (int i = imx; i > k; i--)
                        {

                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                (matrix[i - 1, j], matrix[i, j]) = (matrix[i, j], matrix[i - 1, j]);

                            }
                        }
                    }
                }
                if (k < matrix.GetLength(1))
                {
                    if (k < jmx)
                    {
                        for (int j = jmx; j > k; j--)
                        {
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                (matrix[i, j - 1], matrix[i, j]) = (matrix[i, j], matrix[i, j - 1]);
                            }
                        }
                    }
                    else if (k > jmx)
                    {
                        for (int j = jmx; j < k; j++)
                        {
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                (matrix[i, j + 1], matrix[i, j]) = (matrix[i, j], matrix[i, j + 1]);
                            }
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
            if (A.GetLength(1) == B.GetLength(0))
            {
                answer = new int[A.GetLength(0), B.GetLength(1)];
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int k = 0; k < B.GetLength(1); k++)
                    {
                        for (int j = 0; j < A.GetLength(1); j++)
                        {
                            answer[i, k] += A[i, j] * B[j, k];
                            Console.WriteLine(answer[i, k]);
                        }
                    }

                }
            }

            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {

            // code here
            int[][] answer = new int[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }
                answer[i] = new int[c];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
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
            int c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    c++;
                }
            }

            if (Math.Sqrt(c) == (int)Math.Sqrt(c))
            {
                int[] arr = new int[c];
                int k = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        arr[k++] = array[i][j];
                    }
                }
                int count = 0;
                answer = new int[(int)Math.Sqrt(c), (int)Math.Sqrt(c)];
                for (int i = 0; i < answer.GetLength(0); i++)
                {
                    for (int j = 0; j < answer.GetLength(1); j++)
                    {
                        answer[i, j] = arr[count++];
                    }
                }
            }
            else
            {
                int[] arr = new int[((int)Math.Sqrt(c) + 1) * ((int)Math.Sqrt(c) + 1)];
                int k = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        arr[k++] = array[i][j];
                    }
                }
                answer = new int[(int)Math.Sqrt(c) + 1, (int)Math.Sqrt(c) + 1];
                int kk = 0;
                for (int i = 0; i < answer.GetLength(0); i++)
                {
                    for (int j = 0; j < answer.GetLength(1); j++)
                    {
                        answer[i, j] = arr[kk++];
                    }
                }
            }

            // end

            return answer;
        }
    }
}
