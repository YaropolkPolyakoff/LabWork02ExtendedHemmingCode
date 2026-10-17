namespace HammingApp;

public static partial class HammingCodec
{
    public static byte Encode(byte nibble)
    {
        int[] d = ToBits(nibble, 4);
        byte r = 0;
        for (int col = 0; col < 8; col++)
        {
            int bit = 0;
            for (int row = 0; row < 4; row++)
                bit ^= (d[row] & G[row][col]);
            r = (byte)((r << 1) | (bit & 1));
        }
        return r;
    }
}
