namespace HammingApp;

public static partial class HammingCodec
{
    // Decode an 8-bit codeword, correct single-bit error when possible.
    // errCount: 0=none, 1=corrected, 2=two errors, 3=three errors.
    // errPos: 0-based bit position or -1.
    public static byte Decode(byte codewordByte, out int errCount, out int errPos)
    {
        int[] c = ToBits(codewordByte, 8);
        int[] syndrome = new int[4];
        for (int i = 0; i < 4; i++)
        {
            int total = 0;
            for (int j = 0; j < 8; j++) total += H[i][j] * c[j];
            syndrome[i] = total % 2;
        }

        bool upperClear = (syndrome[0] + syndrome[1] + syndrome[2]) == 0;
        bool lowerSet   = syndrome[3] == 1;

        if (upperClear && !lowerSet)
        {
            errCount = 0; errPos = -1;
        }
        else if (!upperClear && lowerSet)
        {
            errPos = -1;
            for (int j = 0; j < 8; j++)
                if (H[0][j] == syndrome[0] && H[1][j] == syndrome[1] && H[2][j] == syndrome[2])
                { errPos = j; break; }
            if (errPos >= 0) codewordByte ^= (byte)(1 << (7 - errPos));
            errCount = 1;
        }
        else if (upperClear)
        { errCount = 1; errPos = 7; codewordByte ^= 0x01; }
        else
        { int wt = syndrome[0]+syndrome[1]+syndrome[2]+syndrome[3]; errCount = wt >= 3 ? 3 : 2; errPos = -1; }

        return (byte)((codewordByte >> 4) & 0x0F);
    }
}
