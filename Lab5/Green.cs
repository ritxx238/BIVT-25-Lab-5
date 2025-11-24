using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(0)];
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;
                int minI = -1;
                for (int j=0; j<matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] <min )
                    {
                        min = matrix[i,j];
                        minI = j;
                    }
                }
                answer[i] = minI;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                int maxI = -1;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxI = j;
                    }
                }

                for (int j = 0; j < maxI; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j]/max);  
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0)==matrix.GetLength(1) && k < matrix.GetLength(1))
            {
                int maxI = 0, max = 0;
                for (int i =0; i<matrix.GetLength(0); i++)
                {
                    int j = i;
                    if (matrix[i,j]>max)
                    {
                        max=matrix[i,j];
                        maxI = i;
                    }
                }

                if (maxI != k)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        (matrix[i, k], matrix[i, maxI]) = (matrix[i, maxI], matrix[i, k]);
                    }
                }
            }

            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0)!=matrix.GetLength(1)) { return; }

            int max = int.MinValue, maxI = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,i]>max)
                    {
                        max =matrix[i,i]; maxI = i; 
                    }
                
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                (matrix[i, maxI], matrix[maxI, i]) = (matrix[maxI, i], matrix[i, maxI]);


            }

                // end

            }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int maxsum = 0;
            int str = -1;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]>0)
                    {
                        sum += matrix[i, j];
                    }
                }
                if (sum>maxsum) { maxsum = sum;
                    str = i;
                }
            }

            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i =0; i<answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (i<str)
                    {
                        answer[i,j] = matrix[i,j];
                    }
                    else
                    {
                        answer[i, j] = matrix[i + 1, j];
                    }
                }
            }

            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int neg1 = int.MinValue;
            int neg2 = int.MaxValue;
            int i1 = -1;
            int i2 = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]<0) { c++; }
                }
                if (c>neg1 ) {
                    neg1 = c; 
                    i1 = i;
                }
                if (c<neg2) { neg2 = c; i2 = i; }
            }

            if (neg2==neg1) { return; }

            for (int i = 0;i < matrix.GetLength(1); i++)
            {
                (matrix[i1, i], matrix[i2,i]) = (matrix[i2, i], matrix[i1, i]);
            }


            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            if (array.Length != matrix.GetLength(0)) { return matrix; }
            int min = int.MaxValue;
            int st = -1;

            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]<min)
                    {
                        min = matrix[i,j];
                        st = j;
                    }
                }
            }

            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    
                    if (j<=st) { answer[i,j] = matrix[i,j]; }
                    else if (j == st+1) { answer[i, j] = array[i]; }
                    else { answer[i, j] = matrix[i, j - 1];  }
                }
            }

            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int poz = 0;
                int neg = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i,j]>0) { poz++; }
                    if (matrix[i, j] < 0) { neg++; }
                }

                if (poz==neg) { continue; }

                int max = int.MinValue;
                int ii = -1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i,j]>max) { max = matrix[i,j]; ii = i; }
                    }
                if (poz > neg)
                {
                    matrix[ii, j] = 0;
                }
                else
                {
                    matrix[ii, j] = ii;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {return;}

            int n = matrix.GetLength(0);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // Верхняя сторона
                matrix[0, i] = 0;
                // Нижняя сторона  
                matrix[n - 1, i] = 0;
                // Левая сторона
                matrix[i, 0] = 0;
                // Правая сторона
                matrix[i, n - 1] = 0;
            }

            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) { return (A,B); }

            int ca=0, cb = 0;
            for (int i =0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j<matrix.GetLength(1);j++)
                {
                    if (i<=j) { ca++; }
                    else { cb++; }
                }
            }

            A = new int[ca];
            B = new int[cb];

            int iA=0, iB=0;
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j<matrix.GetLength(1); j++)
                {
                    if (i <= j)
                    {
                        A[iA++] = matrix[i,j];
                    }
                    else
                    {
                        B[iB++] = matrix[i,j];
                    }
                }
            }


            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            for (int st = 0; st < matrix.GetLength(1); st++)
            {
                int[] stl = new int[matrix.GetLength(0)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    stl[i] = matrix[i, st];
                }
                Array.Sort(stl);

                if (st % 2 == 0)
                {
                    Array.Reverse(stl);
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, st] = stl[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here

            if (array == null) return;

            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                sums[i] = 0;
                if (array[i] != null)
                {
                    for (int k = 0; k < array[i].Length; k++)
                    {
                        sums[i] = sums[i] + array[i][k];
                    }
                }
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    int countCurrent = 0;      
                    int countNext = 0;         

                    if (array[j] != null)
                        countCurrent = array[j].Length;
                    if (array[j + 1] != null)
                        countNext = array[j + 1].Length;

                    bool needToSwap = false;

                    if (countCurrent < countNext)
                    {
                        needToSwap = true;
                    }
                    else if (countCurrent == countNext)
                    {
                        if (sums[j] < sums[j + 1])
                        {
                            needToSwap = true;
                        }
                    }

                    if (needToSwap)
                    {
                        int[] tempRow = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempRow;

                        int tempSum = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = tempSum;
                    }
                }
            }

            // end

        }
    }
}
