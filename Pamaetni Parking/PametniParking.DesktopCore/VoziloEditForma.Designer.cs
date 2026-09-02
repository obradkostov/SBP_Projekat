namespace PametniParking.DesktopCore
{
    partial class VoziloEditForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label label1, label2, label3, label4, label5, label6, label7, label8;
        private TextBox txtOznaka, txtDrzava, txtMarka, txtModel, txtTip, txtDimenzije, txtPogon;
        private CheckBox chkImaVlasnika;
        private ComboBox cmbKorisnik;
        private Button btnSacuvaj, btnOtkazi;

        private void InitializeComponent()
        {
            label1 = new Label(); txtOznaka = new TextBox();
            label2 = new Label(); txtDrzava = new TextBox();
            label3 = new Label(); txtMarka = new TextBox();
            label4 = new Label(); txtModel = new TextBox();
            label5 = new Label(); txtTip = new TextBox();
            label6 = new Label(); txtDimenzije = new TextBox();
            label7 = new Label(); txtPogon = new TextBox();
            label8 = new Label(); chkImaVlasnika = new CheckBox(); cmbKorisnik = new ComboBox();
            btnSacuvaj = new Button(); btnOtkazi = new Button();
            SuspendLayout();

            label1.Text = "Registarska oznaka:"; label1.Location = new System.Drawing.Point(20, 20); label1.AutoSize = true;
            txtOznaka.Location = new System.Drawing.Point(200, 18); txtOznaka.Size = new System.Drawing.Size(160, 20);

            label2.Text = "Država registracije:"; label2.Location = new System.Drawing.Point(20, 55); label2.AutoSize = true;
            txtDrzava.Location = new System.Drawing.Point(200, 53); txtDrzava.Size = new System.Drawing.Size(160, 20);

            label3.Text = "Marka:"; label3.Location = new System.Drawing.Point(20, 90); label3.AutoSize = true;
            txtMarka.Location = new System.Drawing.Point(200, 88); txtMarka.Size = new System.Drawing.Size(160, 20);

            label4.Text = "Model:"; label4.Location = new System.Drawing.Point(20, 125); label4.AutoSize = true;
            txtModel.Location = new System.Drawing.Point(200, 123); txtModel.Size = new System.Drawing.Size(160, 20);

            label5.Text = "Tip vozila:"; label5.Location = new System.Drawing.Point(20, 160); label5.AutoSize = true;
            txtTip.Location = new System.Drawing.Point(200, 158); txtTip.Size = new System.Drawing.Size(160, 20);

            label6.Text = "Dimenzije:"; label6.Location = new System.Drawing.Point(20, 195); label6.AutoSize = true;
            txtDimenzije.Location = new System.Drawing.Point(200, 193); txtDimenzije.Size = new System.Drawing.Size(160, 20);

            label7.Text = "Pogon:"; label7.Location = new System.Drawing.Point(20, 230); label7.AutoSize = true;
            txtPogon.Location = new System.Drawing.Point(200, 228); txtPogon.Size = new System.Drawing.Size(160, 20);

            label8.Text = "Vlasnik:"; label8.Location = new System.Drawing.Point(20, 265); label8.AutoSize = true;
            chkImaVlasnika.Text = "Ima vlasnika"; chkImaVlasnika.Location = new System.Drawing.Point(200, 263); chkImaVlasnika.AutoSize = true;
            cmbKorisnik.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKorisnik.Location = new System.Drawing.Point(200, 288); cmbKorisnik.Size = new System.Drawing.Size(160, 21);

            btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnSacuvaj.Location = new System.Drawing.Point(20, 330); btnSacuvaj.Size = new System.Drawing.Size(160, 45);
            btnSacuvaj.Text = "Sačuvaj"; btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += new EventHandler(btnSacuvaj_Click);

            btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnOtkazi.Location = new System.Drawing.Point(200, 330); btnOtkazi.Size = new System.Drawing.Size(160, 45);
            btnOtkazi.Text = "Otkaži"; btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += new EventHandler(btnOtkazi_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(392, 400);
            Controls.Add(btnOtkazi); Controls.Add(btnSacuvaj);
            Controls.Add(cmbKorisnik); Controls.Add(chkImaVlasnika); Controls.Add(label8);
            Controls.Add(txtPogon); Controls.Add(label7);
            Controls.Add(txtDimenzije); Controls.Add(label6);
            Controls.Add(txtTip); Controls.Add(label5);
            Controls.Add(txtModel); Controls.Add(label4);
            Controls.Add(txtMarka); Controls.Add(label3);
            Controls.Add(txtDrzava); Controls.Add(label2);
            Controls.Add(txtOznaka); Controls.Add(label1);
            Name = "VoziloEditForma";
            Text = "VoziloEdit";
            Load += new EventHandler(VoziloEditForma_Load);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}