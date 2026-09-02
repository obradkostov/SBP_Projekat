namespace PametniParking.DesktopCore
{
    partial class PretplatnaKartaEditForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label label1, label2, label3, label4, label5, label6, label7;
        private ComboBox cmbKorisnik;
        private TextBox txtTipPretplate, txtCena, txtMaksBrVozila;
        private DateTimePicker dtpPocetak, dtpKraj;
        private CheckedListBox clbZone;
        private Button btnSacuvaj, btnOtkazi;

        private void InitializeComponent()
        {
            label1 = new Label(); cmbKorisnik = new ComboBox();
            label2 = new Label(); txtTipPretplate = new TextBox();
            label3 = new Label(); dtpPocetak = new DateTimePicker();
            label4 = new Label(); dtpKraj = new DateTimePicker();
            label5 = new Label(); txtCena = new TextBox();
            label6 = new Label(); txtMaksBrVozila = new TextBox();
            label7 = new Label(); clbZone = new CheckedListBox();
            btnSacuvaj = new Button(); btnOtkazi = new Button();
            SuspendLayout();

            label1.Text = "Korisnik:"; label1.Location = new System.Drawing.Point(20, 20); label1.AutoSize = true;
            cmbKorisnik.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKorisnik.Location = new System.Drawing.Point(210, 18); cmbKorisnik.Size = new System.Drawing.Size(190, 21);

            label2.Text = "Tip pretplate:"; label2.Location = new System.Drawing.Point(20, 55); label2.AutoSize = true;
            txtTipPretplate.Location = new System.Drawing.Point(210, 53); txtTipPretplate.Size = new System.Drawing.Size(190, 20);

            label3.Text = "Početak važenja:"; label3.Location = new System.Drawing.Point(20, 90); label3.AutoSize = true;
            dtpPocetak.Location = new System.Drawing.Point(210, 88); dtpPocetak.Size = new System.Drawing.Size(190, 20);

            label4.Text = "Kraj važenja:"; label4.Location = new System.Drawing.Point(20, 125); label4.AutoSize = true;
            dtpKraj.Location = new System.Drawing.Point(210, 123); dtpKraj.Size = new System.Drawing.Size(190, 20);

            label5.Text = "Cena:"; label5.Location = new System.Drawing.Point(20, 160); label5.AutoSize = true;
            txtCena.Location = new System.Drawing.Point(210, 158); txtCena.Size = new System.Drawing.Size(190, 20);

            label6.Text = "Maks. broj vozila:"; label6.Location = new System.Drawing.Point(20, 195); label6.AutoSize = true;
            txtMaksBrVozila.Location = new System.Drawing.Point(210, 193); txtMaksBrVozila.Size = new System.Drawing.Size(190, 20);

            label7.Text = "Zone u kojima važi:"; label7.Location = new System.Drawing.Point(20, 230); label7.AutoSize = true;
            clbZone.Location = new System.Drawing.Point(20, 255); clbZone.Size = new System.Drawing.Size(380, 100);
            clbZone.CheckOnClick = true;

            btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnSacuvaj.Location = new System.Drawing.Point(20, 370); btnSacuvaj.Size = new System.Drawing.Size(185, 45);
            btnSacuvaj.Text = "Sačuvaj"; btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += new EventHandler(btnSacuvaj_Click);

            btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnOtkazi.Location = new System.Drawing.Point(215, 370); btnOtkazi.Size = new System.Drawing.Size(185, 45);
            btnOtkazi.Text = "Otkaži"; btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += new EventHandler(btnOtkazi_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(420, 435);
            Controls.Add(btnOtkazi); Controls.Add(btnSacuvaj);
            Controls.Add(clbZone); Controls.Add(label7);
            Controls.Add(txtMaksBrVozila); Controls.Add(label6);
            Controls.Add(txtCena); Controls.Add(label5);
            Controls.Add(dtpKraj); Controls.Add(label4);
            Controls.Add(dtpPocetak); Controls.Add(label3);
            Controls.Add(txtTipPretplate); Controls.Add(label2);
            Controls.Add(cmbKorisnik); Controls.Add(label1);
            Name = "PretplatnaKartaEditForma";
            Text = "PretplatnaKartaEdit";
            Load += new EventHandler(PretplatnaKartaEditForma_Load);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}