namespace PametniParking.Forme
{
    partial class IzvestajForma
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
            this.dgvIzvestaj = new System.Windows.Forms.DataGridView();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.btnOsvezi = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvestaj)).BeginInit();
            this.SuspendLayout();
            //
            // dgvIzvestaj
            //
            this.dgvIzvestaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzvestaj.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvIzvestaj.Location = new System.Drawing.Point(0, 0);
            this.dgvIzvestaj.MultiSelect = false;
            this.dgvIzvestaj.Name = "dgvIzvestaj";
            this.dgvIzvestaj.ReadOnly = true;
            this.dgvIzvestaj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIzvestaj.Size = new System.Drawing.Size(800, 320);
            this.dgvIzvestaj.TabIndex = 0;
            //
            // lblUkupno
            //
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblUkupno.Location = new System.Drawing.Point(24, 335);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(300, 18);
            this.lblUkupno.TabIndex = 1;
            this.lblUkupno.Text = "Ukupan broj parkiranja: 0, ukupan prihod: 0";
            //
            // btnOsvezi
            //
            this.btnOsvezi.BackColor = System.Drawing.Color.YellowGreen;
            this.btnOsvezi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOsvezi.Location = new System.Drawing.Point(24, 379);
            this.btnOsvezi.Name = "btnOsvezi";
            this.btnOsvezi.Size = new System.Drawing.Size(180, 59);
            this.btnOsvezi.TabIndex = 2;
            this.btnOsvezi.Text = "Osveži";
            this.btnOsvezi.UseVisualStyleBackColor = false;
            this.btnOsvezi.Click += new System.EventHandler(this.btnOsvezi_Click);
            //
            // btnIzlaz
            //
            this.btnIzlaz.BackColor = System.Drawing.Color.YellowGreen;
            this.btnIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnIzlaz.Location = new System.Drawing.Point(626, 379);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(143, 59);
            this.btnIzlaz.TabIndex = 3;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = false;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            //
            // IzvestajForma
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnOsvezi);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.dgvIzvestaj);
            this.Name = "IzvestajForma";
            this.Text = "Izveštaj - prihod po zonama";
            this.Load += new System.EventHandler(this.IzvestajForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvestaj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIzvestaj;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.Button btnOsvezi;
        private System.Windows.Forms.Button btnIzlaz;
    }
}