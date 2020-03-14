using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMIP_3 {

  public class PrimeNumbers {
    public static bool IsPrime(int x) {

      for (int i = 2; i <= x / i; i++)
        if ((x % i) == 0) return false;

      return true;
    }
  }

  public class GCF {
    public static int GetGCF(int value1, int value2) {

      int b = 1;
      int q = value1 < value2 ? value1 : value2;
      int r = 1;
      int a = value1 < value2 ? value2 : value1;

      while (r > 0) {

        while (a - (b * q) >= q) {
          b++;
        }

        r = a - (b * q);
        a = q;
        q = r;
      }

      return a;
    }
  }


  public class Program {

    public static int firstInRange = 1;
    public static int lastInRange = 10;

    static void Main(string[] args) {

      #region CheckPrime
      Console.WriteLine($"Input range for search prime nubers: \nfirst in range: ");
      firstInRange = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine($"last in range: ");
      lastInRange = Convert.ToInt32(Console.ReadLine());

      for (int i = firstInRange; i < lastInRange; i++)
        if (PrimeNumbers.IsPrime(i))
          Console.Write(i + "  ");

      Console.WriteLine();
      #endregion


      #region GCF
      Console.WriteLine("greatest common factor for 2 numbers: \nInput numbers: ");

      int gcfTwo = GCF.GetGCF(
        Convert.ToInt32(Console.ReadLine()),
        Convert.ToInt32(Console.ReadLine())
      );

      Console.WriteLine("GCF = " + gcfTwo);

      Console.WriteLine("greatest common factor for 3 numbers: \nInput numbers: ");

      int gcfThree = GCF.GetGCF(
        GCF.GetGCF(
          Convert.ToInt32(Console.ReadLine()),
          Convert.ToInt32(Console.ReadLine())
        ),
        Convert.ToInt32(Console.ReadLine())
      );

      Console.WriteLine("GCF = " + gcfThree);
      #endregion
    }
  }
}
