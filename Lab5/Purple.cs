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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[cols];
            for (int col = 0; col < cols; col++)
            {
                int cnt = 0;
                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, col] < 0) cnt += 1;
                }
                answer[col] = cnt;
            }
            

            Console.WriteLine(String.Join(" ", answer));
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {
            // code here
            int getMinInx(int[] arr)
            {
                int Min = int.MaxValue;
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] < Min)
                        Min = arr[i];
                return Min;
            }
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                int inxMin = 0;
                for (int col = 0; col < cols; col++)
                    if (matrix[row, col] < matrix[row, inxMin])
                        inxMin = col;
                
                int[] arr = new int[cols];
                arr[0] = matrix[row, inxMin];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (i <= inxMin) arr[i] = matrix[row, i - 1];
                    else arr[i] = matrix[row, i];
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    matrix[row, i] = arr[i];
                    Console.Write($"{matrix[row, i]} ");
                }

                Console.Write($"\n");
            }
            Console.Write($"\n");
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
                int inxMax = 0;
                for (int col = 0; col < cols; col++)
                    if (matrix[row, col] > matrix[row, inxMax])
                        inxMax = col;
                
                for (int col = 0; col < cols + 1; col++)
                {
                    if (col <= inxMax) answer[row, col] = matrix[row, col];
                    else answer[row, col] = matrix[row, col - 1];
                    Console.Write($"{answer[row, col]} ");
                }

                Console.Write("\n");

            }
            Console.Write("\n");
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
                int inxMax = 0;
                for (int col = 0; col < cols; col++)
                    if (matrix[row, col] > matrix[row, inxMax])
                        inxMax = col;
                
                
                if (inxMax < cols)
                {
                    int sr = 0;
                    int cnt = 0;
                    for (int col = inxMax + 1; col < cols; col++)
                        if (matrix[row, col] > 0)
                        {
                            sr += matrix[row, col];
                            cnt += 1;
                        }

                    if (cnt > 0)
                    {
                        sr /= cnt;

                        for (int col = 0; col < inxMax; col++) 
                            if (matrix[row, col] < 0)
                                matrix[row, col] = sr;
                    }
                }
                for (int col = 0; col < cols; col++) Console.Write($"{matrix[row, col]} ");
                Console.Write("\n");
            }
            Console.Write("\n");
            
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] arr = new int[rows];
            for (int row = 0; row < rows; row++)
            {
                int Max = int.MinValue;
                for (int col = 0; col < cols; col++)
                    if (matrix[row, col] > Max)
                        Max = matrix[row, col];
                arr[row] = Max;
            }
            
            Array.Reverse(arr);

            if (k < cols)
            {
                for (int row = 0; row < rows; row++)
                {
                    matrix[row, k] = arr[row];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++) 
                    Console.Write($"{matrix[row, col]} "); 
                Console.Write("\n");
            }
            Console.Write("\n");


            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (array.Length != cols) return;
            for (int col = 0; col < cols; col++)
            {
                int inxMax = 0;
                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, col] > matrix[inxMax, col])
                    {
                        inxMax = row;
                    }
                }
                
                if (array[col] > matrix[inxMax, col])
                    matrix[inxMax, col] = array[col];
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                    Console.Write($"{matrix[row, col]} ");
                Console.Write($"\n");
            }
            Console.Write($"\n");
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                    Console.Write($"{matrix[row, col]} ");
                Console.Write($"\n");
            }
            Console.Write($"\n");

            for (int i = 0; i < rows - 1; i++)
            {
                for (int row = 0; row < rows - i - 1; row++)
                {
                    int Min = int.MaxValue;
                    for (int col = 0; col < cols; col++)
                        if (matrix[row, col] < Min)
                            Min = matrix[row, col];
                    
                    int Min1= int.MaxValue;
                    for (int col = 0; col < cols; col++)
                        if (matrix[row + 1, col] < Min1)
                            Min1 = matrix[row + 1, col];
                    
                    if (Min1 > Min)
                        for (int col = 0; col < cols; col++)
                            (matrix[row, col], matrix[row + 1, col]) = (matrix[row + 1, col], matrix[row, col]);
                }
            }
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                    Console.Write($"{matrix[row, col]} ");
                Console.Write($"\n");
            }
            Console.Write($"\n");
            
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))return answer;
            
            answer = new int[2 * n - 1];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            for (int row = n - 1; row >= 0; row--)
            {
                for (int col = 0; col < n; col++)
                {
                    answer[col + (n - 1 - row)] += matrix[row, col];
                    
                }
                
            }
            
            Console.WriteLine(String.Join(" ", answer));
            Console.Write("\n");
            
            
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return;

            Console.WriteLine($"{k}\n");
            
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                    Console.Write($"{matrix[row, col]} ");
                Console.Write("\n");
            }
            Console.Write("\n");

            int MaxRow = 0, MaxCol = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (Math.Abs(matrix[row, col]) > Math.Abs(matrix[MaxRow, MaxCol]))
                    {
                        MaxRow = row;
                        MaxCol = col;
                    }
                }
            }

            if (k - MaxRow != 0)
            {
                int kfRow = (k - MaxRow) / Math.Abs(k - MaxRow);
                for (int row = MaxRow; row*(-kfRow) > k*(-kfRow); row += kfRow)
                {
                    for (int col = 0; col < n; col++)
                    {
                        (matrix[row, col], matrix[row + kfRow, col]) = (matrix[row + kfRow, col], matrix[row, col]);
                    }
                }
            }
            
            if (k - MaxCol != 0)
            {
                int kfCol = (k - MaxCol) / Math.Abs(k - MaxCol);
                for (int col = MaxCol; col*(-kfCol) > k*(-kfCol); col += kfCol)
                {
                    for (int row = 0; row < n; row++)
                    {
                        (matrix[row, col], matrix[row, col + kfCol]) = (matrix[row, col + kfCol], matrix[row, col]);
                    }
                }
            }
            
            
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                    Console.Write($"{matrix[row, col]} ");
                Console.Write("\n");
            }
            Console.Write("\n");
            
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int rows = A.GetLength(0);
            int cols = B.GetLength(1);

            if (A.GetLength(1) == B.GetLength(0))
            {
                answer = new int[rows, cols];
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        for (int i = 0; i < rows; i++)
                        {
                            answer[row, col] += A[row, i] * B[i, col];
                        }
                        Console.Write($"{answer[row, col]} ");
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
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
            
            answer = new int [rows][];

            for (int row = 0; row < rows; row++)
            {
                int cnt = 0;
                for (int col = 0; col < cols; col++)
                    if (matrix[row, col] > 0)
                        cnt += 1;

                int[] arr = new int[cnt];
                cnt = 0;
                for (int col = 0; col < cols; col++)
                    if (matrix[row, col] > 0)
                    {
                        arr[cnt] = matrix[row, col];
                        cnt += 1;
                    }
                
                answer[row] = arr;
            }
            
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int cnt = 0;
            foreach (int[] arr in array)
            {
                cnt += arr.Length;
            }

            int n = (int) Math.Ceiling(Math.Pow(cnt, 0.5));

            answer = new int[n, n];
            int row = 0;
            int col = 0;
            foreach (int[] arr in array)
            {
                foreach (int el in arr)
                {
                    answer[row % n, col % n] = el;
                    Console.Write($"{answer[row, col]} ");
                    col++;
                    if (col == n)
                    {
                        Console.Write("\n");
                        col = 0;
                        row += 1;
                    }
                }
            }
            Console.Write("\n");
            
            
            // end

            return answer;
        }
    }
}