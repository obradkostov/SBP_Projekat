namespace PametniParking.DesktopCore
{
    partial class ParkiranjeEditForma
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label label1, label2, label3, label4, label5;
        private ComboBox cmbVozilo, cmbMesto, cmbZona, cmbKarta;
        private DateTimePicker dtpPocetak;
        private TextBox txtIznos;
        private CheckBox chkImaKartu;
        private Button btnSacuvaj, btnOtkazi;

        private void InitializeComponent()
        {
            label1 = new Label(); cmbVozilo = new ComboBox();
            label2 = new Label(); cmbMesto = new ComboBox();
            label3 = new Label(); cmbZona = new ComboBox();
            label4 = new Label(); dtpPocetak = new DateTimePicker();
            label5 = new Label(); txtIznos = new TextBox();
            chkImaKartu = new CheckBox(); cmbKarta = new ComboBox();
            btnSacuvaj = new Button(); btnOtkazi = new Button();
            SuspendLayout();

            label1.Text = "Vozilo:"; label1.Location = new System.Drawing.Point(20, 20); label1.AutoSize = true;
            cmbVozilo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVozilo.Location = new System.Drawing.Point(200, 18); cmbVozilo.Size = new System.Drawing.Size(190, 21);

            label2.Text = "Parking mesto:"; label2.Location = new System.Drawing.Point(20, 55); label2.AutoSize = true;
            cmbMesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMesto.Location = new System.Drawing.Point(200, 53); cmbMesto.Size = new System.Drawing.Size(190, 21);

            label3.Text = "Zona:"; label3.Location = new System.Drawing.Point(20, 90); label3.AutoSize = true;
            cmbZona.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZona.Location = new System.Drawing.Point(200, 88); cmbZona.Size = new System.Drawing.Size(190, 21);

            label4.Text = "Datum/vreme početka:"; label4.Location = new System.Drawing.Point(20, 125); label4.AutoSize = true;
            dtpPocetak.Format = DateTimePickerFormat.Custom; dtpPocetak.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpPocetak.Location = new System.Drawing.Point(200, 123); dtpPocetak.Size = new System.Drawing.Size(190, 20);

            label5.Text = "Obračunati iznos:"; label5.Location = new System.Drawing.Point(20, 160); label5.AutoSize = true;
            txtIznos.Location = new System.Drawing.Point(200, 158); txtIznos.Size = new System.Drawing.Size(190, 20);

            chkImaKartu.Text = "Ima pretplatnu kartu"; chkImaKartu.Location = new System.Drawing.Point(200, 193); chkImaKartu.AutoSize = true;
            cmbKarta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKarta.Location = new System.Drawing.Point(200, 218); cmbKarta.Size = new System.Drawing.Size(190, 21);

            btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnSacuvaj.Location = new System.Drawing.Point(20, 260); btnSacuvaj.Size = new System.Drawing.Size(185, 45);
            btnSacuvaj.Text = "Sačuvaj"; btnSacuvaj.UseVisualStyleBackColor = false;
            btnSacuvaj.Click += new EventHandler(btnSacuvaj_Click);

            btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btnOtkazi.Location = new System.Drawing.Point(215, 260); btnOtkazi.Size = new System.Drawing.Size(185, 45);
            btnOtkazi.Text = "Otkaži"; btnOtkazi.UseVisualStyleBackColor = false;
            btnOtkazi.Click += new EventHandler(btnOtkazi_Click);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            ClientSize = new System.Drawing.Size(420, 325);
            Controls.Add(btnOtkazi); Controls.Add(btnSacuvaj);
            Controls.Add(cmbKarta); Controls.Add(chkImaKartu);
            Controls.Add(txtIznos); Controls.Add(label5);
            Controls.Add(dtpPocetak); Controls.Add(label4);
            Controls.Add(cmbZona); Controls.Add(label3);
            Controls.Add(cmbMesto); Controls.Add(label2);
            Controls.Add(cmbVozilo); Controls.Add(label1);
            Name = "ParkiranjeEditForma";
            Text = "ParkiranjeEdit";
            Load += new EventHandler(ParkiranjeEditForma_Load);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}