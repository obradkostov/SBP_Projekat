using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class ParkingMestoForma : Form
    {
        public ParkingMestoForma()
        {
            InitializeComponent();
        }

        private void ParkingMestoForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            var (isError, mesta, error) = DTOManager.VratiSvaPM();
            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            dgvMesta.DataSource = mesta;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using ParkingMestoEditForma forma = new();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvMesta.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var mesto = (ParkingMestoView)dgvMesta.CurrentRow.DataBoundItem;
            using ParkingMestoEditForma forma = new(mesto.Id);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvMesta.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var mesto = (ParkingMestoView)dgvMesta.CurrentRow.DataBoundItem;
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete mesto {mesto.OznakaMesta}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (rezultat != DialogResult.Yes) return;

            var (isError, _, error) = await DTOManager.ObrisiPMAsync(mesto.Id);
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
