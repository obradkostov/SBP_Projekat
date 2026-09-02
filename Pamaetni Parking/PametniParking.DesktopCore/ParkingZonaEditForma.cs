using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class ParkingZonaEditForma : Form
    {
        private readonly int? _id;

        public ParkingZonaEditForma()
        {
            InitializeComponent();
            _id = null;
        }

        public ParkingZonaEditForma(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void ParkingZonaEditForma_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                this.Text = "Izmena zone";
                var (isError, zona, error) = await DTOManager.VratiZonuAsync(_id.Value);
                if (isError)
                {
                    MessageBox.Show(error);
                    Close();
                    return;
                }
                txtNaziv.Text = zona.Naziv;
                txtGeografsko.Text = zona.GeografskoPodrucje;
                txtTipZone.Text = zona.TipZone;
                txtOsnovnaTarifa.Text = zona.OsnovnaTarifa.ToString();
                txtMaxVreme.Text = zona.MaxVremeZadrzavanja.ToString();
                txtPravila.Text = zona.PravilaNaplate;
            }
            else
            {
                this.Text = "Dodavanje nove zone";
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Naziv je obavezan.");
                return;
            }
            decimal.TryParse(txtOsnovnaTarifa.Text, out decimal osnovnaTarifa);
            int.TryParse(txtMaxVreme.Text, out int maxVreme);

            ParkingZonaView p = new()
            {
                Id = _id ?? 0,
                Naziv = txtNaziv.Text,
                GeografskoPodrucje = txtGeografsko.Text,
                TipZone = txtTipZone.Text,
                OsnovnaTarifa = osnovnaTarifa,
                MaxVremeZadrzavanja = maxVreme,
                PravilaNaplate = txtPravila.Text
            };

            bool isError;
            string? error;

            if (_id.HasValue)
            {
                (isError, _, error) = await DTOManager.AzurirajZonuAsync(p);
            }
            else
            {
                (isError, _, error) = await DTOManager.DodajZonuAsync(p);
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