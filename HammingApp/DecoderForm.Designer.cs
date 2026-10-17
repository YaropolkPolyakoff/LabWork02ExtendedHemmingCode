namespace HammingApp;

partial class DecoderForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        labelReceived    = new Label();
        receivedBitsBox  = new TextBox();
        decodeButton     = new Button();
        clearLogButton   = new Button();
        labelDecoded     = new Label();
        decodedTextLabel = new Label();
        logBox           = new RichTextBox();
        labelLog         = new Label();
        SuspendLayout();

        // labelReceived
        labelReceived.Text     = "Принятые биты (редактируйте для внесения ошибок):";
        labelReceived.Location = new Point(12, 14);
        labelReceived.Size     = new Size(500, 20);

        // receivedBitsBox
        receivedBitsBox.Location   = new Point(12, 38);
        receivedBitsBox.Size       = new Size(760, 160);
        receivedBitsBox.Multiline  = true;
        receivedBitsBox.ScrollBars = ScrollBars.Both;
        receivedBitsBox.Font       = new Font("Consolas", 9F);
        receivedBitsBox.WordWrap   = false;

        // decodeButton
        decodeButton.Text     = "Декодировать";
        decodeButton.Location = new Point(12, 210);
        decodeButton.Size     = new Size(150, 30);
        decodeButton.Click   += decodeButton_Click;

        // clearLogButton
        clearLogButton.Text     = "Очистить лог";
        clearLogButton.Location = new Point(172, 210);
        clearLogButton.Size     = new Size(130, 30);
        clearLogButton.Click   += clearLogButton_Click;

        // labelDecoded
        labelDecoded.Text     = "Восстановленный текст:";
        labelDecoded.Location = new Point(12, 256);
        labelDecoded.Size     = new Size(200, 20);
        labelDecoded.Font     = new Font("Segoe UI", 9F, FontStyle.Bold);

        // decodedTextLabel
        decodedTextLabel.Text      = "";
        decodedTextLabel.Location  = new Point(220, 256);
        decodedTextLabel.Size      = new Size(552, 24);
        decodedTextLabel.Font      = new Font("Segoe UI", 10F);
        decodedTextLabel.ForeColor = Color.DarkBlue;
        decodedTextLabel.AutoSize  = false;

        // labelLog
        labelLog.Text     = "Журнал декодера (синдромы, ошибки):";
        labelLog.Location = new Point(12, 294);
        labelLog.Size     = new Size(400, 20);

        // logBox
        logBox.Location  = new Point(12, 318);
        logBox.Size      = new Size(760, 280);
        logBox.Font      = new Font("Consolas", 8.5F);
        logBox.ReadOnly  = true;
        logBox.BackColor = Color.White;
        logBox.ScrollBars = RichTextBoxScrollBars.Both;

        // DecoderForm
        ClientSize  = new Size(800, 614);
        Text        = "Декодер — Расширенный код Хэмминга (8,4), вариант 70";
        MinimumSize = new Size(820, 660);
        Controls.AddRange(new Control[] {
            labelReceived, receivedBitsBox,
            decodeButton, clearLogButton,
            labelDecoded, decodedTextLabel,
            labelLog, logBox
        });
        ResumeLayout(false);
        PerformLayout();
    }

    private Label       labelReceived;
    private TextBox     receivedBitsBox;
    private Button      decodeButton;
    private Button      clearLogButton;
    private Label       labelDecoded;
    private Label       decodedTextLabel;
    private RichTextBox logBox;
    private Label       labelLog;
}
