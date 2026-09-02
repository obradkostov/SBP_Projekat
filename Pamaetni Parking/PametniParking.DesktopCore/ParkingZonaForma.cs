using PametniParkingLibrary;

namespace PametniParking.DesktopCore
{
    public partial class ParkingZonaForma : Form
    {
        public ParkingZonaForma()
        {
            InitializeComponent();
        }

        private void ParkingZonaForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            var (isError, zone, error) = DTOManager.VratiSveZone();
            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            dgvZone.DataSource = zone;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using ParkingZonaEditForma forma = new();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvZone.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var zona = (PametniParkingLibrary.DTOs.ParkingZonaView)dgvZone.CurrentRow.DataBoundItem;
            using ParkingZonaEditForma forma = new(zona.Id);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvZone.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var zona = (PametniParkingLibrary.DTOs.ParkingZonaView)dgvZone.CurrentRow.DataBoundItem;
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete zonu {zona.Naziv}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (rezultat != DialogResult.Yes) return;

            var (isError, _, error) = await DTOManager.ObrisiZonuAsync(zona.Id);
            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            UcitajPodatke();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
