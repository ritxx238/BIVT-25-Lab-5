using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            answer = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                answer[i] = count > 0 ? sum / count : 0;
            }
            // end

            return answer;
        }

        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 0 || cols == 0)
            {
                answer = new int[0, 0];
                return answer;
            }

            int maxVal = int.MinValue;
            int maxRow = -1, maxCol = -1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            answer = new int[rows - 1, cols - 1];
            int newRow = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == maxRow) continue;
                int newCol = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == maxCol) continue;
                    answer[newRow, newCol] = matrix[i, j];
                    newCol++;
                }
                newRow++;
            }
            // end

            return answer;
        }

        public void Task3(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int maxVal = int.MinValue;
                int maxIndex = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxIndex = j;
                    }
                }

                if (maxIndex != -1 && maxIndex != cols - 1)
                {
                    int temp = matrix[i, maxIndex];
                    for (int j = maxIndex; j < cols - 1; j++)
                    {
                        matrix[i, j] = matrix[i, j + 1];
                    }
                    matrix[i, cols - 1] = temp;
                }
            }
            // end
        }

        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int maxVal = int.MinValue;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                        maxVal = matrix[i, j];
                }

                for (int j = 0; j < cols + 1; j++)
                {
                    if (j < cols - 1)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == cols - 1)
                    {
                        answer[i, j] = maxVal;
                    }
                    else
                    {
                        answer[i, j] = matrix[i, j - 1];
                    }
                }
            }
            // end

            return answer;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int size = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if ((i + j) % 2 == 1)
                        size++;

            answer = new int[size];
            int index = 0;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if ((i + j) % 2 == 1)
                        answer[index++] = matrix[i, j];
            // end

            return answer;
        }

        public void Task6(int[,] matrix, int k)
        {
            // code here
            int n = matrix.GetLength(0);

            
            if (n != matrix.GetLength(1) || k < 0 || k >= n) return;

            int maxDiagVal = int.MinValue;
            int maxDiagRow = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > maxDiagVal)
                {
                    maxDiagVal = matrix[i, i];
                    maxDiagRow = i;
                }
            }

            int negativeRow = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    negativeRow = i;
                    break;
                }
            }

            if (negativeRow != -1 && maxDiagRow != negativeRow && maxDiagRow != -1)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[maxDiagRow, j];
                    matrix[maxDiagRow, j] = matrix[negativeRow, j];
                    matrix[negativeRow, j] = temp;
                }
            }
            // end
        }

        public void Task7(int[,] matrix, int[] array)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols < 2 || array == null) return;

            int maxVal = int.MinValue;
            int targetRow = -1;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, cols - 2] > maxVal)
                {
                    maxVal = matrix[i, cols - 2];
                    targetRow = i;
                }
            }

            if (targetRow != -1 && array.Length == cols)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[targetRow, j] = array[j];
                }
            }
            // end
        }

        public void Task8(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int maxVal = int.MinValue;
                int maxRow = -1;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRow = i;
                    }
                }

                if (maxRow < rows / 2)
                {
                    int sum = 0;
                    for (int i = maxRow + 1; i < rows; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }
            }
            // end
        }

        public void Task9(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i += 2)
            {
                int maxOdd = int.MinValue;
                int maxOddCol = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxOdd)
                    {
                        maxOdd = matrix[i, j];
                        maxOddCol = j;
                    }
                }

                int maxEven = int.MinValue;
                int maxEvenCol = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i + 1, j] > maxEven)
                    {
                        maxEven = matrix[i + 1, j];
                        maxEvenCol = j;
                    }
                }

                if (maxOddCol != -1 && maxEvenCol != -1)
                {
                    int temp = matrix[i, maxOddCol];
                    matrix[i, maxOddCol] = matrix[i + 1, maxEvenCol];
                    matrix[i + 1, maxEvenCol] = temp;
                }
            }
            // end
        }

        public void Task10(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);

            
            if (n != matrix.GetLength(1)) return;

            int maxVal = int.MinValue;
            int maxRow = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > maxVal)
                {
                    maxVal = matrix[i, i];
                    maxRow = i;
                }
            }

            if (maxRow != -1 && maxRow > 0)
            {
                for (int i = 0; i < maxRow; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            // end
        }
        public void Task11(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] positiveCounts = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0) count++;
                }
                positiveCounts[i] = count;
            }

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (positiveCounts[j] < positiveCounts[j + 1])
                    {
                        int tempCount = positiveCounts[j];
                        positiveCounts[j] = positiveCounts[j + 1];
                        positiveCounts[j + 1] = tempCount;

                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
            // end
        }

        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            if (array == null || array.Length == 0)
            {
                answer = new int[0][];
                return answer;
            }

            double totalSum = 0;
            int totalCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        totalSum += array[i][j];
                        totalCount++;
                    }
                }
            }
            double globalAverage = totalCount > 0 ? totalSum / totalCount : 0;

            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null && array[i].Length > 0)
                {
                    double rowSum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        rowSum += array[i][j];
                    }
                    double rowAverage = rowSum / array[i].Length;
                    if (rowAverage >= globalAverage) count++;
                }
            }

            answer = new int[count][];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null && array[i].Length > 0)
                {
                    double rowSum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        rowSum += array[i][j];
                    }
                    double rowAverage = rowSum / array[i].Length;

                    if (rowAverage >= globalAverage)
                    {
                        answer[index] = new int[array[i].Length];
                        for (int j = 0; j < array[i].Length; j++)
                        {
                            answer[index][j] = array[i][j];
                        }
                        index++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}
