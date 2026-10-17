using System.Text;
namespace HammingApp;

public static partial class HammingCodec
{
    public static string DecodeText(string bitString, out string decodeLog)
    {
        var text = new StringBuilder();
        var log  = new StringBuilder();
        int numChars = bitString.Length / 32;
        for (int ci = 0; ci < numChars; ci++)
        {
            ushort code = 0;
            for (int ni = 0; ni < 4; ni++)
            {
                string slice = bitString.Substring(ci * 32 + ni * 8, 8);
                byte cw = Convert.ToByte(slice, 2);
                byte nib = Decode(cw, out int ec, out int ep);
                code = (ushort)((code << 4) | nib);
                int idx = ci * 4 + ni + 1;
                log.AppendLine($"КК #{idx:D2} [{slice}]  синдром={Syndrome(cw)}");
                if (ec == 0) log.AppendLine("  Ошибок нет.");
                else if (ec == 1) log.AppendLine($"  Одна ошибка, бит #{ep + 1} исправлен.");
                else log.AppendLine($"  {ec} ошибки — исправление невозможно.");
            }
            text.Append((char)code);
        }
        decodeLog = log.ToString();
        return text.ToString();
    }
}
