using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace PametniParking.DesktopCore
{
    public partial class KorisnikEditForma : Form
    {
        private readonly int? _id;

        public KorisnikEditForma()
        {
            InitializeComponent();
            _id = null;
        }

        public KorisnikEditForma(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void KorisnikEditForma_Load(object sender, EventArgs e)
        {
            cmbTip.Items.Clear();
            cmbTip.Items.AddRange(new object[] { "Fizičko lice", "Pravno lice" });

            if (_id.HasValue)
            {
                Text = "Izmena korisnika";
                cmbTip.Enabled = false;
                var (isError, k, error) = await DTOManager.VratiKorisnikaAsync(_id.Value);
                if (isError)
                {
                    MessageBox.Show(error);
                    Close();
                    return;
                }
                txtEmail.Text = k.Email;
                txtAdresa.Text = k.Adresa;
                txtStatusNaloga.Text = k.StatusNaloga;

                if (k.Tip == "FizickoLice")
                {
                    cmbTip.SelectedItem = "Fizičko lice";
                    txtIme.Text = k.Ime;
                    txtPrezime.Text = k.Prezime;
                    txtJmbg.Text = k.Jmbg;
                }
                else
                {
                    cmbTip.SelectedItem = "Pravno lice";
                    txtNaziv.Text = k.Naziv;
                    txtPib.Text = k.Pib;
                    txtMaticniBroj.Text = k.MaticniBroj;
                    txtKontaktOsoba.Text = k.KontaktOsoba;
                    txtSediste.Text = k.Sediste;
                }
            }
            else
            {
                Text = "Dodavanje novog korisnika";
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
            bool jeFizicko = cmbTip.SelectedItem?.ToString() == "Fizičko lice";
            pnlFizickoLice.Visible = jeFizicko;
            pnlPravnoLice.Visible = !jeFizicko;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email je obavezan.");
                return;
            }
            bool jeFizicko = cmbTip.SelectedItem?.ToString() == "Fizičko lice";

            KorisnikView p = new()
            {
                Id = _id ?? 0,
                Email = txtEmail.Text,
                Adresa = txtAdresa.Text,
                StatusNaloga = txtStatusNaloga.Text,
                Tip = jeFizicko ? "FizickoLice" : "PravnoLice",
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Jmbg = txtJmbg.Text,
                Naziv = txtNaziv.Text,
                Pib = txtPib.Text,
                MaticniBroj = txtMaticniBroj.Text,
                KontaktOsoba = txtKontaktOsoba.Text,
                Sediste = txtSediste.Text
            };

            bool isError;
            string? error;

            if (_id.HasValue)
            {
                (isError, _, error) = await DTOManager.AzurirajKorisnikaAsync(p);
            }
            else if (jeFizicko)
            {
                (isError, _, error) = await DTOManager.DodajFizickoLiceAsync(p);
            }
            else
            {
                (isError, _, error) = await DTOManager.DodajPravnoLiceAsync(p);
            }

            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
