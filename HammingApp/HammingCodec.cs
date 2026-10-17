namespace HammingApp;

// Extended Hamming (8,4) variant 70 — matrices
public static partial class HammingCodec
{
    // Parity-check matrix H, 4 rows x 8 columns
    public static readonly int[][] H =
    {
        new[] { 1, 1, 0, 1, 1, 0, 0, 0 },
        new[] { 0, 1, 1, 1, 0, 1, 0, 0 },
        new[] { 1, 1, 1, 0, 0, 0, 1, 0 },
        new[] { 1, 1, 1, 1, 1, 1, 1, 1 },
    };

    // Generator matrix G, 4 rows x 8 columns  —  G * H^T = 0 (mod 2)
    public static readonly int[][] G =
    {
        new[] { 1, 0, 0, 0, 1, 0, 1, 1 },
        new[] { 0, 1, 0, 0, 1, 1, 1, 0 },
        new[] { 0, 0, 1, 0, 0, 1, 1, 1 },
        new[] { 0, 0, 0, 1, 1, 1, 0, 1 },
    };

    // Unpack byte value into a bit array (MSB first)
    public static int[] ToBits(byte value, int length)
    {
        int[] bits = new int[length];
        for (int i = 0; i < length; i++)
            bits[i] = (value >> (length - 1 - i)) & 1;
        return bits;
    }
}
