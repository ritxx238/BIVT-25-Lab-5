using System.Data.Common;
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
            int count=0;
            answer=new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++) if (matrix[j,i]<0) count++;
                answer[i]=count;
                count=0;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int indexMin=0;
                for (int j = 0; j < cols; j++) if (matrix[i,j]<matrix[i,indexMin]) indexMin=j;
                int temp=matrix[i,indexMin];
                for (int k = indexMin; k > 0; k--) matrix[i,k]=matrix[i,k-1];
                matrix[i,0]=temp;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            answer=new int[rows,cols+1];
            for (int i = 0; i < rows; i++)
            {
                int indexMax=0,maxValue;
                for (int j = 0; j < cols; j++) if (matrix[i,indexMax]<matrix[i,j]) indexMax=j;
                for (int l = 0; l <= indexMax; l++) answer[i,l]=matrix[i,l];
                maxValue=matrix[i,indexMax];
                answer[i,++indexMax]=maxValue;
                int indexAnswer=cols;
                for (int j = cols - 1; j > indexMax-1; j--) answer[i,indexAnswer--]=matrix[i,j];
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int indexMax=0,average=0,count=0;
                for (int j = 0; j < cols; j++) if (matrix[i,indexMax]<matrix[i,j]) indexMax=j;
                for (int j = indexMax + 1; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        average+=matrix[i,j];
                        count++;
                    }
                }
                if (average == 0) continue;
                else average/=count;
                for (int j = 0; j < indexMax; j++)if (matrix[i,j]<0) matrix[i,j]=average;
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            if (k<0 || k>=cols) return;
            int[] maxElemets=new int[rows];
            for (int i=0;i<rows;i++)
            {
                int indexMax=0;
                for (int j = 0; j < cols; j++) if (matrix[i,indexMax]<matrix[i,j]) indexMax=j;
                maxElemets[rows-i-1]=matrix[i,indexMax];
            }
            for (int i = 0; i < rows; i++) matrix[i,k]=maxElemets[i];   
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows=matrix.GetLength(0), cols=matrix.GetLength(1);
            if (array.Length!=cols) return;
            for (int i = 0; i < cols; i++)
            {
                int indexMax=0;
                for (int j = 0; j < rows; j++) if (matrix[indexMax,i]<matrix[j,i]) indexMax=j;
                if (matrix[indexMax,i]<array[i]) matrix[indexMax,i]=array[i];
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int rows=matrix.GetLength(0),cols=matrix.GetLength(1);
            int[] minElements=new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int indexMin=0;
                for (int j = 0; j < cols; j++)if (matrix[i,indexMin]>matrix[i,j]) indexMin=j;
                minElements[i]=matrix[i,indexMin];
            }
            int l=1;
            while (l < rows)
            {
                if (l==0 || minElements[l-1]>=minElements[l]) l++;
                else
                {
                    (minElements[l-1],minElements[l])=(minElements[l],minElements[l-1]);
                    for (int j = 0; j < cols; j++)(matrix[l-1,j],matrix[l,j])=(matrix[l,j],matrix[l-1,j]);
                    l--;
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows=matrix.GetLength(0),cols=matrix.GetLength(1);
            if (rows!=cols) return answer;
            answer=new int[2*rows-1];
            for (int i = 0; i < rows; i++ )
            {
                for (int j = 0; j < rows; j++)
                {
                    int index = i-j+(rows-1);
                    answer[index]+=matrix[i,j];
                }
            }
            int left=0,right=answer.Length-1;
            while (left < right)
            {
                (answer[left],answer[right])=(answer[right],answer[left]);
                left++;
                right--;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int rows=matrix.GetLength(0),cols=matrix.GetLength(1);
            if (rows!=cols || k<0 || k>=rows) return;
            int indexMaxI=0,indexMaxJ=0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(matrix[i,j]) >Math.Abs(matrix[indexMaxI,indexMaxJ]))
                    {
                        indexMaxI=i;
                        indexMaxJ=j;
                    }
                }
            }
            if (indexMaxI != k)
            {
                int[] term=new int[cols];
                for (int j=0;j<cols;j++) term[j]=matrix[indexMaxI,j];
                if (indexMaxI > k) for (int i = indexMaxI; i > k; i--) for (int j = 0; j < cols; j++) matrix[i,j]=matrix[i-1,j];
                if (indexMaxI < k) for (int i = indexMaxI; i < k; i++) for (int j = 0; j < cols; j++) matrix[i,j]=matrix[i+1,j];
                for (int j = 0; j < cols; j++)matrix[k,j]=term[j];
            }
            if (indexMaxJ != k)
            {
                int[] term=new int [cols];
                for (int i=0;i<rows;i++) term[i]=matrix[i,indexMaxJ];
                if (indexMaxJ < k) for (int i = 0; i < rows; i++) for (int j = indexMaxJ; j < k; j++) matrix[i,j]=matrix[i,j+1];
                if (indexMaxJ > k) for (int i = 0; i < rows; i++) for (int j = indexMaxJ; j > k; j--) matrix[i,j]=matrix[i,j-1];
                for (int i=0;i<rows;i++) matrix[i,k]=term[i];
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int rowsA=A.GetLength(0),colsA=A.GetLength(1);
            int rowsB=B.GetLength(0),colsB=B.GetLength(1);
            if (colsA!=rowsB) return answer;
            answer=new int[rowsA,colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA;k++)
                    {
                        answer[i,j]+=A[i,k]*B[k,j];
                    }
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int rows=matrix.GetLength(0),cols=matrix.GetLength(1);
            answer=new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int count=0;
                for (int j = 0; j < cols; j++) if (matrix[i,j]>0) count++;
                answer[i]=new int [count];
                count=0;
                for (int j = 0; j < cols; j++) if (matrix[i,j]>0) answer[i][count++]=matrix[i,j];
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int sumElements=0,len,index=0;
            for (int i = 0; i < array.Length; i++) sumElements+=array[i].Length;
            len=(int)Math.Ceiling(Math.Sqrt(sumElements));
            answer=new int[len,len];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (index < len * len)
                    {
                        int row = index/len;
                        int col=index%len;
                        answer[row,col]=array[i][j];
                        index++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}
