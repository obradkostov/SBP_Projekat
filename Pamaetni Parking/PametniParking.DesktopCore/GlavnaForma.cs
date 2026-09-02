namespace PametniParking.DesktopCore
{
    public partial class GlavnaForma : Form
    {
        public GlavnaForma()
        {
            InitializeComponent();
        }

        private void btnZona_Click(object sender, EventArgs e)
        {
            new ParkingZonaForma().Show();
        }

        private void btnParkingMesto_Click(object sender, EventArgs e)
        {
            new ParkingMestoForma().Show();
        }

        private void btnSenzor_Click(object sender, EventArgs e)
        {
            new SenzorForma().Show();
        }

        private void btnDogadjaj_Click(object sender, EventArgs e)
        {
            new DogadjajForma().Show();
        }

        private void btnKorisnik_Click(object sender, EventArgs e)
        {
            new KorisnikForma().Show();
        }

        private void btnVozilo_Click(object sender, EventArgs e)
        {
            new VoziloForma().Show();
        }

        private void btnParkiranje_Click(object sender, EventArgs e)
        {
            new ParkiranjeForma().Show();
        }

        private void btnPretplatnaKarta_Click(object sender, EventArgs e)
        {
            new PretplatnaKartaForma().Show();
        }

        private void btnIzvestaj_Click(object sender, EventArgs e)
        {
            new IzvestajForma().Show();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
