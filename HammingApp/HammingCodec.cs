namespace HammingApp;

// Extended Hamming (8,4) variant 70 — matrices
public static partial class HammingCodec
{
    // Parity-check matrix H, 4 rows x 8 columns
    // Variant 70:
    //   row 0:  1 1 1 1 1 1 1 1  (overall parity)
    //   row 1:  0 1 1 0 1 1 0 0
    //   row 2:  0 1 0 1 1 0 1 0
    //   row 3:  0 0 1 1 1 0 0 1
    public static readonly int[][] H =
    {
        new[] { 1, 1, 1, 1, 1, 1, 1, 1 },
        new[] { 0, 1, 1, 0, 1, 1, 0, 0 },
        new[] { 0, 1, 0, 1, 1, 0, 1, 0 },
        new[] { 0, 0, 1, 1, 1, 0, 0, 1 },
    };

    // Generator matrix G, 4 rows x 8 columns  —  G * H^T = 0 (mod 2)
    // Basis codewords of the null-space of H over GF(2).
    // Each row g verified: H·g^T = 0 (mod 2).
    //
    // g0=(1,0,1,0,0,1,0,1): R0=4→0, R1=2→0, R2=0→0, R3=2→0
    // g1=(0,1,1,0,0,0,1,1): R0=4→0, R1=2→0, R2=2→0, R3=2→0
    // g2=(1,1,0,0,1,0,0,1): R0=4→0, R1=2→0, R2=2→0, R3=2→0
    // g3=(0,1,0,1,0,1,0,1): R0=4→0, R1=2→0, R2=2→0, R3=2→0
    public static readonly int[][] G =
    {
        new[] { 1, 0, 1, 0, 0, 1, 0, 1 },
        new[] { 0, 1, 1, 0, 0, 0, 1, 1 },
        new[] { 1, 1, 0, 0, 1, 0, 0, 1 },
        new[] { 0, 1, 0, 1, 0, 1, 0, 1 },
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
