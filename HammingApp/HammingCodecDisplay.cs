using System.Text;
namespace HammingApp;

public static partial class HammingCodec
{
    // Format matrix as multi-line display string
    public static string MatrixString(int[][] m, string label)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Матрица {label} ({m.Length}x{m[0].Length}):");
        foreach (int[] row in m)
        {
            sb.Append("  [ ");
            sb.Append(string.Join("  ", row));
            sb.AppendLine(" ]");
        }
        return sb.ToString();
    }
}
