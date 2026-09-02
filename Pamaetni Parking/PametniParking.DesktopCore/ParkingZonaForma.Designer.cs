namespace PametniParking.DesktopCore
{
    partial class ParkingZonaForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvZone = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZone)).BeginInit();
            this.SuspendLayout();

            this.dgvZone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZone.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvZone.Location = new System.Drawing.Point(0, 0);
            this.dgvZone.Name = "dgvZone";
            this.dgvZone.ReadOnly = true;
            this.dgvZone.Size = new System.Drawing.Size(800, 354);
            this.dgvZone.TabIndex = 0;

            this.btnDodaj.BackColor = System.Drawing.Color.YellowGreen;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDodaj.Location = new System.Drawing.Point(24, 379);
            this.btnDodaj.Size = new System.Drawing.Size(143, 59);
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);

            this.btnIzmeni.BackColor = System.Drawing.Color.YellowGreen;
            this.btnIzmeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnIzmeni.Location = new System.Drawing.Point(215, 379);
            this.btnIzmeni.Size = new System.Drawing.Size(143, 59);
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);

            this.btnObrisi.BackColor = System.Drawing.Color.YellowGreen;
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnObrisi.Location = new System.Drawing.Point(425, 379);
            this.btnObrisi.Size = new System.Drawing.Size(143, 59);
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);

            this.btnIzlaz.BackColor = System.Drawing.Color.YellowGreen;
            this.btnIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnIzlaz.Location = new System.Drawing.Point(626, 379);
            this.btnIzlaz.Size = new System.Drawing.Size(143, 59);
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = false;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.dgvZone);
            this.Name = "ParkingZonaForma";
            this.Text = "Parking zone";
            this.Load += new System.EventHandler(this.ParkingZonaForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZone)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvZone;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnIzlaz;
    }
}