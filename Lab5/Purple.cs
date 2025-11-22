using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code her
            int[] array = new int[matrix.GetLength(1)];

            int indexForArray = 0;
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                int numOfNegativeNumsInColumn = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int curNum = matrix[row, column];
                    if (curNum < 0)
                        numOfNegativeNumsInColumn++;
                }

                array[indexForArray++] = numOfNegativeNumsInColumn;
            }

            answer = array;
            // end
            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int mn = int.MaxValue;
                int cmn = -1;
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] < mn)
                    {
                        mn = matrix[row, column];
                        cmn = column;
                    }
                }

                for (int column = cmn; column >= 1; column--)
                    matrix[row, column] = matrix[row, column - 1];

                matrix[row, 0] = mn;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            
            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int[,] matrixIncludeTwoMax = new int[rows, columns + 1];

            for (int row = 0; row < rows; row++)
            {
                int mx = int.MinValue;
                int cmx = -1;
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > mx)
                    {
                        mx = matrix[row, column];
                        cmx = column;
                    }
                }

                for (int column = 0; column < cmx; column++)
                    matrixIncludeTwoMax[row, column] = matrix[row, column];

                matrixIncludeTwoMax[row, cmx] = mx;
                matrixIncludeTwoMax[row, cmx + 1] = mx;

                for (int column = cmx + 2; column < columns + 1; column++)
                {
                    matrixIncludeTwoMax[row, column] = matrix[row, column - 1];
                }

            }

            answer = matrixIncludeTwoMax;
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int mx = int.MinValue;
                int cmx = -1;
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > mx)
                    {
                        mx = matrix[row, column];
                        cmx = column;
                    }
                }



                bool isPositiveAfterMax = false;
                for (int column = cmx + 1; column < columns; column++)
                {
                    if (matrix[row, column] > 0) { 
                        isPositiveAfterMax = true;
                        break;
                    }
                }

                
                if (isPositiveAfterMax) {
                    int ln = columns - cmx - 1;
                    int aver;

                    if (ln != 0) { 
                        int sum = 0;
                        for (int column = cmx + 1; column < columns; column++)
                        {
                            sum += matrix[row, column];
                        }
                        aver = sum / ln;
                    }
                    else
                        aver = 0;

                    for (int column = 0; column < cmx; column++)
                    {
                        if (matrix[row, column] < 0)
                            matrix[row, column] = aver;
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int[] reversedArrayWithMaxNumsInRows = new int[rows];
            int indexReversedArray = 0;
            for (int row = 0; row < rows; row++)
            {
                int mx = int.MinValue;
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > mx)
                        mx = matrix[row, column];
                }

                reversedArrayWithMaxNumsInRows[indexReversedArray++] = mx;
            }
            Array.Reverse(reversedArrayWithMaxNumsInRows);

            if (k >= 0 && k < columns) { 
                for (int row = 0; row < rows; row++)
                {
                    matrix[row, k] = reversedArrayWithMaxNumsInRows[row];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (columns == array.Length) 
            {
                for (int column = 0; column < columns; column++)
                {
                    int mx = int.MinValue;
                    int rmx = -1;
                    for (int row = 0; row < rows; row++)
                    {
                        if (matrix[row, column] > mx)
                        {
                            mx = matrix[row, column];
                            rmx = row;
                        }
                    }
                    //if (column > array.Length - 1)
                    //    break;
                    if (array[column] > mx)
                    {
                        matrix[rmx, column] = array[column];
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

            int[] indexesMinItems = new int[rows];

            for (int row = 0; row < rows; row++)
            {
                int mn = int.MaxValue;
                int cmn = -1;
                for(int col = 0; col < cols; col++)
                {
                    if ((matrix[row, col] < mn))
                    {
                        mn = matrix[row, col];
                        cmn = col;
                    }
                }
                indexesMinItems[row] = cmn;
            }

            for (int i = 0; i < rows; i++)
            {
                bool isSwap = false;
                for (int j = 1; j < rows - i; j++)
                {
                    if (matrix[j - 1, indexesMinItems[j - 1]] < matrix[j, indexesMinItems[j]])
                    {
                        for (int c = 0; c < cols; c++)
                        {
                            (matrix[j - 1, c], matrix[j, c]) = (matrix[j, c], matrix[j - 1, c]);
                        }
                        isSwap = true;
                        (indexesMinItems[j - 1], indexesMinItems[j]) = (indexesMinItems[j], indexesMinItems[j - 1]);
                    }
                }
                if (!isSwap) break;
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == cols)
            {
                int n = rows;
                int[] arrayParalMainDiagWithMainDiag = new int[2 * n - 1];

                int indexArray = 0;
                //arrayParalMainDiagWithMainDiag[indexArray++] = matrix[rows - 1, 0];
                int dopNumsOnDiag = 0;
                for (int row = rows - 1; row >= 0; row--)
                {
                    int sumDown = matrix[row, 0];
                    int r = row + 1;
                    for (int col = 0; col < dopNumsOnDiag; col++)
                    {
                        sumDown += matrix[r, col + 1];
                        r++;
                    }
                    dopNumsOnDiag++;
                    arrayParalMainDiagWithMainDiag[indexArray++] = sumDown;
                }

                int upnumbers = rows - 2;
                for (int col = 1; col < cols; col++)
                {
                    int sumUp = matrix[0, col];
                    int c = col + 1;
                    for (int row = 0; row < upnumbers; row++)
                    {
                        sumUp += matrix[row + 1, c];
                        c++;
                    }
                    upnumbers--;
                    arrayParalMainDiagWithMainDiag[indexArray++] = sumUp;
                }
                answer = arrayParalMainDiagWithMainDiag;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == cols)
            {
                int mx = 0;
                int rmx = 0;
                int cmx = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (Math.Abs(matrix[row, col]) > Math.Abs(mx))
                        {
                            mx = matrix[row, col];
                            rmx = row;
                            cmx = col;
                        }
                    }
                }

                if (rmx != k || cmx != k)
                {
                    if (cmx != k)
                    {
                        if (cmx > k)
                        {
                            for (int col = cmx; col > 0; col--)
                            {
                                if (cmx == k) break;
                                for (int row = 0; row < rows; row++)
                                {
                                    (matrix[row, col], matrix[row, col - 1]) = (matrix[row, col - 1], matrix[row, col]);

                                }
                                cmx--;
                            }
                        }

                        if (cmx < k)
                        {
                            for (int col = cmx; col < cols - 1; col++)
                            {
                                if (cmx == k) break;
                                for (int row = 0; row < rows; row++)
                                {
                                    (matrix[row, col], matrix[row, col + 1]) = (matrix[row, col + 1], matrix[row, col]);

                                }
                                cmx++;
                            }
                        }
                    }
                    if (rmx != k)
                    {
                        if (rmx > k)
                        {
                            for (int row = rmx; row > 0; row--)
                            {
                                if (rmx == k) break;
                                for (int col = 0; col < cols; col++)
                                {
                                    (matrix[row, col], matrix[row - 1, col]) = (matrix[row - 1, col], matrix[row, col]);

                                }
                                rmx--;
                            }
                        }
                        if (rmx < k)
                        {
                            for (int row = rmx; row < rows - 1; row++)
                            {
                                if (rmx == k) break;
                                for (int col = 0; col < cols; col++)
                                {
                                    (matrix[row, col], matrix[row + 1, col]) = (matrix[row + 1, col], matrix[row, col]);

                                }
                                rmx++;
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
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);


            if (colsA == rowsB || colsB == rowsA)
            {
                int[] array = new int[colsA * colsB];
                if (colsA == rowsB)
                {
                    int[,] matrix = new int[colsA, colsB];

                    int index = 0;
                    for (int rowA = 0; rowA < rowsA; rowA++)
                    {
                        for (int colB = 0; colB < colsB; colB++)
                        {
                            int sum = 0;
                            for (int colA = 0; colA < colsA; colA++)
                            {
                                sum += A[rowA, colA] * B[colA, colB];
                            }

                            array[index++] = sum;
                        }

                    }
                    index = 0;
                    for (int row = 0; row < colsA; row++)
                    {
                        for (int col = 0; col < colsB; col++)
                        {
                            matrix[row, col] = array[index++];
                        }
                    }
                    answer = matrix;

                }
                if (colsB == rowsA)
                {
                    int[,] matrix = new int[colsB, colsA];

                    int index = 0;
                    for (int rowB = 0; rowB < rowsB; rowB++)
                    {
                        for (int colA = 0; colA < colsA; colA++)
                        {
                            int sum = 0;
                            for (int colB = 0; colB < colsB; colB++)
                                sum += B[rowB, colB] * A[colB, colA];

                            array[index++] = sum;
                        }

                    }
                    index = 0;
                    for (int row = 0; row < colsB; row++)
                    {
                        for (int col = 0; col < colsA; col++)
                        {
                            matrix[row, col] = array[index++];
                        }
                    }
                    answer = matrix;
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[][] seratedArray = new int[rows][];

            int indexMainArray = 0;
            for (int row = 0; row < rows; row++)
            {
                int lnLocalArray = 0;
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                        lnLocalArray++;
                }
                int[] localArray = new int[lnLocalArray];
                int indexLocalArray = 0;
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                        localArray[indexLocalArray++] = matrix[row, col];
                }

                seratedArray[indexMainArray++] = localArray;
            }
            answer = seratedArray;
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int countAllNums = 0;
            for(int i = 0; i < array.Length; i++)
            {
                foreach (int item in array[i])
                    countAllNums++;
            }

            int[] allArray = new int[countAllNums];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    allArray[index++] = array[i][j];
                }
            }

            int size;
            double root = Math.Sqrt(countAllNums);
            if (root == (int)root)
                size = (int)root;
            else
                size = (int)root + 1;

            int numsOfZero = countAllNums % size;

            int[,] resMatrix = new int[size, size];

            index = 0;
            for (int row = 0; row < size; row++)
            {
                
                for (int col = 0; col < size; col++)
                {
                    if (index < allArray.Length) { 
                        resMatrix[row, col] = allArray[index++];
                    }
                    else
                    {
                        resMatrix[row, col] = 0;
                    }
                }
            }
            answer = resMatrix;
            // end

            return answer;
        }
    }
}
