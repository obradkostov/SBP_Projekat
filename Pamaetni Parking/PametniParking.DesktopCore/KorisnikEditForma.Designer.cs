namespace PametniParking.DesktopCore
{
    partial class KorisnikEditForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label label1, label2, label3, label4;
        private ComboBox cmbTip;
        private TextBox txtEmail, txtAdresa, txtStatusNaloga;
        private Panel pnlFizickoLice, pnlPravnoLice;
        private TextBox txtIme, txtPrezime, txtJmbg;
        private TextBox txtNaziv, txtPib, txtMaticniBroj, txtKontaktOsoba, txtSediste;
        private Button btnSacuvaj, btnOtkazi;

        private void InitializeComponent()
        {
            label1 = new Label(); cmbTip = new ComboBox();
            label2 = new Label(); txtEmail = new TextBox();
            label3 = new Label(); txtAdresa = new TextBox();
            label4 = new Label(); txtStatusNaloga = new TextBox();
            pnlFizickoLice = new Panel();
            pnlPravnoLice = new Panel();
            txtIme = new TextBox(); txtPrezime = new TextBox(); txtJmbg = new TextBox();
            txtNaziv = new TextBox(); txtPib = new TextBox(); txtMaticniBroj = new TextBox();
            txtKontaktOsoba = new TextBox(); txtSediste = new TextBox();
            btnSacuvaj = new Button(); btnOtkazi = new Button();
            pnlFizickoLice.SuspendLayout();
            pnlPravnoLice.SuspendLayout();
            SuspendLayout();

            label1.Text = "Tip korisnika:"; label1.Location = new System.Drawing.Point(20, 20); label1.AutoSize = true;
            cmbTip.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTip.Location = new System.Drawing.Point(210, 18); cmbTip.Size = new System.Drawing.Size(180, 21);
            cmbTip.SelectedIndexChanged += new EventHandler(cmbTip_SelectedIndexChanged);

            label2.Text = "Email:"; label2.Location = new System.Drawing.Point(20, 55); label2.AutoSize = true;
            txtEmail.Location = new System.Drawing.Point(210, 53); txtEmail.Size = new System.Drawing.Size(180, 20);

            label3.Text = "Adresa:"; label3.Location = new System.Drawing.Point(20, 90); label3.AutoSize = true;
            txtAdresa.Location = new System.Drawing.Point(210, 88); txtAdresa.Size = new System.Drawing.Size(180, 20);

            label4.Text = "Status naloga:"; label4.Location = new System.Drawing.Point(20, 125); label4.AutoSize = true;
            txtStatusNaloga.Location = new System.Drawing.Point(210, 123); txtStatusNaloga.Size = new System.Drawing.Size(180, 20);

            // Fizicko lice panel
            Label lblIme = new() { Text = "Ime:", Location = new System.Drawing.Point(5, 10), AutoSize = true };
            txtIme.Location = new System.Drawing.Point(190, 8); txtIme.Size = new System.Drawing.Size(180, 20);
            Label lblPrezime = new() { Text = "Prezime:", Location = new System.Drawing.Point(5, 40), AutoSize = true };
            txtPrezime.Location = new System.Drawing.Point(190, 38); txtPrezime.Size = new System.Drawing.Size(180, 20);
            Label lblJmbg = new() { Text = "JMBG:", Location = new System.Drawing.Point(5, 70), AutoSize = true };
            txtJmbg.Location = new System.Drawing.Point(190, 68); txtJmbg.Size = new System.Drawing.Size(180, 20);
            pnlFizickoLice.Controls.Add(lblIme); pnlFizickoLice.Controls.Add(txtIme);
            pnlFizickoLice.Controls.Add(lblPrezime); pnlFizickoLice.Controls.Add(txtPrezime);
            pnlFizickoLice.Controls.Add(lblJmbg); pnlFizickoLice.Controls.Add(txtJmbg);
            pnlFizickoLice.Location = new System.Drawing.Point(15, 160); pnlFizickoLice.Size = new System.Drawing.Size(390, 110);

            // Pravno lice panel
            Label lblNaziv = new() { Text = "Naziv:", Location = new System.Drawing.Point(5, 10), AutoSize = true };
            txtNaziv.Location = new System.Drawing.Point(190, 8); txtNaziv.Size = new System.Drawing.Size(180, 20);
            Label lblPib = new() { Text = "PIB:", Location = new System.Drawing.Point(5, 40), AutoSize = true };
            txtPib.Location = new System.Drawing.Point(190, 38); txtPib.Size = new System.Drawing.Size(180, 20);
            Label lblMaticni = new() { Text = "Matični broj:", Location = new System.Drawing.Point(5, 70), AutoSize = true };
            txtMaticniBroj.Location = new System.Drawing.Point(190, 68); txtMaticniBroj.Size = new System.Drawing.Size(180, 20);
            Label lblKontakt = new() { Text = "Kontakt osoba:", Location = new System.Drawing.Point(5, 100), AutoSize = true };
            txtKontaktOsoba.Location = new System.Drawing.Point(190, 98); txtKontaktOsoba.Size = new System.Drawing.Size(180, 20);
            Label lblSediste = new() { Text = "Sedište:", Location = new System.Drawing.Point(5, 130), AutoSize = true };
            txtSediste.Location = new System.Drawing.Point(190, 128); txtSediste.Size = new System.Drawing.Size(180, 20);
            pnlPravnoLice.Controls.Add(lblNaziv); pnlPravnoLice.Controls.Add(txtNaziv);
            pnlPravnoLice.Controls.Add(lblPib); pnlPravnoLice.Controls.Add(txtPib);
            pnlPravnoLice.Controls.Add(lblMaticni); pnlPravnoLice.Controls.Add(txtMaticniBroj);
            pnlPravnoLice.Controls.Add(lblKontakt); pnlPravnoLice.Controls.Add(txtKontaktOsoba);
            pnlPravnoLice.Controls.Add(lblSediste); pnlPravnoLice.Controls.Add(txtSediste);
            pnlPravnoLice.Location = new System.Drawing.Point(15, 160); pnlPravnoLice.Size = new System.Drawing.Size(390, 175);

            btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnSacuvaj.Location = new System.Drawing.Point(20, 350); btnSacuvaj.Size = new System.Drawing.Size(180, 45);
            btnSacuvaj.Text = "Sačuvaj"; btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += new EventHandler(btnSacuvaj_Click);

            btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnOtkazi.Location = new System.Drawing.Point(215, 350); btnOtkazi.Size = new System.Drawing.Size(180, 45);
            btnOtkazi.Text = "Otkaži"; btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += new EventHandler(btnOtkazi_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(420, 410);
            Controls.Add(btnOtkazi); Controls.Add(btnSacuvaj);
            Controls.Add(pnlPravnoLice); Controls.Add(pnlFizickoLice);
            Controls.Add(txtStatusNaloga); Controls.Add(label4);
            Controls.Add(txtAdresa); Controls.Add(label3);
            Controls.Add(txtEmail); Controls.Add(label2);
            Controls.Add(cmbTip); Controls.Add(label1);
            Name = "KorisnikEditForma";
            Text = "KorisnikEdit";
            Load += new EventHandler(KorisnikEditForma_Load);
            pnlFizickoLice.ResumeLayout(false); pnlFizickoLice.PerformLayout();
            pnlPravnoLice.ResumeLayout(false); pnlPravnoLice.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}