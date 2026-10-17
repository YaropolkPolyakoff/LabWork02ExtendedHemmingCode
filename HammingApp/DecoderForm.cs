namespace HammingApp;

public partial class DecoderForm : Form
{
    public DecoderForm()
    {
        InitializeComponent();
    }

    // Called by EncoderForm to load bits into the editable field
    public void LoadBits(string bits)
    {
        receivedBitsBox.Text = bits;
        logBox.Clear();
        decodedTextLabel.Text = "";
    }

    private void decodeButton_Click(object sender, EventArgs e)
    {
        string bits = receivedBitsBox.Text.Trim();

        if (string.IsNullOrEmpty(bits))
        {
            MessageBox.Show("Нет данных для декодирования.", "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Validate: only '0' and '1'
        foreach (char ch in bits)
        {
            if (ch != '0' && ch != '1')
            {
                MessageBox.Show("Поле содержит недопустимые символы. Разрешены только '0' и '1'.",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        if (bits.Length % 32 != 0)
        {
            MessageBox.Show($"Длина битовой строки ({bits.Length}) должна быть кратна 32.",
                "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            string decoded = HammingCodec.DecodeText(bits, out string log);
            decodedTextLabel.Text = decoded;

            logBox.Clear();
            logBox.AppendText(log);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка декодирования: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void clearLogButton_Click(object sender, EventArgs e)
    {
        logBox.Clear();
        decodedTextLabel.Text = "";
    }
}
