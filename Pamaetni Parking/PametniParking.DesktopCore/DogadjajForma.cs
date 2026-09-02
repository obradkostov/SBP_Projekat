using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class DogadjajForma : Form
    {
        public DogadjajForma()
        {
            InitializeComponent();
        }

        private void DogadjajForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            var (isError, dogadjaji, error) = DTOManager.VratiSveDogadjaje();
            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            dgvDogadjaji.DataSource = dogadjaji;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using DogadjajEditForma forma = new();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvDogadjaji.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var dogadjaj = (DogadjajView)dgvDogadjaji.CurrentRow.DataBoundItem;
            using DogadjajEditForma forma = new(dogadjaj.Id);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvDogadjaji.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var dogadjaj = (DogadjajView)dgvDogadjaji.CurrentRow.DataBoundItem;
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete događaj br. {dogadjaj.RedniBroj}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (rezultat != DialogResult.Yes) return;

            var (isError, _, error) = await DTOManager.ObrisiDogadjajAsync(dogadjaj.Id);
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