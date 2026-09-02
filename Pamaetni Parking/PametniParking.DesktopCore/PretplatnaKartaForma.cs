using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class PretplatnaKartaForma : Form
    {
        public PretplatnaKartaForma()
        {
            InitializeComponent();
        }

        private void PretplatnaKartaForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            var (isError, karte, error) = DTOManager.VratiSveKarte();
            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            dgvKarte.DataSource = karte;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using PretplatnaKartaEditForma forma = new();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvKarte.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var karta = (PretplatnaKartaView)dgvKarte.CurrentRow.DataBoundItem;
            using PretplatnaKartaEditForma forma = new(karta.Id);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvKarte.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var karta = (PretplatnaKartaView)dgvKarte.CurrentRow.DataBoundItem;
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete pretplatnu kartu br. {karta.Id}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (rezultat != DialogResult.Yes) return;

            var (isError, _, error) = await DTOManager.ObrisiKartuAsync(karta.Id);
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
