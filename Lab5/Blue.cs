using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5

public class Blue
{
    public double[] Task1(int[,] matrix)
    {
        double[] answer = null;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);


        for (int i = 0; i < rows; i++)
        {
            int sum = 0, count = 0;
            for (int j = 0; j < cols; j++)
            {
                int val = matrix[i, j];
                if (val > 0)
                {
                    sum += val;
                    count++;
                }
            }
            answer[i] = count > 0 ? (double)sum / count : 0;
        }
        return answer;
    }

    public int[,] Task2(int[,] matrix)
    {
        int[,] answer = null;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int maxVal = int.MinValue;
        int maxRow = -1, maxCol = -1;

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if (matrix[i, j] > maxVal)
                {
                    maxVal = matrix[i, j];
                    maxRow = i;
                    maxCol = j;
                }

        
        int rIdx = 0;

        for (int i = 0; i < rows; i++)
        {
            if (i == maxRow) continue;
            int cIdx = 0;
            for (int j = 0; j < cols; j++)
            {
                if (j == maxCol) continue;
                answer[rIdx, cIdx] = matrix[i, j];
                cIdx++;
            }
            rIdx++;
        }
        return answer;
    }

    public void Task3(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int maxVal = int.MinValue;
            int maxIdx = -1;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > maxVal)
                {
                    maxVal = matrix[i, j];
                    maxIdx = j;
                }
            }

            int[] newRow = new int[cols];
            int index = 0;
            for (int j = 0; j < cols; j++)
            {
                if (j != maxIdx)
                {
                    newRow[index++] = matrix[i, j];
                }
            }
            newRow[index] = maxVal;

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = newRow[j];
            }
        }
    }

    public int[,] Task4(int[,] matrix)
    {
        int[,] answer = null;

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        

        for (int i = 0; i < rows; i++)
        {
            int maxVal = int.MinValue;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > maxVal)
                    maxVal = matrix[i, j];
            }

            for (int j = 0; j < cols - 1; j++)
            {
                answer[i, j] = matrix[i, j];
            }


            answer[i, cols - 1] = maxVal;


            answer[i, cols] = matrix[i, cols - 1];
        }

        return answer;
    }

    public int[] Task5(int[,] matrix)
    {
        int[] answer = null;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int size = 0;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if ((i + j) % 2 == 1)
                    size++;

       
        int index = 0;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if ((i + j) % 2 == 1)
                    answer[index++] = matrix[i, j];

        return answer;
    }

    public void Task6(int[,] matrix, int k)
    {
        int n = matrix.GetLength(0);
        int maxVal = int.MinValue;
        int diagRowIdx = -1;

        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] > maxVal)
            {
                maxVal = matrix[i, i];
                diagRowIdx = i;
            }
        }

        int negRowIdx = -1;
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, k] < 0)
            {
                negRowIdx = i;
                break;
            }
        }

        if (negRowIdx != -1 && diagRowIdx != -1 && negRowIdx != diagRowIdx)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[diagRowIdx, j];
                matrix[diagRowIdx, j] = matrix[negRowIdx, j];
                matrix[negRowIdx, j] = temp;
            }
        }
    }

    public void Task7(int[,] matrix, int[] array)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (cols < 2) return;

        int maxVal = int.MinValue;
        int maxRowIdx = -1;

        for (int i = 0; i < rows; i++)
        {
            if (matrix[i, cols - 2] > maxVal)
            {
                maxVal = matrix[i, cols - 2];
                maxRowIdx = i;
            }
        }

        if (maxRowIdx != -1)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[maxRowIdx, j] = array[j];
            }
        }
    }

    public void Task8(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int j = 0; j < cols; j++)
        {
            int maxVal = int.MinValue;
            int maxIdx = -1;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, j] > maxVal)
                {
                    maxVal = matrix[i, j];
                    maxIdx = i;
                }
            }

            int mid = rows / 2;
            if (maxIdx <= mid)
            {
                int sumBelowMax = 0;
                for (int i = maxIdx + 1; i < rows; i++)
                {
                    sumBelowMax += matrix[i, j];
                }
                matrix[0, j] = sumBelowMax;
            }
        }
    }

    public void Task9(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows - 1; i += 2)
        {
            int maxOddVal = int.MinValue, maxOddIdx = -1;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > maxOddVal)
                {
                    maxOddVal = matrix[i, j];
                    maxOddIdx = j;
                }
            }

            int maxEvenVal = int.MinValue, maxEvenIdx = -1;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i + 1, j] > maxEvenVal)
                {
                    maxEvenVal = matrix[i + 1, j];
                    maxEvenIdx = j;
                }
            }

            if (maxOddIdx != -1 && maxEvenIdx != -1)
            {
                int temp = matrix[i, maxOddIdx];
                matrix[i, maxOddIdx] = matrix[i + 1, maxEvenIdx];
                matrix[i + 1, maxEvenIdx] = temp;
            }
        }
    }

    public void Task10(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int maxDiagVal = int.MinValue;
        int maxDiagIdx = -1;

        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] > maxDiagVal)
            {
                maxDiagVal = matrix[i, i];
                maxDiagIdx = i;
            }
        }

        for (int i = 0; i < maxDiagIdx; i++)
        {
            for (int j = maxDiagIdx + 1; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = 0;
            }
        }
    }

    public void Task11(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] counts = new int[rows];

        for (int i = 0; i < rows; i++)
        {
            int countPos = 0;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > 0)
                    countPos++;
            }
            counts[i] = countPos;
        }


        for (int i = 0; i < rows - 1; i++)
            for (int j = i + 1; j < rows; j++)
            {
                if (counts[j] > counts[i])
                {
                    int tempCount = counts[i];
                    counts[i] = counts[j];
                    counts[j] = tempCount;

                    for (int c = 0; c < cols; c++)
                    {
                        int temp = matrix[i, c];
                        matrix[i, c] = matrix[j, c];
                        matrix[j, c] = temp;
                    }
                }
            }
    }

    public int[][] Task12(int[][] array)
    {
        int[][] answer = null;
        
        int totalSum = 0, totalCount = 0;
        for (int i = 0; i < array.Length; i++)
            for (int j = 0; j < array[i].Length; j++)
            {
                totalSum += array[i][j];
                totalCount++;
            }

        double totalAvg = (double)totalSum / totalCount;

        int newSize = 0;
        for (int i = 0; i < array.Length; i++)
        {
            int sumRow = 0;
            for (int j = 0; j < array[i].Length; j++)
                sumRow += array[i][j];

            double avgRow = (double)sumRow / array[i].Length;
            if (avgRow >= totalAvg)
                newSize++;
        }

        
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            int sumRow = 0;
            for (int j = 0; j < array[i].Length; j++)
                sumRow += array[i][j];

            double avgRow = (double)sumRow / array[i].Length;
            if (avgRow >= totalAvg)
            {
                answer[index++] = array[i];
            }
        }
        return answer;
    }
}
