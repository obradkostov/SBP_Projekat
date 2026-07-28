using NHibernate;
using PametniParking.Models;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace PametniParking.Forme
{
    public partial class KorisnikEditForma : Form
    {
        private readonly int? _korisnikId;

        public KorisnikEditForma()
        {
            InitializeComponent();
            _korisnikId = null;
        }

        public KorisnikEditForma(int korisnikId)
        {
            InitializeComponent();
            _korisnikId = korisnikId;
        }

        private void KorisnikEditForma_Load(object sender, EventArgs e)
        {
            cmbTip.Items.Clear();
            cmbTip.Items.AddRange(new object[] { "Fizičko lice", "Pravno lice" });

            if (_korisnikId.HasValue)
            {
                this.Text = "Izmena korisnika";
                cmbTip.Enabled = false; // tip korisnika se ne menja nakon kreiranja
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var korisnik = session.Get<Korisnik>(_korisnikId.Value);
                    txtEmail.Text = korisnik.Email;
                    txtAdresa.Text = korisnik.Adresa;
                    cmbStatusNaloga.Text = korisnik.StatusNaloga;

                    if (korisnik is FizickoLice fl)
                    {
                        cmbTip.SelectedItem = "Fizičko lice";
                        txtIme.Text = fl.Ime;
                        txtPrezime.Text = fl.Prezime;
                        txtJmbg.Text = fl.Jmbg;
                    }
                    else if (korisnik is PravnoLice pl)
                    {
                        cmbTip.SelectedItem = "Pravno lice";
                        txtNaziv.Text = pl.Naziv;
                        txtPib.Text = pl.Pib;
                        txtMaticniBroj.Text = pl.MaticniBroj;
                        txtKontaktOsoba.Text = pl.KontaktOsoba;
                        txtSediste.Text = pl.Sediste;
                    }
                }
            }
            else
            {
                this.Text = "Dodavanje novog korisnika";
                cmbTip.SelectedIndex = 0;
            }

            PrikaziPolja();
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrikaziPolja();
        }

        private void PrikaziPolja()
        {
            bool jeFizicko = cmbTip.SelectedItem != null && cmbTip.SelectedItem.ToString() == "Fizičko lice";
            pnlFizickoLice.Visible = jeFizicko;
            pnlPravnoLice.Visible = !jeFizicko;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email je obavezan.");
                return;
            }
            bool jeFizicko = cmbTip.SelectedItem != null && cmbTip.SelectedItem.ToString() == "Fizičko lice";
            if (jeFizicko && (string.IsNullOrWhiteSpace(txtIme.Text) || string.IsNullOrWhiteSpace(txtPrezime.Text)))
            {
                MessageBox.Show("Ime i prezime su obavezni za fizičko lice.");
                return;
            }
            if (!jeFizicko && string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Naziv je obavezan za pravno lice.");
                return;
            }

            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    bool novo = !_korisnikId.HasValue;
                    Korisnik korisnik;

                    if (!novo)
                    {
                        korisnik = session.Get<Korisnik>(_korisnikId.Value);
                    }
                    else
                    {
                        korisnik = jeFizicko ? (Korisnik)new FizickoLice() : new PravnoLice();
                    }

                    korisnik.Email = txtEmail.Text;
                    korisnik.Adresa = txtAdresa.Text;
                    korisnik.StatusNaloga = cmbStatusNaloga.Text;

                    if (korisnik is FizickoLice fl)
                    {
                        fl.Ime = txtIme.Text;
                        fl.Prezime = txtPrezime.Text;
                        fl.Jmbg = txtJmbg.Text;
                    }
                    else if (korisnik is PravnoLice pl)
                    {
                        pl.Naziv = txtNaziv.Text;
                        pl.Pib = txtPib.Text;
                        pl.MaticniBroj = txtMaticniBroj.Text;
                        pl.KontaktOsoba = txtKontaktOsoba.Text;
                        pl.Sediste = txtSediste.Text;
                    }

                    if (novo)
                        session.Save(korisnik);
                    else
                        session.Update(korisnik);

                    transaction.Commit();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string poruka = "Greška: " + ex.Message;
                var inner = ex.InnerException;
                while (inner != null)
                {
                    poruka += "\n\n---\n" + inner.Message;
                    inner = inner.InnerException;
                }
                MessageBox.Show(poruka);
            }
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
