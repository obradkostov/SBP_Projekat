namespace PametniParking.DesktopCore
{
    partial class DogadjajEditForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label label1, label2, label3, label4, label5, label6, label7;
        private TextBox txtRedniBroj, txtTip, txtOcitanaVrednost, txtNivoPouzdanosti, txtPotvrda;
        private ComboBox cmbSenzor;
        private DateTimePicker dtpVreme;
        private Button btnSacuvaj, btnOtkazi;

        private void InitializeComponent()
        {
            label1 = new Label(); txtRedniBroj = new TextBox();
            label2 = new Label(); cmbSenzor = new ComboBox();
            label3 = new Label(); txtTip = new TextBox();
            label4 = new Label(); dtpVreme = new DateTimePicker();
            label5 = new Label(); txtOcitanaVrednost = new TextBox();
            label6 = new Label(); txtNivoPouzdanosti = new TextBox();
            label7 = new Label(); txtPotvrda = new TextBox();
            btnSacuvaj = new Button(); btnOtkazi = new Button();
            SuspendLayout();

            label1.Text = "Redni broj:"; label1.Location = new System.Drawing.Point(20, 20); label1.AutoSize = true;
            txtRedniBroj.Location = new System.Drawing.Point(210, 18); txtRedniBroj.Size = new System.Drawing.Size(160, 20);

            label2.Text = "Senzor:"; label2.Location = new System.Drawing.Point(20, 55); label2.AutoSize = true;
            cmbSenzor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSenzor.Location = new System.Drawing.Point(210, 53); cmbSenzor.Size = new System.Drawing.Size(160, 21);

            label3.Text = "Tip događaja:"; label3.Location = new System.Drawing.Point(20, 90); label3.AutoSize = true;
            txtTip.Location = new System.Drawing.Point(210, 88); txtTip.Size = new System.Drawing.Size(160, 20);

            label4.Text = "Vreme nastanka:"; label4.Location = new System.Drawing.Point(20, 125); label4.AutoSize = true;
            dtpVreme.Format = DateTimePickerFormat.Custom; dtpVreme.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpVreme.Location = new System.Drawing.Point(210, 123); dtpVreme.Size = new System.Drawing.Size(160, 20);

            label5.Text = "Očitana vrednost:"; label5.Location = new System.Drawing.Point(20, 160); label5.AutoSize = true;
            txtOcitanaVrednost.Location = new System.Drawing.Point(210, 158); txtOcitanaVrednost.Size = new System.Drawing.Size(160, 20);

            label6.Text = "Nivo pouzdanosti:"; label6.Location = new System.Drawing.Point(20, 195); label6.AutoSize = true;
            txtNivoPouzdanosti.Location = new System.Drawing.Point(210, 193); txtNivoPouzdanosti.Size = new System.Drawing.Size(160, 20);

            label7.Text = "Potvrda:"; label7.Location = new System.Drawing.Point(20, 230); label7.AutoSize = true;
            txtPotvrda.Location = new System.Drawing.Point(210, 228); txtPotvrda.Size = new System.Drawing.Size(160, 20);

            btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnSacuvaj.Location = new System.Drawing.Point(20, 270); btnSacuvaj.Size = new System.Drawing.Size(160, 45);
            btnSacuvaj.Text = "Sačuvaj"; btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += new EventHandler(btnSacuvaj_Click);

            btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnOtkazi.Location = new System.Drawing.Point(210, 270); btnOtkazi.Size = new System.Drawing.Size(160, 45);
            btnOtkazi.Text = "Otkaži"; btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += new EventHandler(btnOtkazi_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(392, 335);
            Controls.Add(btnOtkazi); Controls.Add(btnSacuvaj);
            Controls.Add(txtPotvrda); Controls.Add(label7);
            Controls.Add(txtNivoPouzdanosti); Controls.Add(label6);
            Controls.Add(txtOcitanaVrednost); Controls.Add(label5);
            Controls.Add(dtpVreme); Controls.Add(label4);
            Controls.Add(txtTip); Controls.Add(label3);
            Controls.Add(cmbSenzor); Controls.Add(label2);
            Controls.Add(txtRedniBroj); Controls.Add(label1);
            Name = "DogadjajEditForma";
            Text = "DogadjajEdit";
            Load += new EventHandler(DogadjajEditForma_Load);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}