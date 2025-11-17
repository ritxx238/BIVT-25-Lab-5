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
            int rows=matrix.GetLength(0);
            int cols=matrix.GetLength(1);
            answer=new int[cols];
            int ind = 0;
            for (int col = 0; col < cols; col++)
            {
                int neg = 0;
                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, col] < 0)
                    {
                        neg++;
                    }
                }
                answer[ind++]=neg;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int rows=matrix.GetLength(0);
            int cols=matrix.GetLength(1);
            
            for (int row = 0; row < rows; row++)
            {
                int min =int.MaxValue;
                int minind = -1;
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] < min)
                    {
                        min = matrix[row, col];
                        minind = col;
                    }
                }
                for (int col = minind; col > 0; col--)
                {
                    (matrix[row, col], matrix[row, col - 1]) = (matrix[row, col - 1], matrix[row, col]);
                }
                
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows, cols + 1];

            for (int row = 0; row < rows; row++)
            {
                int max = int.MinValue;
                int maxind = -1;

                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > max)
                    {
                        max = matrix[row, col];
                        maxind = col;  
                    }
                }

                int newCol = 0;
                for (int col = 0; col < cols; col++)
                {
                    answer[row, newCol++] = matrix[row, col];
                    if (col == maxind)
                    {
                        answer[row, newCol++] = max;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int max = int.MinValue;
                int maxind = -1;

                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > max)
                    {
                        max = matrix[row, col];
                        maxind = col;
                    }
                }

                double sr = 0;
                double sum = 0;
                double n = 0;
                for (int col = 0; col < cols; col++)
                {
                    if (col > maxind && matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        n++;
                    }
                }
                if (n > 0)
                {
                    sr = sum / n;
                    for (int col = 0; col < cols; col++)
                    {
                        if (col < maxind)
                        {
                            if (matrix[row, col] < 0)
                            {
                                matrix[row, col] = (int)sr;
                            }
                        }
                    }
                }
                // end
            }
        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] array = new int[rows];
            if (k < cols && k>=0)
            {
                for (int row = 0; row < rows; row++)
                {
                    int max = int.MinValue;
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] > max)
                        {
                            max = matrix[row, col];
                        }
                    }
                    array[row] = max;
                }
                Array.Reverse(array);
                for (int row = 0; row<rows; row++)
                {
                    matrix[row, k] = array[row];
                }
            }
                // end

            }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (array.Length == cols)
            {
                for (int col = 0; col < cols; col++)
                {
                    int max=int.MinValue;
                    int indmax = -1;
                    for (int row = 0; row < rows; row++)
                    {
                        if (matrix[row, col] > max)
                        {
                            max = matrix[row, col];
                            indmax = row;
                        }
                    }
                    if (array[col] > max)
                    {
                        matrix[indmax,col]=array[col];
                    }
                }
            }
            
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int pass = 0; pass < rows - 1; pass++)
            {
                for (int currentRow = 0; currentRow < rows - pass - 1; currentRow++)
                {
                    int minCurrent = matrix[currentRow, 0];
                    for (int col = 1; col < cols; col++)
                    {
                        if (matrix[currentRow, col] < minCurrent)
                            minCurrent = matrix[currentRow, col];
                    }

                    int minNext = matrix[currentRow + 1, 0];
                    for (int col = 1; col < cols; col++)
                    {
                        if (matrix[currentRow + 1, col] < minNext)
                            minNext = matrix[currentRow + 1, col];
                    }

                    if (minCurrent < minNext)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            int temp = matrix[currentRow, col];
                            matrix[currentRow, col] = matrix[currentRow + 1, col];
                            matrix[currentRow + 1, col] = temp;
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
            int rows=matrix.GetLength(0);
            int cols=matrix.GetLength(1);
            
            if (rows == cols)
            {
                answer = new int[2 * rows - 1];
                answer[0] = matrix[rows - 1, 0];
                answer[2*rows-1-1]= matrix[0, cols - 1];
                int ind = 1;
                for (int startrow = rows-2; startrow>0; startrow--)
                {
                    int sum = 0;
                    for (int row=startrow,col=0;row<rows && col < cols; row++, col++)
                    {
                        sum += matrix[row, col];
                    }
                    answer[ind++] = sum;
                }
                for (int startcol=0;startcol<cols;startcol++)
                {
                    int sum = 0;
                    for (int row=0,col=startcol; row < rows && col < cols; row++, col++)
                    {
                        sum += matrix[row, col];
                    }
                    answer[ind++] = sum;
                }
            }
            
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {
            // code here

            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int max = 0;
            int rowmax = 0;
            int colmax = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (Math.Abs(matrix[row, col]) > Math.Abs(max))
                    {
                        max = matrix[row, col];
                        rowmax = row;
                        colmax = col;
                    }
                }
            }

            int sdvigrow = k - rowmax;
            int sdvigcol = k - colmax;
            if (sdvigrow < 0)
            {
                for (int row = rowmax; row > k; row--)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        (matrix[row, col], matrix[row - 1, col]) =
                        (matrix[row - 1, col], matrix[row, col]);
                    }
                }
            }
            else
            {
                for (int row = rowmax; row < k; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        (matrix[row, col], matrix[row + 1, col]) =
                        (matrix[row + 1, col], matrix[row, col]);
                    }
                }
            }

            if (sdvigcol < 0)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = colmax; col > k; col--)
                    {
                        (matrix[row, col], matrix[row, col - 1]) =
                        (matrix[row, col - 1], matrix[row, col]);
                    }
                }
            }
            else
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = colmax; col < k; col++)
                    {
                        (matrix[row, col], matrix[row, col + 1]) =
                        (matrix[row, col + 1], matrix[row, col]);
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int arows=A.GetLength(0);
            int acols=A.GetLength(1);
            int brows = B.GetLength(0);
            int bcols = B.GetLength(1);
            
            if (acols == brows)
            {
                answer = new int[arows, bcols];
                for (int row = 0; row < arows; row++)
                {
                    for (int col = 0; col < bcols; col++)
                    {
                        int sum = 0;
                        for (int k = 0; k < brows; k++)
                        {
                            sum += A[row, k] * B[k, col];
                        }
                        answer[row, col] = sum;
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
            int rows=matrix.GetLength(0);
            int cols=matrix.GetLength(1);
            answer = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                int count = 0;
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0) count++;
                }

                answer[row] = new int[count];
                int index = 0;

                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        answer[row][index++] = matrix[row, col];
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
            {
                total += array[i].Length;
            }

            int size = 0;
            while (size * size < total)
            {
                size++;
            }

            answer = new int[size, size];

            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (index < size * size)
                    {
                        int row = index / size;
                        int col = index % size;
                        answer[row, col] = array[i][j];
                        index++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}