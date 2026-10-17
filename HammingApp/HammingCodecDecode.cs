namespace HammingApp;

public static partial class HammingCodec
{
    // Decode an 8-bit codeword, correct single-bit error when possible.
    // errCount: 0=none, 1=corrected, 2=double-bit error (uncorrectable).
    // errPos: 0-based bit position or -1.
    //
    // Extended Hamming (8,4) error detection/correction rules
    // with H row-0 = all-ones (overall parity):
    //   s = H·c^T mod 2
    //   s = 0000           → no error
    //   s[0]=1             → single-bit error, locate by matching H column
    //   s[0]=0, s[1..3]≠0  → double-bit error (detectable, not correctable)
    public static byte Decode(byte codewordByte, out int errCount, out int errPos)
    {
        int[] c = ToBits(codewordByte, 8);

        // Compute syndrome s = H·c^T  (mod 2)
        int[] s = new int[4];
        for (int i = 0; i < 4; i++)
        {
            int total = 0;
            for (int j = 0; j < 8; j++) total += H[i][j] * c[j];
            s[i] = total % 2;
        }

        // s[0]: overall-parity bit (H row 0 = all 1s)
        // s[1..3]: positional syndrome
        bool overallParity  = s[0] == 1;
        bool positionalZero = (s[1] | s[2] | s[3]) == 0;

        if (!overallParity && positionalZero)
        {
            // syndrome = 0000 → no error
            errCount = 0; errPos = -1;
        }
        else if (overallParity)
        {
            // Single-bit error: find the column of H whose entries equal the syndrome
            errPos = -1;
            for (int j = 0; j < 8; j++)
            {
                if (H[0][j] == s[0] && H[1][j] == s[1] && H[2][j] == s[2] && H[3][j] == s[3])
                {
                    errPos = j;
                    break;
                }
            }
            if (errPos >= 0)
                codewordByte ^= (byte)(1 << (7 - errPos));
            errCount = 1;
        }
        else
        {
            // s[0]=0 but positional syndrome ≠ 0 → double-bit error
            errCount = 2; errPos = -1;
        }

        // Recover the data nibble from the (possibly corrected) codeword.
        // G is non-systematic so data bits are not simply the top nibble;
        // we search all 16 encodings for a match.
        return ExtractNibble(codewordByte);
    }

    // Find the 4-bit data value whose Encode() output matches codewordByte.
    // Returns 0 as a safe fallback when no valid codeword is found
    // (only occurs for double-bit errors, where correction is not attempted).
    private static byte ExtractNibble(byte codewordByte)
    {
        for (byte nib = 0; nib < 16; nib++)
        {
            if (Encode(nib) == codewordByte)
                return nib;
        }
        // Fallback for uncorrectable errors: return top nibble
        return (byte)((codewordByte >> 4) & 0x0F);
    }
}
