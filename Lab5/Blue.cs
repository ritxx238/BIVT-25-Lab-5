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

      int n = matrix.GetLength(0), m = matrix.GetLength(1);

      answer = new double[n];
      for (int i = 0; i < n; i++)
      {
        double S = 0, si = 0;
        for (int j = 0; j < m; j++)
          if (matrix[i, j] > 0)
          {
            S += matrix[i, j];
            si++;
          }
        if (si == 0)
          answer[i] = 0;
        else
          answer[i] = S / si;
      }

      // end

      return answer;
    }
    public int[,] Task2(int[,] matrix)
    {
      int[,] answer = null;

      // code here

      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      int mxi = 0, mxj = 0;
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if (matrix[i, j] > matrix[mxi, mxj])
            (mxi, mxj) = (i, j);

      answer = new int[n-1, m-1];
      if ((n == 0) || (m == 0))
        return answer;
      
      int ki = 0;
      for (int i = 0; i < n; i++)
      {
        int kj = 0;
        if (i == mxi)
          continue;

        for (int j = 0; j < m; j++)
        {
          if (j == mxj)
            continue;
          answer[ki, kj] = matrix[i, j];
          kj++;
        }
        ki++;
      }

      // end

        return answer;
    }
    public void Task3(int[,] matrix)
    {

      // code here
      
      int n = matrix.GetLength(0), m = matrix.GetLength(1);
      
      for (int i = 0; i < n; i++)
      {
        int mx = 0;
        for (int j = 0; j < m; j++)
          if (matrix[i, j] > matrix[i, mx])
            mx = j;

        for (int j = mx; j < (m - 1); j++)
          (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
      }

      // end

    }
    public int[,] Task4(int[,] matrix)
    {
      int[,] answer = null;

      // code here

      int n = matrix.GetLength(0), m = matrix.GetLength(1);

      answer = new int[n, m + 1];
      for (int i = 0; i < n; i++)
      {
        int mx = 0;
        for (int j = 0; j < m; j++)
          if (matrix[i, j] > matrix[i, mx])
            mx = j;

        for (int j = 0; j < (m + 1); j++)
        {
          if (j < (m - 1))
            answer[i, j] = matrix[i, j];
          else if (j == (m - 1))
            answer[i, j] = matrix[i, mx];
          else
            answer[i, j] = matrix[i, (j - 1)];
        }
      }

      // end

      return answer;
    }
    public int[] Task5(int[,] matrix)
    {
      int[] answer = null;

      // code here

      int n = matrix.GetLength(0), m = matrix.GetLength(1);

      int count = 0;
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if ((i + j) % 2 == 1)
            count++;

      answer = new int[count];

      count = 0;
      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          if ((i + j) % 2 == 1)
            answer[count++] = matrix[i, j];

      // end

      return answer;
    }
    public void Task6(int[,] matrix, int k)
    {

      // code here

      if ((matrix.GetLength(0) != matrix.GetLength(1)) || (k >= matrix.GetLength(0)))
        return;

      int n = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

      int mx = 0;
      for (int i = 0; i < n; i++)
        if (matrix[i, i] > matrix[mx, mx])
          mx = i;

      n = matrix.GetLength(0); int m = matrix.GetLength(1);

      int mn = 0;
      bool flag = false;
      for (int i = 0; i < n; i++)
      {
          if ((!flag) && (matrix[i, k] < 0))
        {
          mn = i;
          flag = true;
        }
      }

      if ((!flag) || (mx == mn))
        return;

      for (int j = 0; j < m; j++)
        (matrix[mx, j], matrix[mn, j]) = (matrix[mn, j], matrix[mx, j]);

      // end

      }
    public void Task7(int[,] matrix, int[] array)
    {

      // code here

      int n = matrix.GetLength(0), m = matrix.GetLength(1), arrm = array.Length;

      if (m != arrm)
        return;

      int mx = 0;
      for (int i = 0; i < n; i++)
        if (matrix[i, m - 2] > matrix[mx, m - 2])
          mx = i;

      for (int j = 0; j < m; j++)
        (matrix[mx, j], array[j]) = (array[j], matrix[mx, j]);

      // end

    }
    public void Task8(int[,] matrix)
    {

      // code here

      int n = matrix.GetLength(0), m = matrix.GetLength(1);

      for (int j = 0; j < m; j++)
      {
        int mx = 0;
        for (int i = 0; i < n; i++)
          if (matrix[i, j] > matrix[mx, j])
            mx = i;

        if (mx >= (n / 2))
          continue;

        int s = 0;
        for (int i = mx + 1; i < n; i++)
          s += matrix[i, j];
        matrix[0, j] = s;
      }

      // end

    }
    public void Task9(int[,] matrix)
    {

      // code here
      
      int n = matrix.GetLength(0), m = matrix.GetLength(1);

      for (int i = 0; i < (n - 1); i+=2)
      {
        int mx1 = 0, mx2 = 0;
        for (int j = 0; j < m; j++)
        {
          if (matrix[i, j] > matrix[i, mx1])
            mx1 = j;
          if (matrix[i + 1, j] > matrix[i + 1, mx2])
            mx2 = j;
        }

        (matrix[i, mx1], matrix[i + 1, mx2]) = (matrix[i + 1, mx2], matrix[i, mx1]);
      }

      // end

    }
    public void Task10(int[,] matrix)
    {

      // code here

      int n = matrix.GetLength(0), m = matrix.GetLength(1);

      if (n != m)
        return;

      int mxi = 0;
      for (int i = 0; i < n; i++)
        if (matrix[i, i] > matrix[mxi, mxi])
          mxi = i;

      for (int i = 0; i < mxi; i++)
      {
        for (int j = 0; j < m; j++)
        {
          if (i < j)
          {
            matrix[i, j] = 0;
          }
        }
      }

      // end

    }
    public void Task11(int[,] matrix)
    {

      // code here
      
      int n = matrix.GetLength(0), m = matrix.GetLength(1);

      int[] arrk = new int[n];
      int[] arri = new int[n];
      for (int i = 0; i < n; i++)
      {
        int count = 0;
        for (int j = 0; j < m; j++)
          if (matrix[i, j] > 0)
            count++;
        arrk[i] = count;
        arri[i] = i;
      }

      int jj = 0;
      while (jj < n)
      {
        if ((jj == 0) || (arrk[jj] <= arrk[jj - 1]))
          jj++;
        else
        {
          (arrk[jj], arrk[jj - 1]) = (arrk[jj - 1], arrk[jj]);
          (arri[jj], arri[jj - 1]) = (arri[jj - 1], arri[jj]);
          jj--;
        }
      }

      int[,] ans = (int[,])matrix.Clone();

      for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
          matrix[i, j] = ans[arri[i], j];

      // end

    }
    public int[][] Task12(int[][] array)
    {
      int[][] answer = null;

      // code here
      
      double s = 0;
      int count = 0;
      for (int i = 0; i < array.Length; i++)
      {
        for (int j = 0; j < array[i].Length; j++)
          s += array[i][j];
        count += array[i].Length;
      }
      s /= count;

      count = 0;
      for (int i = 0; i < array.Length; i++)
      {
        double s1 = 0;
        for (int j = 0; j < array[i].Length; j++)
          s1 += array[i][j];
        s1 /= array[i].Length;

        if (s1 >= s)
          count++;
      }

      answer = new int[count][];
      
      count = 0;
      for (int i = 0; i < array.Length; i++)
      {
        double s1 = 0;
        for (int j = 0; j < array[i].Length; j++)
          s1 += array[i][j];
        s1 /= array[i].Length;

        if (s1 >= s)
        {
          answer[count] = new int[array[i].Length];
          Array.Copy(array[i], 0, answer[count++], 0, array[i].Length);
        }
      }

      // end

      return answer;
    }
  }
}
