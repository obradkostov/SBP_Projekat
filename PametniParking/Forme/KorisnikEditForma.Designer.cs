namespace PametniParking.Forme
{
    partial class KorisnikEditForma
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlFizickoLice = new System.Windows.Forms.Panel();
            this.txtJmbg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlPravnoLice = new System.Windows.Forms.Panel();
            this.txtSediste = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtKontaktOsoba = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaticniBroj = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPib = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.cmbStatusNaloga = new System.Windows.Forms.ComboBox();
            this.pnlFizickoLice.SuspendLayout();
            this.pnlPravnoLice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tip korisnika:";
            // 
            // cmbTip
            // 
            this.cmbTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Location = new System.Drawing.Point(210, 18);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(180, 21);
            this.cmbTip.TabIndex = 1;
            this.cmbTip.SelectedIndexChanged += new System.EventHandler(this.cmbTip_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(210, 53);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Adresa:";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(210, 88);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(180, 20);
            this.txtAdresa.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(20, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Status naloga:";
            // 
            // pnlFizickoLice
            // 
            this.pnlFizickoLice.Controls.Add(this.txtJmbg);
            this.pnlFizickoLice.Controls.Add(this.label7);
            this.pnlFizickoLice.Controls.Add(this.txtPrezime);
            this.pnlFizickoLice.Controls.Add(this.label6);
            this.pnlFizickoLice.Controls.Add(this.txtIme);
            this.pnlFizickoLice.Controls.Add(this.label5);
            this.pnlFizickoLice.Location = new System.Drawing.Point(15, 160);
            this.pnlFizickoLice.Name = "pnlFizickoLice";
            this.pnlFizickoLice.Size = new System.Drawing.Size(390, 110);
            this.pnlFizickoLice.TabIndex = 8;
            // 
            // txtJmbg
            // 
            this.txtJmbg.Location = new System.Drawing.Point(190, 70);
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.Size = new System.Drawing.Size(180, 20);
            this.txtJmbg.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "JMBG:";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(190, 40);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(180, 20);
            this.txtPrezime.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Prezime:";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(190, 10);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(180, 20);
            this.txtIme.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ime:";
            // 
            // pnlPravnoLice
            // 
            this.pnlPravnoLice.Controls.Add(this.txtSediste);
            this.pnlPravnoLice.Controls.Add(this.label12);
            this.pnlPravnoLice.Controls.Add(this.txtKontaktOsoba);
            this.pnlPravnoLice.Controls.Add(this.label11);
            this.pnlPravnoLice.Controls.Add(this.txtMaticniBroj);
            this.pnlPravnoLice.Controls.Add(this.label10);
            this.pnlPravnoLice.Controls.Add(this.txtPib);
            this.pnlPravnoLice.Controls.Add(this.label9);
            this.pnlPravnoLice.Controls.Add(this.txtNaziv);
            this.pnlPravnoLice.Controls.Add(this.label8);
            this.pnlPravnoLice.Location = new System.Drawing.Point(15, 160);
            this.pnlPravnoLice.Name = "pnlPravnoLice";
            this.pnlPravnoLice.Size = new System.Drawing.Size(390, 175);
            this.pnlPravnoLice.TabIndex = 9;
            // 
            // txtSediste
            // 
            this.txtSediste.Location = new System.Drawing.Point(190, 130);
            this.txtSediste.Name = "txtSediste";
            this.txtSediste.Size = new System.Drawing.Size(180, 20);
            this.txtSediste.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Sedište:";
            // 
            // txtKontaktOsoba
            // 
            this.txtKontaktOsoba.Location = new System.Drawing.Point(190, 100);
            this.txtKontaktOsoba.Name = "txtKontaktOsoba";
            this.txtKontaktOsoba.Size = new System.Drawing.Size(180, 20);
            this.txtKontaktOsoba.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Kontakt osoba:";
            // 
            // txtMaticniBroj
            // 
            this.txtMaticniBroj.Location = new System.Drawing.Point(190, 70);
            this.txtMaticniBroj.Name = "txtMaticniBroj";
            this.txtMaticniBroj.Size = new System.Drawing.Size(180, 20);
            this.txtMaticniBroj.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Matični broj:";
            // 
            // txtPib
            // 
            this.txtPib.Location = new System.Drawing.Point(190, 40);
            this.txtPib.Name = "txtPib";
            this.txtPib.Size = new System.Drawing.Size(180, 20);
            this.txtPib.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "PIB:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(190, 10);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(180, 20);
            this.txtNaziv.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Naziv:";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSacuvaj.Location = new System.Drawing.Point(20, 350);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(180, 45);
            this.btnSacuvaj.TabIndex = 10;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            this.btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOtkazi.Location = new System.Drawing.Point(215, 350);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(180, 45);
            this.btnOtkazi.TabIndex = 11;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = false;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // cmbStatusNaloga
            // 
            this.cmbStatusNaloga.FormattingEnabled = true;
            this.cmbStatusNaloga.Items.AddRange(new object[] {
            "AKTIVAN",
            "BLOKIRAN",
            "NEVERIFIKOVAN"});
            this.cmbStatusNaloga.Location = new System.Drawing.Point(210, 121);
            this.cmbStatusNaloga.Name = "cmbStatusNaloga";
            this.cmbStatusNaloga.Size = new System.Drawing.Size(180, 21);
            this.cmbStatusNaloga.TabIndex = 12;
            // 
            // KorisnikEditForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(420, 410);
            this.Controls.Add(this.cmbStatusNaloga);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.pnlPravnoLice);
            this.Controls.Add(this.pnlFizickoLice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.label1);
            this.Name = "KorisnikEditForma";
            this.Text = "KorisnikEdit";
            this.Load += new System.EventHandler(this.KorisnikEditForma_Load);
            this.pnlFizickoLice.ResumeLayout(false);
            this.pnlFizickoLice.PerformLayout();
            this.pnlPravnoLice.ResumeLayout(false);
            this.pnlPravnoLice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlFizickoLice;
        private System.Windows.Forms.TextBox txtJmbg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlPravnoLice;
        private System.Windows.Forms.TextBox txtSediste;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtKontaktOsoba;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaticniBroj;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPib;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOtkazi;
        private System.Windows.Forms.ComboBox cmbStatusNaloga;
    }
}