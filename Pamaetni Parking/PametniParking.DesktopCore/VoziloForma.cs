using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class VoziloForma : Form
    {
        public VoziloForma()
        {
            InitializeComponent();
        }

        private void VoziloForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            var (isError, vozila, error) = DTOManager.VratiSvaVozila();
            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            dgvVozila.DataSource = vozila;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using VoziloEditForma forma = new();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvVozila.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var vozilo = (VoziloView)dgvVozila.CurrentRow.DataBoundItem;
            using VoziloEditForma forma = new(vozilo.RegistarskaOznaka!);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvVozila.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var vozilo = (VoziloView)dgvVozila.CurrentRow.DataBoundItem;
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete vozilo {vozilo.RegistarskaOznaka}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (rezultat != DialogResult.Yes) return;

            var (isError, _, error) = await DTOManager.ObrisiVoziloAsync(vozilo.RegistarskaOznaka!);
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
