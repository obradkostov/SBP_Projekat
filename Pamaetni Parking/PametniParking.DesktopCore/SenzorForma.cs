using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class SenzorForma : Form
    {
        public SenzorForma()
        {
            InitializeComponent();
        }

        private void SenzorForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            var (isError, senzori, error) = DTOManager.VratiSveSenzore();
            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            dgvSenzori.DataSource = senzori;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using SenzorEditForma forma = new();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvSenzori.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var senzor = (SenzorView)dgvSenzori.CurrentRow.DataBoundItem;
            using SenzorEditForma forma = new(senzor.Id);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvSenzori.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var senzor = (SenzorView)dgvSenzori.CurrentRow.DataBoundItem;
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete senzor {senzor.SerijskiBroj}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (rezultat != DialogResult.Yes) return;

            var (isError, _, error) = await DTOManager.ObrisiSenzorAsync(senzor.Id);
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
