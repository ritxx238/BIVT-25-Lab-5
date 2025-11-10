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

	    answer = new double[matrix.GetLength(0)]; //хочется плакать, кто придумал такой синтаксис?

	    for (int i = 0; i < matrix.GetLength(0); i++){
	      double line = 0;
	      int count = 0;
	      for (int j = 0; j < matrix.GetLength(1); j++){
		if (matrix[i, j]>0){ //и снова очень странный синтаксис, почему не как везде? в чем преимущество такого решения?
		  line+=matrix[i, j];
		  count++;
		}
	      }
	      if (count != 0){
		answer[i] = line/count;
	      }
	    }

            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here

	    int col = 0;
	    int row = 0;
	    for (int i = 0; i < matrix.GetLength(1); i++){
	      for (int j = 0; j < matrix.GetLength(0); j++){
		if (matrix[j, i] > matrix[row, col]) (row, col) = (j, i);
	      }
	    }
	    
	    answer = new int[matrix.GetLength(0)-1, matrix.GetLength(1)-1];
	    if (answer.GetLength(0) == 0 || answer.GetLength(1) == 0) return answer;
	    answer[0, 0] = -1;
	    int donei = 0;
	    for (int i = 0; i < matrix.GetLength(0); i++){
	      if (i != row){
		int donej = 0;
		for (int j = 0; j < matrix.GetLength(1); j++){
		  if (j != col){
		    answer[donei, donej] = matrix[i, j];
		    donej+=1;
		  }
		}
		donei+=1;
	      }
	    }



            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here

	    for (int i = 0; i < matrix.GetLength(0); i++){
	      int localMax = 0;
	      for (int j = 0; j < matrix.GetLength(1); j++){
		if (matrix[i, j] > matrix[i, localMax]){
		  localMax = j;
		}
	      }
	      for (int j = localMax+1; j < matrix.GetLength(1); j++){
		(matrix[i, j], matrix[i, j-1]) = (matrix[i, j-1], matrix[i, j]);
	      }
	    }

            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here

	    answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];
	    for (int i = 0; i < matrix.GetLength(0); i++){
	      int max = matrix[i, 0];
	      for (int j = 0; j < matrix.GetLength(1); j++){
		if (max < matrix[i, j]){
		  max = matrix[i, j];
		}
	      }
	      for (int j = 0; j < matrix.GetLength(1)-1; j++){
		answer[i, j] = matrix[i, j];
	      }
	      answer[i, matrix.GetLength(1)-1] = max;
	      answer[i, matrix.GetLength(1)] = matrix[i, matrix.GetLength(1)-1];
	    }
	      

            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here

	    answer = new int[(matrix.GetLength(0)*matrix.GetLength(1))/2];
	    int done = 0;
	    for (int i = 0; i < matrix.GetLength(0); i++){
	      for (int j = 0; j < matrix.GetLength(1); j++){
		if ((i+j)%2 == 1){
		  answer[done] = matrix[i, j];
		  done+=1;
		}
	      }
	    }


            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here

	    if (matrix.GetLength(0) != matrix.GetLength(1) || k>=matrix.GetLength(0)) return;
	    int n = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
	    int mrow = 0;
	    //if (matrix.GetLength(0) != matrix.GetLength(1)){ throw new ArgumentException("matrix is not square"); return;}
	    for (int i = 0; i < n; i++){
	      if (matrix[mrow, mrow] < matrix[i, i]) {
		mrow = i;
	      }
	    }
	    int row = -1;
	    for (int i = 0; i < matrix.GetLength(0); i++){
	      if (matrix[i, k] < 0){
		row = i;
		break;
	      }
	    }
	    if (row == -1 || row == mrow) return;

	    for (int i = 0; i < matrix.GetLength(1); i++)
	      (matrix[mrow, i], matrix[row, i]) = (matrix[row, i], matrix[mrow, i]);

	    
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here

	    if (matrix.GetLength(1))

            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here

            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here

            // end

            return answer;
        }
    }
}
