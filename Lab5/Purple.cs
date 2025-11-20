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
            int countNegInCol;
            answer = new int[matrix.GetLength(1)];
            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                countNegInCol = 0;
                for (var j = 0; j < matrix.GetLength(0); j++)
                    if (matrix[j, i] < 0)
                        countNegInCol++;
                answer[i] = countNegInCol;
            }
            // end

            return answer;
        }

        public void Task2(int[,] matrix)
        {
            // code here
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                var minElemInRow = matrix[row, 0];
                for (var col = 1; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] < minElemInRow)
                        minElemInRow = matrix[row, col];

                var foundMinElem = false;
                var newRow = new int[matrix.GetLength(1)];
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == minElemInRow && !foundMinElem)
                    {
                        foundMinElem = true;
                        newRow[0] = minElemInRow;
                        continue;
                    }

                    if (foundMinElem)
                        newRow[col] = matrix[row, col];
                    else
                        newRow[col + 1] = matrix[row, col];
                }

                for (var col = 0; col < matrix.GetLength(1); col++)
                    matrix[row, col] = newRow[col];
            }
            // end
        }

        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                var maxElemInRow = matrix[row, 0];
                for (var col = 1; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] > maxElemInRow)
                        maxElemInRow = matrix[row, col];

                var foundMaxElem = false;
                var newRow = new int[matrix.GetLength(1) + 1];
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == maxElemInRow && !foundMaxElem)
                    {
                        foundMaxElem = true;
                        newRow[col] = maxElemInRow;
                        newRow[col + 1] = maxElemInRow;
                        continue;
                    }

                    if (foundMaxElem)
                        newRow[col + 1] = matrix[row, col];
                    else
                        newRow[col] = matrix[row, col];
                }

                for (var col = 0; col < matrix.GetLength(1) + 1; col++)
                    answer[row, col] = newRow[col];
            }
            // end

            return answer;
        }

        public void Task4(int[,] matrix)
        {
            // code here
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                int maxElemInRow = matrix[i, 0], sumPositivAfterMaxElem = 0, countPositivElemAfterMax = 0;
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxElemInRow)
                    {
                        maxElemInRow = matrix[i, j];
                        sumPositivAfterMaxElem = 0;
                        countPositivElemAfterMax = 0;
                    }
                    else if (matrix[i, j] > 0)
                    {
                        sumPositivAfterMaxElem += matrix[i, j];
                        countPositivElemAfterMax++;
                    }
                }

                if (countPositivElemAfterMax != 0)
                {
                    var meanPosElemInRow = sumPositivAfterMaxElem / countPositivElemAfterMax;
                    for (var j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == maxElemInRow)
                            break;
                        if (matrix[i, j] < 0)
                            matrix[i, j] = meanPosElemInRow;
                    }
                }
            }
            // end
        }

        public void Task5(int[,] matrix, int k)
        {
            // code here
            if (k < matrix.GetLength(1) && k >= 0)
            {
                var kCol = new int[matrix.GetLength(0)];
                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    var maxElemInRow = matrix[i, 0];
                    for (var j = 0; j < matrix.GetLength(1); j++)
                        if (matrix[i, j] > maxElemInRow)
                            maxElemInRow = matrix[i, j];
                    kCol[matrix.GetLength(0) - i - 1] = maxElemInRow;
                }

                for (var i = 0; i < matrix.GetLength(0); i++)
                    matrix[i, k] = kCol[i];
            }
            // end
        }

        public void Task6(int[,] matrix, int[] array)
        {
            // code here
            if (matrix.GetLength(1) == array.Length)
            {
                for (var i = 0; i < matrix.GetLength(1); i++)
                {
                    int maxElemInCol = matrix[0, i], idxMaxElemInCol = 0;
                    for (var j = 0; j < matrix.GetLength(0); j++)
                        if (matrix[j, i] > maxElemInCol)
                        {
                            maxElemInCol = matrix[j, i];
                            idxMaxElemInCol = j;
                        }

                    if (array[i] > maxElemInCol)
                        matrix[idxMaxElemInCol, i] = array[i];
                }
            }
            // end
        }

        public void Task7(int[,] matrix)
        {
            // code here
            var minElemsInRow = new int[matrix.GetLength(0), 2];
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                var minElemInRow = matrix[i, 0];
                for (var j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < minElemInRow)
                        minElemInRow = matrix[i, j];
                minElemsInRow[i, 0] = minElemInRow;
                minElemsInRow[i, 1] = i;
            }

            for (var i = 0; i < minElemsInRow.GetLength(0); i++)
            {
                for (var j = 0; j < minElemsInRow.GetLength(0) - 1 - i; j++)
                    if (minElemsInRow[j, 0] < minElemsInRow[j + 1, 0])
                        (minElemsInRow[j, 0], minElemsInRow[j, 1], minElemsInRow[j + 1, 0], minElemsInRow[j + 1, 1]) =
                            (minElemsInRow[j + 1, 0], minElemsInRow[j + 1, 1], minElemsInRow[j, 0],
                                minElemsInRow[j, 1]);
            }

            for (var newRow = 0; newRow < minElemsInRow.GetLength(0); newRow++)
            {
                var oldRow = minElemsInRow[newRow, 1];
                if (oldRow == newRow)
                    continue;

                for (var col = 0; col < matrix.GetLength(1); col++)
                    (matrix[oldRow, col], matrix[newRow, col]) = (matrix[newRow, col], matrix[oldRow, col]);

                for (var k = newRow + 1; k < minElemsInRow.GetLength(0); k++)
                    if (minElemsInRow[k, 1] == newRow)
                    {
                        minElemsInRow[k, 1] = oldRow;
                        break;
                    }

                minElemsInRow[newRow, 1] = newRow;
            }
            // end
        }

        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int n = matrix.GetLength(0), placeInAns = 0;
                answer = new int[2 * n - 1];
                for (var i = n - 1; i >= -(n - 1); i--)
                {
                    var sumDiagonal = 0;
                    for (var j = 0; j < n; j++)
                    {
                        int k = j - i;
                        if (k >= 0 && k < n)
                            sumDiagonal += matrix[j, k];
                    }

                    answer[placeInAns++] = sumDiagonal;
                }
            }
            // end

            return answer;
        }

        public void Task9(int[,] matrix, int k)
        {
            // code here
            var n = matrix.GetLength(0);
            if (n == matrix.GetLength(1))
            {
                var maxElem = matrix[0, 0];
                int rowMax = 0, colMax = 0;
                for (var i = 0; i < n; i++)
                {
                    for (var j = 0; j < n; j++)
                        if (Math.Abs(matrix[i, j]) > Math.Abs(maxElem))
                        {
                            maxElem = matrix[i, j];
                            (rowMax, colMax) = (i, j);
                        }
                }

                if (rowMax == k && colMax == k)
                    return;

                if (rowMax > k)
                {
                    for (int i = rowMax; i > k; i--)
                    {
                        for (int j = 0; j < n; j++)
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                    }
                }
                else if (rowMax < k)
                {
                    for (int i = rowMax; i < k; i++)
                    {
                        for (int j = 0; j < n; j++)
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                    }
                }

                if (colMax > k)
                {
                    for (int j = colMax; j > k; j--)
                    {
                        for (int i = 0; i < n; i++)
                            (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                    }
                }
                else if (colMax < k)
                {
                    for (int j = colMax; j < k; j++)
                    {
                        for (int i = 0; i < n; i++)
                            (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }
            }

            // end
        }

        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int aRow = A.GetLength(0), aCol = A.GetLength(1);
            int bRow = B.GetLength(0), bCol = B.GetLength(1);
            if (aCol != bRow)
                return answer;

            answer = new int[aRow, bCol];
            for (var row = 0; row < aRow; row++)
            {
                for (int col = 0; col < bCol; col++)
                {
                    for (int i = 0; i < aRow; i++)
                        answer[row, col] += A[row, i] * B[i, col];
                }
            }
            // end

            return answer;
        }

        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            var arrayCountNegativeAndZeroInRows = new int[matrix.GetLength(0)];
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] <= 0)
                        arrayCountNegativeAndZeroInRows[row]++;
            }

            answer = new int[matrix.GetLength(0)][];
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = new int[matrix.GetLength(1) - arrayCountNegativeAndZeroInRows[row]];
                var idxCurrentRow = 0;
                for (var col = 0; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] > 0)
                        currentRow[idxCurrentRow++] = matrix[row, col];
                answer[row] = currentRow;
            }
            // end

            return answer;
        }

        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            var countElems = 0;
            for (var row = 0; row < array.Length; row++)
                countElems += array[row].Length;

            var n = (int)Math.Ceiling(Math.Sqrt(countElems));
            answer = new int[n, n];
            int[] allElements = new int[countElems];
            int idx = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                    allElements[idx++] = array[i][j];
            }

            idx = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                    answer[row, col] = idx < countElems ? allElements[idx++] : 0;
            }
            // end

            return answer;
        }
    }
}