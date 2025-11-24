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
            
            int l = matrix.GetLength(1), cow = 0;
            answer = new int[l];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                cow = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                        cow++;
                }
                answer[j] = cow;
            }
            
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0], minid = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minid = j;
                    }
                }
                for (int j = minid; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
                matrix[i, 0] = min;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0], maxid = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxid = j;
                    }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == maxid)
                        answer[i, j + 1] = matrix[i, j];
                    if (j <= maxid)
                        answer[i, j] = matrix[i, j];
                    else
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
                int max = matrix[i, 0], maxid = 0, sred = 0, cow = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxid = j;
                    }
                }

                for (int j = maxid + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sred += matrix[i, j];
                        cow++;
                    }
                }

                if (cow > 0)
                {
                    sred /= cow;
                    for (int j = 0; j < maxid; j++)
                        if (matrix[i, j] < 0)
                            matrix[i, j] = sred;
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            if (k < 0 | k >= matrix.GetLength(1))
                return;

            int[] temp = new int[matrix.GetLength(0)];
            int cow = matrix.GetLength(0) - 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                temp[cow--] = max;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
                matrix[i, k] = temp[i];
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            if (array.Length != matrix.GetLength(1))
                return;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = matrix[0, j], maxid = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxid = i;
                    }
                }
                if (max < array[j])
                    matrix[maxid, j] = array[j];
            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int[] temp = new int[matrix.GetLength(0)];
            int cow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                temp[cow++] = min;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(0) - 1; k++)
                {
                    if (temp[k] < temp[k + 1])
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                            (matrix[k, j], matrix[k + 1, j]) = (matrix[k + 1, j], matrix[k, j]);
                        (temp[k], temp[k + 1]) = (temp[k + 1], temp[k]);
                    }
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return answer;
            int n = matrix.GetLength(0);
            answer = new int[2 * n - 1];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    answer[(n * 2 - 1) / 2 + j - i] += matrix[i, j];

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (k >= matrix.GetLength(0) || matrix.GetLength(0) != matrix.GetLength(1) || k < 0)
                return;

            int max = 0, idx = 0, idy = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (Math.Abs(matrix[i, j]) > max)
                    {
                        max = Math.Abs(matrix[i, j]);
                        idx = i;
                        idy = j;
                    }
            
            int cow = 0;
            int[] temp = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
                temp[cow++] = matrix[int.Max(k, idx), j];
            cow = 0;

            for (int i = int.Max(k, idx); i > int.Min(k, idx); i--)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = matrix[i - 1, j];

            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[int.Min(k, idx), j] = temp[cow++];
            cow = 0;


            temp = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                temp[cow++] = matrix[i, int.Max(k, idy)];
            cow = 0;
            for (int j = int.Max(k, idy); j > int.Min(k, idx); j--)
                for (int i = 0; i < matrix.GetLength(0); i++)
                    matrix[i, j] = matrix[i, j - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
                matrix[i, int.Min(k, idy)] = temp[cow++];
            
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1) != B.GetLength(0))
                return answer;
            int suma = 0;
            answer = new int[A.GetLength(0), B.GetLength(1)];
            for (int k = 0; k < B.GetLength(1); k++)
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    suma = 0;
                    for (int j = 0; j < A.GetLength(1); j++)
                        suma += A[i, j] * B[j, k];
                    answer[i, k] = suma;
                }
                    
                
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int s = 0;
            
            answer = new int[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0)
                        s++;
                answer[i] = new int[s];
                s = 0;
            }

            int n = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0)
                        answer[i][n++] = matrix[i, j];
                n = 0;
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int cow = 0;
            for (int i = 0; i < array.Length; i++)
                cow += array[i].Length;
            int[] temp = new int[cow + 1];
            int size = (int) Math.Ceiling(Math.Sqrt(cow));
            cow = 0;
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    temp[cow++] = array[i][j];
            
            cow = 0;
            answer = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (cow < temp.Length)
                        answer[i, j] = temp[cow++];
            // end

            return answer;
        }
    }
}