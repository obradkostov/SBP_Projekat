namespace PametniParking.Forme
{
    partial class ParkiranjeForma
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
            this.dgvParkiranja = new System.Windows.Forms.DataGridView();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkiranja)).BeginInit();
            this.SuspendLayout();
            //
            // dgvParkiranja
            //
            this.dgvParkiranja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParkiranja.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvParkiranja.Location = new System.Drawing.Point(0, 0);
            this.dgvParkiranja.MultiSelect = false;
            this.dgvParkiranja.Name = "dgvParkiranja";
            this.dgvParkiranja.ReadOnly = true;
            this.dgvParkiranja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParkiranja.Size = new System.Drawing.Size(800, 354);
            this.dgvParkiranja.TabIndex = 0;
            //
            // btnIzmeni
            //
            this.btnIzmeni.BackColor = System.Drawing.Color.YellowGreen;
            this.btnIzmeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnIzmeni.Location = new System.Drawing.Point(215, 379);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(143, 59);
            this.btnIzmeni.TabIndex = 2;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = false;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            //
            // btnDodaj
            //
            this.btnDodaj.BackColor = System.Drawing.Color.YellowGreen;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDodaj.Location = new System.Drawing.Point(24, 379);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(143, 59);
            this.btnDodaj.TabIndex = 3;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            //
            // btnObrisi
            //
            this.btnObrisi.BackColor = System.Drawing.Color.YellowGreen;
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnObrisi.Location = new System.Drawing.Point(425, 379);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(143, 59);
            this.btnObrisi.TabIndex = 4;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            //
            // btnIzlaz
            //
            this.btnIzlaz.BackColor = System.Drawing.Color.YellowGreen;
            this.btnIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnIzlaz.Location = new System.Drawing.Point(626, 379);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(143, 59);
            this.btnIzlaz.TabIndex = 5;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = false;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            //
            // ParkiranjeForma
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnIzmeni);
            this.Controls.Add(this.dgvParkiranja);
            this.Name = "ParkiranjeForma";
            this.Text = "Parkiranja";
            this.Load += new System.EventHandler(this.ParkiranjeForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParkiranja)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvParkiranja;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnIzlaz;
    }
}