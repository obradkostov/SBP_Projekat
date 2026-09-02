namespace PametniParking.DesktopCore
{
    partial class ParkingZonaEditForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6;
        private System.Windows.Forms.TextBox txtNaziv, txtGeografsko, txtTipZone, txtOsnovnaTarifa, txtMaxVreme, txtPravila;
        private System.Windows.Forms.Button btnSacuvaj, btnOtkazi;

        private void InitializeComponent()
        {
            label1 = new Label(); txtNaziv = new TextBox();
            label2 = new Label(); txtGeografsko = new TextBox();
            label3 = new Label(); txtTipZone = new TextBox();
            label4 = new Label(); txtOsnovnaTarifa = new TextBox();
            label5 = new Label(); txtMaxVreme = new TextBox();
            label6 = new Label(); txtPravila = new TextBox();
            btnSacuvaj = new Button(); btnOtkazi = new Button();
            SuspendLayout();

            label1.Text = "Naziv:"; label1.Location = new System.Drawing.Point(20, 20); label1.AutoSize = true;
            txtNaziv.Location = new System.Drawing.Point(200, 18); txtNaziv.Size = new System.Drawing.Size(180, 20);

            label2.Text = "Geografsko područje:"; label2.Location = new System.Drawing.Point(20, 55); label2.AutoSize = true;
            txtGeografsko.Location = new System.Drawing.Point(200, 53); txtGeografsko.Size = new System.Drawing.Size(180, 20);

            label3.Text = "Tip zone:"; label3.Location = new System.Drawing.Point(20, 90); label3.AutoSize = true;
            txtTipZone.Location = new System.Drawing.Point(200, 88); txtTipZone.Size = new System.Drawing.Size(180, 20);

            label4.Text = "Osnovna tarifa:"; label4.Location = new System.Drawing.Point(20, 125); label4.AutoSize = true;
            txtOsnovnaTarifa.Location = new System.Drawing.Point(200, 123); txtOsnovnaTarifa.Size = new System.Drawing.Size(180, 20);

            label5.Text = "Max vreme zadržavanja:"; label5.Location = new System.Drawing.Point(20, 160); label5.AutoSize = true;
            txtMaxVreme.Location = new System.Drawing.Point(200, 158); txtMaxVreme.Size = new System.Drawing.Size(180, 20);

            label6.Text = "Pravila naplate:"; label6.Location = new System.Drawing.Point(20, 195); label6.AutoSize = true;
            txtPravila.Location = new System.Drawing.Point(200, 193); txtPravila.Size = new System.Drawing.Size(180, 20);

            btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnSacuvaj.Location = new System.Drawing.Point(20, 235); btnSacuvaj.Size = new System.Drawing.Size(180, 45);
            btnSacuvaj.Text = "Sačuvaj"; btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += new EventHandler(btnSacuvaj_Click);

            btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnOtkazi.Location = new System.Drawing.Point(210, 235); btnOtkazi.Size = new System.Drawing.Size(180, 45);
            btnOtkazi.Text = "Otkaži"; btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += new EventHandler(btnOtkazi_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(420, 300);
            Controls.Add(btnOtkazi); Controls.Add(btnSacuvaj);
            Controls.Add(txtPravila); Controls.Add(label6);
            Controls.Add(txtMaxVreme); Controls.Add(label5);
            Controls.Add(txtOsnovnaTarifa); Controls.Add(label4);
            Controls.Add(txtTipZone); Controls.Add(label3);
            Controls.Add(txtGeografsko); Controls.Add(label2);
            Controls.Add(txtNaziv); Controls.Add(label1);
            Name = "ParkingZonaEditForma";
            Text = "ParkingZonaEdit";
            Load += new EventHandler(ParkingZonaEditForma_Load);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}