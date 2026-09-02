namespace PametniParking.DesktopCore
{
    partial class IzvestajForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.DataGridView dgvIzvestaj;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.Button btnOsvezi, btnIzlaz;

        private void InitializeComponent()
        {
            dgvIzvestaj = new System.Windows.Forms.DataGridView();
            lblUkupno = new System.Windows.Forms.Label();
            btnOsvezi = new System.Windows.Forms.Button();
            btnIzlaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(dgvIzvestaj)).BeginInit();
            SuspendLayout();

            dgvIzvestaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIzvestaj.Dock = System.Windows.Forms.DockStyle.Top;
            dgvIzvestaj.ReadOnly = true;
            dgvIzvestaj.Size = new System.Drawing.Size(800, 320);

            lblUkupno.AutoSize = true;
            lblUkupno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            lblUkupno.Location = new System.Drawing.Point(24, 335);
            lblUkupno.Text = "Ukupan broj parkiranja: 0, ukupan prihod: 0";

            btnOsvezi.BackColor = System.Drawing.Color.YellowGreen;
            btnOsvezi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnOsvezi.Location = new System.Drawing.Point(24, 379); btnOsvezi.Size = new System.Drawing.Size(180, 59);
            btnOsvezi.Text = "Osveži"; btnOsvezi.UseVisualStyleBackColor = false;
            btnOsvezi.Click += new EventHandler(btnOsvezi_Click);

            btnIzlaz.BackColor = System.Drawing.Color.YellowGreen;
            btnIzlaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnIzlaz.Location = new System.Drawing.Point(626, 379); btnIzlaz.Size = new System.Drawing.Size(143, 59);
            btnIzlaz.Text = "Izlaz"; btnIzlaz.UseVisualStyleBackColor = false;
            btnIzlaz.Click += new EventHandler(btnIzlaz_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnIzlaz); Controls.Add(btnOsvezi); Controls.Add(lblUkupno); Controls.Add(dgvIzvestaj);
            Name = "IzvestajForma";
            Text = "Izveštaj - prihod po zonama";
            Load += new EventHandler(IzvestajForma_Load);
            ((System.ComponentModel.ISupportInitialize)(dgvIzvestaj)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}