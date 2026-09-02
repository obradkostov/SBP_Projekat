namespace PametniParking.DesktopCore
{
    partial class KorisnikForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.DataGridView dgvKorisnici;
        private System.Windows.Forms.Button btnDodaj, btnIzmeni, btnObrisi, btnIzlaz;

        private void InitializeComponent()
        {
            dgvKorisnici = new System.Windows.Forms.DataGridView();
            btnDodaj = new System.Windows.Forms.Button();
            btnIzmeni = new System.Windows.Forms.Button();
            btnObrisi = new System.Windows.Forms.Button();
            btnIzlaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(dgvKorisnici)).BeginInit();
            SuspendLayout();

            dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKorisnici.Dock = System.Windows.Forms.DockStyle.Top;
            dgvKorisnici.ReadOnly = true;
            dgvKorisnici.Size = new System.Drawing.Size(800, 354);

            btnDodaj.BackColor = System.Drawing.Color.YellowGreen;
            btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnDodaj.Location = new System.Drawing.Point(24, 379); btnDodaj.Size = new System.Drawing.Size(143, 59);
            btnDodaj.Text = "Dodaj"; btnDodaj.UseVisualStyleBackColor = false;
            btnDodaj.Click += new EventHandler(btnDodaj_Click);

            btnIzmeni.BackColor = System.Drawing.Color.YellowGreen;
            btnIzmeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnIzmeni.Location = new System.Drawing.Point(215, 379); btnIzmeni.Size = new System.Drawing.Size(143, 59);
            btnIzmeni.Text = "Izmeni"; btnIzmeni.UseVisualStyleBackColor = false;
            btnIzmeni.Click += new EventHandler(btnIzmeni_Click);

            btnObrisi.BackColor = System.Drawing.Color.YellowGreen;
            btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnObrisi.Location = new System.Drawing.Point(425, 379); btnObrisi.Size = new System.Drawing.Size(143, 59);
            btnObrisi.Text = "Obrisi"; btnObrisi.UseVisualStyleBackColor = false;
            btnObrisi.Click += new EventHandler(btnObrisi_Click);

            btnIzlaz.BackColor = System.Drawing.Color.YellowGreen;
            btnIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnIzlaz.Location = new System.Drawing.Point(626, 379); btnIzlaz.Size = new System.Drawing.Size(143, 59);
            btnIzlaz.Text = "Izlaz"; btnIzlaz.UseVisualStyleBackColor = false;
            btnIzlaz.Click += new EventHandler(btnIzlaz_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnIzlaz); Controls.Add(btnObrisi); Controls.Add(btnDodaj); Controls.Add(btnIzmeni); Controls.Add(dgvKorisnici);
            Name = "KorisnikForma";
            Text = "Korisnici";
            Load += new EventHandler(KorisnikForma_Load);
            ((System.ComponentModel.ISupportInitialize)(dgvKorisnici)).EndInit();
            ResumeLayout(false);
        }
    }
}