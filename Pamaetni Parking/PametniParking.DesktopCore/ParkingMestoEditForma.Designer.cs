namespace PametniParking.DesktopCore
{
    partial class ParkingMestoEditForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label label1, label2, label3, label4, label5, label6, label7;
        private ComboBox cmbZona, cmbTip;
        private TextBox txtOznaka, txtLokacija, txtStatus, txtDozDuzina, txtKameraSenzor;
        private CheckBox chkNatkriveno;
        private Panel pnlInvaliditet, pnlPunjac;
        private TextBox txtNivoPristupacnosti;
        private TextBox txtSnagaPunjaca, txtTipKonektora, txtBrojPrikljucaka, txtRezimiPunjenja;
        private Button btnSacuvaj, btnOtkazi;

        private void InitializeComponent()
        {
            label1 = new Label(); cmbZona = new ComboBox();
            label2 = new Label(); txtOznaka = new TextBox();
            label3 = new Label(); txtLokacija = new TextBox();
            label4 = new Label(); txtStatus = new TextBox();
            label5 = new Label(); cmbTip = new ComboBox();
            label6 = new Label(); txtDozDuzina = new TextBox();
            chkNatkriveno = new CheckBox();
            label7 = new Label(); txtKameraSenzor = new TextBox();
            pnlInvaliditet = new Panel(); txtNivoPristupacnosti = new TextBox();
            pnlPunjac = new Panel();
            txtSnagaPunjaca = new TextBox(); txtTipKonektora = new TextBox();
            txtBrojPrikljucaka = new TextBox(); txtRezimiPunjenja = new TextBox();
            btnSacuvaj = new Button(); btnOtkazi = new Button();
            pnlInvaliditet.SuspendLayout();
            pnlPunjac.SuspendLayout();
            SuspendLayout();

            label1.Text = "Zona:"; label1.Location = new System.Drawing.Point(20, 20); label1.AutoSize = true;
            cmbZona.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZona.Location = new System.Drawing.Point(200, 18); cmbZona.Size = new System.Drawing.Size(190, 21);

            label2.Text = "Oznaka mesta:"; label2.Location = new System.Drawing.Point(20, 55); label2.AutoSize = true;
            txtOznaka.Location = new System.Drawing.Point(200, 53); txtOznaka.Size = new System.Drawing.Size(190, 20);

            label3.Text = "Geografska lokacija:"; label3.Location = new System.Drawing.Point(20, 90); label3.AutoSize = true;
            txtLokacija.Location = new System.Drawing.Point(200, 88); txtLokacija.Size = new System.Drawing.Size(190, 20);

            label4.Text = "Status:"; label4.Location = new System.Drawing.Point(20, 125); label4.AutoSize = true;
            txtStatus.Location = new System.Drawing.Point(200, 123); txtStatus.Size = new System.Drawing.Size(190, 20);

            label5.Text = "Tip mesta:"; label5.Location = new System.Drawing.Point(20, 160); label5.AutoSize = true;
            cmbTip.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTip.Location = new System.Drawing.Point(200, 158); cmbTip.Size = new System.Drawing.Size(190, 21);
            cmbTip.SelectedIndexChanged += new EventHandler(cmbTip_SelectedIndexChanged);

            label6.Text = "Dozvoljena dužina:"; label6.Location = new System.Drawing.Point(20, 195); label6.AutoSize = true;
            txtDozDuzina.Location = new System.Drawing.Point(200, 193); txtDozDuzina.Size = new System.Drawing.Size(190, 20);

            chkNatkriveno.Text = "Natkriveno"; chkNatkriveno.Location = new System.Drawing.Point(200, 228); chkNatkriveno.AutoSize = true;

            label7.Text = "Kamera / senzor:"; label7.Location = new System.Drawing.Point(20, 265); label7.AutoSize = true;
            txtKameraSenzor.Location = new System.Drawing.Point(200, 263); txtKameraSenzor.Size = new System.Drawing.Size(190, 20);

            Label lblNivo = new() { Text = "Nivo pristupačnosti:", Location = new System.Drawing.Point(5, 8), AutoSize = true };
            txtNivoPristupacnosti.Location = new System.Drawing.Point(185, 5); txtNivoPristupacnosti.Size = new System.Drawing.Size(200, 20);
            pnlInvaliditet.Controls.Add(lblNivo); pnlInvaliditet.Controls.Add(txtNivoPristupacnosti);
            pnlInvaliditet.Location = new System.Drawing.Point(15, 295); pnlInvaliditet.Size = new System.Drawing.Size(390, 40);

            Label lblSnaga = new() { Text = "Snaga punjača:", Location = new System.Drawing.Point(5, 8), AutoSize = true };
            txtSnagaPunjaca.Location = new System.Drawing.Point(185, 5); txtSnagaPunjaca.Size = new System.Drawing.Size(200, 20);
            Label lblKonektor = new() { Text = "Tip konektora:", Location = new System.Drawing.Point(5, 38), AutoSize = true };
            txtTipKonektora.Location = new System.Drawing.Point(185, 35); txtTipKonektora.Size = new System.Drawing.Size(200, 20);
            Label lblBroj = new() { Text = "Broj priključaka:", Location = new System.Drawing.Point(5, 68), AutoSize = true };
            txtBrojPrikljucaka.Location = new System.Drawing.Point(185, 65); txtBrojPrikljucaka.Size = new System.Drawing.Size(200, 20);
            Label lblRezimi = new() { Text = "Režimi punjenja:", Location = new System.Drawing.Point(5, 98), AutoSize = true };
            txtRezimiPunjenja.Location = new System.Drawing.Point(185, 95); txtRezimiPunjenja.Size = new System.Drawing.Size(200, 20);
            pnlPunjac.Controls.Add(lblSnaga); pnlPunjac.Controls.Add(txtSnagaPunjaca);
            pnlPunjac.Controls.Add(lblKonektor); pnlPunjac.Controls.Add(txtTipKonektora);
            pnlPunjac.Controls.Add(lblBroj); pnlPunjac.Controls.Add(txtBrojPrikljucaka);
            pnlPunjac.Controls.Add(lblRezimi); pnlPunjac.Controls.Add(txtRezimiPunjenja);
            pnlPunjac.Location = new System.Drawing.Point(15, 295); pnlPunjac.Size = new System.Drawing.Size(390, 130);

            btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnSacuvaj.Location = new System.Drawing.Point(20, 440); btnSacuvaj.Size = new System.Drawing.Size(185, 45);
            btnSacuvaj.Text = "Sačuvaj"; btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += new EventHandler(btnSacuvaj_Click);

            btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnOtkazi.Location = new System.Drawing.Point(215, 440); btnOtkazi.Size = new System.Drawing.Size(185, 45);
            btnOtkazi.Text = "Otkaži"; btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += new EventHandler(btnOtkazi_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(420, 500);
            Controls.Add(btnOtkazi); Controls.Add(btnSacuvaj);
            Controls.Add(pnlPunjac); Controls.Add(pnlInvaliditet);
            Controls.Add(txtKameraSenzor); Controls.Add(label7);
            Controls.Add(chkNatkriveno);
            Controls.Add(txtDozDuzina); Controls.Add(label6);
            Controls.Add(cmbTip); Controls.Add(label5);
            Controls.Add(txtStatus); Controls.Add(label4);
            Controls.Add(txtLokacija); Controls.Add(label3);
            Controls.Add(txtOznaka); Controls.Add(label2);
            Controls.Add(cmbZona); Controls.Add(label1);
            Name = "ParkingMestoEditForma";
            Text = "ParkingMestoEdit";
            Load += new EventHandler(ParkingMestoEditForma_Load);
            pnlInvaliditet.ResumeLayout(false); pnlInvaliditet.PerformLayout();
            pnlPunjac.ResumeLayout(false); pnlPunjac.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}