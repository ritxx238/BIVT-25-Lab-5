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

	    answer = new int[matrix.GetLength(1)];
	    for (int i = 0; i < matrix.GetLength(1); i++){
	      for (int j = 0; j < matrix.GetLength(0); j++){
		if (matrix[j, i] < 0) answer[i]+=1;
	      }
	    }


            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

	  int n = matrix.GetLength(0);
	  int m = matrix.GetLength(1);

	  for (int i = 0; i < n; i++){
	    int imin = 0;
	    for (int j = 0; j < m; j++){
	      if (matrix[i, imin]>matrix[i, j]){
		imin = j;
	      }
	    }
	    int min = matrix[i, imin];
	    for (int j = imin; j > 0; j--){
	      (matrix[i, j], matrix[i, j-1]) = (matrix[i, j-1], matrix[i, j]);
	    }
	    matrix[i, 0] = min;
	  }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here

	  int n = matrix.GetLength(0);
	  int m = matrix.GetLength(1);
	  answer = new int[n, m+1];
	  for (int i = 0; i < n; i++){
	    int imax = 0;
	    for (int j = 0; j < m; j++){
	      if (matrix[i, imax] < matrix[i, j]){
		imax = j;
	      }
	    }
	    for (int j = 0; j < m; j++){
	      if (j < imax){
		answer[i, j] = matrix[i, j];
	      }
	      else if (j == imax){
		answer[i, j] = matrix[i, j];
		answer[i, j+1] = matrix[i, j];
	      }
	      else{
		answer[i, j+1] = matrix[i, j];
	      }
	    }
	  }

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

	  // code here

	  int n = matrix.GetLength(0);
	  int m = matrix.GetLength(1);
	  for (int i = 0; i < n; i++){
	    int imax = 0;
	    for (int j = 0; j < m; j++){
	      if (matrix[i, imax] < matrix[i, j]){
		imax = j;
	      }
	    }
	    int sum = 0;
	    int count = 0;
	    for (int j = imax+1; j < m; j++){
	      if (matrix[i, j] > 0){
		count+=1; sum+= matrix[i, j];
	      }
	    }
	    if (count != 0){
	      for (int j = 0; j < imax; j++){
		if (matrix[i, j] < 0){
		  matrix[i, j] = sum/count;
		}
	      }
	    }
	    else{
	      for (int j = 0; j < imax; j++){
		if (matrix[i, j] < 0){
		  matrix[i, j] = 0;
		}
	      }
	    }
	  }

	  // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

	  int n = matrix.GetLength(0);
	  int m = matrix.GetLength(1);

	  if (k >= m) return;
	  int[] new_col = new int[n];
	  for (int i = 0; i < n; i++){
	    new_col[i] = matrix[i, 0];
	    for (int j = 0; j < m; j++){
	      new_col[i] = Math.Max(new_col[i], matrix[i, j]);
	    }
	  }
	  for (int i = 0; i < n; i++){
	    matrix[i, k] = new_col[new_col.Length - i - 1];
	  }

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

	  int n = matrix.GetLength(0);
	  int m = matrix.GetLength(1);

	  if (array.Length != m) return;

	  for (int j = 0; j < m; j++){
	    int imax = 0;
	    for (int i = 0; i < n; i++){
	      if (matrix[imax, j] < matrix[i, j]){
		imax = i;
	      }
	    }
	    matrix[imax, j] = Math.Max(array[j], matrix[imax, j]);
	  }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here

	  int n = matrix.GetLength(0);
	  int m = matrix.GetLength(1);

	  int[,] data = new int[n, 2];
	  
	  for (int i = 0; i < n; i++){
	    data[i, 1] = i;
	    data[i, 0] = matrix[i, 0];
	    for (int j = 0; j < m; j++){
	      data[i, 0] = Math.Min(data[i, 0], matrix[i, j]);
	    }
	  }

	  int I = 0; 
	  while (I < n){
	    if (I == 0 || data[I, 0] <= data[I - 1, 0]) 
	      I++;
	    else{
	      (data[I, 0], data[I - 1, 0]) = (data[I - 1, 0], data[I, 0]);
	      for (int j = 0; j < m; j++){
		(matrix[I, j], matrix[I-1, j]) = (matrix[I-1, j], matrix[I, j]); //код неоптимизирован, очевидно. Так писать нельзя
	      }
	      I--;
	    }
	  }
	  
	  
