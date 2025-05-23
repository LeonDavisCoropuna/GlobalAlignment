using System;
using System.IO;

namespace GlobalAlignment
{
  class Program
  {
    static void Main(string[] args)
    {
      string s1 = "TACCGAT";
      string s2 = "ATACCATACGT";
      var resultado = GlobalAligner.Align(s1, s2, "resultado.txt");
      Console.WriteLine("Score: " + resultado.score);
      foreach (var (a1, a2) in resultado.alignments)
      {
        Console.WriteLine(a1);
        Console.WriteLine(a2);
        Console.WriteLine();
      }
    }
  }
}
