namespace PametniParking.Forme
{
    partial class ParkiranjeEditForma
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
            this.cmbVozilo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMesto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbZona = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPocetak = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKarta = new System.Windows.Forms.ComboBox();
            this.chkImaKartu = new System.Windows.Forms.CheckBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vozilo:";
            //
            // cmbVozilo
            //
            this.cmbVozilo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVozilo.FormattingEnabled = true;
            this.cmbVozilo.Location = new System.Drawing.Point(200, 18);
            this.cmbVozilo.Name = "cmbVozilo";
            this.cmbVozilo.Size = new System.Drawing.Size(190, 21);
            this.cmbVozilo.TabIndex = 1;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parking mesto:";
            //
            // cmbMesto
            //
            this.cmbMesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesto.FormattingEnabled = true;
            this.cmbMesto.Location = new System.Drawing.Point(200, 53);
            this.cmbMesto.Name = "cmbMesto";
            this.cmbMesto.Size = new System.Drawing.Size(190, 21);
            this.cmbMesto.TabIndex = 3;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Zona:";
            //
            // cmbZona
            //
            this.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZona.FormattingEnabled = true;
            this.cmbZona.Location = new System.Drawing.Point(200, 88);
            this.cmbZona.Name = "cmbZona";
            this.cmbZona.Size = new System.Drawing.Size(190, 21);
            this.cmbZona.TabIndex = 5;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(20, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Datum/vreme početka:";
            //
            // dtpPocetak
            //
            this.dtpPocetak.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpPocetak.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPocetak.Location = new System.Drawing.Point(200, 123);
            this.dtpPocetak.Name = "dtpPocetak";
            this.dtpPocetak.Size = new System.Drawing.Size(190, 20);
            this.dtpPocetak.TabIndex = 7;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(20, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Obračunati iznos:";
            //
            // txtIznos
            //
            this.txtIznos.Location = new System.Drawing.Point(200, 158);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(190, 20);
            this.txtIznos.TabIndex = 9;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(20, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Pretplatna karta:";
            //
            // chkImaKartu
            //
            this.chkImaKartu.AutoSize = true;
            this.chkImaKartu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkImaKartu.Location = new System.Drawing.Point(200, 193);
            this.chkImaKartu.Name = "chkImaKartu";
            this.chkImaKartu.Size = new System.Drawing.Size(160, 21);
            this.chkImaKartu.TabIndex = 11;
            this.chkImaKartu.Text = "Ima pretplatnu kartu";
            this.chkImaKartu.UseVisualStyleBackColor = true;
            //
            // cmbKarta
            //
            this.cmbKarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKarta.FormattingEnabled = true;
            this.cmbKarta.Location = new System.Drawing.Point(200, 218);
            this.cmbKarta.Name = "cmbKarta";
            this.cmbKarta.Size = new System.Drawing.Size(190, 21);
            this.cmbKarta.TabIndex = 12;
            //
            // btnSacuvaj
            //
            this.btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSacuvaj.Location = new System.Drawing.Point(20, 260);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(185, 45);
            this.btnSacuvaj.TabIndex = 12;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            //
            // btnOtkazi
            //
            this.btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            this.btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOtkazi.Location = new System.Drawing.Point(215, 260);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(185, 45);
            this.btnOtkazi.TabIndex = 13;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = false;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            //
            // ParkiranjeEditForma
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(420, 325);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cmbKarta);
            this.Controls.Add(this.chkImaKartu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIznos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpPocetak);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbZona);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMesto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbVozilo);
            this.Controls.Add(this.label1);
            this.Name = "ParkiranjeEditForma";
            this.Text = "ParkiranjeEdit";
            this.Load += new System.EventHandler(this.ParkiranjeEditForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVozilo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMesto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbZona;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpPocetak;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbKarta;
        private System.Windows.Forms.CheckBox chkImaKartu;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOtkazi;
    }
}