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
            int len =  matrix.GetLength(0);
            int l2 = matrix.GetLength(1);
            answer = new double[len];

            for (int i = 0; i < len; i++)
            {
                double sum = 0;
                int count = 0;
                for (int j = 0; j < l2; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                double mean;
                if (count > 0)
                {
                    mean = sum / count;
                }
                else
                {
                    mean = 0;
                }

                answer[i] = mean;
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
            
            int maxValue = matrix[0, 0];
            int maxRow = 0;
            int maxCol = 0;
    
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int idx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        idx = j;
                    }
                }
                for (int j = idx; j < matrix.GetLength(1)-1; j++) matrix[i, j] = matrix[i, j+1];
                matrix[i, matrix.GetLength(1)-1] = max;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int len = matrix.GetLength(1);
                for (int j = 0; j < len; j++) if (matrix[i, j] > max) max = matrix[i, j];
                for (int j = 0; j < len; j++) answer[i, j] = matrix[i, j];
                answer[i, len] = answer[i, len - 1];
                answer[i, len-1] = max;
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++) if ((i + j) % 2 == 1) cnt++;
            answer = new int[cnt];
            cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++) if ((i + j) % 2 == 1) answer[cnt++] = matrix[i, j];
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int size = matrix.GetLength(0);
            int idx1 = 0, idx2 = 0;
            bool flag = false;
            for (int i = 0; i < size; i++) if (matrix[i, i] > matrix[idx1, idx1]) idx1 = i;
            for (int i = 0; i < size; i++)
            {
                if (matrix[i, k] < 0 && !flag)
                {
                    flag = true; 
                    idx2 = i;
                    break;
                }
            }
            if (flag && (idx1 != idx2)) for (int j = 0; j < size; j++) (matrix[idx1, j], matrix[idx2, j]) = (matrix[idx2, j], matrix[idx1, j]);
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int size = matrix.GetLength(1);
            if (size != array.Length) return;
            if (size < 2) return;
            int predlast = size - 2;
            int max = matrix[0, predlast], idx = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, predlast] > max)
                {
                    max = matrix[i, predlast];
                    idx = i;
                }
            }
            for (int j = 0; j < array.Length; j++) matrix[idx, j] = array[j];
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int idx = 0;
                for (int j = 0; j < matrix.GetLength(0); j++) if (matrix[j, i] > matrix[idx, i])  idx=j;
                if (idx < matrix.GetLength(0) / 2)
                {
                    int sum = 0;
                    for (int j = idx+1; j < matrix.GetLength(0); j++) sum += matrix[j, i];
                    matrix[0, i] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {
            // code here
            for (int i = 0; i < matrix.GetLength(0) - 1; i += 2)
            {
                int idx1=0, idx2=0;
                for (int j = 1; j < matrix.GetLength(1); j++) if (matrix[i, j] > matrix[i, idx1]) idx1 = j;
                for (int j = 1; j < matrix.GetLength(1); j++) if (matrix[i + 1, j] > matrix[i + 1, idx2]) idx2 = j;
                (matrix[i, idx1], matrix[i + 1, idx2]) = (matrix[i + 1, idx2], matrix[i, idx1]);
            }
            // end
        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int idx = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) if (matrix[i, i] > matrix[idx, idx]) idx = i;
            for (int i = 0; i < idx; i++) for (int j = 0; j < matrix.GetLength(1); j++) if (j > i) matrix[i, j] = 0;
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
                for (int j = 0; j < cols; j++) if (matrix[i, j] > 0) count++;
                positiveCounts[i] = count;
            }
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (positiveCounts[j] < positiveCounts[j + 1])
                    {
                        (positiveCounts[j], positiveCounts[j + 1]) = (positiveCounts[j + 1], positiveCounts[j]);
                        for (int k = 0; k < cols; k++) (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                    }
                }
            }
            // end
        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double totalSum = 0;
            int totalCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    totalSum += array[i][j]; 
                    totalCount++;
                }
            }
            double overallMean = totalSum / totalCount;
            int resultCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < array[i].Length; j++) rowSum += array[i][j]; 
                double rowMean = rowSum / array[i].Length;
                if (rowMean >= overallMean) resultCount++;
            }
            answer = new int[resultCount][];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double rowSum = 0; 
                for (int j = 0; j < array[i].Length; j++) rowSum += array[i][j]; 
                double rowMean = rowSum / array[i].Length;
                if (rowMean >= overallMean) answer[index++] = array[i];
            }
            // end

            return answer;
        }
    }
}
