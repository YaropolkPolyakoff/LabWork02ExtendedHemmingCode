namespace HammingApp;

public static partial class HammingCodec
{
    // Returns 4-digit binary syndrome string for a given codeword byte
    public static string Syndrome(byte codewordByte)
    {
        int[] bits = ToBits(codewordByte, 8);
        char[] digits = new char[4];
        for (int rowIdx = 0; rowIdx < 4; rowIdx++)
        {
            int total = 0;
            for (int colIdx = 0; colIdx < 8; colIdx++)
                total += H[rowIdx][colIdx] * bits[colIdx];
            digits[rowIdx] = total % 2 == 0 ? '0' : '1';
        }
        return new string(digits);
    }
}
