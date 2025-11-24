using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;
            answer = new int[matrix.GetLength(1)];
            int k = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        answer[k] += 1;
                    }
                }

                k += 1;
            }
            // end

            return answer;
        }

        public void Task2(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int minIndex = 0;
                int minValue = matrix[i, 0];

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minIndex = j;
                    }
                }

                if (minIndex != 0)
                {

                    int temp = matrix[i, 0];


                    for (int j = minIndex; j > 0; j--)
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }

                    matrix[i, 0] = minValue;
                }
            }
        }

        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxValue = matrix[i, 0], maxIndex = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                if (maxIndex != 0)
                {
                    bool flag = false;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == maxValue && j == maxIndex)
                        {
                            answer[i, j] = maxValue;
                            answer[i, j + 1] = maxValue;
                            flag = true;
                        }
                        else if (flag == true)
                        {
                            answer[i, j + 1] = matrix[i, j];
                        }
                        else
                        {
                            answer[i, j] = matrix[i, j];
                        }
                    }
                }
                else
                {
                    answer[i, 0] = maxValue;
                    for (int j = 0; j < answer.GetLength(1) - 1; j++)
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
                int maxValue = matrix[i, 0], maxIndex = 0, sum = 0, count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int j = maxIndex + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                if (count == 0)
                    continue;
                int sred_arifm = sum / count;
                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0)
                        matrix[i, j] = sred_arifm;
                }
            }
            // end

        }

        public void Task5(int[,] matrix, int k)
        {

            // code here
            if (k <= matrix.GetLength(1) - 1 && k >= 0)
            {
                int n = 0;
                int[] maxValues = new int[matrix.GetLength(0)];
                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                {
                    int maxValue = matrix[i, 0];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > maxValue)
                            maxValue = matrix[i, j];
                    }

                    maxValues[n] = maxValue;
                    n++;
                }

                n = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = maxValues[n];
                    n++;
                }
            }
            // end

        }

        public void Task6(int[,] matrix, int[] array)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            if (array.Length != cols)
                return;
            for (int j = 0; j < cols; j++)
            {
                int maxValue = matrix[0, j];
                int maxRow = 0;

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxRow = i;
                    }
                }
                if (j < array.Length && array[j] > maxValue)
                {
                    matrix[maxRow, j] = array[j];
                }
            }
        }

        public void Task7(int[,] matrix)
        {
            int[] minValue = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = Int32.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (min > matrix[i, j])
                        min = matrix[i, j];
                }
                minValue[i] = min;
            }
            
            int[] index = new int[minValue.Length];
            for (int i = 0; i < minValue.Length; i++)
            {
                index[i] = i;
            }
            
            for (int i = 0; i < minValue.Length; i++)
            {
                for (int j = 1; j < minValue.Length - i; j++)
                {
                    if (minValue[j - 1] < minValue[j])
                    {
                        (minValue[j], minValue[j - 1]) = (minValue[j - 1], minValue[j]);
                        (index[j], index[j - 1]) = (index[j - 1], index[j]);
                    }
                }
            }
            
            int[,] temp =  new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp[i, j] = matrix[i, j];
                }
            }
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = temp[index[i], j];
                }
            }
        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return answer;
            int n = matrix.GetLength(0);
            answer = new int[n * 2 - 1];
            int count = 1;
            for (int step = 0; step < answer.Length; step++)
            {
                if (step < n - 1)
                {
                    int length = n - 1, row = step;
                    for (int i = 0; i < step + 1; i++)
                    {
                        answer[step] += matrix[length, row];
                        length--;
                        row--;
                    }

                    continue;
                }
                
                if (step == n - 1)
                {
                    int length = 0, row = 0;
                    for (int i = 0; i < n; i++)
                    {
                        answer[step] += matrix[length, row];
                        length++;
                        row++;
                    }
                    
                    continue;
                }
                
                if (step > n - 1)
                {
                    int length = n - 1 - count, row = n - 1;
                    for (int i = 0; i < n - count; i++)
                    {
                        answer[step] += matrix[length, row];
                        length--;
                        row--;
                    }
                    
                    count++;
                }
            }

            return answer;
        }
        
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            if (rows != cols || k > rows - 1 || k < 0)
                return;
            int maxAbs = matrix[0, 0], iMax = 0, jMax = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(maxAbs))
                    {
                        maxAbs = matrix[i, j];
                        iMax = i;
                        jMax = j;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                (matrix[i, k], matrix[i, jMax]) = (matrix[i, jMax], matrix[i, k]);
            }
        
            if (k < 2)
            {
                for (int j = k + 1; j < cols - 1; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }
            }

            for (int j = 0; j < cols; j++)
            {
                (matrix[iMax, j], matrix[k, j]) = (matrix[k, j], matrix[iMax, j]);
            }
            // end
            

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1) != B.GetLength(0))
                return answer;
            
            int rows = A.GetLength(0);
            int cols = B.GetLength(1);
            int common = A.GetLength(1);
            
            answer = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int C = 0;
                    for (int k = 0; k < common; k++)
                        C += A[i, k] * B[k, j];
                    answer[i, j] = C;
                }
            }
            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = new int[matrix.GetLength(0)][];

            // code here
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
                answer[i] = new int[count];
            }
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int j1 = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][j1] = matrix[i, j];
                        j1++;
                    }
                }
            }
            // end

            return answer;
        }

        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }
            }

            int n = (int)Math.Sqrt(count);
            if (n * n != count)
                n += 1;
            answer = new int[n, n];
            int[] flatArray = new int[count];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    flatArray[index++] = array[i][j];
                }
            }

            index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (index < count)
                        answer[i, j] = flatArray[index++];
                    else break;
                }
            }
            return answer;
        }
    }
}