/*
	  int[,] new_matrix = new int[n, m];

	  for (int i = 0; i < n; i++){
	    int line = data[data.GetLength(0) - i - 1, 1];
	    for (int j = 0; j < m; j++){
	      new_matrix[i, j] = matrix[line, j];
	    }
	  }
	  throw new Exception(String.Join(" ", data[n-1, 1]));
*/
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here

	  int n = matrix.GetLength(0);
	  int m = matrix.GetLength(1);

	  if (n!=m){return null;}

	  answer = new int[n*2-1];

	  for (int i = n-1; i >= 0; i--){
	    for (int j = 0; i+j<n; j++){
	      answer[n-i-1]+=matrix[i+j, j];
	    }
	  }
	  for (int j = 0; j < n; j++){
	    for (int i = 1; i+j < n; i++){
	      answer[n+i-1]+=matrix[j, i+j];
	    }
	  }
	  //throw new Exception(String.Join(" ", answer));
	    

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

	  int n = matrix.GetLength(0);
	  int m = matrix.GetLength(1);

	  if (n!=m){return;}

	  int imax = 0, jmax = 0;

	  for (int i = 0; i < n; i++){
	    for (int j = 0; j < m; j++){
	      if (Math.Abs(matrix[imax, jmax]) < Math.Abs(matrix[i, j])){
		imax = i;
		jmax = j;
	      }
	    }
	  }
	  int ishift = k-imax;
	  int jshift = k-jmax;
	  int[,] new_matrix = new int[n, m];
	  if (ishift < 0){
	    for (int i = imax; i > k; i--){
	      for (int j = 0; j < m; j++){
		(matrix[i, j], matrix[i-1, j]) = (matrix[i-1, j], matrix[i, j]);
	      }
	    }
	  }
	  else{

	    for (int i = imax; i < k; i++){
	      for (int j = 0; j < m; j++){
		(matrix[i, j], matrix[i+1, j]) = (matrix[i+1, j], matrix[i, j]);
	      }
	    }

	  }
	  if (jshift < 0){
	    for (int j = jmax; j > k; j--){
	      for (int i = 0; i < m; i++){
		(matrix[i, j], matrix[i, j-1]) = (matrix[i, j-1], matrix[i, j]);
	      }
	    }
	  }
	  else{

	    for (int j = jmax; j < k; j++){
	      for (int i = 0; i < m; i++){
		(matrix[i, j], matrix[i, j+1]) = (matrix[i, j+1], matrix[i, j]);
	      }
	    }
	  }
	  /*
	     for (int i = 0; i < n; i++){
	     for (int j = 0; j < m; j++){
	     new_matrix[(i+ishift)%n, (j+jshift)%m] = matrix[i, j];
	     }
	     }
	     matrix = new_matrix;
	     */	    
	  /*
	     if (n==4){
	     string output = Convert.ToString(n) + '\n'; 
	     for (int i = 0; i < n; i++){
	     for (int j = 0; j < m; j++){
	     output += Convert.ToString(matrix[i, j]) + ' ';
	     }
	     output+='\n';
	     }
	     throw new Exception(output);
	     }
	     */	  


            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here

	  int n0 = A.GetLength(1);
	  int m0 = A.GetLength(0);
	  int n1 = B.GetLength(1);
	  int m1 = B.GetLength(0);

	  if (n0!=m1) return answer;

	  answer = new int[n0, m1];

	  for (int i = 0; i < n0; i++){
	    for (int j = 0; j < n0; j++){
	      for (int k = 0; k < n0; k++){
		answer[i, j] += A[i, k] * B[k, j];
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

            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here

            // end

            return answer;
        }
    }
}
