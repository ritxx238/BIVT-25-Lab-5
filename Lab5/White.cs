using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;
            int sum = 0;
            int count = 0;
            // code here
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        count++;
                    }
                }
            }
            average = (double)sum / count;
            
            return average;
            // end
        }
        
        public (int row, int col) Task2(int[,] matrix)
        {
            bool found = false;
            int row = 0, col = 0;
            int min = int.MaxValue;
            // code here
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] < min)
                    {
                        min = matrix[rows, cols];
                    }
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    if (matrix[rows, cols] == min)
                    {
                        row = rows;
                        col = cols;
                        found = true;
                    }
                } 
                if (found == true)
                {
                    break;
                }    
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {
            if (matrix == null)
                return;
    
            if (k < 0 || k >= matrix.GetLength(1))
                return; 
    
            int max = int.MinValue;
            int maxRow = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > max)
                {
                    max = matrix[i, k];
                    maxRow = i;
                }
            }
            if (maxRow != 0)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    (matrix[maxRow, i], matrix[0, i]) = (matrix[0, i], matrix[maxRow, i]);
                }
            }
        }
        public int[,] Task4(int[,] matrix)
        {
           
            // code here
            if (matrix == null)
            {
                return new int[0, 0];
            }
            
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            switch (row)
            {
                case 1:
                    return new int[0, col];
                case 0:
                    return matrix;
            }

            int min = matrix[0, 0];
            int minRow = 0;
            for (int i = 1; i < row; i++)
            {
                if (matrix[i, 0] < min)
                {
                    min = matrix[i, 0];
                    minRow = i;
                }
            }
            
            int[,] matrix2 = new int[row - 1, col];
            for (int i = 0; i < row - 1; i++)
            {
                if (i < minRow)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix2[i, j] = matrix[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix2[i, j] = matrix[i + 1, j];
                    }
                }
            }
            // end
            

            return matrix2;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return 0;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int firstNegativeIndex = -1;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < 0)
                    {
                        firstNegativeIndex = col;
                        break;
                    }
                }

                if (firstNegativeIndex <= 0)
                {
                    continue;
                }

                int maxIndex = 0;
                for (int col = 0; col < firstNegativeIndex; col++)
                {
                    if (matrix[row, col] > matrix[row, maxIndex])
                    {
                        maxIndex = col;
                    }
                }

                int minIndex = -1;
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    if (matrix[row, col] < 0)
                    {
                        minIndex = col;
                        break;
                    }
                }

                if (minIndex != -1)
                {
                    int temp = matrix[row, maxIndex];
                    matrix[row, maxIndex] = matrix[row, minIndex];
                    matrix[row, minIndex] = temp;
                }
            }
        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int negativeCounter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negativeCounter++;
                    }
                }
            }

            if (negativeCounter > 0)
            {
                negatives = new int[negativeCounter];
                int index = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            negatives[index] = matrix[i, j];
                            index++;
                        }
                    }
                }
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix.GetLength(1) == 1)
                {
                    continue;
                }
                int maxRow = int.MinValue;
                int maxRowIndex = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxRow)
                    {
                        maxRow = matrix[i, j];
                        maxRowIndex = j;
                    }
        
                }
                
                if (maxRowIndex == 0)
                {
                    matrix[i, 1] *= 2;
                }

                if (maxRowIndex == matrix.GetLength(1) - 1)
                {
                    matrix[i, matrix.GetLength(1) - 2] *= 2;
                }
                else if (maxRowIndex != 0 && maxRowIndex != matrix.GetLength(1) - 1)
                {
                    int leftElement = matrix[i, maxRowIndex - 1];
                    int rightElement = matrix[i, maxRowIndex + 1];
                    int leftElementIndex = maxRowIndex - 1;
                    int rightElementIndex = maxRowIndex + 1;
                    if (leftElement == rightElement || leftElement < rightElement)
                    {
                        matrix[i, leftElementIndex] *= 2;
                    }

                    if (rightElement < leftElement)
                    {
                        matrix[i, rightElementIndex] *= 2;
                    }
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) / 2; col++)
                {
                    int newCol = matrix.GetLength(1) - 1 - col;
                    int temp =  matrix[row, col];
                    matrix[row, col] = matrix[row, newCol];
                    matrix[row, newCol] = temp;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {
            
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;
            int middleRow = matrix.GetLength(0) / 2;

            for (int row = middleRow; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row >= col)
                    {
                        matrix[row, col] = 1;
                    }
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int zeroCounter = 0;
            int newRow = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        zeroCounter++;
                        break;
                    }
                }
            }

            int [,] b = new int [matrix.GetLength(0) - zeroCounter, matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                bool hasZero = false;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }

                if (!hasZero)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        b[newRow, col] = matrix[row, col];
                    }
                    newRow++;
                }
            }

            answer = b;
            
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {
            
            // code here
            int[] sum = new int[array.Length]; 

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum[i] += array[i][j]; 
                }
            }

            for (int i = 0; i < sum.Length - 1; i++)
            {
                for (int j = 0; j < sum.Length - 1 - i; j++)
                {
                    if (sum[j] > sum[j + 1])
                    {
                        (array[j],  array[j + 1]) = (array[j + 1], array[j]);
                        (sum[j], sum[j + 1]) = (sum[j + 1], sum[j]);
                    }
                }
            }
            // end

        }
    }
}
