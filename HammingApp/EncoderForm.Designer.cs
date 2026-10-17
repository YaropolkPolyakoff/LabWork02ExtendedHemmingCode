namespace HammingApp;

partial class EncoderForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        labelInput       = new Label();
        inputTextBox     = new TextBox();
        encodeButton     = new Button();
        labelOutput      = new Label();
        outputBitsBox    = new TextBox();
        sendButton       = new Button();
        clearButton      = new Button();
        matrixBox        = new RichTextBox();
        labelBound       = new Label();
        SuspendLayout();

        // labelInput
        labelInput.Text      = "Исходное сообщение (Unicode):";
        labelInput.Location  = new Point(12, 14);
        labelInput.Size      = new Size(300, 20);

        // inputTextBox
        inputTextBox.Location = new Point(12, 38);
        inputTextBox.Size     = new Size(760, 24);
        inputTextBox.Font     = new Font("Consolas", 10F);

        // encodeButton
        encodeButton.Text     = "Кодировать";
        encodeButton.Location = new Point(12, 74);
        encodeButton.Size     = new Size(130, 30);
        encodeButton.Click   += encodeButton_Click;

        // clearButton
        clearButton.Text     = "Очистить";
        clearButton.Location = new Point(152, 74);
        clearButton.Size     = new Size(100, 30);
        clearButton.Click   += clearButton_Click;

        // labelOutput
        labelOutput.Text     = "Закодированные биты (32 бит/символ):";
        labelOutput.Location = new Point(12, 118);
        labelOutput.Size     = new Size(400, 20);

        // outputBitsBox
        outputBitsBox.Location   = new Point(12, 142);
        outputBitsBox.Size       = new Size(760, 160);
        outputBitsBox.Multiline  = true;
        outputBitsBox.ScrollBars = ScrollBars.Both;
        outputBitsBox.Font       = new Font("Consolas", 9F);
        outputBitsBox.ReadOnly   = true;
        outputBitsBox.WordWrap   = false;

        // sendButton
        sendButton.Text     = "Передать в декодер →";
        sendButton.Location = new Point(12, 314);
        sendButton.Size     = new Size(200, 30);
        sendButton.Click   += sendButton_Click;

        // matrixBox
        matrixBox.Location   = new Point(12, 360);
        matrixBox.Size       = new Size(760, 200);
        matrixBox.Font       = new Font("Consolas", 9F);
        matrixBox.ReadOnly   = true;
        matrixBox.BackColor  = SystemColors.Control;

        // labelBound
        labelBound.Text     = "Граница Хэмминга: —";
        labelBound.Location = new Point(12, 572);
        labelBound.Size     = new Size(760, 22);
        labelBound.Font     = new Font("Segoe UI", 9F, FontStyle.Bold);

        // EncoderForm
        ClientSize  = new Size(800, 610);
        Text        = "Кодер — Расширенный код Хэмминга (8,4), вариант 70";
        MinimumSize = new Size(820, 660);
        Controls.AddRange(new Control[] {
            labelInput, inputTextBox, encodeButton, clearButton,
            labelOutput, outputBitsBox, sendButton,
            matrixBox, labelBound
        });
        ResumeLayout(false);
        PerformLayout();
    }

    private Label      labelInput;
    private TextBox    inputTextBox;
    private Button     encodeButton;
    private Button     clearButton;
    private Label      labelOutput;
    private TextBox    outputBitsBox;
    private Button     sendButton;
    private RichTextBox matrixBox;
    private Label      labelBound;
}
