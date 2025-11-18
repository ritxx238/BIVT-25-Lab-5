using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            double rowCount = matrix.GetLength(0); // кол-во строк
            double colCount = matrix.GetLength(1); // кол-во столбцов

            double count = 0;
            double sum = 0;
            // проход по элементам матрицы
            for (int i = 0; i < rowCount; i++)
            {
                for (int  j = 0; j < colCount; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count+=1;
                        sum += matrix[i, j];
                    }
                }
            }
            average = sum / count;
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);
            int min = matrix[0, 0];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            if (k < 0 || k >= colCount) return;

            int maxRow = 0;
            int max = matrix[0, k];

            for (int i = 0; i < rowCount; i++)
            {
                if (matrix[i, k] > max)
                {
                    max = matrix[i, k];
                    maxRow = i;
                }
            }

            for (int j = 0; j < colCount; j++)
            {
                int temp = matrix[maxRow, j];
                matrix[maxRow, j] = matrix[0, j];
                matrix[0, j] = temp;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            if (rowCount == 1) return new int[0, colCount];

            int minRow = 0;
            int min = matrix[0, 0];

            for (int i = 1; i < rowCount; i++)
            {
                if (matrix[i, 0] < min)
                {
                    min = matrix[i, 0];
                    minRow = i;
                }
            }

            answer = new int[rowCount - 1, colCount];
            for (int i = 0, newRow = 0; i < rowCount; i++)
            {
                if (i != minRow)
                {
                    for (int j = 0; j < colCount; j++)
                        answer[newRow, j] = matrix[i, j];
                    newRow++;
                }
            }
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            int size = matrix.GetLength(0);
            // проверяем что матрица квадратная
            if (size != matrix.GetLength(1)) return 0;

            for (int i = 0; i < size; i++)
                sum += matrix[i, i];
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxIndex = -1, lastNegative = -1;
                int maxVal = int.MinValue;
                bool foundNegative = false;

                // Поиск максимального до первого отрицательного и последнего отрицательного
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!foundNegative && matrix[i, j] < 0)
                        foundNegative = true;

                    if (!foundNegative && matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxIndex = j;
                    }

                    if (matrix[i, j] < 0)
                        lastNegative = j;
                }

                // Обмен
                if (maxIndex != -1 && lastNegative != -1)
                {
                    int temp = matrix[i, maxIndex];
                    matrix[i, maxIndex] = matrix[i, lastNegative];
                    matrix[i, lastNegative] = temp;
                }
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            List<int> negativeList = new List<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < 0)
                        negativeList.Add(matrix[i, j]);

            if (negativeList.Count == 0)
                negatives = null;
            else
                negatives = negativeList.ToArray();
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix.GetLength(1) == 1) continue;

                int maxIndex = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > matrix[i, maxIndex])
                        maxIndex = j;

                if (maxIndex > 0 && maxIndex < matrix.GetLength(1) - 1)
                {
                    if (matrix[i, maxIndex - 1] <= matrix[i, maxIndex + 1])
                        matrix[i, maxIndex - 1] *= 2;
                    else
                        matrix[i, maxIndex + 1] *= 2;
                }
                else if (maxIndex == 0)
                    matrix[i, 1] *= 2;
                else
                    matrix[i, maxIndex - 1] *= 2;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, matrix.GetLength(1) - 1 - j];
                    matrix[i, matrix.GetLength(1) - 1 - j] = temp;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return; // проверка что матрица квадратная
            if (n == 0) return; // проверка на пустую матрицу

            int startRow = n / 2;

            for (int i = startRow; i < n; i++)
            {
                for (int j = 0; j <= i; j++) // j <= i всегда в пределах т.к. i < n
                {
                    matrix[i, j] = 1;
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            // Сначала посчитаем сколько строк без нулей
            int countWithoutZeros = 0;
            for (int i = 0; i < rowCount; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < colCount; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (!hasZero) countWithoutZeros++;
            }

            // Создаем результирующую матрицу
            if (countWithoutZeros == 0)
            {
                answer = new int[0, colCount];
            }
            else
            {
                answer = new int[countWithoutZeros, colCount];
                int newRow = 0;

                for (int i = 0; i < rowCount; i++)
                {
                    bool hasZero = false;
                    for (int j = 0; j < colCount; j++)
                    {
                        if (matrix[i, j] == 0)
                        {
                            hasZero = true;
                            break;
                        }
                    }

                    if (!hasZero)
                    {
                        for (int j = 0; j < colCount; j++)
                            answer[newRow, j] = matrix[i, j];
                        newRow++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            Array.Sort(array, (a, b) => a.Sum().CompareTo(b.Sum()));
            // end

        }
    }
}
