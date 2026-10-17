namespace HammingApp;

public partial class EncoderForm : Form
{
    private DecoderForm? _decoderForm;

    public EncoderForm()
    {
        InitializeComponent();
        ShowMatricesAndBound();
    }

    private void ShowMatricesAndBound()
    {
        matrixBox.Clear();
        matrixBox.AppendText(HammingCodec.MatrixString(HammingCodec.G, "G (порождающая)"));
        matrixBox.AppendText(Environment.NewLine);
        matrixBox.AppendText(HammingCodec.MatrixString(HammingCodec.H, "H (проверочная)"));

        var (lhs, bound) = HammingCodec.HammingBound(8, 4, 1);
        labelBound.Text =
            $"Граница Хэмминга: Σ C(8,i), i=0..1 = {lhs}  ≤  2^(8-4) = {bound}  → " +
            (lhs <= bound ? "условие выполнено ✓" : "условие нарушено ✗");
    }

    private void encodeButton_Click(object sender, EventArgs e)
    {
        string input = inputTextBox.Text;
        if (string.IsNullOrEmpty(input))
        {
            MessageBox.Show("Введите исходное сообщение.", "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            string bits = HammingCodec.EncodeText(input);
            outputBitsBox.Text = bits;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка кодирования: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void clearButton_Click(object sender, EventArgs e)
    {
        inputTextBox.Clear();
        outputBitsBox.Clear();
    }

    private void sendButton_Click(object sender, EventArgs e)
    {
        string bits = outputBitsBox.Text;
        if (string.IsNullOrEmpty(bits))
        { MessageBox.Show("Сначала закодируйте сообщение.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

        if (_decoderForm == null || _decoderForm.IsDisposed)
            _decoderForm = new DecoderForm();
        _decoderForm.LoadBits(bits);
        _decoderForm.Show();
        _decoderForm.BringToFront();
    }
}
