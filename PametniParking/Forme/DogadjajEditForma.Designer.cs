namespace PametniParking.Forme
{
    partial class DogadjajEditForma
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
            this.txtRedniBroj = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSenzor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpVreme = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOcitanaVrednost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNivoPouzdanosti = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPotvrda = new System.Windows.Forms.TextBox();
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
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Redni broj:";
            //
            // txtRedniBroj
            //
            this.txtRedniBroj.Location = new System.Drawing.Point(210, 18);
            this.txtRedniBroj.Name = "txtRedniBroj";
            this.txtRedniBroj.Size = new System.Drawing.Size(160, 20);
            this.txtRedniBroj.TabIndex = 1;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Senzor:";
            //
            // cmbSenzor
            //
            this.cmbSenzor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSenzor.FormattingEnabled = true;
            this.cmbSenzor.Location = new System.Drawing.Point(210, 53);
            this.cmbSenzor.Name = "cmbSenzor";
            this.cmbSenzor.Size = new System.Drawing.Size(160, 21);
            this.cmbSenzor.TabIndex = 3;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tip događaja:";
            //
            // txtTip
            //
            this.txtTip.Location = new System.Drawing.Point(210, 88);
            this.txtTip.Name = "txtTip";
            this.txtTip.Size = new System.Drawing.Size(160, 20);
            this.txtTip.TabIndex = 5;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(20, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vreme nastanka:";
            //
            // dtpVreme
            //
            this.dtpVreme.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpVreme.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVreme.Location = new System.Drawing.Point(210, 123);
            this.dtpVreme.Name = "dtpVreme";
            this.dtpVreme.Size = new System.Drawing.Size(160, 20);
            this.dtpVreme.TabIndex = 7;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(20, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Očitana vrednost:";
            //
            // txtOcitanaVrednost
            //
            this.txtOcitanaVrednost.Location = new System.Drawing.Point(210, 158);
            this.txtOcitanaVrednost.Name = "txtOcitanaVrednost";
            this.txtOcitanaVrednost.Size = new System.Drawing.Size(160, 20);
            this.txtOcitanaVrednost.TabIndex = 9;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(20, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nivo pouzdanosti:";
            //
            // txtNivoPouzdanosti
            //
            this.txtNivoPouzdanosti.Location = new System.Drawing.Point(210, 193);
            this.txtNivoPouzdanosti.Name = "txtNivoPouzdanosti";
            this.txtNivoPouzdanosti.Size = new System.Drawing.Size(160, 20);
            this.txtNivoPouzdanosti.TabIndex = 11;
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(20, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Potvrda:";
            //
            // txtPotvrda
            //
            this.txtPotvrda.Location = new System.Drawing.Point(210, 228);
            this.txtPotvrda.Name = "txtPotvrda";
            this.txtPotvrda.Size = new System.Drawing.Size(160, 20);
            this.txtPotvrda.TabIndex = 13;
            //
            // btnSacuvaj
            //
            this.btnSacuvaj.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSacuvaj.Location = new System.Drawing.Point(20, 270);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(160, 45);
            this.btnSacuvaj.TabIndex = 14;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = false;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            //
            // btnOtkazi
            //
            this.btnOtkazi.BackColor = System.Drawing.Color.YellowGreen;
            this.btnOtkazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnOtkazi.Location = new System.Drawing.Point(210, 270);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(160, 45);
            this.btnOtkazi.TabIndex = 15;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = false;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            //
            // DogadjajEditForma
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(392, 335);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.txtPotvrda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNivoPouzdanosti);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOcitanaVrednost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpVreme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSenzor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRedniBroj);
            this.Controls.Add(this.label1);
            this.Name = "DogadjajEditForma";
            this.Text = "DogadjajEdit";
            this.Load += new System.EventHandler(this.DogadjajEditForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRedniBroj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSenzor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpVreme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOcitanaVrednost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNivoPouzdanosti;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPotvrda;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOtkazi;
    }
}