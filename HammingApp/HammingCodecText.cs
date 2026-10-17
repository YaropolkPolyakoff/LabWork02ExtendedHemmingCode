using System.Text;
namespace HammingApp;

public static partial class HammingCodec
{
    // Encode a Unicode string to a bit string (32 bits per character)
    public static string EncodeText(string input)
    {
        var buf = new StringBuilder(input.Length * 32);
        foreach (char ch in input)
        {
            ushort charCode = (ushort)ch;
            for (int ni = 3; ni >= 0; ni--)
            {
                byte nib = (byte)((charCode >> (ni * 4)) & 0x0F);
                byte cw  = Encode(nib);
                buf.Append(Convert.ToString(cw, 2).PadLeft(8, '0'));
            }
        }
        return buf.ToString();
    }

    // Hamming bound: sum C(n,i) i=0..t  vs  2^(n-k)
    public static (long lhs, long bound) HammingBound(int n, int k, int t)
    {
        long total = 0;
        for (int i = 0; i <= t; i++) { long b = 1; for (int j = 0; j < i; j++) { b *= (n - j); b /= (j + 1); } total += b; }
        return (total, 1L << (n - k));
    }
}
