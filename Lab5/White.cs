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
            int sum = 0;
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        sum += matrix[i,j];
                        count++;
                    }
                }
            }
            average = (double)sum / count;
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0,mins = matrix[0,0];

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] < mins)
                    {
                        mins = matrix[i, j];
                        row = i; 
                        col = j;
                    }
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (k < 0 || k >= matrix.GetLength(1)) return;
            int row = 0, maxs = matrix[0, k];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                    if (matrix[i, k] > maxs)
                    {
                        maxs = matrix[i, k];
                        row = i;
                    }
            }
            if (row == 0) return; 
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int t = matrix[0, j];
                matrix[0, j] = matrix[row, j];
                matrix[row, j] = t;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[,] answer = new int[n-1,m];
            int row = 0, mins = matrix[0, 0];
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, 0] < mins)
                {
                    mins = matrix[i, 0];
                    row = i;
                }
            }
            for (int i = 0; i < n - 1; i++)
                if (i < row)
                    for (int j = 0; j < m; j++) answer[i, j] = matrix[i, j];
                else
                    for (int j = 0; j < m; j++) answer[i, j] = matrix[i + 1, j];
            // end
            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            //code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return 0;
            for (int i = 0; i < matrix.GetLength(0); i++) sum += matrix[i, i];
            //end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int q = -1,maxq = -1,w = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        q = j;
                        break;
                    }

                    if (maxq == -1 || matrix[i, j] > matrix[i, maxq]) maxq = j;
                    
                }
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        w = j;
                        break;
                    }
                }
                if (maxq != -1 && w != -1 && q != -1)
                {
                    int temp = matrix[i, maxq];
                    matrix[i, maxq] = matrix[i, w];
                    matrix[i, w] = temp;
                }
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int n = matrix.GetLength(0),m = matrix.GetLength(1),k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] < 0) k++;
            if (k == 0) return null;
            negatives = new int[k];
            int s = 0;
            for (int i = 0; i < n; i++)   
                for (int j = 0; j < m; j++) 
                    if (matrix[i, j] < 0)
                    {
                        negatives[s] = matrix[i, j];
                        s++;
                    }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                if (m == 1) continue;
                int x = 0;
                for (int j = 1; j < m; j++)
                    if (matrix[i, j] > matrix[i, x]) x = j;
                if (x == 0) matrix[i, 1] *= 2;
                else if (x == m - 1) matrix[i, m - 2] *= 2;
                else
                {
                    if (matrix[i, x - 1] <= matrix[i, x + 1]) matrix[i, x - 1] *= 2;
                    else matrix[i, x + 1] *= 2;
                }
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
                    int t = matrix[i, j];
                    matrix[i, j] = matrix[i, matrix.GetLength(1) - 1 - j];
                    matrix[i, matrix.GetLength(1) - 1 - j] = t;
                }
            }
            // end
        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            for (int i = matrix.GetLength(0) / 2; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++) 
                {
                    matrix[i, j] = 1;
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            bool[] c = new bool[n];
            int s = 0;

            for (int i = 0; i < n; i++)
            {
                bool f = false;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        f = true;
                        break;
                    }
                }
                if (!f)
                {
                    c[i] = true;
                    s++;
                }
            }
            int[,] answer = new int[s, m];
            int w = 0;
            for (int i = 0; i < n; i++)
            {
                if (c[i])
                {
                    for (int j = 0; j < m; j++) answer[w, j] = matrix[i, j];
                    w++;
                }
            }
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {
            // code here
            int sum = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int q = 0,w = 0;
                    for (int k = 0; k < array[i].Length; k++) q += array[i][k];
                    for (int k = 0; k < array[j].Length; k++) w += array[j][k];
                    if (q > w)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            // end
        }
    }
}
