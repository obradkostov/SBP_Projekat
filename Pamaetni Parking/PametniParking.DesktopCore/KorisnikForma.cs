using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class KorisnikForma : Form
    {
        public KorisnikForma()
        {
            InitializeComponent();
        }

        private void KorisnikForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            var (isError, korisnici, error) = DTOManager.VratiSveKorisnike();
            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            dgvKorisnici.DataSource = korisnici;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using KorisnikEditForma forma = new();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var korisnik = (KorisnikView)dgvKorisnici.CurrentRow.DataBoundItem;
            using KorisnikEditForma forma = new(korisnik.Id);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvKorisnici.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var korisnik = (KorisnikView)dgvKorisnici.CurrentRow.DataBoundItem;
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete korisnika {korisnik.Email}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (rezultat != DialogResult.Yes) return;

            var (isError, _, error) = await DTOManager.ObrisiKorisnikaAsync(korisnik.Id);
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
