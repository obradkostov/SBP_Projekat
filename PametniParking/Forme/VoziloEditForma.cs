using NHibernate;
using PametniParking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PametniParking.Forme
{
    public partial class VoziloEditForma : Form
    {
        private readonly string _registarskaOznaka; // null = dodavanje nove, ima vrednost = izmena postojeceg

        public VoziloEditForma()
        {
            InitializeComponent();
            _registarskaOznaka = null;
        }

        public VoziloEditForma(string registarskaOznaka)
        {
            InitializeComponent();
            _registarskaOznaka = registarskaOznaka;
        }

        private void VoziloEditForma_Load(object sender, EventArgs e)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var korisnici = session.Query<Korisnik>().ToList();
                cmbKorisnik.DataSource = korisnici;
                cmbKorisnik.DisplayMember = "Email";
                chkImaVlasnika.CheckedChanged += (s, args) => cmbKorisnik.Enabled = chkImaVlasnika.Checked;

                if (_registarskaOznaka != null)
                {
                    this.Text = "Izmena vozila";
                    txtOznaka.Enabled = false; // registarska oznaka je primarni kljuc, ne menja se
                    var vozilo = session.Get<Vozilo>(_registarskaOznaka);
                    txtOznaka.Text = vozilo.RegistarskaOznaka;
                    txtDrzava.Text = vozilo.DrzavaRegistracije;
                    txtMarka.Text = vozilo.Marka;
                    txtModel.Text = vozilo.Model;
                    txtTip.Text = vozilo.TipVozila;
                    txtDimenzije.Text = vozilo.Dimenzije;
                    txtPogon.Text = vozilo.Pogon;

                    if (vozilo.Korisnik != null)
                    {
                        chkImaVlasnika.Checked = true;
                        cmbKorisnik.SelectedItem = vozilo.Korisnik;
                    }
                    else
                    {
                        chkImaVlasnika.Checked = false;
                        cmbKorisnik.Enabled = false;
                    }
                }
                else
                {
                    this.Text = "Dodavanje novog vozila";
                    chkImaVlasnika.Checked = false;
                    cmbKorisnik.Enabled = false;
                }
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOznaka.Text) || string.IsNullOrWhiteSpace(txtMarka.Text) ||
                string.IsNullOrWhiteSpace(txtModel.Text) || string.IsNullOrWhiteSpace(txtTip.Text))
            {
                MessageBox.Show("Registarska oznaka, marka, model i tip vozila su obavezni.");
                return;
            }
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Vozilo vozilo;
                    bool novo = _registarskaOznaka == null;
                    if (!novo)
                    {
                        vozilo = session.Get<Vozilo>(_registarskaOznaka);
                    }
                    else
                    {
                        vozilo = new Vozilo();
                        vozilo.RegistarskaOznaka = txtOznaka.Text;
                    }
                    vozilo.DrzavaRegistracije = txtDrzava.Text;
                    vozilo.Marka = txtMarka.Text;
                    vozilo.Model = txtModel.Text;
                    vozilo.TipVozila = txtTip.Text;
                    vozilo.Dimenzije = txtDimenzije.Text;
                    vozilo.Pogon = txtPogon.Text;
                    vozilo.Korisnik = chkImaVlasnika.Checked ? cmbKorisnik.SelectedItem as Korisnik : null;

                    if (novo)
                        session.Save(vozilo);
                    else
                        session.Update(vozilo);

                    transaction.Commit();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
