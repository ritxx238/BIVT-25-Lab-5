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
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
        
                    if (matrix[j, i] < 0)
                    {
                        count++;
                    }
                }
                answer[i] = count;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int[] temp = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp[j] = matrix[i, j];
                }

                int min = temp.Min();
                int indxmin = Array.IndexOf(temp, min);
    
                if (indxmin == 0) continue;
    
                matrix[i, 0]=temp[indxmin];
                int index = 0;
                for (int j = 1; j <= indxmin; j++)
                {
                    matrix[i, j]=temp[index];
                    index++;
                }

                if (indxmin != matrix.GetLength(1) - 1)
                {
                    for (int j = indxmin + 1; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j]=temp[j];   
                    }
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] temp = new int[matrix.GetLength(1)];
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = matrix[i, j];
                }

                int max = temp.Max();
                int indxmax = Array.IndexOf(temp, max);
                for (int j = 0; j <= indxmax; j++)
                {
                    answer[i, j] = temp[j];
                }

                answer[i, indxmax + 1] = max;
                for (int j = indxmax + 2; j < answer.GetLength(1); j++)
                {
                    answer[i, j] = temp[j - 1];
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
                int[] temp = new int[matrix.GetLength(1)];
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = matrix[i, j];
                }
                int count = 0;
                int max = temp.Max();
                int indmax = Array.IndexOf(temp, max);
                for (int j = indmax + 1; j < temp.Length; j++)
                {
                    if (temp[j] > 0) count++;
                }
                if (count == 0) continue;
                int sr = 0;
                for (int j = indmax + 1; j < temp.Length; j++)
                {
                    if (temp[j] > 0)
                    {
                        sr += temp[j];
                    }
                }
    
                sr /= count;
                for (int j = 0; j < indmax; j++)
                {
                    if (temp[j] < 0) temp[j] = sr;
                }

    
                for (int j = 0; j < temp.Length; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            if (k < 0 || k >= matrix.GetLength(1)) return;
            int[] temp = new int[matrix.GetLength(0)];
            int index = temp.Length-1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                temp[index] = max;
                index--;
            }

            index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == k)
                    {
                        matrix[i, j] = temp[index];
                        index++;
                    }
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length != matrix.GetLength(1)) return;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int inmax=0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[inmax, j]<matrix[i,j])  inmax = i;
                }

                if (array[j] > matrix[inmax, j])
                {
                    matrix[inmax, j] = array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[] minValues = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }
                minValues[i] = min;
            }
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (minValues[j] < minValues[j + 1])
                    {
                        (minValues[j], minValues[j + 1]) = (minValues[j + 1], minValues[j]);
                        for (int k = 0; k < cols; k++)
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
            if (matrix.GetLength(0) != matrix.GetLength(1)) return answer;
            int n = matrix.GetLength(0);
            answer = new int[2*n-1];
            for (int k = 0; k < answer.Length; k++)
            {
                int sum = 0;
                int startRow = Math.Max(n - 1 - k, 0);
                int startCol = Math.Max(k - (n - 1), 0);
                for (int i = startRow, j = startCol; i < n && j < n; i++, j++)
                {
                    sum += matrix[i, j];
                }
        
                answer[k] = sum;
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
                        (matrix[i, j], matrix[i-1, j]) = (matrix[i-1, j], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = indexi; i < k; i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[i,j], matrix[i+1,j]) = (matrix[i+1,j], matrix[i,j]);
                    }
                }
            }

            if (sdvj < 0)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = indexj; j > k; j--)
                    {
                        (matrix[i,j], matrix[i, j-1])= (matrix[i, j-1], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = indexj; j < k; j++)
                    {
                        (matrix[i, j], matrix[i, j+1])= (matrix[i, j+1], matrix[i, j]);
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1)!=B.GetLength(0)) return answer;
            answer = new int[A.GetLength(0),B.GetLength(1) ];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        answer[i, j]+=A[i, k]*B[k, j];
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
                int[] temp= new int[matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp[j] = matrix[i, j];
                }

                int count = 0;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] > 0) count++;
                }
                int[] temp1 = new int[count];
                int index = 0;
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[j] > 0)
                    {
                        temp1[index]=temp[j];
                        index++;
                    }
                }

                answer[i] = new int[temp1.Length];
                for (int j = 0; j < temp1.Length; j++)
                {
                    answer[i][j] = temp1[j];
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }
            }

            int n = (int)Math.Sqrt(count);
            if (n*n != count)
            {
                n = n+1;
            }

            answer = new int[n, n];
            int[] temp = new int[n * n];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    temp[index++] = array[i][j];
                }
            }
            
            index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    answer[i, j] = temp[index++];
                }
            }
            // end

            return answer;
        }
    }

}
