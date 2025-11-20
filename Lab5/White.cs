using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;
            double summ = 0;
            double cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        summ+= matrix[i,j];
                        cnt++;
                    }
                }
            }
            average = summ / cnt;
            
            

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            int minEl = int.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < minEl)
                    {
                        minEl = matrix[i,j];
                    }
                }
            }

            bool hasfound = false;
            for (int i = 0; i < matrix.GetLength(0) && !hasfound; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == minEl)
                    {
                        row = i;
                        col = j;
                        hasfound = true;
                        break;
                    }
                }
            }


            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {
            if (k < 0 || k >= matrix.GetLength(1))
            {
                return;
            }
            int maxVal = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int value = matrix[i, k];
                if (value > maxVal)
                {
                    maxVal = value;
                }
            }

            int stroka = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int value = matrix[i, k];
                if (value == maxVal)
                {
                    stroka = i;
                    break;
                }
            }
            if (stroka == 0) return;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[0, j];
                matrix[0, j] = matrix[stroka, j];
                matrix[stroka, j] = temp;

            }
        }
        public int[,] Task4(int[,] matrix)
        {
//            int[,] answer = null;
            int minNumb = int.MaxValue;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,0] < minNumb)
                {
                    minNumb = matrix[i, 0];
                }
            }
            int stroka = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] == minNumb)
                {
                    stroka = i;
                    break;
                }
            }

            int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                if (i < stroka)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        newMatrix[i, j] = matrix[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        newMatrix[i, j] = matrix[i + 1, j];
                    }

                }
            }
            matrix = newMatrix;

            return newMatrix;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }
        public void Task6(int[,] matrix)
        {
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxEl = int.MinValue;
                int indexMax = -1;
                int neg;
                int ingexNeg = -1;
                bool firstNeg = false;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > maxEl && matrix[i, j] >= 0 && !firstNeg)
                    {
                        maxEl = matrix[i, j];
                        indexMax = j;
                    }
                    if (matrix[i, j] < 0)
                    {
                        neg = matrix[i, j];
                        ingexNeg = j;
                        firstNeg = true;
                    }

                }
                if (indexMax != -1 && ingexNeg != -1)
                {
                    int temp = matrix[i, indexMax];
                    matrix[i, indexMax] = matrix[i, ingexNeg];
                    matrix[i, ingexNeg] = temp;

                }

            }

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < 0)
                    {
                        cnt++;
                    }
                }
            }
            int[] newArray = new int[cnt];
            int indexNew = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        newArray[indexNew++] = matrix[i, j];
                    }
                }
            }
            if (cnt == 0) return null;

            return newArray;
        }
        public void Task8(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxEl = int.MinValue;
                int indexMax = -1;
                bool first = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix.GetLength(1) == 1) break;
                    if (matrix[i, j] > maxEl)
                    {
                        maxEl = matrix[i, j];
                        indexMax = j;
                    }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (matrix[i, j] == maxEl && !first)
                    {
                        indexMax = j;
                        first = true;
                    }
                    if (matrix.GetLength(1) == 1) break;
                    if (indexMax == 0 && matrix.GetLength(1) > 1)
                    {
                        matrix[i, 1] *= 2;
                        break;
                    }
                    else if (indexMax == matrix.GetLength(1) - 1)
                    {
                        matrix[i, matrix.GetLength(1) - 2] *= 2;
                        break;
                    }
                    else if (matrix[i, indexMax - 1] > matrix[i, indexMax + 1])
                    {
                        matrix[i, indexMax + 1] *= 2;
                        break;
                    }
                    else if (matrix[i, indexMax - 1] < matrix[i, indexMax + 1])
                    {
                        matrix[i, indexMax - 1] *= 2;
                        break;

                    }
                    else if (matrix[i, indexMax - 1] == matrix[i, indexMax + 1])
                    {
                        matrix[i, indexMax - 1] *= 2;
                        break;
                    }
                }


            }
        }
        public void Task9(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, matrix.GetLength(1) - 1 - j];
                    matrix[i, matrix.GetLength(1) - 1 - j] = temp;
                }
            }



        }
        public void Task10(int[,] matrix)
        {

            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            for (int i = matrix.GetLength(0) / 2; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;
            int cnt = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        cnt++;
                        break;
                    }
                }
            }
            if (cnt == matrix.GetLength(0)) return new int[0, matrix.GetLength(1)];
            int[,] newMatrix = new int[matrix.GetLength(0) - cnt, matrix.GetLength(1)];
            int idxRow = 0;
            //            int idxCol = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool hasZero = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (!hasZero)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        newMatrix[idxRow, j] = matrix[i, j];
                    }
                    idxRow++;
                }
            }

            return newMatrix;
        }
        public void Task12(int[][] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int sumI = 0;
                    for (int k = 0; k < array[i].Length; k++)
                    {
                        sumI += array[i][k];
                    }

                    int sumJ = 0;
                    for (int k = 0; k < array[j].Length; k++)
                    {
                        sumJ += array[j][k];
                    }
                    if (sumI > sumJ)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
