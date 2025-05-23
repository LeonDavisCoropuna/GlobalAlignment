using System;
using System.Collections.Generic;
using Xunit;
using GlobalAlignment;

public class GlobalAlignerTests
{
  [Fact]
  public void Align_ShouldReturnExpectedScoreAndAlignments()
  {
    // Cadenas de prueba
    string s1 = "TACGCGC";
    string s2 = "TCCGA";

    // Llamar al método
    var result = GlobalAligner.Align(s1, s2, "dummy.txt"); // dummy.txt porque no nos importa el archivo en el test

    // Score esperado
    int expectedScore = -1;
    Assert.Equal(expectedScore, result.score);

    // Alineamientos esperados
    var expectedAlignments = new List<(string, string)>
        {
            ("TACGCGC", "T-C-CGA")
        };

    // Como puede haber múltiples alineamientos, buscamos que al menos uno coincida exactamente
    bool matchFound = false;
    foreach (var (aligned1, aligned2) in result.alignments)
    {
      // Normalizamos quitando espacios y tabulaciones si los hubiera (por si acaso)
      var normA1 = aligned1.Replace(" ", "").Replace("\t", "");
      var normA2 = aligned2.Replace(" ", "").Replace("\t", "");

      // Comparamos con el esperado (también sin espacios)
      if (normA1 == expectedAlignments[0].Item1.Replace(" ", "") &&
          normA2 == expectedAlignments[0].Item2.Replace(" ", ""))
      {
        matchFound = true;
        break;
      }
    }

    Assert.True(matchFound, "No se encontró el alineamiento esperado.");
  }

  [Fact]
  public void Align_ShouldReturnExpectedScoreAndAlignments2()
  {
    // Cadenas de prueba
    string s1 = "TACCGAT";
    string s2 = "ATACCATACGT";

    // Llamar al método
    var result = GlobalAligner.Align(s1, s2, "dummy.txt"); // dummy.txt porque no nos importa el archivo en el test

    // Score esperado
    int expectedScore = -3;
    Assert.Equal(expectedScore, result.score);

    // Alineamientos esperados
    var expectedAlignments = new List<(string, string)>
    {
        ("-TACC-GA--T", "ATACCATACGT"),
        ("-TACCG-A--T", "ATACCATACGT")
    };

    // Como puede haber múltiples alineamientos, buscamos que al menos uno coincida exactamente
    bool matchFound = false;
    foreach (var (aligned1, aligned2) in result.alignments)
    {
      // Normalizamos quitando espacios y tabulaciones si los hubiera (por si acaso)
      var normA1 = aligned1.Replace(" ", "").Replace("\t", "");
      var normA2 = aligned2.Replace(" ", "").Replace("\t", "");

      // Comparamos con el esperado (también sin espacios)
      if (normA1 == expectedAlignments[0].Item1.Replace(" ", "") &&
          normA2 == expectedAlignments[0].Item2.Replace(" ", ""))
      {
        matchFound = true;
        break;
      }
    }

    Assert.True(matchFound, "No se encontró el alineamiento esperado.");
  }
  [Fact]
  public void IsSubstring_ShouldReturnTrue_WhenSubIsInsideMain()
  {
    string main = "ATACCATACGT";
    string sub = "CCAT";

    bool result = GlobalAligner.IsSubstring(main, sub);

    Assert.True(result);
  }

  [Fact]
  public void IsSubstring_ShouldReturnFalse_WhenSubIsNotInsideMain()
  {
    string main = "ATACCATACGT";
    string sub = "GGG";

    bool result = GlobalAligner.IsSubstring(main, sub);

    Assert.False(result);
  }

}
