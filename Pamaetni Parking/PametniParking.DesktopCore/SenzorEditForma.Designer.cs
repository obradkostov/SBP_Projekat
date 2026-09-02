namespace PametniParking.DesktopCore
{
    partial class SenzorEditForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label label1, label2, label3, label4, label5, label6, label7;
        private ComboBox cmbMesto, cmbTip;
        private TextBox txtProizvodjac, txtModel, txtSerijskiBroj, txtStatus;
        private DateTimePicker dtpDatum;
        private Panel pnlVideo;
        private TextBox txtRezolucija, txtUgao;
        private CheckBox chkPrepoznavanje;
        private Button btnSacuvaj, btnOtkazi;

        private void InitializeComponent()
        {
            label1 = new Label(); cmbMesto = new ComboBox();
            label2 = new Label(); txtProizvodjac = new TextBox();
            label3 = new Label(); txtModel = new TextBox();
            label4 = new Label(); txtSerijskiBroj = new TextBox();
            label5 = new Label(); dtpDatum = new DateTimePicker();
            label6 = new Label(); txtStatus = new TextBox();
            label7 = new Label(); cmbTip = new ComboBox();
            pnlVideo = new Panel();
            txtRezolucija = new TextBox(); txtUgao = new TextBox(); chkPrepoznavanje = new CheckBox();
            btnSacuvaj = new Button(); btnOtkazi = new Button();
            pnlVideo.SuspendLayout();
            SuspendLayout();

            label1.Text = "Parking mesto:"; label1.Location = new System.Drawing.Point(20, 20); label1.AutoSize = true;
            cmbMesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMesto.Location = new System.Drawing.Point(200, 18); cmbMesto.Size = new System.Drawing.Size(180, 21);

            label2.Text = "Proizvođač:"; label2.Location = new System.Drawing.Point(20, 55); label2.AutoSize = true;
            txtProizvodjac.Location = new System.Drawing.Point(200, 53); txtProizvodjac.Size = new System.Drawing.Size(180, 20);

            label3.Text = "Model:"; label3.Location = new System.Drawing.Point(20, 90); label3.AutoSize = true;
            txtModel.Location = new System.Drawing.Point(200, 88); txtModel.Size = new System.Drawing.Size(180, 20);

            label4.Text = "Serijski broj:"; label4.Location = new System.Drawing.Point(20, 125); label4.AutoSize = true;
            txtSerijskiBroj.Location = new System.Drawing.Point(200, 123); txtSerijskiBroj.Size = new System.Drawing.Size(180, 20);

            label5.Text = "Datum instalacije:"; label5.Location = new System.Drawing.Point(20, 160); label5.AutoSize = true;
            dtpDatum.Location = new System.Drawing.Point(200, 158); dtpDatum.Size = new System.Drawing.Size(180, 20);

            label6.Text = "Status:"; label6.Location = new System.Drawing.Point(20, 195); label6.AutoSize = true;
            txtStatus.Location = new System.Drawing.Point(200, 193); txtStatus.Size = new System.Drawing.Size(180, 20);

            label7.Text = "Tip senzora:"; label7.Location = new System.Drawing.Point(20, 230); label7.AutoSize = true;
            cmbTip.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTip.Location = new System.Drawing.Point(200, 228); cmbTip.Size = new System.Drawing.Size(180, 21);
            cmbTip.SelectedIndexChanged += new EventHandler(cmbTip_SelectedIndexChanged);

            Label lblVideo = new() { Text = "Dodatni podaci (video senzor)", Location = new System.Drawing.Point(5, 0), AutoSize = true };
            Label lblRez = new() { Text = "Rezolucija:", Location = new System.Drawing.Point(5, 23), AutoSize = true };
            txtRezolucija.Location = new System.Drawing.Point(185, 20); txtRezolucija.Size = new System.Drawing.Size(180, 20);
            Label lblUgao = new() { Text = "Ugao pokrivanja:", Location = new System.Drawing.Point(5, 53), AutoSize = true };
            txtUgao.Location = new System.Drawing.Point(185, 50); txtUgao.Size = new System.Drawing.Size(180, 20);
            chkPrepoznavanje.Text = "Prepoznavanje registarskih oznaka";
            chkPrepoznavanje.Location = new System.Drawing.Point(5, 82); chkPrepoznavanje.AutoSize = true;
            pnlVideo.Controls.Add(lblVideo); pnlVideo.Controls.Add(lblRez); pnlVideo.Controls.Add(txtRezolucija);
            pnlVideo.Controls.Add(lblUgao); pnlVideo.Controls.Add(txtUgao); pnlVideo.Controls.Add(chkPrepoznavanje);
            pnlVideo.Location = new System.Drawing.Point(15, 260); pnlVideo.Size = new System.Drawing.Size(370, 115);

            btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnSacuvaj.Location = new System.Drawing.Point(20, 385); btnSacuvaj.Size = new System.Drawing.Size(175, 45);
            btnSacuvaj.Text = "Sačuvaj"; btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += new EventHandler(btnSacuvaj_Click);

            btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnOtkazi.Location = new System.Drawing.Point(205, 385); btnOtkazi.Size = new System.Drawing.Size(175, 45);
            btnOtkazi.Text = "Otkaži"; btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += new EventHandler(btnOtkazi_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(410, 445);
            Controls.Add(btnOtkazi); Controls.Add(btnSacuvaj);
            Controls.Add(pnlVideo);
            Controls.Add(cmbTip); Controls.Add(label7);
            Controls.Add(txtStatus); Controls.Add(label6);
            Controls.Add(dtpDatum); Controls.Add(label5);
            Controls.Add(txtSerijskiBroj); Controls.Add(label4);
            Controls.Add(txtModel); Controls.Add(label3);
            Controls.Add(txtProizvodjac); Controls.Add(label2);
            Controls.Add(cmbMesto); Controls.Add(label1);
            Name = "SenzorEditForma";
            Text = "SenzorEdit";
            Load += new EventHandler(SenzorEditForma_Load);
            pnlVideo.ResumeLayout(false); pnlVideo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}