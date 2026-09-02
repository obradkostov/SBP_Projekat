using PametniParkingLibrary;
using PametniParkingLibrary.DTOs;

namespace PametniParking.DesktopCore
{
    public partial class ParkiranjeForma : Form
    {
        public ParkiranjeForma()
        {
            InitializeComponent();
        }

        private void ParkiranjeForma_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            var (isError, parkiranja, error) = DTOManager.VratiSvaParkiranja();
            if (isError)
            {
                MessageBox.Show(error);
                return;
            }
            dgvParkiranja.DataSource = parkiranja;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using ParkiranjeEditForma forma = new();
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvParkiranja.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var p = (ParkiranjeView)dgvParkiranja.CurrentRow.DataBoundItem;
            using ParkiranjeEditForma forma = new(p.Id);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
            }
        }

        private async void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvParkiranja.CurrentRow == null)
            {
                MessageBox.Show("Niste selektovali red u tabeli.");
                return;
            }
            var p = (ParkiranjeView)dgvParkiranja.CurrentRow.DataBoundItem;
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete parkiranje br. {p.Id}?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (rezultat != DialogResult.Yes) return;

            var (isError, _, error) = await DTOManager.ObrisiParkiranjeAsync(p.Id);
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
