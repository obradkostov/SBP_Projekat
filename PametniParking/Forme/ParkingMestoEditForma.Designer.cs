namespace PametniParking.Forme
{
    partial class ParkingMestoEditForma
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
            this.cmbZona = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOznaka = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLokacija = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDozDuzina = new System.Windows.Forms.TextBox();
            this.chkNatkriveno = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKameraSenzor = new System.Windows.Forms.TextBox();
            this.pnlInvaliditet = new System.Windows.Forms.Panel();
            this.txtNivoPristupacnosti = new System.Windows.Forms.TextBox();
            this.labelNivo = new System.Windows.Forms.Label();
            this.pnlPunjac = new System.Windows.Forms.Panel();
            this.txtRezimiPunjenja = new System.Windows.Forms.TextBox();
            this.labelRezimi = new System.Windows.Forms.Label();
            this.txtBrojPrikljucaka = new System.Windows.Forms.TextBox();
            this.labelBroj = new System.Windows.Forms.Label();
            this.txtTipKonektora = new System.Windows.Forms.TextBox();
            this.labelKonektor = new System.Windows.Forms.Label();
            this.txtSnagaPunjaca = new System.Windows.Forms.TextBox();
            this.labelSnaga = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.pnlInvaliditet.SuspendLayout();
            this.pnlPunjac.SuspendLayout();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zona:";
            //
            // cmbZona
            //
            this.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZona.FormattingEnabled = true;
            this.cmbZona.Location = new System.Drawing.Point(200, 18);
            this.cmbZona.Name = "cmbZona";
            this.cmbZona.Size = new System.Drawing.Size(190, 21);
            this.cmbZona.TabIndex = 1;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Oznaka mesta:";
            //
            // txtOznaka
            //
            this.txtOznaka.Location = new System.Drawing.Point(200, 53);
            this.txtOznaka.Name = "txtOznaka";
            this.txtOznaka.Size = new System.Drawing.Size(190, 20);
            this.txtOznaka.TabIndex = 3;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Geografska lokacija:";
            //
            // txtLokacija
            //
            this.txtLokacija.Location = new System.Drawing.Point(200, 88);
            this.txtLokacija.Name = "txtLokacija";
            this.txtLokacija.Size = new System.Drawing.Size(190, 20);
            this.txtLokacija.TabIndex = 5;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(20, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Status:";
            //
            // txtStatus
            //
            this.txtStatus.Location = new System.Drawing.Point(200, 123);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(190, 20);
            this.txtStatus.TabIndex = 7;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(20, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tip mesta:";
            //
            // cmbTip
            //
            this.cmbTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Location = new System.Drawing.Point(200, 158);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(190, 21);
            this.cmbTip.TabIndex = 9;
            this.cmbTip.SelectedIndexChanged += new System.EventHandler(this.cmbTip_SelectedIndexChanged);
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(20, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Dozvoljena dužina:";
            //
            // txtDozDuzina
            //
            this.txtDozDuzina.Location = new System.Drawing.Point(200, 193);
            this.txtDozDuzina.Name = "txtDozDuzina";
            this.txtDozDuzina.Size = new System.Drawing.Size(190, 20);
            this.txtDozDuzina.TabIndex = 11;
            //
            // chkNatkriveno
            //
            this.chkNatkriveno.AutoSize = true;
            this.chkNatkriveno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkNatkriveno.Location = new System.Drawing.Point(200, 228);
            this.chkNatkriveno.Name = "chkNatkriveno";
            this.chkNatkriveno.Size = new System.Drawing.Size(110, 21);
            this.chkNatkriveno.TabIndex = 13;
            this.chkNatkriveno.Text = "Natkriveno";
            this.chkNatkriveno.UseVisualStyleBackColor = true;
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(20, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Kamera / senzor:";
            //
            // txtKameraSenzor
            //
            this.txtKameraSenzor.Location = new System.Drawing.Point(200, 263);
            this.txtKameraSenzor.Name = "txtKameraSenzor";
            this.txtKameraSenzor.Size = new System.Drawing.Size(190, 20);
            this.txtKameraSenzor.TabIndex = 15;
            //
            // pnlInvaliditet
            //
            this.pnlInvaliditet.Controls.Add(this.labelNivo);
            this.pnlInvaliditet.Controls.Add(this.txtNivoPristupacnosti);
            this.pnlInvaliditet.Location = new System.Drawing.Point(15, 295);
            this.pnlInvaliditet.Name = "pnlInvaliditet";
            this.pnlInvaliditet.Size = new System.Drawing.Size(390, 40);
            this.pnlInvaliditet.TabIndex = 16;
            //
            // labelNivo
            //
            this.labelNivo.AutoSize = true;
            this.labelNivo.Location = new System.Drawing.Point(5, 8);
            this.labelNivo.Name = "labelNivo";
            this.labelNivo.Size = new System.Drawing.Size(140, 13);
            this.labelNivo.TabIndex = 0;
            this.labelNivo.Text = "Nivo pristupačnosti:";
            //
            // txtNivoPristupacnosti
            //
            this.txtNivoPristupacnosti.Location = new System.Drawing.Point(185, 5);
            this.txtNivoPristupacnosti.Name = "txtNivoPristupacnosti";
            this.txtNivoPristupacnosti.Size = new System.Drawing.Size(200, 20);
            this.txtNivoPristupacnosti.TabIndex = 1;
            //
            // pnlPunjac
            //
            this.pnlPunjac.Controls.Add(this.txtRezimiPunjenja);
            this.pnlPunjac.Controls.Add(this.labelRezimi);
            this.pnlPunjac.Controls.Add(this.txtBrojPrikljucaka);
            this.pnlPunjac.Controls.Add(this.labelBroj);
            this.pnlPunjac.Controls.Add(this.txtTipKonektora);
            this.pnlPunjac.Controls.Add(this.labelKonektor);
            this.pnlPunjac.Controls.Add(this.txtSnagaPunjaca);
            this.pnlPunjac.Controls.Add(this.labelSnaga);
            this.pnlPunjac.Location = new System.Drawing.Point(15, 295);
            this.pnlPunjac.Name = "pnlPunjac";
            this.pnlPunjac.Size = new System.Drawing.Size(390, 130);
            this.pnlPunjac.TabIndex = 17;
            //
            // txtRezimiPunjenja
            //
            this.txtRezimiPunjenja.Location = new System.Drawing.Point(185, 95);
            this.txtRezimiPunjenja.Name = "txtRezimiPunjenja";
            this.txtRezimiPunjenja.Size = new System.Drawing.Size(200, 20);
            this.txtRezimiPunjenja.TabIndex = 7;
            //
            // labelRezimi
            //
            this.labelRezimi.AutoSize = true;
            this.labelRezimi.Location = new System.Drawing.Point(5, 98);
            this.labelRezimi.Name = "labelRezimi";
            this.labelRezimi.Size = new System.Drawing.Size(100, 13);
            this.labelRezimi.TabIndex = 6;
            this.labelRezimi.Text = "Režimi punjenja:";
            //
            // txtBrojPrikljucaka
            //
            this.txtBrojPrikljucaka.Location = new System.Drawing.Point(185, 65);
            this.txtBrojPrikljucaka.Name = "txtBrojPrikljucaka";
            this.txtBrojPrikljucaka.Size = new System.Drawing.Size(200, 20);
            this.txtBrojPrikljucaka.TabIndex = 5;
            //
            // labelBroj
            //
            this.labelBroj.AutoSize = true;
            this.labelBroj.Location = new System.Drawing.Point(5, 68);
            this.labelBroj.Name = "labelBroj";
            this.labelBroj.Size = new System.Drawing.Size(110, 13);
            this.labelBroj.TabIndex = 4;
            this.labelBroj.Text = "Broj priključaka:";
            //
            // txtTipKonektora
            //
            this.txtTipKonektora.Location = new System.Drawing.Point(185, 35);
            this.txtTipKonektora.Name = "txtTipKonektora";
            this.txtTipKonektora.Size = new System.Drawing.Size(200, 20);
            this.txtTipKonektora.TabIndex = 3;
            //
            // labelKonektor
            //
            this.labelKonektor.AutoSize = true;
            this.labelKonektor.Location = new System.Drawing.Point(5, 38);
            this.labelKonektor.Name = "labelKonektor";
            this.labelKonektor.Size = new System.Drawing.Size(95, 13);
            this.labelKonektor.TabIndex = 2;
            this.labelKonektor.Text = "Tip konektora:";
            //
            // txtSnagaPunjaca
            //
            this.txtSnagaPunjaca.Location = new System.Drawing.Point(185, 5);
            this.txtSnagaPunjaca.Name = "txtSnagaPunjaca";
            this.txtSnagaPunjaca.Size = new System.Drawing.Size(200, 20);
            this.txtSnagaPunjaca.TabIndex = 1;
            //
            // labelSnaga
            //
            this.labelSnaga.AutoSize = true;
            this.labelSnaga.Location = new System.Drawing.Point(5, 8);
            this.labelSnaga.Name = "labelSnaga";
            this.labelSnaga.Size = new System.Drawing.Size(95, 13);
            this.labelSnaga.TabIndex = 0;
            this.labelSnaga.Text = "Snaga punjača:";
            //
            // btnSacuvaj
            //
            this.btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSacuvaj.Location = new System.Drawing.Point(20, 440);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(185, 45);
            this.btnSacuvaj.TabIndex = 18;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            //
            // btnOtkazi
            //
            this.btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            this.btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOtkazi.Location = new System.Drawing.Point(215, 440);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(185, 45);
            this.btnOtkazi.TabIndex = 19;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = false;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            //
            // ParkingMestoEditForma
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(420, 500);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.pnlPunjac);
            this.Controls.Add(this.pnlInvaliditet);
            this.Controls.Add(this.txtKameraSenzor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkNatkriveno);
            this.Controls.Add(this.txtDozDuzina);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLokacija);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOznaka);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbZona);
            this.Controls.Add(this.label1);
            this.Name = "ParkingMestoEditForma";
            this.Text = "ParkingMestoEdit";
            this.Load += new System.EventHandler(this.ParkingMestoEditForma_Load);
            this.pnlInvaliditet.ResumeLayout(false);
            this.pnlInvaliditet.PerformLayout();
            this.pnlPunjac.ResumeLayout(false);
            this.pnlPunjac.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbZona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOznaka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLokacija;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDozDuzina;
        private System.Windows.Forms.CheckBox chkNatkriveno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKameraSenzor;
        private System.Windows.Forms.Panel pnlInvaliditet;
        private System.Windows.Forms.TextBox txtNivoPristupacnosti;
        private System.Windows.Forms.Label labelNivo;
        private System.Windows.Forms.Panel pnlPunjac;
        private System.Windows.Forms.TextBox txtRezimiPunjenja;
        private System.Windows.Forms.Label labelRezimi;
        private System.Windows.Forms.TextBox txtBrojPrikljucaka;
        private System.Windows.Forms.Label labelBroj;
        private System.Windows.Forms.TextBox txtTipKonektora;
        private System.Windows.Forms.Label labelKonektor;
        private System.Windows.Forms.TextBox txtSnagaPunjaca;
        private System.Windows.Forms.Label labelSnaga;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOtkazi;
    }
}