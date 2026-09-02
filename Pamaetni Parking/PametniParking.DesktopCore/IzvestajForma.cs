using PametniParkingLibrary;

namespace PametniParking.DesktopCore
{
    public partial class IzvestajForma : Form
    {
        public IzvestajForma()
        {
            InitializeComponent();
        }

        private void IzvestajForma_Load(object sender, EventArgs e)
        {
            GenerisiIzvestaj();
        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            GenerisiIzvestaj();
        }

        private void GenerisiIzvestaj()
        {
            var (isErrorZ, zone, errorZ) = DTOManager.VratiSveZone();
            if (isErrorZ)
            {
                MessageBox.Show(errorZ);
                return;
            }
            var (isErrorP, parkiranja, errorP) = DTOManager.VratiSvaParkiranja();
            if (isErrorP)
            {
                MessageBox.Show(errorP);
                return;
            }

            var izvestaj = zone.Select(zona => new
            {
                Zona = zona.Naziv,
                BrojParkiranja = parkiranja.Count(p => p.ZonaId == zona.Id),
                UkupanPrihod = parkiranja.Where(p => p.ZonaId == zona.Id).Sum(p => p.ObracunatiIznos)
            }).ToList();

            dgvIzvestaj.DataSource = izvestaj;

            lblUkupno.Text = $"Ukupan broj parkiranja: {parkiranja.Count}, ukupan prihod svih zona: {parkiranja.Sum(p => p.ObracunatiIznos):0.00}";
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
