using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class VoziloEditForma : Form
    {
        private readonly string? _oznaka;

        public VoziloEditForma()
        {
            InitializeComponent();
            _oznaka = null;
        }

        public VoziloEditForma(string oznaka)
        {
            InitializeComponent();
            _oznaka = oznaka;
        }

        private async void VoziloEditForma_Load(object sender, EventArgs e)
        {
            var (isErrorK, korisnici, errorK) = DTOManager.VratiSveKorisnike();
            if (isErrorK)
            {
                MessageBox.Show(errorK);
            }
            else
            {
                cmbKorisnik.DataSource = korisnici;
                cmbKorisnik.DisplayMember = "Email";
                cmbKorisnik.Enabled = false;
                chkImaVlasnika.CheckedChanged += (s, args) => cmbKorisnik.Enabled = chkImaVlasnika.Checked;
            }

            if (_oznaka != null)
            {
                Text = "Izmena vozila";
                txtOznaka.Enabled = false;
                var (isError, vozilo, error) = await DTOManager.VratiVoziloAsync(_oznaka);
                if (isError)
                {
                    MessageBox.Show(error);
                    Close();
                    return;
                }
                txtOznaka.Text = vozilo.RegistarskaOznaka;
                txtDrzava.Text = vozilo.DrzavaRegistracije;
                txtMarka.Text = vozilo.Marka;
                txtModel.Text = vozilo.Model;
                txtTip.Text = vozilo.TipVozila;
                txtDimenzije.Text = vozilo.Dimenzije;
                txtPogon.Text = vozilo.Pogon;

                if (vozilo.KorisnikId.HasValue)
                {
                    chkImaVlasnika.Checked = true;
                    for (int i = 0; i < cmbKorisnik.Items.Count; i++)
                    {
                        if (((KorisnikView)cmbKorisnik.Items[i]!).Id == vozilo.KorisnikId.Value)
                        {
                            cmbKorisnik.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                Text = "Dodavanje novog vozila";
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOznaka.Text))
            {
                MessageBox.Show("Registarska oznaka je obavezna.");
                return;
            }

            VoziloView p = new()
            {
                RegistarskaOznaka = txtOznaka.Text,
                DrzavaRegistracije = txtDrzava.Text,
                Marka = txtMarka.Text,
                Model = txtModel.Text,
                TipVozila = txtTip.Text,
                Dimenzije = txtDimenzije.Text,
                Pogon = txtPogon.Text,
                KorisnikId = chkImaVlasnika.Checked && cmbKorisnik.SelectedItem != null
                    ? ((KorisnikView)cmbKorisnik.SelectedItem).Id
                    : (int?)null
            };

            bool isError;
            string? error;

            if (_oznaka != null)
            {
                (isError, _, error) = await DTOManager.AzurirajVoziloAsync(p);
            }
            else
            {
                (isError, _, error) = await DTOManager.DodajVoziloAsync(p);
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
